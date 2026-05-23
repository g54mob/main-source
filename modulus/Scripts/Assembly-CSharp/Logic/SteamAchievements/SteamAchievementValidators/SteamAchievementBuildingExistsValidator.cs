using Data.Buildings;
using Data.FactoryFloor;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Building Exists", fileName = "SteamAchievementBuildingExistsValidator", order = 0)]
	public class SteamAchievementBuildingExistsValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private BuildingObjectData _targetBuilding;

		[SerializeField]
		private int _targetAmount;

		[SerializeField]
		private int _targetBuildingStage;

		public override bool IsSteamAchievementReached()
		{
			int num = 0;
			foreach (FactoryObject objectsFromDatum in _factoryLayer.GetObjectsFromData(_targetBuilding))
			{
				if (objectsFromDatum.TryGetFactoryObjectBehaviour<BuildingBehaviour>(out var behaviour) && behaviour.CurrentBuildingStage >= _targetBuildingStage)
				{
					num++;
				}
				if (num >= _targetAmount)
				{
					return true;
				}
			}
			return false;
		}
	}
}
