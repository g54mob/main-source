using UnityEngine;

public static class PlatformUniqueFunctionality
{
	public static readonly DefaultPlatformUniqueFunctionality Instance = new DefaultPlatformUniqueFunctionality();

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Init()
	{
		Instance.Initialize();
	}
}
