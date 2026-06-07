using System;
using Rewired;

namespace DV.RewiredExtensions
{
	public class CustomControllerCalibrationMapSaveData : CalibrationMapSaveData
	{
		public Guid guid;

		public CustomControllerCalibrationMapSaveData(CalibrationMap map, ControllerType type, string identifier, Guid guid)
			: base(map, type, identifier)
		{
			this.guid = guid;
		}
	}
}
