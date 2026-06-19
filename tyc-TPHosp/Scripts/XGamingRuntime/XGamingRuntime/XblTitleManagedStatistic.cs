namespace XGamingRuntime
{
	public class XblTitleManagedStatistic
	{
		public string StatisticName { get; }

		public XblTitleManagedStatType StatisticType { get; }

		public double NumberValue { get; }

		public string StringValue { get; }

		internal XblTitleManagedStatistic(string statisticName, XblTitleManagedStatType statType, string stringValue, double numberValue)
		{
			StatisticName = statisticName;
			StatisticType = statType;
			StringValue = stringValue;
			NumberValue = numberValue;
		}

		public static int Create(string statisticName, string statisticValue, out XblTitleManagedStatistic titleManagedStatistic)
		{
			titleManagedStatistic = new XblTitleManagedStatistic(statisticName, XblTitleManagedStatType.String, statisticValue, 0.0);
			return 0;
		}

		public static int Create(string statisticName, double statisticValue, out XblTitleManagedStatistic titleManagedStatistic)
		{
			titleManagedStatistic = new XblTitleManagedStatistic(statisticName, XblTitleManagedStatType.Number, null, statisticValue);
			return 0;
		}
	}
}
