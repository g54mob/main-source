using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class CoreButtonUnityGUI : Button, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IDragHandler
{
	public bool cursorUpdateLate;

	public bool useGlobalGUIActiveStatus = true;

	public CursorController.CursorType overCursor = CursorController.CursorType.CLICKABLE;

	public int cursorPriority;

	public UnityEvent onPointerEnterEvents;

	public UnityEvent onPointerExitEvents;

	public UnityEvent onPointerOverEvents;

	public string mouseDownSound = "button_down";

	private bool mouseOver;

	private CoreButton.OnClickDelegate onClickCallback;

	private object clickCallbackArg;

	private CoreButton.OnClickDelegateArg onClickCallbackArg;

	private bool needsReEnter;

	private bool previousInteractableState = true;

	private GUIManagerPens UIManagerRef;

	protected CursorController cursorRef;

	protected override void Awake()
	{
		base.Awake();
		previousInteractableState = base.interactable;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		if (registrationScript != null)
		{
			UIManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
			cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR, nullAllowed: true);
		}
	}

	protected override void Start()
	{
		base.Start();
		if (!(UIManagerRef != null) || !(cursorRef != null))
		{
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			if (registrationScript != null)
			{
				UIManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
				cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR, nullAllowed: true);
			}
		}
	}

	protected override void OnDisable()
	{
		mouseOver = false;
		base.OnPointerExit(null);
		base.OnDisable();
	}

	private void Update()
	{
		if (!cursorUpdateLate)
		{
			UpdateCursor();
		}
		if (UIManagerRef != null)
		{
			if (useGlobalGUIActiveStatus && base.interactable != UIManagerRef.GetGUIInteractiveStatus())
			{
				base.interactable = !base.interactable;
				if (base.interactable)
				{
					base.enabled = false;
					base.enabled = true;
				}
			}
			if (base.interactable != previousInteractableState)
			{
				previousInteractableState = base.interactable;
				if (!base.interactable)
				{
					needsReEnter = true;
				}
			}
		}
		if (base.interactable && mouseOver)
		{
			onPointerOverEvents.Invoke();
		}
	}

	private void LateUpdate()
	{
		if (cursorUpdateLate)
		{
			UpdateCursor();
		}
	}

	public void SetCallback(CoreButton.OnClickDelegate callback)
	{
		onClickCallback = callback;
	}

	public void SetArgCallback(CoreButton.OnClickDelegateArg callback, object arg)
	{
		clickCallbackArg = arg;
		onClickCallbackArg = callback;
	}

	public void SetCallbackArg(object arg)
	{
		clickCallbackArg = arg;
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		mouseOver = true;
		if (!base.interactable)
		{
			needsReEnter = true;
			return;
		}
		needsReEnter = false;
		base.OnPointerEnter(eventData);
		onPointerEnterEvents.Invoke();
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		mouseOver = false;
		needsReEnter = false;
		if (base.interactable)
		{
			base.OnPointerExit(eventData);
			onPointerExitEvents.Invoke();
		}
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
				cursorRef.SetCursor(CursorController.CursorType.CLICKING);
			}
			else
			{
				cursorRef.SetCursor(overCursor, force: false, cursorPriority);
			}
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
		}
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (!base.interactable)
		{
			return;
		}
		if (needsReEnter)
		{
			needsReEnter = false;
			return;
		}
		base.OnPointerClick(eventData);
		onClickCallback?.Invoke();
		onClickCallbackArg?.Invoke(clickCallbackArg);
		if (mouseDownSound.Length > 0)
		{
			AudioController.Play(mouseDownSound);
		}
	}
}
