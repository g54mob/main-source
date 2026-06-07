namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerMatchmakingServer
	{
		internal readonly XblMatchmakingStatus Status;

		internal readonly UTF8StringPtr StatusDetails;

		internal readonly uint TypicalWaitInSeconds;

		internal readonly XblMultiplayerSessionReference TargetSessionRef;

		internal XblMultiplayerMatchmakingServer(XGamingRuntime.XblMultiplayerMatchmakingServer publicObject, DisposableCollection disposableCollection)
		{
			Status = default(XblMatchmakingStatus);
			StatusDetails = default(UTF8StringPtr);
			TypicalWaitInSeconds = 0u;
			TargetSessionRef = default(XblMultiplayerSessionReference);
		}
	}
}
