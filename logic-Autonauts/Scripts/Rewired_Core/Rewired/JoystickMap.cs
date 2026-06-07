using System;

namespace Rewired
{
	public sealed class JoystickMap : ControllerMapWithAxes
	{
		public JoystickMap()
		{
		}

		public JoystickMap(JoystickMap joystickMap)
			: base(joystickMap)
		{
		}

		internal void SetIdentity(Guid hardwareGuid, int categoryId, int layoutId)
		{
			_hardwareGuid = hardwareGuid;
			_categoryId = categoryId;
			_layoutId = layoutId;
		}

		internal static JoystickMap Blank(Guid hardwareGuid, int categoryId, int layoutId)
		{
			JoystickMap joystickMap = new JoystickMap();
			joystickMap._hardwareGuid = hardwareGuid;
			joystickMap._categoryId = categoryId;
			joystickMap._layoutId = layoutId;
			joystickMap._sourceMapId = -1;
			return joystickMap;
		}
	}
}
