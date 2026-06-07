using UnityEngine;
using UnityEngine.EventSystems;

namespace Gh.Tk.UI
{
	public class DragScrollDetector : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		public bool IsDragScrolling { get; private set; }

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		private void OnDisable()
		{
		}
	}
}
