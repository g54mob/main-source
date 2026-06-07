using System.Collections.Generic;
using System.Linq;

namespace Rewired.UI.ControlMapper
{
	public static class ControllerHelperExtensions
	{
		public static IEnumerable<Controller> JoysticksAndCustomControllers(this Player.ControllerHelper helper)
		{
			return ((IEnumerable<Controller>)helper.CustomControllers).Concat((IEnumerable<Controller>)helper.Joysticks).ToArray();
		}

		public static int JoystickAndCustomControllersCount(this Player.ControllerHelper helper)
		{
			return helper.joystickCount + helper.customControllerCount;
		}
	}
}
