using UnityEngine;
using UnityEngine.InputSystem;

internal static class StickAccelerationProcessorRegistration
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Register()
	{
		try
		{
			InputSystem.RegisterProcessor<StickAccelerationProcessor>();
		}
		catch
		{
		}
	}
}
