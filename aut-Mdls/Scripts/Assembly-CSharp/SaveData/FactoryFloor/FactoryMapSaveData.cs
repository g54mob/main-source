using System;
using System.Collections.Generic;
using Data.SaveData;
using SaveData.FactoryFloor.Map;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class FactoryMapSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 1;

		public List<FactoryIslandSaveData> FactoryIslandSaveDatas = new List<FactoryIslandSaveData>();

		public List<IslandInMapSaveData> Islands = new List<IslandInMapSaveData>();

		public Bounds Bounds;

		public FactoryMapSaveData(List<FactoryIslandSaveData> factoryIslandSaveDatas, List<IslandInMapSaveData> islands, Bounds bounds)
			: base(1)
		{
			FactoryIslandSaveDatas = factoryIslandSaveDatas;
			Islands = islands;
			Bounds = bounds;
		}
	}
}
