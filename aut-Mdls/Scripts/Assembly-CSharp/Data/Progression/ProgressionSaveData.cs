using System;
using System.Collections.Generic;
using Data.SaveData;
using Data.Shapes;

namespace Data.Progression
{
	[Serializable]
	public class ProgressionSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int[] MonumentIds;

		public int[] MonumentStates;

		public ShapeHashPair[] DiscoveredShapeHashes;

		public ProgressionSaveData()
			: base(0)
		{
			MonumentIds = Array.Empty<int>();
			MonumentStates = Array.Empty<int>();
			DiscoveredShapeHashes = Array.Empty<ShapeHashPair>();
		}

		public ProgressionSaveData(IReadOnlyList<ProgressionMonumentsManager.Monument> monumentInfos, IReadOnlyList<ShapeData> discoveredShapes)
			: base(0)
		{
			MonumentIds = new int[monumentInfos.Count];
			MonumentStates = new int[monumentInfos.Count];
			for (int i = 0; i < monumentInfos.Count; i++)
			{
				MonumentIds[i] = monumentInfos[i].BuildingObjectData.ID;
				MonumentStates[i] = (int)monumentInfos[i].State;
			}
			DiscoveredShapeHashes = new ShapeHashPair[discoveredShapes.Count];
			for (int j = 0; j < discoveredShapes.Count; j++)
			{
				DiscoveredShapeHashes[j] = discoveredShapes[j].GetShapeHash();
			}
		}
	}
}
