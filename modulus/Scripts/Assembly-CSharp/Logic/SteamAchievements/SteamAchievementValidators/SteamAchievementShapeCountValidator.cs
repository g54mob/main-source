using Data.Shapes;
using Data.Statistics;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Total Shape Count", fileName = "SteamAchievementShapeCountValidator", order = 0)]
	public class SteamAchievementShapeCountValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ulong _targetAmount;

		[SerializeField]
		private ShapeDataSO _targetShapeDataSO;

		public override bool IsSteamAchievementReached()
		{
			return _statisticsSO.GetProducedShapesStatistic(_targetShapeDataSO.Data.RotationIndependantHash) >= _targetAmount;
		}
	}
}
