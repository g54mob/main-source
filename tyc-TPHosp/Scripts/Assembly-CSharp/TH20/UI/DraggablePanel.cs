using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	public class DraggablePanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private GraphicRaycaster _raycaster;

		private RectTransform _canvasTransform;

		private bool _followMouse;

		private Vector2 _mouseOffset = Vector2.zero;

		public void Awake()
		{
			if (_canvas != null)
			{
				_canvasTransform = _canvas.transform as RectTransform;
			}
		}

		public void SetCanvas(Canvas canvas)
		{
			_canvas = canvas;
			_canvasTransform = _canvas.transform as RectTransform;
			_raycaster = _canvas.GetComponent<GraphicRaycaster>();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_followMouse = true;
			_mouseOffset = base.transform.position - Input.mousePosition;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_followMouse = false;
			_mouseOffset = Vector2.zero;
		}

		public void Update()
		{
			if (_followMouse)
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasTransform, Input.mousePosition, _canvas.worldCamera, out var localPoint);
				base.transform.position = _canvas.transform.TransformPoint(localPoint + _mouseOffset);
			}
		}
	}
}
