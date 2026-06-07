using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class WarningHandle : MonoBehaviour
	{
		public TextMeshProUGUI title;

		public TextMeshProUGUI text;

		public TextMeshProUGUI continueText;

		public GameObject cancelButton;

		public Toggle doNotShowAgain;

		private ActionWarning actionWarning;

		public UnityEvent OnDismiss = new UnityEvent();

		public UnityEvent OnCancel = new UnityEvent();

		public bool dismissed;

		public bool destroyedOnDismiss = true;

		public void InitWarning(ActionWarning actionWarning, string _title, string _text, string proceedText = "OK", UnityAction afterDismiss = null)
		{
			cancelButton.SetActive(value: false);
			this.actionWarning = actionWarning;
			title.text = _title;
			text.text = _text;
			continueText.text = proceedText;
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			if (this.actionWarning == null)
			{
				doNotShowAgain.gameObject.SetActive(value: false);
			}
			if (afterDismiss != null)
			{
				OnDismiss.AddListener(afterDismiss);
			}
		}

		public void InitWarningWithCancel(ActionWarning actionWarningRef, string titleText, string bodyText, string proceedText = "OK", UnityAction afterProceed = null, UnityAction afterCancel = null)
		{
			InitWarning(actionWarningRef, titleText, bodyText, proceedText, afterProceed);
			cancelButton.SetActive(value: true);
			if (afterCancel != null)
			{
				OnCancel.AddListener(afterCancel);
			}
		}

		public void AfterDismiss(UnityAction afterDismiss)
		{
			OnDismiss.AddListener(afterDismiss);
		}

		public void AfterCancel(UnityAction afterCancel)
		{
			OnCancel.AddListener(afterCancel);
		}

		public void Dismiss()
		{
			base.gameObject.SetActive(value: false);
			if (doNotShowAgain.isOn && actionWarning != null)
			{
				actionWarning.doNotShowAgain = true;
			}
			if (destroyedOnDismiss)
			{
				Object.Destroy(base.gameObject);
			}
			OnDismiss.Invoke();
			dismissed = true;
		}

		public void Cancel()
		{
			OnCancel.Invoke();
			dismissed = true;
			base.gameObject.SetActive(value: false);
			if (destroyedOnDismiss)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void ClearDismissActions()
		{
			OnDismiss.RemoveAllListeners();
		}

		public void ClearCancelActions()
		{
			OnCancel.RemoveAllListeners();
		}
	}
}
