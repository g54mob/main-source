using System;

namespace Rewired
{
	public sealed class JoystickMapSaveData : ControllerMapSaveData
	{
		public Joystick joystick => null;

		public JoystickMap joystickMap => null;

		public Guid joystickHardwareTypeGuid => default(Guid);

		internal JoystickMapSaveData(Joystick P_0, JoystickMap P_1)
			: base(null, null)
		{
		}
	}
}
