using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class HideParticleSystemDuringPause : MonoBehaviour
	{
		private Vector3 initialScale;

		private void Awake()
		{
			initialScale = base.transform.localScale;
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused += AppUtilOnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += AppUtilOnGameUnpaused;
			}
			else
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= AppUtilOnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= AppUtilOnGameUnpaused;
			}
		}

		private void AppUtilOnGameUnpaused()
		{
			base.transform.localScale = initialScale;
		}

		private void AppUtilOnGamePaused()
		{
			base.transform.localScale = Vector3.zero;
		}
	}
}
