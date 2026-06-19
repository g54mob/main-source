namespace XGamingRuntime.Interop
{
	internal struct XblTitleManagedStatistic
	{
		internal readonly UTF8StringPtr statisticName;

		internal readonly XblTitleManagedStatType statisticType;

		internal readonly double numberValue;

		internal readonly UTF8StringPtr stringValue;

		internal XblTitleManagedStatistic(XGamingRuntime.XblTitleManagedStatistic statistic, DisposableCollection disposableCollection)
		{
			statisticName = new UTF8StringPtr(statistic.StatisticName, disposableCollection);
			statisticType = statistic.StatisticType;
			numberValue = statistic.NumberValue;
			stringValue = new UTF8StringPtr(statistic.StringValue, disposableCollection);
		}
	}
}
