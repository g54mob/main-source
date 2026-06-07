using System;
using UnityEngine;

public class InteractableMotherboard : Interactable
{
	[NonSerialized]
	[HideInInspector]
	public Vector2 dragMouseOffest;

	private Vector2 _dragMouseOffest;

	[NonSerialized]
	[HideInInspector]
	public Motherboard.Position defaultPosition;

	private Motherboard motherboard;

	private bool movementEnabled;

	private Vector2 positionVel;

	public Vector2 outsidePoint;

	private float smoothStartTime;

	private bool isMouseHoverBoard;

	private float snapWeight;

	private float snapWeightVel;

	private Vector2 lastSnapPosition;

	private bool isSnapping;

	public bool clamp;

	private static Material _blitMotherboardCaseDataMaterial;

	private static Vector2[] uvsBuffer;

	public bool isOutside { get; private set; }

	private static Material blitMotherboardCaseDataMaterial => null;

	public void Setup(Motherboard motherboard)
	{
	}

	public override bool IsValidInteractionPosition(Vector2 position)
	{
		return false;
	}

	public override void OnInteractionDown()
	{
	}

	public override void OnInteractionUp()
	{
	}

	private bool IsMouseInside()
	{
		return false;
	}

	private bool IsMotherboardInside(Vector2 position, out Vector2 outsidePoint)
	{
		outsidePoint = default(Vector2);
		return false;
	}

	private Vector2 GetClampedMotherboardPosition(Vector2 position, out bool isOutside)
	{
		isOutside = default(bool);
		return default(Vector2);
	}

	public override void Update()
	{
	}

	private void _Update(bool interpolate = true)
	{
	}

	private bool CheckSnapping(Vector2 position, float threshold, out Vector2 snapPosition)
	{
		snapPosition = default(Vector2);
		return false;
	}

	public void EnableMovement()
	{
	}

	public void DisableMovement()
	{
	}

	public void RotateMotherboard()
	{
	}
}
