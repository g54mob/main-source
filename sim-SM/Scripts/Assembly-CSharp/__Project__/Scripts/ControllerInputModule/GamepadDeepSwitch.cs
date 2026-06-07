using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace __Project__.Scripts.ControllerInputModule
{
	[RequireComponent(typeof(GamepadUISelectable))]
	public class GamepadDeepSwitch : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		[SerializeField]
		private List<GameObject> m_GamepadSwitchObjects;

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void SwitchObjects(bool isOpen)
		{
		}
	}
}
