using System;
using Data.SaveData;

namespace SaveData.FactoryFloor.Versions
{
	public class FactoryShapesSaveDataConverter : SaveDataConverter<FactoryShapesSaveData>
	{
		public FactoryShapesSaveDataConverter()
			: base(1)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(FactoryShapesSaveData_Version0);
			}
			return null;
		}
	}
}
