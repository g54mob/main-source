using System;
using System.Collections.Generic;
using UnityEngine;

public class PaletteColorBoxContainer : MonoBehaviour
{
	public GameObject paletteColorBoxPrefab;

	[NonSerialized]
	public Color32[] palette;

	private List<int> paletteOrder;

	private List<PaletteColorBox> boxes;

	private int BOX_WIDTH;

	public void InitPalette(Color32[] palette)
	{
	}

	public void SetDefaultPaletteOrder()
	{
	}

	public void SetBrightPaletteOrder()
	{
	}

	private int GetDimmestColorFromPaletteList(List<int> indices)
	{
		return 0;
	}

	private float GetColorBrightness(Color32 c)
	{
		return 0f;
	}

	public void OnDroppedPCB(PaletteColorBox pcb)
	{
	}

	private void PositionBoxes()
	{
	}

	public int GetPaletteOrderIndex(int paletteIndex)
	{
		return 0;
	}

	public void HilightColorBox(int i)
	{
	}

	public int GetPaletteIndexForColor(Color32 color)
	{
		return 0;
	}

	public int GetPaletteOrder(int index)
	{
		return 0;
	}

	public static bool ColorsEqual(Color32 x, Color32 y)
	{
		return false;
	}
}
