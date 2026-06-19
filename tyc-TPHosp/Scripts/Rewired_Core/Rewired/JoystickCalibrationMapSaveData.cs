using System;

namespace Rewired
{
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		private Guid gOEPYIISKlgCyWkmIhxbcsAVjZjs;

		public Guid joystickHardwareTypeGuid => gOEPYIISKlgCyWkmIhxbcsAVjZjs;

		public JoystickCalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier, Guid joystickHardwareTypeGuid)
			: base(calibrationMap, controllerType, hardwareIdentifier)
		{
			gOEPYIISKlgCyWkmIhxbcsAVjZjs = joystickHardwareTypeGuid;
		}
	}
}
