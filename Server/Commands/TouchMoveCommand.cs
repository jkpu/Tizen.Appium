using System;

namespace Tizen.Appium
{
    public class TouchMoveCommand : ICommand
    {
        public string Command => Commands.TouchMove;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var elementId = req.Params.ElementId;
            var x = req.Params.X;
            var y = req.Params.Y;
            var result = new Result();

            try
            {
                if (!String.IsNullOrEmpty(elementId))
                {
                    var geometry = objectList.GetGeometry(elementId);
                    result.Value = inputGen.TouchDown(geometry.CenterX, geometry.CenterY);
                }
                else if ((x > 0) && (y > 0))
                {
                    result.Value = inputGen.TouchDown(x, y);
                }
                else
                {
                    Log.Debug("Invalid values");
                }
            }
            catch (TimeoutException te)
            {
                Log.Debug(te.ToString());
                result.Status = 44;
                result.Value = "false";
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
                result.Value = "false";
            }

            return result;
        }
    }
}