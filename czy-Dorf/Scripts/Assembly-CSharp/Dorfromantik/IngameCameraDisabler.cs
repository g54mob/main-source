using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class IngameCameraDisabler : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public IngameCameraDisabler _003C_003E4__this;

			public int targetFrameBudget;

			internal void _003CDisableIngameCamera_003Eb__0()
			{
				_003C_003E4__this.DisableCamera(targetFrameBudget);
			}
		}

		[SerializeField]
		private Image maskingScreen;

		private bool visualLoadingEnabled = true;

		private Tween fadeTween;

		public void Toggle()
		{
			if (visualLoadingEnabled)
			{
				DisableIngameCamera(150);
			}
			else
			{
				EnableIngameCamera();
			}
		}

		private void DisableIngameCamera(int targetFrameBudget)
		{
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals4._003C_003E4__this = this;
			CS_0024_003C_003E8__locals4.targetFrameBudget = targetFrameBudget;
			visualLoadingEnabled = false;
			maskingScreen.gameObject.SetActive(value: true);
			Tween tween = fadeTween;
			if (tween != null)
			{
				TweenExtensions.Kill(tween);
			}
			fadeTween = TweenSettingsExtensions.OnComplete(DOTweenModuleUI.DOFade(maskingScreen, 1f, 1f), delegate
			{
				CS_0024_003C_003E8__locals4._003C_003E4__this.DisableCamera(CS_0024_003C_003E8__locals4.targetFrameBudget);
			});
		}

		private void DisableCamera(int targetFrameBudget)
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= EnableIngameCamera;
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup += EnableIngameCamera;
			OverwritingSingleton<IngameUi>.Instance.mainCamera.gameObject.SetActive(value: false);
			OverwritingSingleton<IngameUi>.Instance.uiCamera.gameObject.SetActive(value: false);
			SetTargetFrameBudget(targetFrameBudget);
		}

		public void SetTargetFrameBudget(int targetBudget)
		{
			OverwritingSingleton<IngameUi>.Instance.saveLoadSystem.overrideFrameBudget = targetBudget;
		}

		private void EnableIngameCamera()
		{
			visualLoadingEnabled = true;
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= EnableIngameCamera;
			TweenSettingsExtensions.OnComplete(DOTweenModuleUI.DOFade(maskingScreen, 0f, 1f), delegate
			{
				maskingScreen.gameObject.SetActive(value: false);
			});
			OverwritingSingleton<IngameUi>.Instance.mainCamera.gameObject.SetActive(value: true);
			OverwritingSingleton<IngameUi>.Instance.uiCamera.gameObject.SetActive(value: true);
			OverwritingSingleton<IngameUi>.Instance.saveLoadSystem.overrideFrameBudget = -1;
		}

		public void LoadAtOnce()
		{
			DisableIngameCamera(int.MaxValue);
		}

		private void _003CEnableIngameCamera_003Eb__7_0()
		{
			maskingScreen.gameObject.SetActive(value: false);
		}
	}
}
