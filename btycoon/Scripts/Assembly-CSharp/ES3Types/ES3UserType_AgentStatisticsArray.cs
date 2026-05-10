using CTS;

namespace ES3Types
{
	public class ES3UserType_AgentStatisticsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentStatisticsArray()
			: base(typeof(AgentStatistics[]), ES3UserType_AgentStatistics.Instance)
		{
			Instance = this;
		}
	}
}
