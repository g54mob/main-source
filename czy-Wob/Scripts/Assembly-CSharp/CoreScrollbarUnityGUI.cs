using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class CoreScrollbarUnityGUI : Scrollbar, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool useGlobalGUIActiveStatus;

	public ScrollRect gamepadControlledScrollRect;

	private CursorController.CursorType overCursor = CursorController.CursorType.PETTABLE;

	private CursorController.CursorType downCursor = CursorController.CursorType.GRABBING2D;

	private bool mouseOver;

	private GUIManagerPens UIManagerRef;

	protected CursorController cursorRef;

	protected override void Awake()
	{
		base.Awake();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		if (registrationScript != null)
		{
			UIManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
			cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR, nullAllowed: true);
		}
		if (base.transform.parent != null)
		{
			gamepadControlledScrollRect = base.transform.parent.GetComponent<ScrollRect>();
		}
	}

	protected override void Update()
	{
		base.Update();
		UpdateCursor();
		if (!(UIManagerRef == null) && useGlobalGUIActiveStatus && base.interactable != UIManagerRef.GetGUIInteractiveStatus())
		{
			base.interactable = !base.interactable;
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		mouseOver = true;
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		mouseOver = false;
	}

	private void UpdateCursor()
	{
		if (!mouseOver || (useGlobalGUIActiveStatus && !UIManagerRef.GetGUIInteractiveStatus()))
		{
			return;
		}
		if (base.interactable)
		{
			if (GameControls.actions.Interact.IsPressed)
			{
				cursorRef.SetCursor(downCursor);
			}
			else
			{
				cursorRef.SetCursor(overCursor);
			}
			if (!(gamepadControlledScrollRect != null))
			{
				return;
			}
			GameControls.CheckScrollValuesIfNeeded();
			if (GameControls.actions.GamepadCameraX.IsPressed || GameControls.actions.GamepadCameraY.IsPressed)
			{
				gamepadControlledScrollRect.velocity = new Vector2(GameControls.actions.GamepadCameraX.Value, GameControls.actions.GamepadCameraY.Value) * 50f * gamepadControlledScrollRect.scrollSensitivity;
			}
			else if (GameControls.actions.ScrollUIElementUp.IsPressed)
			{
				if (GameControls.isUIScrollUpScrollWheel && Input.mouseScrollDelta != Vector2.zero)
				{
					gamepadControlledScrollRect.velocity = Vector2.one * 2.083f * gamepadControlledScrollRect.scrollSensitivity * GameControls.scrollDeltaMultiplier * GameControls.currentUIScrollMultiplier;
				}
				else
				{
					gamepadControlledScrollRect.velocity = Vector2.one * GameControls.actions.ScrollUIElementUp.Value * 25f * gamepadControlledScrollRect.scrollSensitivity;
				}
			}
			else if (GameControls.actions.ScrollUIElementDown.IsPressed)
			{
				if (GameControls.isUIScrollDownScrollWheel && Input.mouseScrollDelta != Vector2.zero)
				{
					gamepadControlledScrollRect.velocity = -Vector2.one * 2.083f * gamepadControlledScrollRect.scrollSensitivity * GameControls.scrollDeltaMultiplier * GameControls.currentUIScrollMultiplier;
				}
				else
				{
					gamepadControlledScrollRect.velocity = -Vector2.one * GameControls.actions.ScrollUIElementDown.Value * 25f * gamepadControlledScrollRect.scrollSensitivity;
				}
			}
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
		}
	}
}
