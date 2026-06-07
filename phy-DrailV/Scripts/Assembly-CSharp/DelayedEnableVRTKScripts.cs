using UnityEngine;
using VRTK;

public class DelayedEnableVRTKScripts : MonoBehaviour
{
	public GameObject vr;

	private void Awake()
	{
		VRTK_SDKManager.instance.LoadedSetupChanged += OnLoadedSetupChanged;
	}

	private void OnLoadedSetupChanged(VRTK_SDKManager _, VRTK_SDKManager.LoadedSetupChangeEventArgs __)
	{
		vr.SetActive(value: true);
	}
}
