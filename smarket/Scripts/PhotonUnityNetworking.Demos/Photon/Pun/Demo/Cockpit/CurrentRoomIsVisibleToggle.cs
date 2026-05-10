using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	[RequireComponent(typeof(Toggle))]
	public class CurrentRoomIsVisibleToggle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private Toggle _toggle;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public void ToggleValue(bool value)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
