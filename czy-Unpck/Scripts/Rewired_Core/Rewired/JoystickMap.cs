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
			while (true)
			{
				int num = -905614046;
				while (true)
				{
					switch (num ^ -905614045)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						return joystickMap;
					}
					break;
					IL_0024:
					joystickMap._hardwareGuid = hardwareGuid;
					joystickMap._categoryId = categoryId;
					joystickMap._layoutId = layoutId;
					joystickMap._sourceMapId = -1;
					num = -905614045;
				}
			}
		}
	}
}
