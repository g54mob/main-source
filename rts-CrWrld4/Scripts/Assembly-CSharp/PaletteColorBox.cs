using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaletteColorBox : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler
{
	public Image image;

	public GameObject hilight;

	[NonSerialized]
	public PaletteColorBoxContainer paletteContainer;

	[NonSerialized]
	public int paletteIndex;

	private int hilightCount;

	public void Init(int paletteIndex)
	{
	}

	public void Update()
	{
	}

	public void Hilight()
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}
}
