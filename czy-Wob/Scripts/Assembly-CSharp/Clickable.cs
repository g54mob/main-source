using System.Collections.Generic;
using InControl;
using UnityEngine;

public class Clickable : MonoBehaviour
{
	public enum CallbackTime
	{
		CLICK_START = 0,
		CLICK_END = 1
	}

	public enum InteractType
	{
		SCALE = 0,
		SLIDE = 1
	}

	public enum EaseTargets
	{
		SELF = 0,
		CHILDREN = 1
	}

	public delegate void UnloadCallback();

	public delegate void ClickCallback();

	public delegate void ClickCallbackIntArg(int a);

	public delegate void ClickCallbackUlongArg(ulong a);

	public delegate void ClickCallbackObjArg(GameObject obj);

	private enum ButtonState
	{
		OFF = 0,
		EASING = 1,
		OVER = 2,
		CLICKED = 3,
		UNLOADING = 4
	}

	private CallbackTime clickCallbackTime = CallbackTime.CLICK_END;

	private InteractType interactType;

	private EaseTargets easeTargets;

	private ButtonState neededState;

	private ButtonState currentState;

	private Segment currentEase;

	private ClickCallback clickCallback;

	private ClickCallbackIntArg clickCallbackInt;

	private ClickCallbackUlongArg clickCallbackUlong;

	private ClickCallbackObjArg clickCallbackObjArg;

	private UnloadCallback unloadCallback;

	private int intArg;

	private ulong ulongArg;

	private float hoverEaseOnTime = 0.05f;

	private float hoverEaseOffTime = 0.05f;

	private float clickEaseDownTime = 0.05f;

	private float clickEaseUpTime = 0.05f;

	private float clickFinishTime = 0.05f;

	private bool defaultScaleSet;

	private Vector3 defaultScale = Vector3.one;

	private Vector3 adjustedHoverOverScale;

	private Vector3 adjustedDownScale;

	private Vector3 adjustedUpScale;

	private Vector3 hoverOverScale = new Vector3(1.2f, 1.2f, 1.2f);

	private Vector3 clickScaleDown = new Vector3(0.8f, 0.8f, 0.8f);

	private Vector3 clickScaleUp = new Vector3(1.2f, 1.2f, 1.2f);

	private Vector3 hoverOverSlide = new Vector3(0f, 0.2f, 0f);

	private List<GameObject> targetRefs = new List<GameObject>();

	private Camera uiCameraRef;

	private Inchworm inchwormRef;

	private Collider2D colliderRef;

	private CursorController cursorRef;

	private void Awake()
	{
		colliderRef = GetComponentInChildren<Collider2D>();
		defaultScaleSet = true;
		defaultScale = base.transform.localScale;
		UpdateScales();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		uiCameraRef = registrationScript.GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		targetRefs.Add(base.gameObject);
	}

	private void Update()
	{
		if (IsColliding())
		{
			if (currentState == ButtonState.UNLOADING)
			{
				cursorRef.SetCursor(CursorController.CursorType.LOCKED_CLICKABLE);
			}
			else if (GameControls.actions.Interact.IsPressed)
			{
				cursorRef.SetCursor(CursorController.CursorType.CLICKING);
			}
			else
			{
				cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
			}
		}
		if (currentState == ButtonState.UNLOADING)
		{
			if (unloadCallback != null && currentEase == null)
			{
				FinishDelayedUnload();
			}
		}
		else
		{
			CheckStates();
			ResolveStates();
		}
	}

	public void SetDefaultScale(Vector3 scaleValue)
	{
		defaultScale = scaleValue;
		UpdateScales();
	}

	private void UpdateScales()
	{
		adjustedHoverOverScale = new Vector3(hoverOverScale.x * defaultScale.x, hoverOverScale.y * defaultScale.y, hoverOverScale.z * defaultScale.z);
		adjustedDownScale = new Vector3(clickScaleDown.x * defaultScale.x, clickScaleDown.y * defaultScale.y, clickScaleDown.z * defaultScale.z);
		adjustedUpScale = new Vector3(clickScaleUp.x * defaultScale.x, clickScaleUp.y * defaultScale.y, clickScaleUp.z * defaultScale.z);
	}

	public void SetCustomUpScale(Vector3 newUpScale)
	{
		hoverOverScale = newUpScale;
		clickScaleUp = newUpScale;
		UpdateScales();
	}

	public void SetColliderRef(Collider2D newRef)
	{
		colliderRef = newRef;
	}

	public void SetClickCallbacks(ClickCallback newCallback = null, ClickCallbackIntArg newCallbackInt = null, ClickCallbackUlongArg newCallbackUlong = null, ClickCallbackObjArg newCallbackObjArg = null, int intArg = -1, ulong? ulongArg = null)
	{
		clickCallback = newCallback;
		clickCallbackInt = newCallbackInt;
		clickCallbackUlong = newCallbackUlong;
		clickCallbackObjArg = newCallbackObjArg;
		this.intArg = intArg;
		if (ulongArg.HasValue)
		{
			this.ulongArg = ulongArg.Value;
		}
	}

	public void SetClickCallbackInt(int newIntArg)
	{
		intArg = newIntArg;
	}

	public void SetClickCallbackUlong(ulong newUlongArg)
	{
		ulongArg = newUlongArg;
	}

	public void SetClickCallbackTime(CallbackTime time)
	{
		clickCallbackTime = time;
	}

	public void SetInteractType(InteractType type)
	{
		interactType = type;
	}

