using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : Controller
{
	public struct RaycastResult
	{
		public Interactable interactable;

		public MultitoolCanvas canvas;

		public RaycastResult(Interactable interactable)
		{
			this.interactable = null;
			canvas = null;
		}

		public RaycastResult(MultitoolCanvas canvas)
		{
			interactable = null;
			this.canvas = null;
		}
	}

	public CursorGestaltEnum defaultCursor;

	private CursorGestaltEnum currentCursor;

	public Interactable hoveredInteractable;

	public static int interactablesMask;

	[NonSerialized]
	[HideInInspector]
	public bool cursorIsVisible;

	[NonSerialized]
	[HideInInspector]
	public bool forceSystemCursor;

	private int cursorFrameI;

	private Texture2D[] cursorTextures;

	private float lastCursorFrameTime;

	private CursorGestaltEnum preInteractionCursor;

	private Interactable interacting;

	private bool isActive;

	public CursorGestaltEnum actualCursor => default(CursorGestaltEnum);

	[HideInInspector]
	public CursorGestaltEnum overrideCursor { get; private set; }

	public void Disable()
	{
	}

	public void Enable()
	{
	}

	public override void Init()
	{
	}

	public void ResetOverrideCursor()
	{
	}

	public void SetCursor(CursorGestaltEnum cursor, bool isOverride = false)
	{
	}

	private List<Interactable> GetInteractablesOnObject(GameObject obj)
	{
		return null;
	}

	public RaycastResult? Raycast(out bool foundSomething, bool overrideValidPositionCheck = false)
	{
		foundSomething = default(bool);
		return null;
	}

	public void StopInteraction()
	{
	}

	public void StartInteraction(Interactable interactable)
	{
	}

	private void Update()
	{
	}

	private void UpdateInteractions()
	{
	}

	private void UpdateCursor()
	{
	}

	public (Texture2D, Vector2)? GetCursorInfo()
	{
		return null;
	}
}
