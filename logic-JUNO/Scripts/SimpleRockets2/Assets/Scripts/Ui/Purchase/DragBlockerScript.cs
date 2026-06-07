using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Purchase
{
	public class DragBlockerScript : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler
	{
		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}
	}
}
