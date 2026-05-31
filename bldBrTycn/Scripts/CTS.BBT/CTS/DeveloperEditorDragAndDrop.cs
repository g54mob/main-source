using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class DeveloperEditorDragAndDrop : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		[SerializeField]
		private RectTransform _dragAndDropRectTransform;

		[SerializeField]
		private Canvas _canvas;

		private LayoutElement _layoutElement;

		public void Awake()
		{
			_layoutElement = base.gameObject.GetComponent<LayoutElement>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!_layoutElement.ignoreLayout)
			{
				_layoutElement.ignoreLayout = true;
			}
			_dragAndDropRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
		}
	}
}
