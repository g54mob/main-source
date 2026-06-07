using DV;
using DV.Utils;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
	private const float FIXED_TIME_STEP = 1f / 60f;

	private const int PAUSE_FRAME_LIMIT = 60;

	private void Start()
	{
		Time.fixedDeltaTime = 1f / 60f;
		if (!VRManager.IsVREnabled())
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.FrameLimit, FrameLimitUpdated);
			SingletonBehaviour<AppUtil>.Instance.GamePaused += FrameLimitUpdated;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += FrameLimitUpdated;
			FrameLimitUpdated();
		}
	}

	private void OnDestroy()
	{
		if (!VRManager.IsVREnabled())
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.FrameLimit, FrameLimitUpdated);
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= FrameLimitUpdated;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= FrameLimitUpdated;
			}
		}
	}

	private void FrameLimitUpdated()
	{
		int num = GamePreferences.Get<int>(Preferences.FrameLimit);
		bool flag = num != 0;
		int num2 = num;
		if (num2 == 999)
		{
			num2 = 0;
		}
		if (SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen)
		{
			num2 = (flag ? Mathf.Min(num2, 60) : 60);
			flag = true;
		}
		Application.targetFrameRate = (flag ? num2 : 0);
		QualitySettings.vSyncCount = ((!flag) ? 1 : 0);
	}

	private void Update()
	{
		if (Time.fixedDeltaTime != 1f / 60f)
		{
			Time.fixedDeltaTime = 1f / 60f;
		}
	}
}
