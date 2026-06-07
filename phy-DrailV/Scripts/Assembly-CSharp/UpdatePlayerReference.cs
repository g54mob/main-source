using UnityEngine;
using VRTK;

public class UpdatePlayerReference : MonoBehaviour
{
	private void Awake()
	{
		VRTK_SDKManager.SubscribeLoadedSetupChanged(OnLoadedSetupChanged);
	}

	private void OnLoadedSetupChanged(VRTK_SDKManager _, VRTK_SDKManager.LoadedSetupChangeEventArgs __)
	{
		if (!UnloadWatcher.isUnloading)
		{
			PlayerManager.SetPlayer(VRTK_DeviceFinder.PlayAreaTransform(), GetCamera());
			VRTK_SDKManager.UnsubscribeLoadedSetupChanged(OnLoadedSetupChanged);
			Object.Destroy(this);
		}
	}

	public static Camera GetCamera()
	{
		Camera component = VRTK_DeviceFinder.HeadsetCamera().GetComponent<Camera>();
		if (!component)
		{
			Debug.LogError("UpdatePlayerReference couldn't get camera from VRTK");
		}
		return component;
	}
}
