using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Current")]
	public Color currentDefaultColor;

	public Color currentHoverColor;

	[Header("Child")]
	public Color childDefaultColor;

	public Color childHoverColor;

	private void Start()
	{
		SetColor(currentDefaultColor);
		SetColorChild(childDefaultColor);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		SetColor(currentHoverColor);
		SetColorChild(childHoverColor);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		SetColor(currentDefaultColor);
		SetColorChild(childDefaultColor);
	}

	public void SetColor(Color c)
	{
		GetComponent<Image>().color = c;
	}

	public void SetColorChild(Color c)
	{
		base.transform.GetChild(0).GetComponent<Text>().color = c;
	}
}
