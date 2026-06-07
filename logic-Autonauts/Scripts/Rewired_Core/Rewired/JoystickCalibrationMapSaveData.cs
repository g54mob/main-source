using System;

namespace Rewired
{
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		private Guid XDloqgsAEZzNsOnCsrteQagUfhT;

		public Guid joystickHardwareTypeGuid
		{
			get
			{
				return XDloqgsAEZzNsOnCsrteQagUfhT;
			}
		}

		public JoystickCalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier, Guid joystickHardwareTypeGuid)
			: base(calibrationMap, controllerType, hardwareIdentifier)
		{
			while (true)
			{
				int num = -1353317285;
				while (true)
				{
					switch (num ^ -1353317286)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0027;
					case 2:
						return;
					}
					break;
					IL_0027:
					XDloqgsAEZzNsOnCsrteQagUfhT = joystickHardwareTypeGuid;
					num = -1353317288;
				}
			}
		}
	}
}
