using System;
using Data.SaveData;

namespace SaveData.FactoryFloor.Versions
{
	public class FactoryFloorSaveDataConverter : SaveDataConverter<FactoryFloorSaveData>
	{
		public FactoryFloorSaveDataConverter()
			: base(0)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(FactoryFloorSaveData_Version0);
			}
			return null;
		}
	}
}
