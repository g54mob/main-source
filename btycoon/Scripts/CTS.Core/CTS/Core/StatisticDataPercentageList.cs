using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/Statistics/Types/Percentage List")]
	public class StatisticDataPercentageList : StatisticData
	{
		[SerializeField]
		private PercentageList<float> _percentageList;

		public override IStatistic CreateStatistic()
		{
			return new PercentageListStatistic(_percentageList);
		}
	}
}
