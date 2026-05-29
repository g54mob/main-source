using System;

namespace Rewired
{
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		private Guid LUhsaeOlqEpxdsfgpctFgvpNJaQ;

		public Guid joystickHardwareTypeGuid => default(Guid);

		public JoystickCalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier, Guid joystickHardwareTypeGuid)
			: base(null, default(ControllerType), null)
		{
		}
	}
}
