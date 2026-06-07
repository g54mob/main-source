namespace Coherence
{
	public struct SyncedBehaviour
	{
		public string BehaviourName;

		public string UnmangledBehaviourName;

		public string AssetId;

		public bool IsGlobal;

		public SyncedComponent[] Components;

		public CommandDescription[] Commands;

		public SyncedBehaviour(string name, string unmangledName, string assetId, bool isGlobal, SyncedComponent[] components, CommandDescription[] commands)
		{
			BehaviourName = null;
			UnmangledBehaviourName = null;
			AssetId = null;
			IsGlobal = false;
			Components = null;
			Commands = null;
		}
	}
}
