using FoxyVoxel.Logging;
using UnityEngine;

public class EnableStoreSdk : MonoBehaviour
{
	private static bool initialized;

	[SerializeField]
	private GameObject egsSdkObject;

	[SerializeField]
	private GameObject gogSdkObject;

	[SerializeField]
	private GameObject steamSdkObject;

	[SerializeField]
	private bool steamRunInEditor;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnDomainReload()
	{
		initialized = false;
	}

	private void Awake()
	{
		if (!initialized)
		{
			initialized = true;
			Log.Info("Not enabling EGS sdk.", "C:\\GIT\\dev\\Assets\\EnableStoreSdk.cs");
			Log.Info("Not enabling GOG sdk.", "C:\\GIT\\dev\\Assets\\EnableStoreSdk.cs");
			EnableSteamSDK();
		}
	}

	private void EnableSteamSDK()
	{
		if (!steamSdkObject.activeSelf)
		{
			Log.Info("Enabling Steam sdk.", "C:\\GIT\\dev\\Assets\\EnableStoreSdk.cs");
			steamSdkObject.SetActive(value: true);
		}
	}
}
