namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerMemberInitialization
	{
		internal readonly ulong JoinTimeout;

		internal readonly ulong MeasurementTimeout;

		internal readonly ulong EvaluationTimeout;

		internal readonly NativeBool ExternalEvaluation;

		internal readonly uint MembersNeededToStart;

		internal XblMultiplayerMemberInitialization(XGamingRuntime.XblMultiplayerMemberInitialization publicObject)
		{
			JoinTimeout = 0uL;
			MeasurementTimeout = 0uL;
			EvaluationTimeout = 0uL;
			ExternalEvaluation = default(NativeBool);
			MembersNeededToStart = 0u;
		}
	}
}
