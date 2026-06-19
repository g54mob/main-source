namespace Rewired
{
	public class CalibrationMapSaveData
	{
		private CalibrationMap JZdKegczFPbFaaFoPVnmhlSYigB;

		private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

		private string EwSIuwKmClNejrdvYdergFlVidpN;

		public CalibrationMap map => JZdKegczFPbFaaFoPVnmhlSYigB;

		public ControllerType controllerType => beJOxBqDtyzXnNjzgKyRzARzFSQ;

		public string hardwareIdentifier => EwSIuwKmClNejrdvYdergFlVidpN;

		public CalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier)
		{
			JZdKegczFPbFaaFoPVnmhlSYigB = calibrationMap;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = controllerType;
			EwSIuwKmClNejrdvYdergFlVidpN = hardwareIdentifier;
		}
	}
}
