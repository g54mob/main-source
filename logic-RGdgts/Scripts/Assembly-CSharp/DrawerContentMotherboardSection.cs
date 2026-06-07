using System.Collections.Generic;
using UnityEngine;

public class DrawerContentMotherboardSection : DrawerContent
{
	public MotherboardSectionEnum motherboardSectionId;

	protected Vector2 size;

	protected Vector2 pivot;

	private bool init;

	private Dictionary<Motherboard.Layer, MotherboardLayerRenderer> renderers;

	private PixelShape pixelShape;

	public GameObject interactableContainer;

	public Interactable interactable;

	private GadgetCoverMaterial _coverMaterial;

	public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
	{
	}

	public Bounds GetBounds()
	{
		return default(Bounds);
	}

	public virtual void SetSection(MotherboardSectionEnum motherboardSectionId)
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

	protected virtual bool IsMotherboardVisible()
	{
		return false;
	}

	protected void RefreshMotherboardVisibility()
	{
	}

	private void LateUpdate()
	{
	}

	public void SetCoverMaterial(GadgetCoverMaterial value)
	{
	}

	public void SetCoverInteractionMask(Mask mask)
	{
	}
}
