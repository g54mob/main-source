using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.CommonElements
{
	public sealed class GUI_AutoDeselector : MonoBehaviour
	{
		private void OnEnable()
		{
			if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
			{
				BaseEventData eventData = new BaseEventData(EventSystem.current);
				ISelectHandler[] components = GetComponents<ISelectHandler>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].OnSelect(eventData);
				}
			}
		}

		private void OnDisable()
		{
			if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
			{
				BaseEventData eventData = new BaseEventData(EventSystem.current);
				IDeselectHandler[] components = GetComponents<IDeselectHandler>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].OnDeselect(eventData);
				}
				EventSystem.current.SetSelectedGameObject(null);
			}
		}
	}
}
