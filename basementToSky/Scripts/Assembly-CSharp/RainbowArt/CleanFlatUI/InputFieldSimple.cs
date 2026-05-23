using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class InputFieldSimple : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private Image background;

		[SerializeField]
		private Image foreground;

		private CanvasGroup canvasGroupBg;

		private CanvasGroup canvasGroupFg;

		private EventTrigger eventTrigger;

		private void Awake()
		{
			AddTriggersListener(inputField.gameObject, EventTriggerType.Select, InputFieldIn);
			inputField.onEndEdit.AddListener(InputFieldOut);
			inputField.onValueChanged.AddListener(InputFieldValueChanged);
		}

		private void OnEnable()
		{
			UpdateGUI(bIn: false);
		}

		private void AddTriggersListener(GameObject obj, EventTriggerType eventID, UnityAction<BaseEventData> action)
		{
			EventTrigger eventTrigger = obj.GetComponent<EventTrigger>();
			if (eventTrigger == null)
			{
				eventTrigger = obj.AddComponent<EventTrigger>();
			}
			if (eventTrigger.triggers.Count == 0)
			{
				eventTrigger.triggers = new List<EventTrigger.Entry>();
			}
			UnityAction<BaseEventData> call = action.Invoke;
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = eventID;
			entry.callback.AddListener(call);
			eventTrigger.triggers.Add(entry);
		}

		public void InputFieldIn(BaseEventData data)
		{
			UpdateGUI(bIn: true);
		}

		public void InputFieldOut(string value)
		{
			UpdateGUI(bIn: false);
		}

		public void InputFieldValueChanged(string value)
		{
			if (value.Length == 0 || value.Length == 1)
			{
				UpdateGUI(bIn: true);
			}
		}

		private void InitCanvasGroup()
		{
			if (canvasGroupBg == null)
			{
				canvasGroupBg = background.gameObject.GetComponent<CanvasGroup>();
			}
			if (canvasGroupFg == null)
			{
				canvasGroupFg = foreground.gameObject.GetComponent<CanvasGroup>();
			}
		}

		public void UpdateGUI(bool bIn)
		{
			InitCanvasGroup();
			if (inputField.text.Length == 0)
			{
				if (!bIn)
				{
					SetCanvasGroupAlpha(canvasGroupFg, 0f);
				}
				else
				{
					SetCanvasGroupAlpha(canvasGroupFg, 0f);
				}
			}
			else if (!bIn)
			{
				SetCanvasGroupAlpha(canvasGroupFg, 1f);
			}
			else
			{
				SetCanvasGroupAlpha(canvasGroupFg, 1f);
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
