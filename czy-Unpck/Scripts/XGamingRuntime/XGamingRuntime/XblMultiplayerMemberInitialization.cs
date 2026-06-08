using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerMemberInitialization
	{
		public ulong JoinTimeout { get; private set; }

		public ulong MeasurementTimeout { get; private set; }

		public ulong EvaluationTimeout { get; private set; }

		public bool ExternalEvaluation { get; private set; }

		public uint MembersNeededToStart { get; private set; }

		internal XblMultiplayerMemberInitialization(XGamingRuntime.Interop.XblMultiplayerMemberInitialization interopStruct)
		{
			JoinTimeout = interopStruct.JoinTimeout;
			MeasurementTimeout = interopStruct.MeasurementTimeout;
			EvaluationTimeout = interopStruct.EvaluationTimeout;
			ExternalEvaluation = interopStruct.ExternalEvaluation.Value;
			MembersNeededToStart = interopStruct.MembersNeededToStart;
		}
	}
}
