namespace XGamingRuntime.Interop
{
	internal struct XblPresenceBroadcastRecord
	{
		internal readonly UTF8StringPtr broadcastId;

		internal readonly byte[] session;

		internal readonly XblPresenceBroadcastProvider provider;

		internal readonly uint viewerCount;

		internal readonly TimeT startTime;
	}
}
