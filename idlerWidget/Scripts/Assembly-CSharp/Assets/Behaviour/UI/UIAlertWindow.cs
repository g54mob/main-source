using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.UI
{
	public class UIAlertWindow : MonoBehaviour
	{
		private static UIAlertWindow _instance;

		[SerializeField]
		private TMP_Text _title;

		[SerializeField]
		private TMP_Text _body;

		[SerializeField]
		private Transform _buttonsParent;

		[SerializeField]
		private Button _buttonPrefab;

		private Action<string> _onClick;

		public static void Init(UIAlertWindow instance)
		{
			_instance = instance;
		}

		public static void Show(string title, string message, Action onClose = null)
		{
			Show(title, message, new string[1] { "Okay" }, delegate
			{
				onClose?.Invoke();
			});
		}

		public static void Query(string title, string message, Action onYes = null, Action onNo = null)
		{
			Show(title, message, new string[2] { "Yes", "No" }, delegate(string label)
			{
				if (label == "Yes")
				{
					onYes?.Invoke();
				}
				else
				{
					onNo?.Invoke();
				}
			});
		}

		public static void Show(string title, string message, string[] buttons, Action<string> onClick)
		{
			if ((bool)_instance)
			{
				_instance.ShowAlert(title, message, buttons, onClick);
			}
		}

		public static void Hide()
		{
			if ((bool)_instance)
			{
				_instance.gameObject.SetActive(value: false);
				UISounds.WindowClose();
			}
		}

		public void ShowAlert(string title, string message, string[] buttons, Action<string> onClick)
		{
			UISounds.WindowOpen();
			_title.text = title;
			RectTransform rectTransform = (RectTransform)_title.transform.parent;
			rectTransform.sizeDelta = new Vector2(_title.preferredWidth + 30f, rectTransform.sizeDelta.y);
			_body.text = message;
			_body.ForceMeshUpdate();
			RectTransform rectTransform2 = (RectTransform)_body.transform.parent;
			Vector2 preferredValues = _body.GetPreferredValues(rectTransform2.sizeDelta.x - 40f, 9999f);
			rectTransform2.sizeDelta = new Vector2(rectTransform2.sizeDelta.x, Mathf.Max(200f, preferredValues.y + 100f));
			_onClick = onClick;
			_buttonsParent.DestroyChildren();
			float num = 0f;
			for (int num2 = buttons.Length - 1; num2 >= 0; num2--)
			{
				string label = buttons[num2];
				Button button = UnityEngine.Object.Instantiate(_buttonPrefab, _buttonsParent);
				TMP_Text componentInChildren = button.GetComponentInChildren<TMP_Text>();
				componentInChildren.text = label;
				button.onClick.AddListener(delegate
				{
					_onClick?.Invoke(label);
					Hide();
				});
				RectTransform rectTransform3 = (RectTransform)button.transform;
				rectTransform3.sizeDelta = new Vector2(componentInChildren.preferredWidth + 30f, rectTransform3.sizeDelta.y);
				rectTransform3.anchoredPosition = new Vector2(num, 0f);
				num -= rectTransform3.sizeDelta.x + 20f;
			}
			base.gameObject.SetActive(value: true);
		}
	}
}
