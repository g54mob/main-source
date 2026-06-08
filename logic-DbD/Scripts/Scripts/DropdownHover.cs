using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownHover : Selectable
{
	[SerializeField]
	private TextMeshProUGUI resText;

	private static Color32 highlightedColor = new Color32(30, 144, byte.MaxValue, byte.MaxValue);

	protected override void OnEnable()
	{
		base.OnEnable();
		base.targetGraphic.color = Color.white;
		resText.color = Color.black;
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		base.targetGraphic.color = highlightedColor;
		resText.color = Color.white;
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		base.targetGraphic.color = Color.white;
		resText.color = Color.black;
	}
}
