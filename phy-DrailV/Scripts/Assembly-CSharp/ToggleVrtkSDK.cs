using UnityEngine;
using VRTK;

public class ToggleVrtkSDK : MonoBehaviour
{
	public KeyCode toggleKey;

	private string curName;

	private void Start()
	{
		VRTK_SDKManager.SubscribeLoadedSetupChanged(OnLoadedSetupChanged);
	}

	private void OnLoadedSetupChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
	{
		curName = e.currentSetup?.name;
	}

	private void Update()
	{
		if (Input.GetKeyDown(toggleKey))
		{
			ToggleSDK();
		}
	}

	public void ToggleSDK()
	{
		VRTK_SDKSetup[] allSDKSetups = VRTK_SDKManager.GetAllSDKSetups();
		int? currentSetupsIndex = GetCurrentSetupsIndex(allSDKSetups);
		VRTK_SDKManager.AttemptTryLoadSDKSetup(currentSetupsIndex.HasValue ? ((currentSetupsIndex.Value + 1) % allSDKSetups.Length) : 0, tryToReinitialize: true, allSDKSetups);
	}

	private int? GetCurrentSetupsIndex(VRTK_SDKSetup[] setups)
	{
		for (int i = 0; i < setups.Length; i++)
		{
			if (curName != null && setups[i] != null && setups[i].name == curName)
			{
				return i;
			}
		}
		return null;
	}
}
