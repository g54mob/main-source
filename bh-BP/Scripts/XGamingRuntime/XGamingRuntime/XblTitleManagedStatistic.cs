using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblTitleManagedStatistic
	{
		public string StatisticName { get; set; }

		public XblTitleManagedStatType StatisticType { get; set; }

		public double NumberValue { get; set; }

		public string StringValue { get; set; }

		internal XblTitleManagedStatistic(XGamingRuntime.Interop.XblTitleManagedStatistic interopStruct)
		{
		}

		internal XblTitleManagedStatistic(string statisticName, XblTitleManagedStatType statType, string stringValue, double numberValue)
		{
		}

		public XblTitleManagedStatistic()
		{
		}

		public XblTitleManagedStatistic(string statisticName, string statisticValue)
		{
		}

		public XblTitleManagedStatistic(string statisticName, double statisticValue)
		{
		}
	}
}
