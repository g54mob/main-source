using System;

namespace Rewired
{
	public sealed class JoystickMap : ControllerMapWithAxes
	{
		public JoystickMap()
		{
		}

		public JoystickMap(JoystickMap joystickMap)
		{
		}

		internal void SetIdentity(Guid hardwareGuid, int categoryId, int layoutId)
		{
		}

		internal static JoystickMap Blank(Guid hardwareGuid, int categoryId, int layoutId)
		{
			return null;
		}
	}
}
