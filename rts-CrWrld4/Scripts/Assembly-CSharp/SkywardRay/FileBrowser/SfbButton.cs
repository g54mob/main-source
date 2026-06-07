using UnityEngine;
using UnityEngine.EventSystems;

namespace SkywardRay.FileBrowser
{
	public class SfbButton : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		[SerializeField]
		public SfbButtonAction action;

		public void SetListeners()
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}
