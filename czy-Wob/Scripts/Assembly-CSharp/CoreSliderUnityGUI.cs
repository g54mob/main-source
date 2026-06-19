using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class CoreSliderUnityGUI : Slider, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler
{
	public bool useGlobalGUIActiveStatus;

	public UnityEvent BeginDragHandler;

	public UnityEvent EndDragHandler;

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

	public void OnBeginDrag(PointerEventData eventData)
	{
		BeginDragHandler.Invoke();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		EndDragHandler.Invoke();
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
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
		}
	}
}
