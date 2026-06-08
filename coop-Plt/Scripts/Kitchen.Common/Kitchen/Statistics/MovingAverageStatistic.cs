namespace Kitchen.Statistics
{
	public class MovingAverageStatistic : Statistic<float, float>
	{
		public readonly float TimePeriod;

		public MovingAverageStatistic(float time_period = 1f)
		{
			TimePeriod = time_period;
		}

		public override float ResultValue()
		{
			if (Values.Count == 0)
			{
				return 0f;
			}
			ReportedValue reportedValue = Values[Values.Count - 1];
			float num = 0f;
			float num2 = 0f;
			for (int num3 = Values.Count - 1; num3 >= 0; num3--)
			{
				ReportedValue reportedValue2 = Values[num3];
				if (reportedValue2.Index < reportedValue.Index - TimePeriod)
				{
					break;
				}
				num += reportedValue2.Value;
				num2 += 1f;
			}
			return num / num2 / TimePeriod;
		}
	}
}
