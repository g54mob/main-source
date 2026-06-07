using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Flight.Maps
{
	public class DefaultMap : MapBase
	{
		public override string MapId => "DefaultMap";

		public override string Name => "Default Map";

		public override MapLoadResult LoadMap(LevelInfo level)
		{
			MapLoadResult mapLoadResult = new MapLoadResult();
			if (string.IsNullOrEmpty(level.ModName))
			{
				Object obj = Resources.Load("Levels/" + level.Prefab);
				if (obj == null)
				{
					Debug.Log("Could not find prefab for level: " + level.Prefab);
					return mapLoadResult;
				}
				GameObject gameObject = Object.Instantiate(obj) as GameObject;
				mapLoadResult.LevelScript = gameObject.GetComponent<LevelBase>();
				mapLoadResult.RootObjects.Add(gameObject);
			}
			return mapLoadResult;
		}
	}
}
