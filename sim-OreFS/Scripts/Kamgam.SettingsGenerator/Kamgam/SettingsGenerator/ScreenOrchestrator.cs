using System.Collections;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class ScreenOrchestrator : MonoBehaviour
	{
		private static ScreenOrchestrator _instance;

		protected Resolution? requestedResolution;

		protected RefreshRate? requestedRefreshRate;

		protected bool? requestedFullScreen;

		protected FullScreenMode? requestedFullScreenMode;

		protected Coroutine _applyCoroutine;

		public static ScreenOrchestrator Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = new GameObject().AddComponent<ScreenOrchestrator>();
					_instance.name = _instance.GetType().ToString();
					Object.DontDestroyOnLoad(_instance.gameObject);
				}
				return _instance;
			}
		}

		public void RequestResolution(Resolution resolution)
		{
			requestedResolution = resolution;
		}

		public void RequestRefreshRate(RefreshRate refreshRate)
		{
			requestedRefreshRate = refreshRate;
		}

		public void RequestFullScreen(bool fullScreen)
		{
			requestedFullScreen = fullScreen;
		}

		public void RequestFullScreenMode(FullScreenMode fullScreenMode)
		{
			requestedFullScreenMode = fullScreenMode;
		}

		public void LateUpdate()
		{
			if (requestedResolution.HasValue || requestedFullScreen.HasValue || requestedFullScreenMode.HasValue)
			{
				apply();
			}
		}

		protected void apply()
		{
			if (_applyCoroutine != null)
			{
				StopCoroutine(_applyCoroutine);
			}
			_applyCoroutine = StartCoroutine(applyStaggered());
		}

		protected IEnumerator applyStaggered()
		{
			bool? flag = requestedFullScreen;
			FullScreenMode? tRequestedFullScreenMode = requestedFullScreenMode;
			Resolution? tRequestedResolution = requestedResolution;
			RefreshRate? tRequestedRefreshRate = requestedRefreshRate;
			requestedFullScreen = null;
			requestedFullScreenMode = null;
			requestedResolution = null;
			requestedRefreshRate = null;
			if (flag.HasValue)
			{
				if (!flag.Value)
				{
					Screen.fullScreen = false;
				}
				else
				{
					Screen.fullScreen = true;
				}
				yield return null;
			}
			if (tRequestedFullScreenMode.HasValue)
			{
				Screen.fullScreenMode = tRequestedFullScreenMode.Value;
				yield return null;
			}
			if (tRequestedResolution.HasValue)
			{
				Resolution value = tRequestedResolution.Value;
				RefreshRate preferredRefreshRate = (tRequestedRefreshRate.HasValue ? tRequestedRefreshRate.Value : tRequestedResolution.Value.refreshRateRatio);
				FullScreenMode fullscreenMode = (tRequestedFullScreenMode.HasValue ? tRequestedFullScreenMode.Value : Screen.fullScreenMode);
				Screen.SetResolution(value.width, value.height, fullscreenMode, preferredRefreshRate);
			}
			else if (tRequestedRefreshRate.HasValue)
			{
				Resolution currentResolution = Screen.currentResolution;
				FullScreenMode fullscreenMode2 = (tRequestedFullScreenMode.HasValue ? tRequestedFullScreenMode.Value : Screen.fullScreenMode);
				Screen.SetResolution(currentResolution.width, currentResolution.height, fullscreenMode2, tRequestedRefreshRate.Value);
			}
		}

		public void Destroy()
		{
			_instance = null;
			if (this != null && base.gameObject != null)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
