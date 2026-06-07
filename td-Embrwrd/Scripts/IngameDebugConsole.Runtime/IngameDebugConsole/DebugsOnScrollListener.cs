using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace IngameDebugConsole
{
	public class DebugsOnScrollListener : MonoBehaviour, IScrollHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
	{
		public ScrollRect debugsScrollRect;

		public DebugLogManager debugLogManager;

		public void OnScroll(PointerEventData data)
		{
		}

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}

		public void OnScrollbarDragStart(BaseEventData data)
		{
		}

		public void OnScrollbarDragEnd(BaseEventData data)
		{
		}

		private bool IsScrollbarAtBottom()
		{
			return false;
		}
	}
}
