using Data.Variables;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Data.Minimap
{
	public class MinimapScrollViewControls : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private float _minScale = 1f;

		[SerializeField]
		private float _maxScale = 2.5f;

		[SerializeField]
		private float _zoomSpeed = 1f;

		[SerializeField]
		private float _scrollAmount = 1f;

		[SerializeField]
		private Vector2 _cursorOffset;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private BoolVariableSO _mouseOverUIOverlay;

		[SerializeField]
		private InputActionReference _scrollAction;

		[SerializeField]
		private InputActionReference _mousePosition;

		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private RectTransform _viewport;

		[SerializeField]
		private RectTransform _content;

		private RectTransform _rectTransform;

		private bool _isHovering;

		private float _currentScale;

		private float _targetScale;

		public bool IsHoveringMinimap => _isHovering;

		public float CurrentScale => _currentScale;

		private void Awake()
		{
			_currentScale = _minScale;
			_targetScale = _currentScale;
			_content.localScale = Vector3.one * _currentScale;
			_rectTransform = GetComponent<RectTransform>();
		}

		private void OnEnable()
		{
			_scrollAction.action.performed += OnScroll;
		}

		private void OnDisable()
		{
			_scrollAction.action.performed -= OnScroll;
		}

		private void Update()
		{
			if (_isHovering)
			{
				Vector2 localMousePosition = GetLocalMousePosition();
				float currentScale = _currentScale;
				float num = Mathf.Lerp(_currentScale, _targetScale, Time.deltaTime * _zoomSpeed);
				if (!Mathf.Approximately(currentScale, num))
				{
					_content.localScale = Vector3.one * num;
					Vector2 vector = localMousePosition * (num - currentScale);
					_content.anchoredPosition -= vector;
					_currentScale = num;
				}
			}
		}

		public Vector2 GetLocalMousePosition()
		{
			Vector2 mousePosInMinimapViewport = GetMousePosInMinimapViewport();
			Vector2 vector = new Vector2(_content.anchoredPosition.x * _canvas.transform.localScale.x, _content.anchoredPosition.y * _canvas.transform.localScale.y);
			Vector2 vector2 = (mousePosInMinimapViewport - vector) / CurrentScale;
			return new Vector2(vector2.x / _canvas.transform.localScale.x, vector2.y / _canvas.transform.localScale.y);
		}

		private void OnScroll(InputAction.CallbackContext callbackContext)
		{
			if (_isHovering)
			{
				_targetScale += _scrollAction.action.ReadValue<Vector2>().y * _scrollAmount;
				_targetScale = Mathf.Clamp(_targetScale, _minScale, _maxScale);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UpdateIsHovering(hovering: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			UpdateIsHovering(hovering: false);
		}

		private void UpdateIsHovering(bool hovering)
		{
			_isHovering = hovering;
			_mouseOverUIOverlay.SetValue(_isHovering);
		}

		public void FocusOnPosition(Vector2 pos, MinimapData minimapData)
		{
			Vector2 viewportSize = new Vector2(_viewport.rect.width, _viewport.rect.height);
			Vector2 pos2 = -pos * _currentScale;
			pos2 = ClampPosToContentSize(pos2, minimapData, viewportSize);
			_content.anchoredPosition = pos2;
		}

		private Vector2 ClampPosToContentSize(Vector2 pos, MinimapData minimapData, Vector2 viewportSize)
		{
			Vector2 vector = new Vector2(minimapData.MapBounds.size.x * _currentScale, minimapData.MapBounds.size.z * _currentScale);
			float min = Mathf.Min((0f - (vector.x - viewportSize.x)) * 0.5f, 0f);
			float max = Mathf.Max((vector.x - viewportSize.x) * 0.5f, 0f);
			float min2 = Mathf.Min((0f - (vector.y - viewportSize.y)) * 0.5f, 0f);
			float max2 = Mathf.Max((vector.y - viewportSize.y) * 0.5f, 0f);
			float x = Mathf.Clamp(pos.x, min, max);
			float y = Mathf.Clamp(pos.y, min2, max2);
			return new Vector2(x, y);
		}

		public Vector2 GetMousePosInMinimapViewport()
		{
			Vector2 vector = _mousePosition.action.ReadValue<Vector2>();
			return -new Vector2(_rectTransform.position.x - vector.x, _rectTransform.position.y - vector.y) + _cursorOffset;
		}

		public void SetMinimapHidden()
		{
			UpdateIsHovering(hovering: false);
		}
	}
}
