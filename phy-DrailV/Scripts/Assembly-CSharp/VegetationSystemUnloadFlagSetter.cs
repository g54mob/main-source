using AwesomeTechnologies.VegetationStudio;
using UnityEngine;

public static class VegetationSystemUnloadFlagSetter
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Init()
	{
		UnloadWatcher.UnloadRequested -= OnUnloadRequested;
		UnloadWatcher.UnloadRequested += OnUnloadRequested;
	}

	private static void OnUnloadRequested()
	{
		VegetationStudioManager.isLevelUnloading = true;
	}
}
