using UnityEngine;
using UnityEngine.EventSystems;

namespace Photon.Pun.Demo.Cockpit
{
	public class OnlineDocButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public string Url;

		public void OnPointerClick(PointerEventData pointerEventData)
		{
		}
	}
}
