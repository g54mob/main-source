using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Data.Operator;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Overclock Building Validator", fileName = "SteamAchievementOverclockBuildingValidator", order = 0)]
	public class SteamAchievementOverclockBuildingValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _overclockStationData;

		public override bool IsSteamAchievementReached()
		{
			foreach (FactoryObject objectsFromDatum in _factoryLayer.GetObjectsFromData(_overclockStationData))
			{
				if (objectsFromDatum.TryGetFactoryObjectBehaviour<OverclockStationBehaviour>(out var behaviour) && behaviour.OverclockedBuildings.Count > 0 && behaviour.IsOverclockActive)
				{
					return true;
				}
			}
			return false;
		}
	}
}
