using System.Collections.Generic;
using DV.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class Popup : MonoBehaviour
	{
		[Header("Optional, will wire up Closed event to these buttons if set")]
		public Button positiveButton;

		public Button negativeButton;

		public Button abortionButton;

		[Header("Optional")]
		public TextMeshProUGUI titleTMPro;

		public TextMeshProUGUI labelTMPro;

		public bool allowEnterKey = true;

		public bool allowEscapeKey = true;

		public bool pauseOnOpen = true;

		private IPopupSubmitHandler handler;

		private bool handled;

		public PopupClosedByAction EnterAction { get; set; }

		public PopupClosedByAction EscAction { get; set; } = PopupClosedByAction.Abortion;

		public event PopupClosedDelegate Closed;

		private void Start()
		{
			if ((bool)positiveButton)
			{
				positiveButton.onClick.AddListener(CloseHandler_Positive);
			}
			if ((bool)negativeButton)
			{
				negativeButton.onClick.AddListener(CloseHandler_Negative);
			}
			if ((bool)abortionButton)
			{
				abortionButton.onClick.AddListener(CloseHandler_Abortion);
			}
			handler = GetComponent<IPopupSubmitHandler>();
		}

		public void RequestClose(PopupClosedByAction closedByAction, string resultData)
		{
			this.Closed?.Invoke(new PopupResult(this, closedByAction, resultData));
		}

		public void SetLocalizationData(PopupLocalizationKeys keys, Dictionary<string, string> parameters, bool keepLiteralData = false)
		{
			if (keepLiteralData)
			{
				if ((bool)positiveButton)
				{
					SetLiteral(positiveButton, keys.positiveKey);
				}
				if ((bool)negativeButton)
				{
					SetLiteral(negativeButton, keys.negativeKey);
				}
				if ((bool)abortionButton)
				{
					SetLiteral(abortionButton, keys.abortionKey);
				}
				if ((bool)titleTMPro)
				{
					SetLiteral(titleTMPro, keys.titleKey);
				}
				if ((bool)labelTMPro)
				{
					SetLiteral(labelTMPro, keys.labelKey);
				}
			}
			else
			{
				if ((bool)positiveButton)
				{
					Localize(positiveButton, keys.positiveKey, parameters);
				}
				if ((bool)negativeButton)
				{
					Localize(negativeButton, keys.negativeKey, parameters);
				}
				if ((bool)abortionButton)
				{
					Localize(abortionButton, keys.abortionKey, parameters);
				}
				if ((bool)titleTMPro)
				{
					Localize(titleTMPro, keys.titleKey, parameters);
				}
				if ((bool)labelTMPro)
				{
					Localize(labelTMPro, keys.labelKey, parameters);
				}
			}
		}

		private void Localize(Component component, string key, Dictionary<string, string> parameters)
		{
			if (component == null)
			{
				Debug.LogWarning("Couldn't apply localization '" + key + "', passed component is null");
			}
			else
			{
				Localize(component.gameObject, key, parameters);
			}
		}

		private void SetLiteral(Component component, string key)
		{
			if (component == null)
			{
				Debug.LogWarning("Couldn't apply localization '" + key + "', passed component is null");
			}
			else
			{
				SetLiteral(component.gameObject, key);
			}
		}

		private void SetLiteral(GameObject go, string key)
		{
			Localize componentInChildren = go.GetComponentInChildren<Localize>();
			if (!componentInChildren)
			{
				if (!string.IsNullOrWhiteSpace(key))
				{
					Debug.LogWarning("Couldn't apply localization '" + key + "' because '" + go.name + "' doesn't have a Localize component", go);
				}
			}
			else if (string.IsNullOrWhiteSpace(key))
			{
				Debug.LogWarning("Couldn't apply localization to '" + go.name + "', passed bad key", go);
			}
			else
			{
				componentInChildren.enabled = false;
				TMP_Text component = componentInChildren.GetComponent<TMP_Text>();
				if ((bool)component)
				{
					component.text = key;
				}
			}
		}

		private void Localize(GameObject go, string key, Dictionary<string, string> parameters)
		{
			if (go == null)
			{
				Debug.LogWarning("Couldn't apply localization '" + key + "', passed gameobject is null", this);
				return;
			}
			Localize componentInChildren = go.GetComponentInChildren<Localize>();
			if (string.IsNullOrWhiteSpace(key))
			{
				if ((bool)componentInChildren)
				{
					Debug.LogWarning("Couldn't apply localization to '" + go.name + "', passed bad key", go);
				}
			}
			else if (!componentInChildren)
			{
				Debug.LogWarning("Couldn't apply localization '" + key + "' because '" + go.name + "' doesn't have a Localize component", go);
			}
			else
			{
				componentInChildren.key = key;
				componentInChildren.UpdateLocalization(parameters);
			}
		}

		private void CloseHandler_Positive()
		{
			Handle(PopupClosedByAction.Positive);
		}

		private void CloseHandler_Negative()
		{
			Handle(PopupClosedByAction.Negative);
		}

		private void CloseHandler_Abortion()
		{
			Handle(PopupClosedByAction.Abortion);
		}

		public void Handle(PopupClosedByAction action)
		{
			if (!handled)
			{
				handled = true;
				if (handler != null)
				{
					handler.HandleAction(action);
				}
				else
				{
					this.Closed?.Invoke(new PopupResult(this, action));
				}
			}
		}

		private void Update()
		{
			if (allowEnterKey && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
			{
				Handle(EnterAction);
			}
			else if (allowEscapeKey && Input.GetKeyDown(KeyCode.Escape))
			{
				Handle(EscAction);
			}
		}

		private void OnEnable()
		{
			handled = false;
		}

		private void OnDisable()
		{
			if (!handled)
			{
				Handle(PopupClosedByAction.Abortion);
			}
		}
	}
}
