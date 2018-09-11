using System;

namespace Tizen.Appium
{
    public class GetLocationCommand : ICommand
    {
        public string Command => Commands.GetLocation;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetLocation");
            var elementId = req.Params.ElementId;

            var result = new Result();
            var geometry = objectList.GetGeometry(elementId);
            result.Value = new Result.Location(geometry.X, geometry.Y);

            return result;
        }
    }
}
