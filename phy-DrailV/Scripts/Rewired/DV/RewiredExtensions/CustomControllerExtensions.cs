using Rewired;

namespace DV.RewiredExtensions
{
	public static class CustomControllerExtensions
	{
		public static CustomControllerCalibrationMapSaveData GetCalibrationMapSaveData(this CustomController controller)
		{
			if (ReInput.isReady)
			{
				return new CustomControllerCalibrationMapSaveData(controller.calibrationMap, controller.type, controller.hardwareIdentifier, controller.hardwareTypeGuid);
			}
			return null;
		}
	}
}
