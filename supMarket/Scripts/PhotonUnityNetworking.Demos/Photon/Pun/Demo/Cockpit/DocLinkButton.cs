using Photon.Pun.Demo.Shared;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Photon.Pun.Demo.Cockpit
{
	public class DocLinkButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public DocLinks.DocTypes Type;

		public string Reference;

		public void Start()
		{
		}

		public void OnPointerClick(PointerEventData pointerEventData)
		{
		}
	}
}
