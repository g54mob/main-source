using UnityEngine;
using UnityEngine.XR;

public class XrGameViewSettings : MonoBehaviour
{
	private void Start()
	{
		if (!VRManager.IsVREnabled())
		{
			Object.Destroy(base.gameObject);
			return;
		}
		OnXrGameViewChanged();
		GamePreferences.RegisterToPreferenceUpdated(Preferences.XrGameViewDisplayMode, OnXrGameViewChanged);
	}

	private void OnDestroy()
	{
		if (VRManager.IsVREnabled())
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.XrGameViewDisplayMode, OnXrGameViewChanged);
		}
	}

	private static void OnXrGameViewChanged()
	{
		XRSettings.gameViewRenderMode = (GameViewRenderMode)GamePreferences.Get<int>(Preferences.XrGameViewDisplayMode);
	}
}
