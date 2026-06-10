using System;
using System.Collections;
using System.Globalization;
using NSEipix.Base;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ScreenSettingsResetView : UIView
	{
		[SerializeField]
		private float secondsOpen = 5f;

		[SerializeField]
		private GraphicOptionsView optionsView;

		[SerializeField]
		private TMP_Text countxownText;

		[SerializeField]
		private Button cancelButton;

		[SerializeField]
		private Button keepButton;

		private Coroutine countdownInstance;

		private Action keepAction;

		private Action resetAction;

		public void ShowResolution(Action keepAction, Action resetAction)
		{
			base.gameObject.SetActive(value: true);
			this.keepAction = keepAction;
			this.resetAction = resetAction;
			countdownInstance = StartCoroutine(Countdown());
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: true);
			}
		}

		public void ShowUIScale(Action keepAction, Action resetAction)
		{
			base.gameObject.SetActive(value: true);
			this.keepAction = keepAction;
			this.resetAction = resetAction;
			countdownInstance = StartCoroutine(Countdown());
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: true);
			}
		}

		public override void Hide()
		{
			StopCoroutine(countdownInstance);
			keepAction = null;
			resetAction = null;
			base.gameObject.SetActive(value: false);
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: false);
			}
		}

		public void OnKeepSettings()
		{
			keepAction?.Invoke();
			Hide();
		}

		public void OnRevertSettings()
		{
			resetAction?.Invoke();
			Hide();
		}

		private IEnumerator Countdown()
		{
			for (float seconds = secondsOpen; seconds > 0f; seconds -= 1f)
			{
				countxownText.text = seconds.ToString(CultureInfo.InvariantCulture);
				yield return new WaitForSecondsRealtime(1f);
			}
			OnRevertSettings();
		}
	}
}
