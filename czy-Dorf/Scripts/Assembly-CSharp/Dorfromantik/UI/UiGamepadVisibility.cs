using UnityEngine;

namespace Dorfromantik.UI
{
	public class UiGamepadVisibility : MonoBehaviour
	{
		[SerializeField]
		private bool isVisibleWhenGamepadActive = true;

		[SerializeField]
		private bool shouldUseCanvasGroupAlpha;

		[SerializeField]
		private CanvasGroup canvasGroupToAffect;

		[SerializeField]
		internal GameObject gameObjectToAffect;

		private HideableUi hideableUi;

		private void Start()
		{
			Singleton<InputManager>.Instance.OnInputDeviceChanged += UpdateVisibility;
			if (gameObjectToAffect == null)
			{
				gameObjectToAffect = base.gameObject;
			}
			hideableUi = gameObjectToAffect.GetComponent<HideableUi>();
			UpdateVisibility(Singleton<InputManager>.Instance.CurrentInputDevice);
		}

		private void OnDestroy()
		{
			if ((bool)Singleton<InputManager>.Instance)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged -= UpdateVisibility;
			}
		}

		private void UpdateVisibility(InputDevice obj)
		{
			if (isVisibleWhenGamepadActive)
			{
				Show(Singleton<InputManager>.Instance.CurrentInputDevice != InputDevice.MouseKeyboard);
			}
			else
			{
				Show(Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard);
			}
		}

		private void Show(bool shouldShow)
		{
			if ((bool)hideableUi)
			{
				if (shouldShow)
				{
					hideableUi.Lock(shouldLock: false);
				}
				hideableUi.Show(shouldShow);
				if (!shouldShow)
				{
					hideableUi.Lock(shouldLock: true);
				}
			}
			else
			{
				if (shouldUseCanvasGroupAlpha && (bool)canvasGroupToAffect)
				{
					canvasGroupToAffect.alpha = (shouldShow ? 1 : 0);
				}
				gameObjectToAffect.SetActive(shouldShow);
			}
		}
	}
}
