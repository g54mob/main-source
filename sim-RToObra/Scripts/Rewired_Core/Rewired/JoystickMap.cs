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
			while (true)
			{
				int num = -1029430850;
				while (true)
				{
					switch (num ^ -1029430852)
					{
					case 0:
						break;
					case 2:
						goto IL_002b;
					default:
						joystickMap._layoutId = layoutId;
						joystickMap._sourceMapId = -1;
						return joystickMap;
					}
					break;
					IL_002b:
					joystickMap._categoryId = categoryId;
					num = -1029430851;
				}
			}
		}
	}
}
