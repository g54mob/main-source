using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorUpdateArea : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public CursorController.CursorType cursorUpdate;

	public bool updateDifferentlyOnMouseDown;

	public CursorController.CursorType cursorUpdateMouseDown;

	public int customPriority;

	private bool scrollingLocked;

	public bool blockCameraScrolling;

	public ScrollRect gamepadControlledScrollRect;

	private bool mouseOver;

	private int mouseOverContentFrame;

	private float scrollvelocity = 25f;

	private float standardDecelerationRate = 0.01f;

	private PenFocus focusRef;

	private CursorController cursorRef;

	private void Awake()
	{
		focusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		if (gamepadControlledScrollRect != null)
		{
			gamepadControlledScrollRect.decelerationRate = standardDecelerationRate;
		}
	}

	private void OnDestroy()
	{
		UnlockScrolling();
	}

	private void OnDisable()
	{
		UnlockScrolling();
	}

	private void Update()
	{
		if ((mouseOver || Time.frameCount - mouseOverContentFrame <= 1) && gamepadControlledScrollRect != null)
		{
			GameControls.CheckScrollValuesIfNeeded();
			if (GameControls.actions.GamepadCameraX.IsPressed || GameControls.actions.GamepadCameraY.IsPressed)
			{
				gamepadControlledScrollRect.velocity = new Vector2(GameControls.actions.GamepadCameraX.Value, GameControls.actions.GamepadCameraY.Value) * scrollvelocity * gamepadControlledScrollRect.scrollSensitivity;
			}
			else if (GameControls.actions.ScrollUIElementUp.IsPressed)
			{
				if (GameControls.isUIScrollUpScrollWheel && Input.mouseScrollDelta != Vector2.zero)
				{
					gamepadControlledScrollRect.velocity = Vector2.one * scrollvelocity * 0.0833f * gamepadControlledScrollRect.scrollSensitivity * GameControls.scrollDeltaMultiplier * GameControls.currentUIScrollMultiplier;
				}
				else
				{
					gamepadControlledScrollRect.velocity = Vector2.one * GameControls.actions.ScrollUIElementUp.Value * scrollvelocity * gamepadControlledScrollRect.scrollSensitivity;
				}
			}
			else if (GameControls.actions.ScrollUIElementDown.IsPressed)
			{
				if (GameControls.isUIScrollDownScrollWheel && Input.mouseScrollDelta != Vector2.zero)
				{
					gamepadControlledScrollRect.velocity = -Vector2.one * scrollvelocity * 0.0833f * gamepadControlledScrollRect.scrollSensitivity * GameControls.scrollDeltaMultiplier * GameControls.currentUIScrollMultiplier;
				}
				else
				{
					gamepadControlledScrollRect.velocity = -Vector2.one * GameControls.actions.ScrollUIElementDown.Value * scrollvelocity * gamepadControlledScrollRect.scrollSensitivity;
				}
			}
		}
		if (!mouseOver)
		{
			if (scrollingLocked && Time.frameCount - mouseOverContentFrame >= 10)
			{
				UnlockScrolling();
			}
		}
		else if (updateDifferentlyOnMouseDown && GameControls.actions.Interact.IsPressed)
		{
			cursorRef.SetCursor(cursorUpdateMouseDown, force: false, customPriority);
		}
		else
		{
			cursorRef.SetCursor(cursorUpdate, force: false, customPriority);
		}
	}

	public void ReportCursorOverContent()
	{
		if (blockCameraScrolling)
		{
			LockScrolling();
		}
		mouseOverContentFrame = Time.frameCount;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseOver = true;
		LockScrolling();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseOver = false;
		if (mouseOverContentFrame != Time.frameCount)
		{
			UnlockScrolling();
		}
	}

	private void LockScrolling()
	{
		if (!scrollingLocked && blockCameraScrolling)
		{
			scrollingLocked = true;
			focusRef.LockScrolling();
		}
	}

	private void UnlockScrolling()
	{
		if (scrollingLocked && blockCameraScrolling)
		{
			scrollingLocked = false;
			focusRef.UnlockScrolling();
		}
	}
}
