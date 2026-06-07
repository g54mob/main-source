using UnityEngine;
using UnityEngine.EventSystems;

namespace SLS.Widgets.Table
{
	public class ScrollWatcher : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		private bool _isDragging;

		public Table table { get; private set; }

		public bool isDragging => false;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}

		public bool Initialize(Table table)
		{
			return false;
		}

		private void OnScrollerValueChanged(float f)
		{
		}
	}
}
