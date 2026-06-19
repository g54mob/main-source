using UnityEngine;
using UnityEngine.EventSystems;

namespace Aggro.Core
{
	public class AggroSettingSelectedContainerUI : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		public GameObject container;

		private void OnEnable()
		{
			container.SetActive(value: false);
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (AggroSettings.inputMode == InputMode.Gamepad)
			{
				container.SetActive(value: true);
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			container.SetActive(value: false);
		}
	}
}
