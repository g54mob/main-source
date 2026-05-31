namespace CTS.Core
{
	public class PercentageListStatistic : IStatistic
	{
		private readonly PercentageList<float> _percentageList;

		public float FloatValue => _percentageList.GetWeightedRandom();

		public PercentageListStatistic(PercentageList<float> percentageList)
		{
			_percentageList = percentageList;
		}
	}
}
