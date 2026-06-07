namespace Coherence.Toolkit
{
	public static class ScriptExecutionOrder
	{
		public const int CoherenceBridge = -1000;

		public const int SyncGroup = -955;

		public const int CoherenceNode = -950;

		public const int CoherenceSync = -900;

		public const int CoherenceInput = -800;

		public const int CoherenceQuery = 900;

		public const int OnApplicationQuitSender = 1000;
	}
}
