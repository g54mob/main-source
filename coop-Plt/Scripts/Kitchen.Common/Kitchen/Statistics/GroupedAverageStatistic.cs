namespace Kitchen.Statistics
{
	public class GroupedAverageStatistic : Statistic<int, float>
	{
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
				if (reportedValue2.Index != reportedValue.Index)
				{
					break;
				}
				num2 += reportedValue2.Value;
				num += 1f;
			}
			return num2 / num;
		}
	}
}
