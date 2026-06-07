using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu.ListView
{
	public class PreviewDragHandler : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IBeginDragHandler
	{
		private ListViewScript _listView;

		private RectTransform _rt;

		public void Initialize(XmlElement element, ListViewScript listView)
		{
			_rt = element.rectTransform;
			_listView = listView;
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			_listView.ObjectViewer.OnDrag(new Vector2(0f, 0f));
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			Vector2 delta = new Vector2(eventData.delta.x / _rt.rect.width, eventData.delta.y / _rt.rect.height) * 90f;
			_listView.ObjectViewer.OnDrag(delta);
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			_listView.ObjectViewer.OnEndDrag();
		}
	}
}
