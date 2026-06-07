using System;
using Data.SaveData;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class FactoryFloorSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public FactoryLayerSaveData TerrainLayer;

		public FactoryLayerSaveData EditableFloor;

		public FactoryFloorSaveData(FactoryLayerSaveData terrainLayer, FactoryLayerSaveData editableFloor)
			: base(0)
		{
			TerrainLayer = terrainLayer;
			EditableFloor = editableFloor;
		}
	}
}
