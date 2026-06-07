using Data.FactoryFloor.Resources;
using Data.Statistics;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Total Resource Count", fileName = "SteamAchievementTotalBotCountValidator", order = 0)]
	public class SteamAchievementTotalResourceCountValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ulong _targetAmount;

		[SerializeField]
		private NonShapeResourceDataSO _targetResourceDataSO;

		public override bool IsSteamAchievementReached()
		{
			return _statisticsSO.GetDeliveredStatistic(_targetResourceDataSO.ID) >= _targetAmount;
		}
	}
}
