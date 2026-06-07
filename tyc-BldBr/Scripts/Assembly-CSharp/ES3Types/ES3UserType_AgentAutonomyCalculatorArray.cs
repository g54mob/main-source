using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_AgentAutonomyCalculatorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentAutonomyCalculatorArray()
			: base(typeof(AgentAutonomyCalculator[]), ES3UserType_AgentAutonomyCalculator.Instance)
		{
			Instance = this;
		}
	}
}
