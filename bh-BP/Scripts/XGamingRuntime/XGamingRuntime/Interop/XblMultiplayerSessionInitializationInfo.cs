namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionInitializationInfo
	{
		internal readonly XblMultiplayerInitializationStage Stage;

		internal readonly TimeT StageStartTime;

		internal readonly uint Episode;

		internal XblMultiplayerSessionInitializationInfo(XGamingRuntime.XblMultiplayerSessionInitializationInfo publicObject)
		{
			Stage = default(XblMultiplayerInitializationStage);
			StageStartTime = default(TimeT);
			Episode = 0u;
		}
	}
}
