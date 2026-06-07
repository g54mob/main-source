using SettingScripts;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;

namespace ManagementScripts
{
	public class PopupManager : MonoBehaviour, ISerializationCallbackReceiver
	{
		public GameObject errorPrefab;

		public GameObject dialogPrefab;

		public GameObject warningPrefab;

		public GameObject choicePrefab;

		private static GameObject ErrorPrefab;

		private static GameObject DialogPrefab;

		private static GameObject WarningPrefab;

		private static GameObject ChoicePrefab;

		public static Transform popupHolder;

		public static GameObject screenBlocker;

		public static UnityEvent<bool> onPopupPresent = new UnityEvent<bool>();

		public void OnAfterDeserialize()
		{
			ErrorPrefab = errorPrefab;
			DialogPrefab = dialogPrefab;
			WarningPrefab = warningPrefab;
			ChoicePrefab = choicePrefab;
		}

		public void OnBeforeSerialize()
		{
		}

		public static void OnPopupHide()
		{
			onPopupPresent.Invoke(arg0: false);
		}

		public static void SetBlockingScreen(bool val)
		{
			if (screenBlocker != null)
			{
				screenBlocker.SetActive(val);
			}
		}

		public static ErrorPopupHandle DisplayError(string source, string text, UnityAction afterDismiss = null, bool setBlockingScreen = false)
		{
			ErrorPopupHandle component = Object.Instantiate(ErrorPrefab, popupHolder).GetComponent<ErrorPopupHandle>();
			onPopupPresent.Invoke(arg0: true);
			component.InitDialog(source, text, afterDismiss);
			component.OnDismiss.AddListener(OnPopupHide);
			if (setBlockingScreen)
			{
				SetBlockingScreen(val: true);
				component.OnDismiss.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
			}
			return component;
		}

		public static DialogHandle DisplayDialog(string title, string text, UnityAction afterDismiss = null, bool setBlockingScreen = false)
		{
			DialogHandle component = Object.Instantiate(DialogPrefab, popupHolder).GetComponent<DialogHandle>();
			onPopupPresent.Invoke(arg0: true);
			component.InitDialog(title, text, afterDismiss);
			component.OnDismiss.AddListener(OnPopupHide);
			if (setBlockingScreen)
			{
				SetBlockingScreen(val: true);
				component.OnDismiss.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
			}
			return component;
		}

		public static WarningHandle DisplayWarning(ActionWarning actionWarning, string title, string text, string proceedText = "OK", UnityAction afterDismiss = null, bool setBlockingScreen = false)
		{
			WarningHandle component = Object.Instantiate(WarningPrefab, popupHolder).GetComponent<WarningHandle>();
			onPopupPresent.Invoke(arg0: true);
			component.InitWarning(actionWarning, title, text, proceedText, afterDismiss);
			component.OnDismiss.AddListener(OnPopupHide);
			if (setBlockingScreen)
			{
				SetBlockingScreen(val: true);
				component.OnDismiss.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
			}
			return component;
		}

		public static void DisplayActionWarning(ActionWarning actionWarning, UnityAction afterProceed, string proceedText = null, string warningText = null, string title = null, bool setBlockingScreen = true)
		{
			if (actionWarning.doNotShowAgain)
			{
				afterProceed?.Invoke();
				return;
			}
			WarningHandle component = Object.Instantiate(WarningPrefab, popupHolder).GetComponent<WarningHandle>();
			component.OnDismiss.AddListener(OnPopupHide);
			component.OnCancel.AddListener(OnPopupHide);
			component.InitWarningWithCancel(actionWarning, title ?? actionWarning.title, warningText ?? actionWarning.warningText, proceedText ?? "Yes", afterProceed);
			component.OnDismiss.AddListener(OnPopupHide);
			if (setBlockingScreen)
			{
				SetBlockingScreen(val: true);
				component.OnDismiss.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
				component.OnCancel.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
			}
		}

		public static WarningHandle DisplayWarningWithCancel(ActionWarning actionWarning, string title, string text, string proceedText = "OK", UnityAction afterDismiss = null, UnityAction afterCancel = null, bool setBlockingScreen = false)
		{
			WarningHandle component = Object.Instantiate(WarningPrefab, popupHolder).GetComponent<WarningHandle>();
			onPopupPresent.Invoke(arg0: true);
			component.InitWarningWithCancel(actionWarning, title, text, proceedText, afterDismiss, afterCancel);
			component.OnDismiss.AddListener(OnPopupHide);
			component.OnCancel.AddListener(OnPopupHide);
			if (setBlockingScreen)
			{
				SetBlockingScreen(val: true);
				component.OnDismiss.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
				component.OnCancel.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
			}
			return component;
		}

		public static ChoicePopupHandle DisplayChoiceDialog(string title, string text, string dismissText = "Cancel", string acceptText = "OK", UnityAction afterDismiss = null, UnityAction afterAccept = null, bool setBlockingScreen = false)
		{
			ChoicePopupHandle component = Object.Instantiate(ChoicePrefab, popupHolder).GetComponent<ChoicePopupHandle>();
			onPopupPresent.Invoke(arg0: true);
			component.InitDialog(title, text, dismissText, acceptText, afterDismiss, afterAccept);
			component.OnDismiss.AddListener(OnPopupHide);
			component.OnAccept.AddListener(OnPopupHide);
			if (setBlockingScreen)
			{
				SetBlockingScreen(val: true);
				component.OnDismiss.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
				component.OnAccept.AddListener(delegate
				{
					SetBlockingScreen(val: false);
				});
			}
			return component;
		}
	}
}
