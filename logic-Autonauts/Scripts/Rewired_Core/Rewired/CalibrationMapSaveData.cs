namespace Rewired
{
	public class CalibrationMapSaveData
	{
		private CalibrationMap sKcOqQIBxtuyLgbDrhdgZdcZCJh;

		private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

		private string vQVAnCuAxTJwWbkeakefzbPARyJ;

		public CalibrationMap map
		{
			get
			{
				return sKcOqQIBxtuyLgbDrhdgZdcZCJh;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return CiEHnIGrjScHYHuMEoDVXvEgwiy;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return vQVAnCuAxTJwWbkeakefzbPARyJ;
			}
		}

		public CalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier)
		{
			sKcOqQIBxtuyLgbDrhdgZdcZCJh = calibrationMap;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = controllerType;
			vQVAnCuAxTJwWbkeakefzbPARyJ = hardwareIdentifier;
		}
	}
}
