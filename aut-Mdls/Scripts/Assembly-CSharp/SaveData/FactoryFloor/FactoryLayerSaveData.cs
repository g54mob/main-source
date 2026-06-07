using System;
using System.Collections.Generic;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class FactoryLayerSaveData
	{
		public List<SavedObjectDto> SavedObjectDtos;

		public FactoryLayerSaveData(List<SavedObjectDto> savedObjectDtos)
		{
			SavedObjectDtos = savedObjectDtos;
		}
	}
}
