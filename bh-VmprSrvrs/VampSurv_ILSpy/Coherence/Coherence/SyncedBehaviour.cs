namespace Coherence;

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
		BehaviourName = name;
		UnmangledBehaviourName = unmangledName;
		AssetId = assetId;
		bool isGlobal2 = default(bool);
		IsGlobal = isGlobal2;
		SyncedComponent[] components2 = default(SyncedComponent[]);
		Components = components2;
		CommandDescription[] commands2 = default(CommandDescription[]);
		Commands = commands2;
	}
}
