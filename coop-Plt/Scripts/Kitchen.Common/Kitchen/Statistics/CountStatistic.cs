namespace Kitchen.Statistics
{
	public class CountStatistic : Statistic<float, int>
	{
		public float Window = 1f;

		public CountStatistic(float time_period = 1f)
		{
			Window = time_period;
		}

		public override int ResultValue()
		{
			if (Values.Count == 0)
			{
				return 0;
			}
			ReportedValue reportedValue = Values[Values.Count - 1];
			int num = 0;
			for (int num2 = Values.Count - 1; num2 >= 0; num2--)
			{
				ReportedValue reportedValue2 = Values[num2];
				if (reportedValue2.Index < reportedValue.Index - Window)
				{
					break;
				}
				num += reportedValue2.Value;
			}
			return num;
		}
	}
}
