using UnityEngine;

public class LinuxVerifySettings : MonoBehaviour
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnGameStart()
	{
	}

	private static bool IsRunningUnderProton()
	{
		return false;
	}
}
