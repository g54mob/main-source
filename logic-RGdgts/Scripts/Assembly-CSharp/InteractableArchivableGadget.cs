using System;
using DG.Tweening;
using UnityEngine;

public class InteractableArchivableGadget : Interactable
{
	public Holder.TransitionDurations transitionDuration;

	public Ease ease;

	[HideInInspector]
	public Gadget gadget;

	[NonSerialized]
	[HideInInspector]
	public Sequence tween;

	private float position;

	private float interactionStartTime;

	private float interactionOffset;

	private Vector2 interactionMousePosition;

	private bool invalidateClick;

	private bool isOnWorkbench;

	private Vector2 moveToSlotVel;

	private bool snapToArchivePhase;

	private Vector3 archivePosition;

	private DraggablePanel.Direction direction;

	private PrintedGadgetCard printedGadgetCard;

	private ArchiveDrawerBehaviour archiveDrawer;

	public bool isMoving => false;

	private void Start()
	{
	}

	public override bool InteractionEnabled()
	{
		return false;
	}

	public override void OnInteractionDown()
	{
	}

	private float GetLength()
	{
		return 0f;
	}

	private bool CheckThreshold()
	{
		return false;
	}

	public override void OnInteractionUp()
	{
	}

	public override void Update()
	{
	}

	public void Toggle()
	{
	}

	private void RefreshPosition()
	{
	}

	public void GoToWorkbench()
	{
	}

	public void GoToArchive()
	{
	}

	private void OnDestroy()
	{
	}

	public void EnableScreenshootMode()
	{
	}

	public void DisableScreenshootMode()
	{
	}

	public void OnPositionChange(Motherboard.Position position, bool immediate)
	{
	}
}
