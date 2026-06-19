using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aggro.Core
{
	public class AggroSettingGamepadDropdown : MonoBehaviour, IUpdateSelectedHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
	{
		public ScrollRect scrollRect;

		public void OnUpdateSelected(BaseEventData eventData)
		{
			if (AggroSettings.inputMode == InputMode.Gamepad)
			{
				RectTransform component = GetComponent<RectTransform>();
				Vector3 vector = scrollRect.transform.InverseTransformPoint(component.position);
				float y = component.sizeDelta.y;
				float num = vector.y + y / 2f + 4f;
				float num2 = vector.y - y / 2f - 4f;
				float y2 = scrollRect.GetComponent<RectTransform>().sizeDelta.y;
				if (num > 0f)
				{
					Vector3 localPosition = scrollRect.content.localPosition;
					localPosition.y -= num;
					scrollRect.content.localPosition = localPosition;
				}
				else if (num2 < 0f - y2)
				{
					Vector3 localPosition2 = scrollRect.content.localPosition;
					localPosition2.y += 0f - num2 - y2;
					scrollRect.content.localPosition = localPosition2;
				}
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			AggroSettingsManagerUI.gamepadSuppressBack = true;
		}

		public void OnDeselect(BaseEventData eventData)
		{
			AggroSettingsManagerUI.gamepadSuppressBack = false;
		}
	}
}
