using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Vizzy.UI
{
	public class ContextMenuButtonScript : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
	{
		[SerializeField]
		private bool _cloneChain;

		private ContextMenuScript _contextMenu;

		public bool CloneChain => _cloneChain;

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			_contextMenu.OnBeginDrag(this, eventData);
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			_contextMenu.OnDrag(this, eventData);
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			_contextMenu.OnEndDrag(this, eventData);
		}

		protected virtual void Awake()
		{
			_contextMenu = GetComponentInParent<ContextMenuScript>();
		}
	}
}
