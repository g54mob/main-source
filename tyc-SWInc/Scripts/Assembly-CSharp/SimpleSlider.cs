using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SimpleSlider : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public float MinValue;

	public float MaxValue = 1f;

	private float _value;

	public bool WholeNumbers;

	public UnityEvent OnValueChanged;

	public RectTransform Self;

	public RectTransform Bar;

	private bool _isDragging;

	public float Value
	{
		get
		{
			return _value;
		}
		set
		{
			float value2 = _value;
			_value = Mathf.Clamp(value, MinValue, MaxValue);
			if (WholeNumbers)
			{
				_value = Mathf.RoundToInt(_value);
			}
			if (_value != value2)
			{
				Bar.sizeDelta = new Vector2(_value.MapRange(MinValue, MaxValue, 0f, Self.rect.width, true), Bar.sizeDelta.y);
				OnValueChanged.Invoke();
			}
		}
	}

	private void Update()
	{
		if (_isDragging)
		{
			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
			Value = localPoint.x.MapRange(0f, Self.rect.width, MinValue, MaxValue, true);
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_isDragging = true;
	}
}
