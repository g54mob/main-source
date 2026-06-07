using System.Linq;
using UnityEngine;

public class ResolutionForcerNonVr : MonoBehaviour
{
	private bool prevFullscreen;

	public void Start()
	{
		if (VRManager.IsVREnabled())
		{
			Debug.Log("ResolutionForcerNonVr is not used in VR, destroying self.");
			Object.Destroy(this);
		}
		else
		{
			Object.DontDestroyOnLoad(base.gameObject);
			prevFullscreen = Screen.fullScreen;
		}
	}

	private void Update()
	{
		if (prevFullscreen == Screen.fullScreen)
		{
			return;
		}
		if (Screen.fullScreen)
		{
			int fullscreenWidth = GamePreferences.Get<int>(Preferences.ScreenResolutionWidth);
			int fullscreenHeight = GamePreferences.Get<int>(Preferences.ScreenResolutionHeight);
			if (!Screen.resolutions.Any((Resolution res) => res.width == fullscreenWidth && res.height == fullscreenHeight))
			{
				fullscreenWidth = Display.main.systemWidth;
				fullscreenHeight = Display.main.systemHeight;
				GamePreferences.Set(Preferences.ScreenResolutionWidth, fullscreenWidth);
				GamePreferences.Set(Preferences.ScreenResolutionHeight, fullscreenHeight);
			}
			Screen.SetResolution(fullscreenWidth, fullscreenHeight, fullscreen: true);
		}
		prevFullscreen = Screen.fullScreen;
	}
}
