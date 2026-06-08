using System;

namespace Rewired
{
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		private Guid oZDUXvGczPZsYvkKpUCsMKUXMco;

		public Guid joystickHardwareTypeGuid => oZDUXvGczPZsYvkKpUCsMKUXMco;

		public JoystickCalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier, Guid joystickHardwareTypeGuid)
			: base(calibrationMap, controllerType, hardwareIdentifier)
		{
			oZDUXvGczPZsYvkKpUCsMKUXMco = joystickHardwareTypeGuid;
		}
	}
}
