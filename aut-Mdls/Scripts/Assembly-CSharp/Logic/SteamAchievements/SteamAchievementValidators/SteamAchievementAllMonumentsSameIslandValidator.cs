using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/All Monuments Same Island", fileName = "SteamAchievementAllMonumentsSameIslandValidator", order = 0)]
	public class SteamAchievementAllMonumentsSameIslandValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BuildingObjectData _greyMonument;

		[SerializeField]
		private BuildingObjectData _blueMonument;

		[SerializeField]
		private BuildingObjectData _yellowMonument;

		public override bool IsSteamAchievementReached()
		{
			List<FactoryObject> objectsFromData = _factoryLayer.GetObjectsFromData(_greyMonument);
			List<FactoryObject> objectsFromData2 = _factoryLayer.GetObjectsFromData(_blueMonument);
			List<FactoryObject> objectsFromData3 = _factoryLayer.GetObjectsFromData(_yellowMonument);
			if (objectsFromData.Count == 1 && objectsFromData2.Count == 1 && objectsFromData3.Count == 1)
			{
				bool num = CheckMonumentCompleted(objectsFromData[0]);
				bool flag = CheckMonumentCompleted(objectsFromData2[0]);
				bool flag2 = CheckMonumentCompleted(objectsFromData3[0]);
				if (num && flag && flag2)
				{
					IslandObject islandObject = objectsFromData[0].IslandObject;
					if (islandObject == objectsFromData2[0].IslandObject)
					{
						return islandObject == objectsFromData3[0].IslandObject;
					}
					return false;
				}
			}
			return false;
		}

		private bool CheckMonumentCompleted(FactoryObject monument)
		{
			if (monument.TryGetFactoryObjectBehaviour<BuildingBehaviour>(out var behaviour))
			{
				return behaviour.CurrentBuildingStage >= 1;
			}
			return false;
		}
	}
}
