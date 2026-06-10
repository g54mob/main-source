using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColourSelectorButtonController : ButtonController, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	public delegate void ChangeColour();

	public RectTransform selector;

	public List<Button> colourButtons;

	public Color selectedColour;

	public event ChangeColour OnChangeColour
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public override void VisualUpdate()
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
	}
}
