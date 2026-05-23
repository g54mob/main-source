using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Statistics;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Multiple Resources Count", fileName = "SteamAchievementMultipleResourceCountValidator", order = 0)]
	public class SteamAchievementMultipleResourceCountValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ulong _targetAmount;

		[SerializeField]
		private List<NonShapeResourceDataSO> _targetResources;

		public override bool IsSteamAchievementReached()
		{
			foreach (NonShapeResourceDataSO targetResource in _targetResources)
			{
				if (_statisticsSO.GetProducedStatistic(targetResource.ID) >= _targetAmount)
				{
					return true;
				}
			}
			return false;
		}
	}
}
