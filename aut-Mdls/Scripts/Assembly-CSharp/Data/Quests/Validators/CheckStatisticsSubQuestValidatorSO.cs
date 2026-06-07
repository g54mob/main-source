using Data.FactoryFloor.Resources;
using Data.Statistics;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Check Statistics", fileName = "CheckStatistics", order = 13)]
	public class CheckStatisticsSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ResourceDataSO _deliveredResource;

		[SerializeField]
		private int _targetAmount;

		public override bool IsValid()
		{
			return _statisticsSO.GetDeliveredStatistic(_deliveredResource.ID) >= _targetAmount;
		}

		public override void Reset()
		{
		}

		public override float GetProgress()
		{
			return _statisticsSO.GetDeliveredStatistic(_deliveredResource.ID);
		}

		public override float GetProgressTarget()
		{
			return _targetAmount;
		}
	}
}
