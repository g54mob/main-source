using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Image buttonImage;

	public TextMeshProUGUI text;

	public Color highlightedColor;

	public Color textHighligtedColor;

	private Color buttonDefaultColor;

	private Color textDefatultColor;

	private void Start()
	{
		buttonDefaultColor = buttonImage.color;
		textDefatultColor = text.color;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnHover();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		OnHoverCompleted();
	}

	public void OnHover()
	{
		buttonImage.color = highlightedColor;
		text.color = textHighligtedColor;
	}

	public void OnHoverCompleted()
	{
		buttonImage.color = buttonDefaultColor;
		text.color = textDefatultColor;
	}
}