	public void SetEaseTargets(EaseTargets targets)
	{
		if (targets == easeTargets)
		{
			return;
		}
		easeTargets = targets;
		targetRefs.Clear();
		if (easeTargets == EaseTargets.SELF)
		{
			targetRefs.Add(base.gameObject);
			return;
		}
		for (int i = 0; i < base.transform.childCount; i++)
		{
			targetRefs.Add(base.transform.GetChild(i).gameObject);
		}
	}

	public void ForceCancelEase()
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		neededState = ButtonState.OFF;
		currentState = ButtonState.OFF;
		if (defaultScaleSet)
		{
			base.transform.localScale = defaultScale;
		}
	}

	public void Unload()
	{
		ForceCancelEase();
		currentState = ButtonState.UNLOADING;
	}

	public void DelayedUnload(UnloadCallback callback)
	{
		unloadCallback = callback;
		currentState = ButtonState.UNLOADING;
		if (currentEase == null)
		{
			FinishDelayedUnload();
		}
	}

	private void FinishDelayedUnload()
	{
		unloadCallback();
		unloadCallback = null;
	}

	private void ResolveStates()
	{
		if (currentState == ButtonState.EASING)
		{
			if (neededState == ButtonState.CLICKED)
			{
				inchwormRef.CancelAndFinishEase(ref currentEase);
				currentEase = null;
				EnterClick();
			}
		}
		else if (currentState != neededState)
		{
			if (neededState == ButtonState.OVER)
			{
				EnterOver();
			}
			else if (neededState == ButtonState.OFF)
			{
				EnterOff();
			}
			else if (neededState == ButtonState.CLICKED)
			{
				EnterClick();
			}
		}
	}

	private void CheckStates()
	{
		if (IsColliding())
		{
			if (GameControls.actions.Interact.WasPressed)
			{
				neededState = ButtonState.CLICKED;
			}
			else
			{
				neededState = ButtonState.OVER;
			}
		}
		else
		{
			neededState = ButtonState.OFF;
		}
	}

	private bool IsColliding()
	{
		if (colliderRef != null)
		{
			return colliderRef.OverlapPoint(uiCameraRef.ScreenToWorldPoint(InputManager.MouseProvider.GetPosition()));
		}
		return false;
	}

	private void EnterOver()
	{
		if (interactType == InteractType.SCALE && easeTargets == EaseTargets.CHILDREN)
		{
			Debug.LogError("Do not currently support multiple scale targets.");
		}
		currentState = ButtonState.EASING;
		defaultScale = base.transform.localScale;
		if (interactType == InteractType.SCALE)
		{
			currentEase = inchwormRef.RequestEaseToScale(base.gameObject, adjustedHoverOverScale, hoverEaseOnTime, Inchworm.EaseStyle.QuadraticOut, OverCallback);
		}
		else if (interactType == InteractType.SLIDE)
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(targetRefs);
			currentEase = inchwormRef.RequestEase(list, hoverOverSlide, hoverEaseOnTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OverCallback, Inchworm.EasePriority.Normal, keepSameParent: true);
		}
	}

	private void EnterOff()
	{
		currentState = ButtonState.EASING;
		if (interactType == InteractType.SCALE)
		{
			currentEase = inchwormRef.RequestEaseToScale(base.gameObject, defaultScale, hoverEaseOffTime, Inchworm.EaseStyle.QuadraticOut, OffCallback);
		}
		else if (interactType == InteractType.SLIDE)
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(targetRefs);
			currentEase = inchwormRef.RequestEase(list, -hoverOverSlide, hoverEaseOffTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OffCallback, Inchworm.EasePriority.Normal, keepSameParent: true);
		}
	}

	private void EnterClick()
	{
		ButtonState buttonState = currentState;
		currentState = ButtonState.EASING;
		if (interactType == InteractType.SCALE)
		{
			currentEase = inchwormRef.RequestEaseToScale(base.gameObject, adjustedDownScale, clickEaseDownTime, Inchworm.EaseStyle.QuadraticOut, ClickCallback1);
		}
		else if (interactType == InteractType.SLIDE)
		{
			if (buttonState != ButtonState.OVER)
			{
				List<GameObject> list = new List<GameObject>();
				list.AddRange(targetRefs);
				currentEase = inchwormRef.RequestEase(list, hoverOverSlide, hoverEaseOffTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, FinalClickCallback, Inchworm.EasePriority.Normal, keepSameParent: true);
			}
			else
			{
				FinalClickCallback();
			}
		}
		if (clickCallbackTime == CallbackTime.CLICK_START)
		{
			CallCallbacks();
		}
	}

	private void ClickCallback1()
	{
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, adjustedUpScale, clickEaseUpTime, Inchworm.EaseStyle.QuadraticOut, ClickCallback2);
	}

	private void ClickCallback2()
	{
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, defaultScale, clickFinishTime, Inchworm.EaseStyle.QuadraticOut, FinalClickCallback);
	}

	private void FinalClickCallback()
	{
		currentEase = null;
		currentState = ButtonState.OFF;
		if (clickCallbackTime == CallbackTime.CLICK_END)
		{
			CallCallbacks();
		}
	}

	private void CallCallbacks()
	{
		if (clickCallback != null)
		{
			clickCallback();
		}
		if (clickCallbackInt != null)
		{
			clickCallbackInt(intArg);
		}
		if (clickCallbackUlong != null)
		{
			clickCallbackUlong(ulongArg);
		}
		if (clickCallbackObjArg != null)
		{
			clickCallbackObjArg(base.gameObject);
		}
	}

	private void OverCallback()
	{
		currentEase = null;
		currentState = ButtonState.OVER;
	}

	private void OffCallback()
	{
		currentEase = null;
		currentState = ButtonState.OFF;
	}
}
