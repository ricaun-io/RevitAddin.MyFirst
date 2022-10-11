using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevitAddin.MyFirst.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            var walls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfClass(typeof(Wall))
                .OfType<Wall>();


            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Change Walls Comments");

                foreach (var wall in walls)
                {
                    var parameter = wall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                    parameter.Set(wall.Name);
                    Console.WriteLine(wall.Name);
                }

                transaction.Commit();
            }

            System.Windows.MessageBox.Show($"Change comments in {walls.Count()} walls!");

            return Result.Succeeded;
        }
    }
}
