using BlynkLibrary.Models;
using BlynkLibrary.NetworkService;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BlynkLibrary.DataManager
{
    public class DataManager
    {

        public enum StatusCode
        {
            /// <summary>
            /// Successful execution.
            /// </summary>
            Success = 0,
            /// <summary>
            /// Connectivity or network issues.
            /// </summary>
            NoInternet = 1,
            /// <summary>
            /// Server errors such as "Unavailable", "Database Error" or "Gateway Timeout".
            /// </summary>
            ServerError = 2,
            /// <summary>
            /// The data has not changed from the previous version.
            /// </summary>
            NoChange = 3,
            /// <summary>
            /// An unknown error occured.
            /// </summary>
            UnknownError = 4,
            /// <summary>
            /// Occurs if the file or content is missing.
            /// </summary>
            NoData = 5,
            /// <summary>
            /// The service provider is busy.
            /// </summary>
            StorageError = 6,
            /// <summary>
            /// Problem with storage.
            /// </summary>
            Busy = 7
        }

        public static string keyLargeObject = "data.txt";
        public static Project proj { get; set; }
        public static StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public static Device navDevice { get; set; }
        public static string authTokenStored { get; set; }

        public static async Task<StatusCode> LoginAsync(string authToken)
        {
            proj = await BlynkService.Login(authToken);
            if(proj.Id == 0)
            {
                var isInternet = await BlynkService.IsInternet();
                if (!isInternet)
                {
                    StatusCode response = await DataManager.LoadSaveAsync();
                    if (response == StatusCode.Success)
                    {
                        return response;
                    }
                    if(response == StatusCode.NoData)
                    {
                        return StatusCode.NoData;
                    }
                    
                    else
                    {
                        return StatusCode.NoInternet;
                    }
                }
                else
                {
                    return StatusCode.UnknownError;
                }
            }
            authTokenStored = authToken;
            await DataManager.SaveDataAsync(authToken);
            return StatusCode.Success;
        }

        public static async Task<StatusCode> RefreshAsync()
        {
            proj = await BlynkService.Login(authTokenStored);
            if (proj.Id == 0)
            {
                var isInternet = await BlynkService.IsInternet();
                if (!isInternet)
                {
                    StatusCode response = await DataManager.LoadSaveAsync();
                    if (response == StatusCode.Success)
                    {
                        return response;
                    }
                    if (response == StatusCode.NoData)
                    {
                        return StatusCode.NoData;
                    }

                    else
                    {
                        return StatusCode.NoInternet;
                    }
                }
                else
                {
                    return StatusCode.UnknownError;
                }
            }
            await DataManager.SaveDataAsync(authTokenStored);
            return StatusCode.Success;
        }

        public static async Task<StatusCode> SaveDataAsync(string authToken)
        {
            try
            {
                StorageFile data = await localFolder.CreateFileAsync("data.txt", CreationCollisionOption.ReplaceExisting);
                var helper = new LocalObjectStorageHelper();
                await helper.SaveFileAsync(keyLargeObject, proj);
                await helper.SaveFileAsync("authToken.txt", authToken);
                return StatusCode.Success;
            }
            catch (Exception)
            {
                return StatusCode.StorageError;
            }
        }

        public static async Task<StatusCode> LoadSaveAsync()
        {
            try
            {
                var helper = new LocalObjectStorageHelper();
                if(await helper.FileExistsAsync("data.txt"))
                {
                    proj = await helper.ReadFileAsync<Project>(keyLargeObject);
                    authTokenStored = await helper.ReadFileAsync<string>("authToken.txt");
                    return StatusCode.Success;
                }
                else
                {
                    return StatusCode.NoData;
                }
            }

            catch
            {
                return StatusCode.NoData;
            }
        }


    }
}
