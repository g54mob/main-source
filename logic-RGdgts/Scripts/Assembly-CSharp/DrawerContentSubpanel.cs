using System.Collections.Generic;
using Fix;
using UnityEngine;
using UnityEngine.Rendering;

public class DrawerContentSubpanel : DrawerContent
{
	public SortingGroup sortingGroup;

	public SpriteMask panelMask;

	public Transform content;

	public List<DrawerContent> contents;

	private Vector2 size;

	private float extraHeight;

	private float _collapsedI;

	public float collapsedI
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
	{
	}

	public void SetSize(float width, float height, float extraHeight)
	{
	}

	public override float GetSize(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMin(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMax(DraggablePanel.Direction direction)
	{
		return 0f;
	}
}
