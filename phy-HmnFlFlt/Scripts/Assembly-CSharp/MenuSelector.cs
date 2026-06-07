using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuSelector : Button
{
	private enum MousePlace
	{
		None = 0,
		Button = 1,
		Left = 2,
		Right = 3
	}

	[Serializable]
	public class SelectorEvent : UnityEvent<int>
	{
	}

	public string[] options;

	public TextMeshProUGUI[] optionLabels;

	public int selectedIndex;

	public TextMeshProUGUI valueLabel;

	public Image leftArrow;

	public Image rightArrow;

	private PointerEventData cachedEventData;

	private MousePlace currentArrow;

	public SelectorEvent onValueChanged;

	private int optionsCount
	{
		get
		{
			return (options.Length == 0) ? optionLabels.Length : options.Length;
		}
	}

	protected override void Start()
	{
		base.Start();
	}

	public void SelectIndex(int index)
	{
		selectedIndex = index;
		RebindValue();
	}

	public void RebindValue()
	{
		if (selectedIndex >= 0 && selectedIndex < optionsCount)
		{
			if (options.Length > 0)
			{
				valueLabel.text = options[selectedIndex];
				return;
			}
			for (int i = 0; i < optionsCount; i++)
			{
				optionLabels[i].gameObject.SetActive(i == selectedIndex);
			}
		}
		else
		{
			Debug.LogError("Option missing", this);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		cachedEventData = eventData;
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		cachedEventData = null;
		SetActiveArrow(MousePlace.Button);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		leftArrow.gameObject.SetActive(true);
		rightArrow.gameObject.SetActive(true);
		SetActiveArrow(MousePlace.None);
		base.OnSelect(eventData);
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		leftArrow.gameObject.SetActive(false);
		rightArrow.gameObject.SetActive(false);
		base.OnDeselect(eventData);
	}

	private MousePlace GetPointPlacement(Vector2 screenPos, Camera camera)
	{
		RectTransform component = leftArrow.transform.parent.GetComponent<RectTransform>();
		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(component, screenPos, camera, out localPoint);
		float num = (localPoint - component.rect.position).x / component.rect.width;
		if (num < 0f)
		{
			return MousePlace.Button;
		}
		if (num > 0.5f)
		{
			return MousePlace.Right;
		}
		return MousePlace.Left;
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		NextValue();
		base.OnSubmit(eventData);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);
		switch (GetPointPlacement(eventData.position, eventData.pressEventCamera))
		{
		case MousePlace.Button:
			NextValue();
			break;
		case MousePlace.Left:
			PrevValue();
			break;
		case MousePlace.Right:
			NextValue();
			break;
		}
	}

	private void NextValue()
	{
		if (optionsCount != 0)
		{
			selectedIndex = (selectedIndex + 1) % optionsCount;
			RebindValue();
			onValueChanged.Invoke(selectedIndex);
			Canvas.ForceUpdateCanvases();
		}
	}

	private void PrevValue()
	{
		if (optionsCount != 0)
		{
			selectedIndex = (selectedIndex + optionsCount - 1) % optionsCount;
			RebindValue();
			onValueChanged.Invoke(selectedIndex);
			Canvas.ForceUpdateCanvases();
		}
	}

	private void Update()
	{
		if (Input.mousePresent && cachedEventData != null)
		{
			MousePlace pointPlacement = GetPointPlacement(Input.mousePosition, cachedEventData.enterEventCamera);
			SetActiveArrow(pointPlacement);
		}
	}

	private void SetActiveArrow(MousePlace place)
	{
		if (place == MousePlace.None)
		{
			leftArrow.canvasRenderer.SetColor(new Color(1f, 1f, 1f, 0.5f));
			rightArrow.canvasRenderer.SetColor(new Color(1f, 1f, 1f, 0.5f));
		}
		else
		{
			if (place == currentArrow)
			{
				return;
			}
			leftArrow.CrossFadeAlpha((place != MousePlace.Left) ? 0.5f : 1f, 0.1f, true);
			rightArrow.CrossFadeAlpha((place != MousePlace.Right) ? 0.5f : 1f, 0.1f, true);
		}
		currentArrow = place;
	}

	public override void OnMove(AxisEventData eventData)
	{
		base.OnMove(eventData);
		if (eventData.moveDir == MoveDirection.Left)
		{
			PrevValue();
		}
		if (eventData.moveDir == MoveDirection.Right)
		{
			NextValue();
		}
	}
}
