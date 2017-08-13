using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace BlynkUWP.Model
{
    public class InstructionItem
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="image">The image Uri.</param>
        /// <param name="targetPage">The target page type.</param>
        public InstructionItem(string headerText, string contentText,
            Uri image, string targetPage = null, Visibility buttonVisibility = Visibility.Collapsed)
        {
            HeaderText = headerText;
            ContentText = contentText;
            Image = image;
            TargetPage = targetPage;
            ButtonVisibility = buttonVisibility;

        }

        /// <summary>
        /// Gets or sets the content text.
        /// </summary>
        public string ContentText { get; set; }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        public string HeaderText { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public Uri Image { get; set; }

        /// <summary>
        /// Gets or sets the optional target page.
        /// </summary>
        public string TargetPage { get; set; }

        ///<summary>
        ///Sets the visiblity for Get started button
        ///</summary>
        public Visibility ButtonVisibility { get; set; }
    }
}
