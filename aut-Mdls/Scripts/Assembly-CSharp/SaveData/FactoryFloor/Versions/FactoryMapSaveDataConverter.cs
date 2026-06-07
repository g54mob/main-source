using System;
using Data.SaveData;

namespace SaveData.FactoryFloor.Versions
{
	public class FactoryMapSaveDataConverter : SaveDataConverter<FactoryMapSaveData>
	{
		public FactoryMapSaveDataConverter()
			: base(1)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(FactoryMapSaveData_Version0);
			}
			return null;
		}
	}
}
