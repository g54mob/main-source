using UnityEngine;

public class AggroEditorSettings : ScriptableObject
{
	public bool setSeed;

	public int seed = 12345;

	public bool enableDemoBuild;

	public bool enableReleaseDebugTools;

	public ContractObject overrideGymContract;

	[Header("Network")]
	public bool startWithLatency;

	[Min(0f)]
	public int latency = 100;

	[Range(0f, 100f)]
	public int packetLoss = 2;

	[Header("Debug")]
	public bool startWithGraphsEnabled;

	public static AggroEditorSettings GetSettings()
	{
		return null;
	}

	public static bool TryGetSettings(out AggroEditorSettings settings)
	{
		settings = null;
		return false;
	}
}
