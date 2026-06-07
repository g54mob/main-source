using System;
using Data.Buildings;

namespace Data.Quests.Validators
{
	[Serializable]
	public struct BuildingObjectDataAndShapeData
	{
		public BuildingObjectData buildingObjectData;

		public int shapeDataIndex;
	}
}
