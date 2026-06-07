using System;
using System.Collections.Generic;

namespace SaveData.FactoryFloor.Map
{
	[Serializable]
	public class MapSaveData
	{
		public List<IslandInMapSaveData> Islands;

		public List<string> Paths;

		public MapSaveData()
		{
		}

		public MapSaveData(List<IslandInMapSaveData> islands, List<string> paths)
		{
			Islands = islands;
			Paths = paths;
		}
	}
}
