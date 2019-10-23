using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App12.iOS;
using Foundation;
using Naxam.Controls.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using static App12.App;

[assembly: ExportRenderer(typeof(myTopTabbedPage), typeof(myTopTabbedRenderer))]
namespace App12.iOS
{
    class myTopTabbedRenderer : TopTabbedRenderer, IUIPageViewControllerDataSource
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public new UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var index = ViewControllers.IndexOf(referenceViewController) - 1;

            //in the source, it is if (index < 0) return null;
            //change here to if (index < 1) will fix the first tab


            if (index < 1) return null;

            return ViewControllers[index];
        }

        public new UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var index = ViewControllers.IndexOf(referenceViewController) + 1;

            //in the source, it is if (index == ViewControllers.Count) return null;
            //change here to if (index == ViewControllers.Count || index == 1) will fix the first tab
            if (index == ViewControllers.Count || index == 1) return null;

            return ViewControllers[index];
        }
    }
}