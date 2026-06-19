using System.Collections.Generic;
using Cinemachine;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
	public enum CursorType
	{
		DEFAULT = 0,
		GRABBABLE = 1,
		GRABBING = 2,
		CLICKABLE = 3,
		LOCKED_CLICKABLE = 4,
		CLICKING = 5,
		PETTABLE = 6,
		PETTING = 7,
		GRABBING2D = 8,
		CAMERA_DRAG = 9,
		CAMERA_ROTATE = 10,
		CAMERA_DRAG_LOCKED = 11,
		TEXT_INPUT = 12,
		BLOWDRY = 13,
		SEEKING_PETTABLE = 14
	}

	public Texture2D defaultCursor;

	public Sprite defaultCursorSprite;

	public Texture2D pettableCursor;

	public Sprite pettableCursorSprite;

	public Texture2D seekingPettableCursor;

	public Sprite seekingPettableCursorSprite;

	public Texture2D clickableCursor;

	public Sprite clickableCursorSprite;

	public Texture2D clickableLockedCursor;

	public Sprite clickableLockedCursorSprite;

	public Texture2D grabbingCursor;

	public Sprite grabbingCursorSprite;

	public Texture2D grabbableCursor;

	public Sprite grabbableCursorSprite;

	public Texture2D cameraDragCursor;

	public Sprite cameraDragCursorSprite;

	public Texture2D cameraRotateCursor;

	public Sprite cameraRotateCursorSprite;

	public Texture2D cameraDragLockedCursor;

	public Sprite cameraDragLockedCursorSprite;

	public Texture2D blowDryCursor;

	public Sprite blowDryCursorSprite;

	public Texture2D textInputCursor;

	public Sprite textInputCursorSprite;

	public AnimationCurve stickSensitivityCurve;

	public GameObject fakeGrabbingCursorPrefab;

	private GameObject instantiatedFakeCursor;

	private Image fakeCursorImage;

	private int lastRequestFrame = -1;

	private int continuousDefaultRequests;

	private int requiredContinuousDefaultRequests = 2;

	private int lastDefaultRequestFrame = -1;

	private int lastPriority;

	private bool invisibleFromTransition;

	private CursorType currentCursor;

	private Vector2 defaultCursorHotspot = new Vector2(16f, 16f);

	private Vector2 clickableCursorHotspot = new Vector2(16f, 8f);

	private float virtualCursorPettingDampen = 0.35f;

	private float defaultVirtualCursorMovementSpeed = 20f;

	private float defaultVirtualCursorCameraSpeedModifier = 0.5f;

	private float virtualCursorPettingCursorSpeedMultiplier = 200f;

	private float gamepadSensitivity = 1f;

	private float gamepadSensitivityLow = 0.25f;

	private float gamepadSensitivityHigh = 2f;

	private float scrollSensitivity = 1f;

	private float scrollSensitivityLow = 0.25f;

	private float scrollSensitivityHigh = 2f;

	private float UIScrollSensitivity = 1f;

	private float UIScrollSensitivityLow = 0.25f;

	private float UIScrollSensitivityHigh = 2f;

	private Vector3 lastMousePosition = Vector3.zero;

	private GameObject lastTopLevelUIObject;

	private GameObject lastDownElement;

	private GameObject overrideUIElement;

	private bool systemMouseActive = true;

	private bool cursorShouldBeVisible = true;

	private bool passiveModeCursorEnabled = true;

	private float currentPassiveModeNoInputTimer;

	private float passiveModeNoInputMouseHideTimer = 5f;

	private bool contextMenuOpen;

	private ObjectIndicatorPens indicatorRef;

	private VirtualMouseProvider virtualMouseProvider;

	private IMouseProvider defaultUnityMouseProvider;

	private GUIManagerPens guiRef;

	private SceneManagerBase sceneRef;

	private ObjectRegistration regRef;

	private SceneTransition transitionRef;

	private DogPettingController pettingRef;

	private void Awake()
	{
		CreateFakeCursor();
		SetCursor(CursorType.DEFAULT, force: true);
		Cursor.SetCursor(GetTextureForCursorType(CursorType.DEFAULT), GetHotspotForCursorType(CursorType.DEFAULT), CursorMode.Auto);
		virtualMouseProvider = new VirtualMouseProvider();
		virtualMouseProvider.CustomSetup(this);
		defaultUnityMouseProvider = InputManager.MouseProvider;
		CinemachineCore.GetInputAxis = GetAxisCustom;
		SetSystemMouseActive();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void SetGamepadSensitivity(float newSens)
	{
		newSens = Mathf.Clamp(newSens, 0f, 1f);
		if (newSens < 0.5f)
		{
			gamepadSensitivity = MathUtil.GetValueOfRangePercentage(newSens / 0.5f, gamepadSensitivityLow, 1f);
		}
		else if (newSens > 0.5f)
		{
			gamepadSensitivity = MathUtil.GetValueOfRangePercentage((newSens - 0.5f) / 0.5f, 1f, gamepadSensitivityHigh);
		}
		else
		{
			gamepadSensitivity = 1f;
		}
	}

	public void SetScrollSensitivity(float newSens)
	{
		newSens = Mathf.Clamp(newSens, 0f, 1f);
		if (newSens < 0.5f)
		{
			scrollSensitivity = MathUtil.GetValueOfRangePercentage(newSens / 0.5f, scrollSensitivityLow, 1f);
		}
		else if (newSens > 0.5f)
		{
			scrollSensitivity = MathUtil.GetValueOfRangePercentage((newSens - 0.5f) / 0.5f, 1f, scrollSensitivityHigh);
		}
		else
		{
			scrollSensitivity = 1f;
		}
		GameControls.currentScrollMultiplier = scrollSensitivity;
	}

	public void SetUIScrollSensitivity(float newSens)
	{
		newSens = Mathf.Clamp(newSens, 0f, 1f);
		if (newSens < 0.5f)
		{
			UIScrollSensitivity = MathUtil.GetValueOfRangePercentage(newSens / 0.5f, UIScrollSensitivityLow, 1f);
		}
		else if (newSens > 0.5f)
		{
			UIScrollSensitivity = MathUtil.GetValueOfRangePercentage((newSens - 0.5f) / 0.5f, 1f, UIScrollSensitivityHigh);
		}
		else
		{
			UIScrollSensitivity = 1f;
		}
		GameControls.currentUIScrollMultiplier = UIScrollSensitivity;
	}

	public float GetAxisCustom(string axisName)
	{
		if (systemMouseActive)
		{
			return Input.GetAxis(axisName);
		}
		if (axisName == "Mouse X")
		{
			return GameControls.actions.GamepadCameraX.Value * defaultVirtualCursorCameraSpeedModifier;
		}
		if (axisName == "Mouse Y")
		{
			return GameControls.actions.GamepadCameraY.Value * defaultVirtualCursorCameraSpeedModifier;
		}
		return 0f;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (instantiatedFakeCursor == null)
		{
			CreateFakeCursor();
		}
		if (systemMouseActive)
		{
			SetSystemMouseActive();
		}
		else
		{
			SetSystemMouseInactive();
		}
	}

	private void CreateFakeCursor()
	{
		if (instantiatedFakeCursor != null)
		{
			Object.Destroy(instantiatedFakeCursor);
		}
		instantiatedFakeCursor = Object.Instantiate(fakeGrabbingCursorPrefab);
		fakeCursorImage = instantiatedFakeCursor.GetComponentInChildren<Image>();
	}

	private void Update()
	{
		CheckCursorSwap();
		UpdateFakeCursor();
		SetCursor(CursorType.DEFAULT);
		CheckCursorHide();
		UpdateCursorEvents();
	}

	private void LateUpdate()
	{
		if (Cursor.visible)
		{
			Cursor.SetCursor(GetTextureForCursorType(currentCursor), GetHotspotForCursorType(currentCursor), CursorMode.Auto);
		}
	}

	public Vector2 GetVirtualMousePosition()
	{
		if (fakeCursorImage != null)
		{
			return GetScreenPosFromCanvasPos(fakeCursorImage.transform.localPosition);
		}
		return Input.mousePosition;
	}

	public CursorType GetCurrentCursor()
	{
		return currentCursor;
	}

	private void CheckCursorHide()
	{
		if (GameSettings.IsPassiveModeEnabled() && sceneRef.GetGameMode() == GameMode.HOME)
		{
			bool flag = false;
			if ((bool)InputManager.ActiveDevice.LeftStick || (bool)InputManager.ActiveDevice.RightStick || (bool)InputManager.ActiveDevice.AnyButton || Input.anyKey || InputManager.MouseProvider.GetDeltaScroll() != 0f || InputManager.MouseProvider.GetDeltaX() != 0f || InputManager.MouseProvider.GetDeltaY() != 0f)
			{
				flag = true;
			}
			if (flag)
			{
				if (!passiveModeCursorEnabled)
				{
					passiveModeCursorEnabled = true;
					if (cursorShouldBeVisible)
					{
						fakeCursorImage.enabled = true;
						if (systemMouseActive)
						{
							Cursor.visible = true;
						}
					}
				}
				currentPassiveModeNoInputTimer = 0f;
			}
			else if (passiveModeCursorEnabled)
			{
				currentPassiveModeNoInputTimer += Time.deltaTime;
				if (currentPassiveModeNoInputTimer >= passiveModeNoInputMouseHideTimer)
				{
					passiveModeCursorEnabled = false;
				}
			}
			if (passiveModeCursorEnabled)
			{
				return;
			}
			passiveModeCursorEnabled = false;
			if (GameSettings.PassiveModeAutoHideCursor())
			{
				fakeCursorImage.enabled = false;
				if (systemMouseActive)
				{
					Cursor.visible = false;
				}
			}
		}
		else if (!passiveModeCursorEnabled)
		{
			passiveModeCursorEnabled = true;
		}
	}

	public bool IsPassiveModeCursorEnabled()
	{
		return passiveModeCursorEnabled;
	}

	public void CheckCursorSwap()
	{
		if (passiveModeCursorEnabled || !GameSettings.PassiveModeAutoHideCursor())
		{
			if (((bool)InputManager.ActiveDevice.LeftStick || (bool)InputManager.ActiveDevice.RightStick || (bool)InputManager.ActiveDevice.AnyButton) && systemMouseActive)
			{
				SetSystemMouseInactive();
			}
			else if (Input.mousePosition != lastMousePosition && !systemMouseActive)
			{
				SetSystemMouseActive();
			}
			lastMousePosition = Input.mousePosition;
		}
	}

	public void SetSystemMouseActive()
	{
		systemMouseActive = true;
		OnSystemMouseStatusChanged();
		if (instantiatedFakeCursor != null)
		{
			instantiatedFakeCursor.SetActive(value: false);
		}
		Cursor.SetCursor(GetTextureForCursorType(currentCursor), GetHotspotForCursorType(currentCursor), CursorMode.Auto);
		if (cursorShouldBeVisible)
		{
			Cursor.visible = true;
		}
		else
		{
			Cursor.visible = false;
		}
		OnMouseProviderSwitched();
		if (defaultUnityMouseProvider != null)
		{
			InputManager.MouseProvider = defaultUnityMouseProvider;
		}
	}

	public void SetSystemMouseInactive()
	{
		if (defaultUnityMouseProvider == null)
		{
			defaultUnityMouseProvider = InputManager.MouseProvider;
			if (defaultUnityMouseProvider == null)
			{
				return;
			}
		}
		OnMouseProviderSwitched();
		systemMouseActive = false;
		OnSystemMouseStatusChanged();
		if (instantiatedFakeCursor != null)
		{
			instantiatedFakeCursor.SetActive(value: true);
		}
		InputManager.MouseProvider = virtualMouseProvider;
	}

	public void TeleportVirtualCursor(Vector3 cursorPos)
	{
		if (!systemMouseActive)
		{
			fakeCursorImage.transform.position = ClampPositionToScreen(cursorPos);
		}
	}

	public float GetVirtualPettingCursorSpeedMultiplier()
	{
		return virtualCursorPettingCursorSpeedMultiplier;
	}

	public float GetVirtualPettingCursorDampen()
	{
		return virtualCursorPettingDampen;
	}

	private void OnMouseProviderSwitched()
	{
		if (EventSystem.current == null)
		{
			return;
		}
		if (EventSystem.current.IsPointerOverGameObject())
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = InputManager.MouseProvider.GetPosition();
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			for (int i = 0; i < list.Count; i++)
			{
				ExecuteEvents.Execute(list[i].gameObject, pointerEventData, ExecuteEvents.pointerExitHandler);
			}
		}
		if (overrideUIElement != null)
		{
			PointerEventData pointerEventData2 = new PointerEventData(EventSystem.current);
			pointerEventData2.position = InputManager.MouseProvider.GetPosition();
			ExecuteEvents.Execute(overrideUIElement, pointerEventData2, ExecuteEvents.pointerExitHandler);
		}
		ClearOverrideUIElement();
		lastTopLevelUIObject = null;
		SetCursor(CursorType.DEFAULT, force: true);
	}

	private void OnSystemMouseStatusChanged()
	{
		if (regRef != null && guiRef == null)
		{
			guiRef = regRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		}
		if (guiRef != null)
		{
			guiRef.UpdateControlVisuals();
		}
	}

	public bool IsSystemMouseActive()
	{
		return systemMouseActive;
	}

	public void ReportContextMenuOpen(ObjectIndicatorPens newIndicatorRef)
	{
		contextMenuOpen = true;
		indicatorRef = newIndicatorRef;
		if (!(instantiatedFakeCursor == null) && !systemMouseActive)
		{
			Vector3 position = indicatorRef.menuCenter.transform.position;
			fakeCursorImage.transform.position = ClampPositionToScreen(position);
		}
	}

	public void ReportContextMenuClosed()
	{
		indicatorRef = null;
		contextMenuOpen = false;
		ClearOverrideUIElement();
	}

	private void UpdateFakeCursor()
	{
		if (instantiatedFakeCursor == null || systemMouseActive || (!passiveModeCursorEnabled && GameSettings.PassiveModeAutoHideCursor()))
		{
			return;
		}
		Cursor.visible = false;
		float num = stickSensitivityCurve.Evaluate(Mathf.Abs(GameControls.actions.GamepadCursorX.Value));
		float num2 = stickSensitivityCurve.Evaluate(Mathf.Abs(GameControls.actions.GamepadCursorY.Value));
		if (GameControls.actions.GamepadCursorX.Value < 0f)
		{
			num *= -1f;
		}
		if (GameControls.actions.GamepadCursorY.Value < 0f)
		{
			num2 *= -1f;
		}
		Vector3 vector = new Vector3(num, num2, 0f);
		float num3 = 1f;
		if (pettingRef != null && pettingRef.HasPettingTarget())
		{
			num3 = virtualCursorPettingDampen;
		}
		float num4 = Time.unscaledDeltaTime * 60f;
		Vector3 vector2 = fakeCursorImage.transform.position + defaultVirtualCursorMovementSpeed * vector * num3 * gamepadSensitivity * num4;
		if (contextMenuOpen && indicatorRef != null)
		{
			Vector3 position = indicatorRef.menuCenter.transform.position;
			float adjustedContextMenuRadius = indicatorRef.GetAdjustedContextMenuRadius();
			float num5 = Vector3.Distance(vector2, position);
			if (num5 > adjustedContextMenuRadius)
			{
				Vector3 vector3 = vector2 - position;
				vector3 *= adjustedContextMenuRadius / num5;
				vector2 = position + vector3;
			}
		}
		fakeCursorImage.transform.position = ClampPositionToScreen(vector2);
	}

	private Vector3 ClampPositionToScreen(Vector3 newPosition)
	{
		Resolution realHalfResolution = GetRealHalfResolution();
		newPosition = new Vector3(Mathf.Clamp(newPosition.x, 0f, (float)realHalfResolution.width * 2f), Mathf.Clamp(newPosition.y, 0f, (float)realHalfResolution.height * 2f), 0f);
		return newPosition;
	}

	public void SetOverrideUIElement(GameObject newObj)
	{
		overrideUIElement = newObj;
	}

	public void ClearOverrideUIElement()
	{
		overrideUIElement = null;
	}

	public bool HasOverrideUIElement()
	{
		return overrideUIElement != null;
	}

	private void UpdateCursorEvents()
	{
		if (!passiveModeCursorEnabled && GameSettings.PassiveModeAutoHideCursor())
		{
			return;
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = InputManager.MouseProvider.GetPosition();
		GameObject gameObject = null;
		if (overrideUIElement != null)
		{
			gameObject = overrideUIElement;
		}
		else
		{
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			RaycastResult raycastResult = RaycastUtil.ReturnClosestRaycastResult(list);
			if (raycastResult.gameObject != null)
			{
				gameObject = RaycastUtil.GivenUIRaycastHitReturnUIElementGameObject(raycastResult.gameObject);
			}
		}
		if (gameObject != null)
		{
			if (GameControls.actions.Interact.WasPressed)
			{
				if (lastDownElement != gameObject)
				{
					lastDownElement = gameObject;
					ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.beginDragHandler);
				}
			}
			else if (GameControls.actions.Interact.IsPressed)
			{
				if (lastDownElement == gameObject)
				{
					ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.dragHandler);
				}
			}
			else if (GameControls.actions.Interact.WasReleased)
			{
				if (lastDownElement == gameObject)
				{
					ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.endDragHandler);
					ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
				}
				else
				{
					ExecuteEvents.Execute(lastDownElement, pointerEventData, ExecuteEvents.endDragHandler);
				}
				lastDownElement = null;
			}
			if (lastTopLevelUIObject != gameObject)
			{
				ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerEnterHandler);
			}
		}
		if (lastTopLevelUIObject != null && lastTopLevelUIObject != gameObject)
		{
			ExecuteEvents.Execute(lastTopLevelUIObject, pointerEventData, ExecuteEvents.pointerExitHandler);
		}
		if (lastDownElement != null)
		{
			if (GameControls.actions.Interact.IsPressed)
			{
				ExecuteEvents.Execute(lastDownElement, pointerEventData, ExecuteEvents.dragHandler);
			}
			else if (GameControls.actions.Interact.WasReleased)
			{
				ExecuteEvents.Execute(lastDownElement, pointerEventData, ExecuteEvents.endDragHandler);
				lastDownElement = null;
			}
		}
		lastTopLevelUIObject = gameObject;
	}

	private Vector3 GetCanvasPosFromScreenPos(Vector3 screenPos)
	{
		Resolution realHalfResolution = GetRealHalfResolution();
		return new Vector3(screenPos.x - (float)realHalfResolution.width, screenPos.y - (float)realHalfResolution.height, 0f);
	}

	private Resolution GetRealHalfResolution()
	{
		Resolution currentResolution = Screen.currentResolution;
		if (Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen)
		{
			currentResolution.width = Screen.width;
			currentResolution.height = Screen.height;
		}
		currentResolution.width /= 2;
		currentResolution.height /= 2;
		return currentResolution;
	}

	private Vector3 GetScreenPosFromCanvasPos(Vector3 canvasPos)
	{
		Resolution realHalfResolution = GetRealHalfResolution();
		return new Vector3(canvasPos.x + (float)realHalfResolution.width, canvasPos.y + (float)realHalfResolution.height, 0f);
	}

	public void SetCursor(CursorType newType, bool force = false, int priority = 0)
	{
		if (!passiveModeCursorEnabled && GameSettings.PassiveModeAutoHideCursor())
		{
			return;
		}
		if (regRef == null)
		{
			regRef = ObjectRegistration.GetRegistrationScript();
		}
		if (regRef != null)
		{
			if (transitionRef == null)
			{
				transitionRef = regRef.GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION, nullAllowed: true);
			}
			if (sceneRef == null)
			{
				sceneRef = regRef.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER, nullAllowed: true);
			}
			if (pettingRef == null)
			{
				pettingRef = regRef.GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER, nullAllowed: true);
			}
		}
		if (transitionRef == null || sceneRef == null || transitionRef.IsTransitioning() || !sceneRef.HasSceneStarted())
		{
			invisibleFromTransition = true;
			currentCursor = CursorType.DEFAULT;
			fakeCursorImage.sprite = GetSpriteForCursorType(currentCursor);
			if (Cursor.visible)
			{
				Cursor.SetCursor(GetTextureForCursorType(currentCursor), GetHotspotForCursorType(currentCursor), CursorMode.Auto);
			}
			return;
		}
		if (invisibleFromTransition)
		{
			invisibleFromTransition = false;
		}
		if (newType == CursorType.DEFAULT)
		{
			if (lastDefaultRequestFrame != Time.frameCount)
			{
				continuousDefaultRequests++;
			}
			lastDefaultRequestFrame = Time.frameCount;
			if (continuousDefaultRequests < requiredContinuousDefaultRequests)
			{
				return;
			}
		}
		else
		{
			continuousDefaultRequests = 0;
		}
		if (lastRequestFrame == Time.frameCount && currentCursor != CursorType.DEFAULT && newType != CursorType.GRABBING2D && (currentCursor != CursorType.LOCKED_CLICKABLE || newType != CursorType.CLICKABLE) && (currentCursor == CursorType.CAMERA_DRAG || currentCursor == CursorType.CAMERA_ROTATE || currentCursor == CursorType.CAMERA_DRAG_LOCKED || priority <= lastPriority))
		{
			return;
		}
		lastPriority = priority;
		lastRequestFrame = Time.frameCount;
		if (!force && currentCursor == newType)
		{
			return;
		}
		if (newType == CursorType.GRABBING)
		{
			cursorShouldBeVisible = false;
			fakeCursorImage.enabled = false;
			if (systemMouseActive)
			{
				Cursor.visible = false;
			}
		}
		else if (currentCursor == CursorType.GRABBING)
		{
			cursorShouldBeVisible = true;
			fakeCursorImage.enabled = true;
			if (systemMouseActive)
			{
				Cursor.visible = true;
			}
		}
		currentCursor = newType;
		if (fakeCursorImage != null)
		{
			fakeCursorImage.sprite = GetSpriteForCursorType(newType);
		}
	}

	private Vector2 GetHotspotForCursorType(CursorType cursorType)
	{
		if (cursorType == CursorType.CLICKABLE || cursorType == CursorType.LOCKED_CLICKABLE || cursorType == CursorType.CLICKING)
		{
			return clickableCursorHotspot;
		}
		return defaultCursorHotspot;
	}

	private Texture2D GetTextureForCursorType(CursorType cursorType)
	{
		switch (currentCursor)
		{
		case CursorType.DEFAULT:
			return defaultCursor;
		case CursorType.GRABBING:
			return grabbingCursor;
		case CursorType.GRABBABLE:
			return grabbableCursor;
		case CursorType.CLICKABLE:
			return clickableCursor;
		case CursorType.LOCKED_CLICKABLE:
			return clickableLockedCursor;
		case CursorType.CLICKING:
			return clickableCursor;
		case CursorType.PETTABLE:
			return pettableCursor;
		case CursorType.PETTING:
			return pettableCursor;
		case CursorType.GRABBING2D:
			return grabbingCursor;
		case CursorType.CAMERA_DRAG:
			return cameraDragCursor;
		case CursorType.CAMERA_ROTATE:
			return cameraRotateCursor;
		case CursorType.CAMERA_DRAG_LOCKED:
			return cameraDragLockedCursor;
		case CursorType.TEXT_INPUT:
			return textInputCursor;
		case CursorType.BLOWDRY:
			return blowDryCursor;
		case CursorType.SEEKING_PETTABLE:
			return seekingPettableCursor;
		default:
			Debug.LogError("No valid cursor found for type: " + cursorType);
			return defaultCursor;
		}
	}

	private Sprite GetSpriteForCursorType(CursorType cursorType)
	{
		switch (currentCursor)
		{
		case CursorType.DEFAULT:
			return defaultCursorSprite;
		case CursorType.GRABBING:
			return grabbingCursorSprite;
		case CursorType.GRABBABLE:
			return grabbableCursorSprite;
		case CursorType.CLICKABLE:
			return clickableCursorSprite;
		case CursorType.LOCKED_CLICKABLE:
			return clickableLockedCursorSprite;
		case CursorType.CLICKING:
			return clickableCursorSprite;
		case CursorType.PETTABLE:
			return pettableCursorSprite;
		case CursorType.PETTING:
			return pettableCursorSprite;
		case CursorType.GRABBING2D:
			return grabbingCursorSprite;
		case CursorType.CAMERA_DRAG:
			return cameraDragCursorSprite;
		case CursorType.CAMERA_ROTATE:
			return cameraRotateCursorSprite;
		case CursorType.CAMERA_DRAG_LOCKED:
			return cameraDragLockedCursorSprite;
		case CursorType.TEXT_INPUT:
			return textInputCursorSprite;
		case CursorType.BLOWDRY:
			return blowDryCursorSprite;
		case CursorType.SEEKING_PETTABLE:
			return seekingPettableCursorSprite;
		default:
			Debug.LogError("No valid cursor found for type: " + cursorType);
			return defaultCursorSprite;
		}
	}
}
