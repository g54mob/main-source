using ModApi;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class InputSliderScript : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
	{
		private RectTransform _clickArea;

		private RectTransform _handle;

		private float _height;

		private InputSlider _inputSlider;

		private TextMeshProUGUI _sliderValue;

		public float Value
		{
			get
			{
				return _inputSlider.GetAction();
			}
			set
			{
				_inputSlider.SetAction(value);
			}
		}

		public void Initialize(InputSlider inputSlider)
		{
			_inputSlider = inputSlider;
			inputSlider.Element.GetElementByInternalId("slider-name")?.SetText(_inputSlider.Name);
			_sliderValue = inputSlider.Element.GetElementByInternalId<TextMeshProUGUI>("slider-value");
			if (_sliderValue != null)
			{
				_sliderValue.text = string.Empty;
			}
			_clickArea = inputSlider.Element.GetElementByInternalId("slider-click-area").GetComponent<RectTransform>();
			_handle = inputSlider.Element.GetElementByInternalId("slider-handle").GetComponent<RectTransform>();
			_height = _clickArea.rect.height / 2f - _handle.rect.height / 2f;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			UpdateHandlePosition(eventData.position);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			UpdateHandlePosition(eventData.position);
		}

		protected virtual void Awake()
		{
			Image component = GetComponent<Image>();
			if (component != null)
			{
				component.raycastTarget = true;
			}
		}

		protected virtual void Update()
		{
			if (_inputSlider.AllowNegative)
			{
				float y = Value * _height;
				_handle.localPosition = new Vector3(0f, y);
			}
			else
			{
				float y2 = 0f - _height + Value * 2f * _height;
				_handle.localPosition = new Vector3(0f, y2);
			}
			if (_sliderValue != null)
			{
				_sliderValue.text = Utilities.FormatPercentage(Value);
			}
		}

		private void UpdateHandlePosition(Vector2 cursorPosition)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_clickArea, cursorPosition, null, out var localPoint);
			float num = Mathf.Clamp(localPoint.y / _height, -1f, 1f);
			if (!_inputSlider.AllowNegative)
			{
				num = (num + 1f) / 2f;
			}
			if (Mathf.Abs(num) < 0.05f)
			{
				num = 0f;
			}
			Value = num;
		}
	}
}
