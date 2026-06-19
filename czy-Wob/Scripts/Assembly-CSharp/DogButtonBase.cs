using UnityEngine;
using UnityEngine.Events;

public class DogButtonBase : MonoBehaviour
{
	public bool hideForDemo;

	public bool disableForDemo;

	public bool disableOnClick;

	public bool useGlobalGUIActiveStatus = true;

	public bool cursorUpdateLate;

	private CursorController.CursorType neededCursorType;

	protected Vector3 defaultScale;

	protected Vector3 defaultPosition;

	public float overScaleAddition = 0.1f;

	public Vector3 overPositionUpdate = Vector3.zero;

	public CursorController.CursorType overCursor = CursorController.CursorType.CLICKABLE;

	public CursorController.CursorType lockedCursor = CursorController.CursorType.LOCKED_CLICKABLE;

	public UnityEvent onPointerEnterEvents;

	public UnityEvent onPointerExitEvents;

	public UnityEvent onPointerOverEvents;

	public string mouseDownSound = "button_down";

	private bool mouseOver;

	protected bool isLarge;

	protected bool scaleLocked;

	protected bool globalGUIStatus = true;

	protected bool completeDisable;

	protected bool disabledFromInteraction;

	protected InchwormBounce bounce;

	protected DogHome homeRef;

	private GUIManagerPens UIManagerRef;

	protected CursorController cursorRef;

	private void Start()
	{
		if (hideForDemo)
		{
			base.gameObject.SetActive(value: false);
		}
		defaultScale = base.transform.parent.localScale;
		defaultPosition = base.transform.parent.localPosition;
		SetReferences();
		bounce = GetComponent<InchwormBounce>();
		if (bounce != null)
		{
			bounce.RegisterBounceStartEvent(LockScale);
			bounce.RegisterBounceEndEvent(UnlockScale);
		}
		OnStart();
	}

	public void UpdateDefaultScale(Vector3 newScale)
	{
		defaultScale = newScale;
	}

	private void Update()
	{
		UpdateBehavior();
	}

	private void OnDisable()
	{
		mouseOver = false;
	}

	private void LateUpdate()
	{
		if (cursorUpdateLate && neededCursorType != CursorController.CursorType.DEFAULT)
		{
			cursorRef.SetCursor(neededCursorType);
			neededCursorType = CursorController.CursorType.DEFAULT;
		}
	}

	protected virtual void UpdateBehavior()
	{
		if (UIManagerRef != null && useGlobalGUIActiveStatus)
		{
			if (isLarge && !UIManagerRef.GetGUIInteractiveStatus())
			{
				ClearScale();
			}
			if (globalGUIStatus != UIManagerRef.GetGUIInteractiveStatus())
			{
				globalGUIStatus = !globalGUIStatus;
			}
		}
		if (onPointerOverEvents.GetPersistentEventCount() != 0 && IsInteractable() && mouseOver)
		{
			onPointerOverEvents.Invoke();
		}
	}

	public void HardDisable()
	{
		OnMouseExitBehavior();
		completeDisable = true;
	}

	public void ClearHardDisable()
	{
		completeDisable = false;
	}

	private void SetReferences()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
		UIManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR, nullAllowed: true);
	}

	public void LockScale()
	{
		if (bounce != null)
		{
			OnMouseDownBehavior();
		}
		OnMouseExit();
		OnMouseExitBehavior();
		scaleLocked = true;
	}

	public void UnlockScale()
	{
		scaleLocked = false;
		OnMouseExit();
	}

	public void OnMouseEnter()
	{
		if (!completeDisable)
		{
			OnMouseEnterBehavior();
		}
	}

	protected virtual void OnMouseEnterBehavior()
	{
		mouseOver = true;
		onPointerEnterEvents.Invoke();
	}

	public void OnMouseOver()
	{
		if (!completeDisable)
		{
			SetCursorToClickable();
			if (!isLarge && IsInteractable())
			{
				OnMouseOverBehavior();
			}
		}
	}

	protected virtual void OnMouseOverBehavior()
	{
		if (!completeDisable)
		{
			mouseOver = true;
			isLarge = true;
			defaultScale = base.transform.parent.localScale;
			base.transform.parent.localScale = defaultScale + defaultScale * overScaleAddition;
			defaultPosition = base.transform.parent.localPosition;
			base.transform.parent.localPosition = defaultPosition + overPositionUpdate;
		}
	}

	private void SetCursorToClickable()
	{
		if (completeDisable || (useGlobalGUIActiveStatus && !globalGUIStatus))
		{
			return;
		}
		if (cursorRef == null)
		{
			SetReferences();
			if (cursorRef == null)
			{
				return;
			}
		}
		if (IsInteractable())
		{
			if (GameControls.actions.Interact.IsPressed)
			{
				neededCursorType = CursorController.CursorType.CLICKING;
				cursorRef.SetCursor(neededCursorType);
			}
			else
			{
				neededCursorType = overCursor;
				cursorRef.SetCursor(neededCursorType);
			}
		}
		else
		{
			neededCursorType = lockedCursor;
			cursorRef.SetCursor(neededCursorType);
		}
	}

	public void OnMouseExit()
	{
		mouseOver = false;
		if (!completeDisable && isLarge && IsInteractable())
		{
			OnMouseExitBehavior();
		}
	}

	protected virtual void OnMouseExitBehavior()
	{
		if (isLarge)
		{
			ClearScale();
			onPointerExitEvents.Invoke();
		}
	}

	private void ClearScale()
	{
		isLarge = false;
		base.transform.parent.localScale = defaultScale;
		base.transform.parent.localPosition = defaultPosition;
	}

	public void OnMouseDown()
	{
		if (!completeDisable && !(bounce != null))
		{
			OnMouseDownBehavior();
		}
	}

	private void OnMouseUp()
	{
		if (!completeDisable)
		{
			SetCursorToClickable();
		}
	}

	private bool IsInteractable()
	{
		if (disableForDemo && CheatEngine.cheatRef != null && CheatEngine.cheatRef.demoMode)
		{
			return false;
		}
		if (disabledFromInteraction)
		{
			return false;
		}
		if (scaleLocked || !globalGUIStatus)
		{
			return false;
		}
		if (completeDisable)
		{
			return false;
		}
		return true;
	}

	private void OnMouseDownBehavior()
	{
		if (IsInteractable())
		{
			neededCursorType = CursorController.CursorType.CLICKING;
			cursorRef.SetCursor(neededCursorType);
			if (bounce == null)
			{
				LockScale();
				UnlockScale();
			}
			ButtonBehavior();
			if (disableOnClick)
			{
				disabledFromInteraction = true;
			}
			if (mouseDownSound.Length > 0)
			{
				AudioController.Play(mouseDownSound);
			}
		}
	}

	protected virtual void OnStart()
	{
	}

	protected virtual void ButtonBehavior()
	{
		Debug.LogError("ButtonBehavior not overridden.");
	}
}
