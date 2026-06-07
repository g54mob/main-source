using System;

namespace Rewired
{
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		private Guid AbaDxiclfkqtwGNGTcxeumphYLHn;

		public Guid joystickHardwareTypeGuid => AbaDxiclfkqtwGNGTcxeumphYLHn;

		public JoystickCalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier, Guid joystickHardwareTypeGuid)
			: base(calibrationMap, controllerType, hardwareIdentifier)
		{
			AbaDxiclfkqtwGNGTcxeumphYLHn = joystickHardwareTypeGuid;
		}
	}
}
