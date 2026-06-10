using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableDestination : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public delegate void DragDestination(GameObject dragObj, string tag);

	public bool isOver;

	public Button but;

	public List<string> acceptedTags;

	private Image graphic;

	public Color originalColour;

	public bool useHoverColours;

	public Color hoverAcceptColour;

	public event DragDestination OnDragged
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

	private void Awake()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}
}
