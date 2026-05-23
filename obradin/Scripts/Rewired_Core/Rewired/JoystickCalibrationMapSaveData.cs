using System;

namespace Rewired
{
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		private Guid qhXnRrKKvTUuuameCvctfGaGedQ;

		public Guid joystickHardwareTypeGuid
		{
			get
			{
				return qhXnRrKKvTUuuameCvctfGaGedQ;
			}
		}

		public JoystickCalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier, Guid joystickHardwareTypeGuid)
			: base(calibrationMap, controllerType, hardwareIdentifier)
		{
			qhXnRrKKvTUuuameCvctfGaGedQ = joystickHardwareTypeGuid;
		}
	}
}
