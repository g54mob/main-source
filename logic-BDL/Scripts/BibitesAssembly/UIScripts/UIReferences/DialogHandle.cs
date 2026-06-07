using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class DialogHandle : MonoBehaviour
	{
		public TextMeshProUGUI title;

		public TextMeshProUGUI text;

		public UnityEvent OnDismiss = new UnityEvent();

		public bool dismissed;

		public bool destroyedOnDismiss;

		public void InitDialog(string _title, string _text, UnityAction afterDismiss = null)
		{
			title.text = _title;
			text.text = _text;
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			if (afterDismiss != null)
			{
				OnDismiss.AddListener(afterDismiss);
			}
		}

		public void AfterDismiss(UnityAction afterDismiss)
		{
			OnDismiss.AddListener(afterDismiss);
		}

		public void Dismiss()
		{
			base.gameObject.SetActive(value: false);
			if (destroyedOnDismiss)
			{
				Object.Destroy(base.gameObject);
			}
			OnDismiss.Invoke();
			dismissed = true;
		}

		public void ClearDismissActions()
		{
			OnDismiss.RemoveAllListeners();
		}
	}
}
