using CTS;

namespace ES3Types
{
	public class ES3UserType_AgentBodyAbandonedArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentBodyAbandonedArray()
			: base(typeof(AgentBodyAbandoned[]), ES3UserType_AgentBodyAbandoned.Instance)
		{
			Instance = this;
		}
	}
}
