using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomUIButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public Color normalColor = Color.white;

	public Color hoverColor = Color.gray;

	public Color selectedColor = Color.green;

	public bool firstSelected;

	private Image image;

	private bool isSelected;

	private static CustomUIButton currentSelected;

	private void Awake()
	{
		image = GetComponent<Image>();
		image.color = normalColor;
		if (firstSelected)
		{
			Select();
			currentSelected = this;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!isSelected)
		{
			image.color = hoverColor;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!isSelected)
		{
			image.color = normalColor;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (currentSelected != null && currentSelected != this)
		{
			currentSelected.Deselect();
		}
		Select();
		currentSelected = this;
	}

	public void WhenOpenSettingUI()
	{
		if (currentSelected != null && currentSelected != this)
		{
			currentSelected.Deselect();
		}
		Select();
		currentSelected = this;
	}

	private void Select()
	{
		isSelected = true;
		image.color = selectedColor;
	}

	private void Deselect()
	{
		isSelected = false;
		image.color = normalColor;
	}
}
