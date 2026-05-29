using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_AgentSatisfactionArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentSatisfactionArray()
			: base(typeof(AgentSatisfaction[]), ES3UserType_AgentSatisfaction.Instance)
		{
			Instance = this;
		}
	}
}
