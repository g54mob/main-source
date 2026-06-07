using System;
using UnityEngine;

public class RegionStar : MonoBehaviour
{
	public LineRenderer line;

	public GameObject selectedIndicator;

	public GameObject overIndicator;

	[NonSerialized]
	public RegionNav.MapEntry mapEntry;

	private bool _selected;

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnMouseDown()
	{
	}

	public void OnPointerEnter()
	{
	}

	public void OnPointerExit()
	{
	}

	public void SetSize(float size)
	{
	}

	public void SetColor(Color color)
	{
	}

	public void SetPosition(Vector3 pos)
	{
	}

	private void SetColor(Color32 color, Mesh m)
	{
	}
}
