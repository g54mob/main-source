using System;

namespace Rewired
{
	public sealed class JoystickMapSaveData : ControllerMapSaveData
	{
		public Joystick joystick
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					while (true)
					{
						int num = -1889937075;
						while (true)
						{
							switch (num ^ -1889937073)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -1889937074;
						}
					}
				}
				return _controller as Joystick;
			}
		}

		public JoystickMap joystickMap
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return _map as JoystickMap;
			}
		}

		public Guid joystickHardwareTypeGuid
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return joystick.hardwareTypeGuid;
			}
		}

		internal JoystickMapSaveData(Joystick joystick, JoystickMap map)
			: base(joystick, map)
		{
		}
	}
}
