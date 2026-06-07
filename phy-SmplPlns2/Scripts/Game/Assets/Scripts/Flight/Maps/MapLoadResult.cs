using System.Collections.Generic;
using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Flight.Maps
{
	public class MapLoadResult
	{
		public LevelBase LevelScript { get; set; }

		public List<GameObject> RootObjects { get; set; }

		public Terrain Terrain { get; set; }

		public MapLoadResult()
		{
			RootObjects = new List<GameObject>();
		}

		public MapLoadResult(List<GameObject> rootGameObjects, LevelBase level, Terrain terrain)
		{
			RootObjects = rootGameObjects;
			LevelScript = level;
			Terrain = terrain;
		}
	}
}
