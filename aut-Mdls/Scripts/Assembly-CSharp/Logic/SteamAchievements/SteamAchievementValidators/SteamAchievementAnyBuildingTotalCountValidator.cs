using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Any Building Total Count Validator", fileName = "SteamAchievementAnyBuildingTotalCountValidator", order = 0)]
	public class SteamAchievementAnyBuildingTotalCountValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private int _targetAmount;

		[SerializeField]
		private BuildingObjectDatabase _buildingObjectDatabase;

		public override bool IsSteamAchievementReached()
		{
			int num = 0;
			foreach (BuildingObjectData buildingData in _buildingObjectDatabase.BuildingDatas)
			{
				foreach (FactoryObject objectsFromDatum in _factoryLayer.GetObjectsFromData(buildingData))
				{
					if (objectsFromDatum.TryGetFactoryObjectBehaviour<BuildingBehaviour>(out var behaviour) && behaviour.MaxBuildingStageReached)
					{
						num++;
						if (num >= _targetAmount)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
