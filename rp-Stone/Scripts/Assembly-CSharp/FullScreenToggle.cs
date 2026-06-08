using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{
	private bool lastFullScreen;

	private const int refreshCountdownResetValue = 3;

	private int refreshCountdown = 3;

	private bool firstTime = true;

	private bool startWithFullScreen = true;

	private void Start()
	{
		lastFullScreen = Screen.fullScreen;
	}

	private void Update()
	{
		if (lastFullScreen != Screen.fullScreen)
		{
			lastFullScreen = Screen.fullScreen;
			refreshCountdown = 3;
		}
		if (refreshCountdown-- == 0)
		{
			if (firstTime)
			{
				firstTime = false;
				refreshCountdown = 3;
				Screen.fullScreen = startWithFullScreen;
				return;
			}
			if (Screen.fullScreen)
			{
				if (Utils.GetScreenResolutions().Length != 0)
				{
					Screen.SetResolution(8000, 4500, fullscreen: true);
				}
			}
			else
			{
				Screen.SetResolution(1322, 750, fullscreen: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.F) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
		{
			Screen.fullScreen = !Screen.fullScreen;
		}
	}
}
