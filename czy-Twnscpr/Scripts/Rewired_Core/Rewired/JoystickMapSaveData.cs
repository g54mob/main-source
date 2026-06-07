using System;

namespace Rewired
{
	public sealed class JoystickMapSaveData : ControllerMapSaveData
	{
		public Joystick joystick => null;

		public JoystickMap joystickMap => null;

		public Guid joystickHardwareTypeGuid => default(Guid);

		internal JoystickMapSaveData(Joystick joystick, JoystickMap map)
			: base(null, null)
		{
		}
	}
}
