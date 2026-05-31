using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class InputFieldSimple : MonoBehaviour
	{
		[SerializeField]
		private InputField inputField;

		[SerializeField]
		private Image background;

		[SerializeField]
		private Image foreground;

		private CanvasGroup canvasGroupBg;

		private CanvasGroup canvasGroupFg;

		private EventTrigger eventTrigger;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void AddTriggersListener(GameObject obj, EventTriggerType eventID, UnityAction<BaseEventData> action)
		{
		}

		public void InputFieldIn(BaseEventData data)
		{
		}

		public void InputFieldOut(string value)
		{
		}

		public void InputFieldValueChanged(string value)
		{
		}

		private void InitCanvasGroup()
		{
		}

		public void UpdateGUI(bool bIn)
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
