using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class PositioningTool : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, ICursorOverride
{
	[Serializable]
	public class VectorEvent : UnityEvent<Vector2>
	{
	}

	public InputField Input1;

	public InputField Input2;

	public RectTransform Cross;

	public RectTransform Self;

	private bool _isDragging;

	public VectorEvent OnMove;

	private Vector2 _lastPos = Vector2.one * 0.5f;

	public int Wait;

	[NonSerialized]
	private bool _disableEdit;

	public Vector2 Position
	{
		get
		{
			return new Vector2(Cross.anchoredPosition.x, 0f - Cross.anchoredPosition.y) / Self.rect.size;
		}
		set
		{
			Cross.anchoredPosition = new Vector2(value.x, 0f - value.y) * Self.rect.size;
			_lastPos = value;
		}
	}

	public string CursorOverrideName
	{
		get
		{
			return "Finger";
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			_isDragging = true;
		}
	}

	public void ShowInput()
	{
		_disableEdit = true;
		Input1.gameObject.SetActive(true);
		Input1.text = Position.x.ToString();
		Input1.ActivateInputField();
		Input2.gameObject.SetActive(true);
		Input2.text = Position.y.ToString();
		_disableEdit = false;
	}

	public void OnEndEdit()
	{
		if (!_disableEdit)
		{
			Position = new Vector2(Input1.text.ConvertToFloatDef(Position.x), Input2.text.ConvertToFloatDef(Position.y));
			_lastPos = Position;
			OnMove.Invoke(Position);
		}
	}

	private void Update()
	{
		if (Input1.gameObject.activeSelf && !Input1.isFocused && !Input2.isFocused)
		{
			if (Wait > 0)
			{
				Wait--;
			}
			else
			{
				Input1.gameObject.SetActive(false);
				Input2.gameObject.SetActive(false);
			}
		}
		else
		{
			if (Input1.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Tab))
			{
				if (Input1.isFocused)
				{
					Input2.ActivateInputField();
				}
				else if (Input2.isFocused)
				{
					Input1.ActivateInputField();
				}
			}
			Wait = 2;
		}
		if (base.transform.hasChanged)
		{
			Position = _lastPos;
		}
		if (_isDragging)
		{
			if (!Input.GetMouseButton(0))
			{
				_isDragging = false;
			}
			Vector2 localPoint;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, null, out localPoint))
			{
				localPoint -= UICamSize.GetUICamOffset();
				Cross.anchoredPosition = new Vector2(Mathf.Clamp(localPoint.x, 0f, Self.rect.width), Mathf.Clamp(localPoint.y, 0f - Self.rect.height, 0f));
				_lastPos = Position;
				OnMove.Invoke(Position);
			}
		}
	}
}
