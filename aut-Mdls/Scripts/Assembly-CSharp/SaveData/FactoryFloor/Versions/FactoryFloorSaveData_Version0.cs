using System;
using Data.SaveData;

namespace SaveData.FactoryFloor.Versions
{
	internal class FactoryFloorSaveData_Version0 : IPreviousSaveVersion, ISaveVersion
	{
		public ISaveVersion ToNextVersion()
		{
			throw new NotImplementedException();
		}
	}
}
