using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.MyFirst.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("MyFirst");
            ribbonPanel.CreatePushButton<Commands.Command>()
                .SetText("Walls\rChange")
                .SetToolTip("Change all walls comments to wall name!")
                .SetContextualHelp("http:\\ricaun.com")
                .SetLargeImage(Properties.Resources.Revit.GetBitmapSource());

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}