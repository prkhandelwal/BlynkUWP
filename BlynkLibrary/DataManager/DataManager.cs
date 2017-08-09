using BlynkLibrary.Models;
using BlynkLibrary.NetworkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Busy = 6
        }

        public static Project proj { get; set; }

        public static async Task<StatusCode> LoginAsync(string authToken)
        {
            proj = await BlynkService.Login(authToken);
            if(proj.id == 0)
            {
                var isInternet = await BlynkService.IsInternet();
                if (!isInternet)
                {
                    return StatusCode.NoInternet;
                }
                else
                {
                    return StatusCode.UnknownError;
                }
            }

            return StatusCode.Success;
        }


    }
}
