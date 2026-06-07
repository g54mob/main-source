using System;
using DG.Tweening;
using UnityEngine;

public class MotherboardPcb : MonoBehaviour
{
	public MotherboardLayerRenderer pcbLayerRenderer;

	private Gadget gadget;

	[NonSerialized]
	[HideInInspector]
	public Motherboard motherboard;

	private DraggablePanel panel;

	private InteractableHandle interactableHandle;

	private SpriteRenderer spriteRenderer;

	private SpriteShadow shadow;

	private Sequence flipTween;

	private BoxCollider2D flipCollider;

	private static Holder.TransitionDurations flipDuration;

	private static Holder.TransitionDurations yMovementDuration;

	private static float yMovementDistance;

	private bool init;

	private SpriteRenderer[] childRenderers;

	public PcbSide side { get; private set; }

	public bool IsMoving => false;

	private void Init()
	{
	}

	public void Setup(Gadget gadget, Motherboard motherboard)
	{
	}

	public void SetFlipPcbArea(Rect rect)
	{
	}

	public void RemoveFlipPcbArea()
	{
	}

	public void OnGadgetPositionChange(Motherboard.Position position)
	{
	}

	public void ShowSide(PcbSide side)
	{
	}

	private void _ShowSide(PcbSide side)
	{
	}

	private void _Refresh(float scale)
	{
	}

	public void Refresh()
	{
	}

	public void OnCaseOpen()
	{
	}

	public void OnCaseClose()
	{
	}

	private void LateUpdate()
	{
	}
}
