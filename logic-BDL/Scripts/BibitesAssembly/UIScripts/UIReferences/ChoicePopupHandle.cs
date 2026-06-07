using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class ChoicePopupHandle : DialogHandle
	{
		public TextMeshProUGUI dismissButton;

		public TextMeshProUGUI acceptButton;

		public UnityEvent OnAccept = new UnityEvent();

		public void InitDialog(string _title, string _text, string _dismissText = "Cancel", string _acceptText = "OK", UnityAction afterDismiss = null, UnityAction afterAccept = null)
		{
			base.gameObject.SetActive(value: true);
			title.text = _title;
			if (!string.IsNullOrEmpty(_text))
			{
				text.text = _text;
			}
			dismissButton.text = _dismissText;
			acceptButton.text = _acceptText;
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			if (afterDismiss != null)
			{
				OnDismiss.AddListener(afterDismiss);
			}
			if (afterAccept != null)
			{
				OnAccept.AddListener(afterAccept);
			}
		}

		public void AfterAccept(UnityAction afterAccept)
		{
			OnAccept.AddListener(afterAccept);
		}

		public void Accept()
		{
			base.gameObject.SetActive(value: false);
			if (destroyedOnDismiss)
			{
				Object.Destroy(base.gameObject);
			}
			OnAccept.Invoke();
		}

		public void ClearAcceptActions()
		{
			OnAccept.RemoveAllListeners();
		}
	}
}
