namespace XGamingRuntime.Interop
{
	internal struct XblTitleManagedStatistic
	{
		internal readonly UTF8StringPtr statisticName;

		internal readonly XblTitleManagedStatType statisticType;

		internal readonly double numberValue;

		internal readonly UTF8StringPtr stringValue;

		internal XblTitleManagedStatistic(XGamingRuntime.XblTitleManagedStatistic publicObject, DisposableCollection disposableCollection)
		{
			statisticName = default(UTF8StringPtr);
			statisticType = default(XblTitleManagedStatType);
			numberValue = 0.0;
			stringValue = default(UTF8StringPtr);
		}
	}
}
