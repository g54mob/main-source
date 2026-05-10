using System;
using System.Collections.Generic;
using DG.Tweening;
using HighlightPlus;
using SmoothShakeFree;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

[RequireComponent(typeof(CursorController))]
public class LTPlayerController : PlayerController
{
	public delegate void OnInputModeChanged(InputMode newInputMode, InputMode oldInputMode);

	[SerializeField]
	private float cameraRotationSpeed = 10f;

	[SerializeField]
	private float joystickPointerSpeed = 1f;

	private LTCamera ltCamera;

	[Header("Camera")]
	[SerializeField]
	private float wasdMovementSpeed = 25f;

	[SerializeField]
	private float dragMovementSpeed = 0.15f;

	[SerializeField]
	private float mouseBorderMovementSpeed = 35f;

	[SerializeField]
	private float defaultRotationSmooth = 0.9f;

	[SerializeField]
	private float mouseRotationSmooth = 0.5f;

	[SerializeField]
	private int mouseBorderSize = 20;

	[SerializeField]
	private float minZoomZoom = 15f;

	[SerializeField]
	private float minZoomPitch = 10f;

	[SerializeField]
	private float maxZoomZoom = 35f;

	[SerializeField]
	private float maxZoomPitch = 20f;

	[SerializeField]
	[Range(0f, 1f)]
	private float startCameraZoom = 0.5f;

	private float currentCameraZoom;

	private float startCameraRotation;

	[Header("Hotbar")]
	[SerializeField]
	private GameplayObjectData[] defaultHotbarElements;

	[Header("Misc")]
	[SerializeField]
	private bool allowPause = true;

	[SerializeField]
	private bool buildDuringPause;

	[SerializeField]
	private float editingObjectHeight = 1f;

	[SerializeField]
	private float editingObjectHeightTime = 1f;

	[SerializeField]
	private float dragCameraMinStartDistance = 50f;

	private float currentDragCameraDistance;

	[SerializeField]
	private PlacementAreaMarker placementAreaMakerPrefab;

	[SerializeField]
	private PlacementDirectionArrow placementDirectionArrowPrefab;

	[Header("Object Highlighting")]
	[SerializeField]
	private HighlightProfile highlitedProfile;

	[Header("VFX")]
	[SerializeField]
	private GameObject placeObjectVFX;

	[SerializeField]
	private AudioData rotateCameraSFX;

	[SerializeField]
	private AudioData resetCameraSFX;

	[SerializeField]
	private AudioData hotbarActionSFX;

	[SerializeField]
	private AudioData toggleGridSFX;

	[SerializeField]
	private AudioData nextIdleSFX;

	[SerializeField]
	private AudioData noIdleSFX;

	[SerializeField]
	private AudioData placeObjectSFX;

	[SerializeField]
	private AudioData placeObjectErrorSFX;

	[SerializeField]
	private AudioData unplaceObjectSFX;

	[SerializeField]
	private AudioData rotateObjectSFX;

	[SerializeField]
	private AudioData sampleObjectSFX;

	[SerializeField]
	private AudioData buyObjectSFX;

	[SerializeField]
	private AudioData sellObjectSFX;

	[SerializeField]
	private AudioData cancelEditSFX;

	[SerializeField]
	private AudioData cancelBuySFX;

	[SerializeField]
	private AudioData selectObjectSFX;

	private Camera mainCamera;

	private bool isMouseOverUI;

	private Vector3 movementInput;

	private bool movingWithWasd;

	private bool movingWithDrag;

	private float constantRotationDirection;

	private CursorController cursorController;

	private bool isRotatingCameraWithMouse;

	private bool isPlayerInputLocked;

	private bool isMouseBorderMovementLocked;

	private Quaternion lastObjectRotation = Quaternion.identity;

	private int isHotbarLocked;

	private InputMode currentInputMode;

	private int currentIdleIdx;

	private List<PlacementDirectionArrow> currentDirectionArrows;

	private HotbarController hotbarController;

	private List<TooltipComponent> buildingsTooltips;

	private float WasdMovementSpeed => wasdMovementSpeed * SettingsController.instance.CameraSpeedMultiplier;

	private float DragMovementSpeed => dragMovementSpeed * SettingsController.instance.CameraSpeedMultiplier;

	private float MouseBorderMovementSpeed => mouseBorderMovementSpeed * SettingsController.instance.CameraSpeedMultiplier;

	public float JoystickPointerSpeed
	{
		get
		{
			return joystickPointerSpeed;
		}
		set
		{
			joystickPointerSpeed = value;
		}
	}

	public LTHUD LTHUD => CurrentHUD as LTHUD;

	public GameObject PlaceObjectVFX => placeObjectVFX;

	public bool AllowPause
	{
		get
		{
			return allowPause;
		}
		set
		{
			allowPause = value;
		}
	}

	public bool BuildDuringPause
	{
		get
		{
			return buildDuringPause;
		}
		set
		{
			buildDuringPause = value;
		}
	}

	public float EditingObjectHeight => editingObjectHeight;

	public float EditingObjectHeightTime => editingObjectHeightTime;

	public PlacementAreaMarker PlacementAreaMakerPrefab => placementAreaMakerPrefab;

	public PlacementDirectionArrow PlacementDirectionArrowPrefab => placementDirectionArrowPrefab;

	public CursorController CursorController => cursorController;

	public bool IsMouseBorderMovementLocked
	{
		get
		{
			return isMouseBorderMovementLocked;
		}
		set
		{
			isMouseBorderMovementLocked = value;
		}
	}

	public Quaternion LastObjectRotation
	{
		get
		{
			return lastObjectRotation;
		}
		set
		{
			lastObjectRotation = value;
		}
	}

	public bool IsMouseOverUI
	{
		get
		{
			return isMouseOverUI;
		}
		set
		{
			isMouseOverUI = value;
		}
	}

	public Camera MainCamera
	{
		get
		{
			if (!mainCamera)
			{
				mainCamera = Camera.main;
			}
			return mainCamera;
		}
	}

	public bool IsPlayerInputLocked
	{
		get
		{
			return isPlayerInputLocked;
		}
		set
		{
			isPlayerInputLocked = value;
			movementInput = Vector3.zero;
			constantRotationDirection = 0f;
			movingWithWasd = false;
			movingWithDrag = false;
			ShowTooltips(show: false);
			this.onPlayerInputLocked?.Invoke(isPlayerInputLocked);
			CursorController.SetCursor(CursorController.ECursor.Default);
		}
	}

	public bool IsHotbarLocked
	{
		get
		{
			return isHotbarLocked > 0;
		}
		set
		{
			if (value)
			{
				isHotbarLocked++;
			}
			else
			{
				isHotbarLocked--;
			}
			isHotbarLocked = Mathf.Max(isHotbarLocked, 0);
		}
	}

	public InputMode CurrentInputMode
	{
		get
		{
			return currentInputMode;
		}
		protected set
		{
			UnityEngine.Object.DestroyImmediate(currentInputMode);
			currentInputMode = value;
			currentInputMode.playerController = this;
		}
	}

	public float CurrentCameraZoom
	{
		get
		{
			return currentCameraZoom;
		}
		set
		{
			currentCameraZoom = value;
			ltCamera.Pitch = Mathf.Lerp(maxZoomPitch, minZoomPitch, CurrentCameraZoom);
			ltCamera.Zoom = Mathf.Lerp(maxZoomZoom, minZoomZoom, CurrentCameraZoom);
		}
	}

	public AudioData RotateCameraSFX => rotateCameraSFX;

	public AudioData ResetCameraSFX => resetCameraSFX;

	public AudioData HotbarActionSFX => hotbarActionSFX;

	public AudioData NextIdleSFX => nextIdleSFX;

	public AudioData NoIdleSFX => noIdleSFX;

	public AudioData PlaceObjectSFX => placeObjectSFX;

	public AudioData PlaceObjectErrorSFX => placeObjectErrorSFX;

	public AudioData UnplaceObjectSFX => unplaceObjectSFX;

	public AudioData RotateObjectSFX => rotateObjectSFX;

	public AudioData SampleObjectSFX => sampleObjectSFX;

	public AudioData BuyObjectSFX => buyObjectSFX;

	public AudioData SellObjectSFX => sellObjectSFX;

	public AudioData CancelEditSFX => cancelEditSFX;

	public AudioData CancelBuySFX => cancelBuySFX;

	public AudioData SelectObjectSFX => selectObjectSFX;

	public event OnInputModeChanged onInputModeChanged;

	public event Action<bool> onPlayerInputLocked;

	public event Action<int> onHotbarBankChanged;

	public event Action<int> onHotbarActionChanged;

	public event Action<int> onHotbarInputButtonPressed;

	protected override void Awake()
	{
		base.Awake();
		cursorController = GetComponent<CursorController>();
		currentDirectionArrows = new List<PlacementDirectionArrow>();
		buildingsTooltips = new List<TooltipComponent>();
	}

	protected override void Start()
	{
		base.Start();
		SwitchInputMode(EInputMode.Standard);
		ltCamera.WorldRotationSmooth = defaultRotationSmooth;
		ltCamera.FollowTarget(smooth: false);
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded += OnPlayerBuildingAdded;
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingRemoved += OnPlayerBuildingRemoved;
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded += OnPlayerBuildingAdded;
		LTFunctionLibrary.GetPlayerData().onPlayerTowerRemoved += OnPlayerBuildingRemoved;
		foreach (GameplayObject playerBuildingsAndTower in LTFunctionLibrary.GetPlayerData().PlayerBuildingsAndTowers)
		{
			OnPlayerBuildingAdded(playerBuildingsAndTower);
		}
		hotbarController = new HotbarController(10, 9);
		if (!hotbarController.HasSavedData())
		{
			for (int i = 0; i < defaultHotbarElements.Length; i++)
			{
				AddHotbarAction(defaultHotbarElements[i], i);
			}
		}
		allowPause = MatchInfo.instance.CurrentMatchSettings.AllowPause;
		buildDuringPause = MatchInfo.instance.CurrentMatchSettings.BuildDuringPause;
	}

	private void Update()
	{
		IsMouseOverUI = EventSystem.current.IsPointerOverGameObject();
		if (!IsPlayerInputLocked)
		{
			if (!IsMouseBorderMovementLocked && !movingWithWasd && !movingWithDrag && !isRotatingCameraWithMouse && Application.isFocused && SettingsController.instance.ScreenBorderCameraMovementEnabled)
			{
				CheckMouseNearScreenBorders();
			}
			MovePlayer();
		}
	}

	public InputMode SwitchInputMode(EInputMode inputMode)
	{
		if (!currentInputMode || inputMode != currentInputMode.InputModeType)
		{
			InputMode oldInputMode = currentInputMode;
			switch (inputMode)
			{
			case EInputMode.Standard:
				CurrentInputMode = base.gameObject.AddComponent<StandardInputMode>();
				break;
			case EInputMode.EditMode:
				CurrentInputMode = base.gameObject.AddComponent<EditModeInputMode>();
				break;
			case EInputMode.BuyMode:
				CurrentInputMode = base.gameObject.AddComponent<BuyModeInputMode>();
				break;
			}
			base.PlayerInput.SwitchCurrentActionMap(inputMode.ToString());
			this.onInputModeChanged?.Invoke(currentInputMode, oldInputMode);
		}
		return currentInputMode;
	}

	protected override void SpawnCamera()
	{
		base.SpawnCamera();
		ltCamera = base.PlayerCamera as LTCamera;
		startCameraRotation = ltCamera.WorldRotation;
		CurrentCameraZoom = startCameraZoom;
	}

	public void ShakeCameraFromPosition(Vector3 originPositon, float shakeForce, SmoothShakeFreePreset shakePreset = null)
	{
		if (SettingsController.instance.ScreenShakeEnabled)
		{
			ltCamera.ShakeCameraController.ShakeCamera(shakePreset, originPositon, shakeForce);
		}
	}

	public void ShakeCamera(SmoothShakeFreePreset shakePreset = null)
	{
		if (SettingsController.instance.ScreenShakeEnabled)
		{
			ltCamera.ShakeCameraController.ShakeCamera(shakePreset);
		}
	}

	public void StopShakeCamera(bool forceStop = false)
	{
		ltCamera.ShakeCameraController.StopShakeCamera(forceStop);
	}

	public void AddCameraRotation(float worldRotation)
	{
		ltCamera.WorldRotation += worldRotation;
	}

	public void SetCameraRotation(float worldRotation)
	{
		ltCamera.WorldRotation = worldRotation;
	}

	public void RotateCamera(float direction, bool applyDeltaTime = true)
	{
		ltCamera.WorldRotation += direction * cameraRotationSpeed * (applyDeltaTime ? Time.deltaTime : 1f);
	}

	public void ResetCameraZoom()
	{
		CurrentCameraZoom = startCameraZoom;
	}

	public void ResetCameraRotation()
	{
		ltCamera.WorldRotation = startCameraRotation;
	}

	private void CheckMouseNearScreenBorders()
	{
		if (!(Mouse.current.lastUpdateTime < 0.0))
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			movementInput = Vector3.zero;
			if (vector.x <= (float)mouseBorderSize && vector.x >= 0f)
			{
				movementInput.x = -1f;
			}
			else if (vector.x >= (float)(Screen.width - mouseBorderSize) && vector.x <= (float)Screen.width)
			{
				movementInput.x = 1f;
			}
			if (vector.y <= (float)mouseBorderSize && vector.y >= 0f)
			{
				movementInput.z = -1f;
			}
			else if (vector.y >= (float)(Screen.height - mouseBorderSize) && vector.y <= (float)Screen.height)
			{
				movementInput.z = 1f;
			}
			movementInput = movementInput.normalized * MouseBorderMovementSpeed;
		}
	}

	private void MovePlayer()
	{
		base.ControlledCharacter?.Move(Quaternion.Euler(0f, playerCamera.OwnCamera.transform.rotation.eulerAngles.y, 0f) * movementInput, normalizeDirection: false);
	}

	public void CenterCameraOnNextIdleBuilding()
	{
		IdleManager idleManager = LTFunctionLibrary.GetLTGameManager().IdleManager;
		if (idleManager.GetCurrentlyIdleDetectorsAmount() > 0)
		{
			currentIdleIdx = Mathf.RoundToInt(Mathf.Repeat(currentIdleIdx, idleManager.GetCurrentlyIdleDetectorsAmount()));
			base.ControlledCharacter.transform.position = idleManager.GetCurrentlyIdleDetector(currentIdleIdx).GetComponent<PlacementComponent>().GetCenter();
			AudioSystem.Instance.PlaySound2D(NextIdleSFX, AudioSystem.EAudioMixerGroup.UI);
			currentIdleIdx = Mathf.RoundToInt(Mathf.Repeat(currentIdleIdx + 1, idleManager.GetCurrentlyIdleDetectorsAmount()));
		}
		else
		{
			AudioSystem.Instance.PlaySound2D(NoIdleSFX, AudioSystem.EAudioMixerGroup.UI);
		}
	}

	public void HighlightObject(GameObject go, bool highlight)
	{
		if (highlight)
		{
			HighlightManager.instance.SelectObject(go.transform);
			go.GetComponent<HighlightEffect>().ProfileLoad(highlitedProfile);
			go.GetComponent<HighlightEffect>().Refresh(discardCachedMeshes: true);
		}
		else
		{
			HighlightManager.instance.UnselectObject(go.transform);
		}
	}

	public void ShowTooltips(bool show)
	{
		if (IsPlayerInputLocked)
		{
			return;
		}
		foreach (TooltipComponent buildingsTooltip in buildingsTooltips)
		{
			if (show)
			{
				buildingsTooltip.ShowTooltip(LTHUD.BuildingsTooltipsContainer.transform);
			}
			else
			{
				buildingsTooltip.HideTooltip();
			}
		}
	}

	public void StartEditingObject(PlacementComponent objectToEdit)
	{
		(SwitchInputMode(EInputMode.EditMode) as EditModeInputMode).StartEditingObject(objectToEdit);
	}

	public void StartBuyingObject(GameplayObjectData objectToBuy, Vector3? position = null, Quaternion rotation = default(Quaternion), ISampleableData sampleableData = null)
	{
		if (rotation.Equals(default(Quaternion)))
		{
			rotation = LastObjectRotation;
		}
		PlacementComponent component = UnityEngine.Object.Instantiate(objectToBuy.Prefab, Vector3.zero, rotation).GetComponent<PlacementComponent>();
		component.SetPositon(LTFunctionLibrary.GetGrid().SnapPositionToGrid((position ?? GetPointerWorldPosition()) - component.GetCenter(localSpace: true)));
		if (sampleableData != null && component.TryGetComponent<ISampleableData>(out var component2))
		{
			component2.SetData(sampleableData.GetData());
		}
		SwitchInputMode(EInputMode.BuyMode);
		(CurrentInputMode as BuyModeInputMode).StartBuyingObject(component);
	}

	public void StopBuyingObject(bool playCancelSound = true)
	{
		if (CurrentInputMode is BuyModeInputMode)
		{
			(CurrentInputMode as BuyModeInputMode).StopBuyingObject(playCancelSound);
		}
	}

	public GameplayObjectData GetHotbarAction(int actionIdx)
	{
		return (hotbarController.GetAction(actionIdx)?.Data as GameplayObjectData) ?? null;
	}

	public GameplayObjectData GetHotbarAction(int actionIdx, int bankIdx)
	{
		return (hotbarController.GetAction(actionIdx, bankIdx)?.Data as GameplayObjectData) ?? null;
	}

	public int GetHotbarCurrentBank()
	{
		return hotbarController.CurrentBank;
	}

	public void AddHotbarAction(object data, int actionIdx)
	{
		hotbarController.AddAction(new HotbarAction_building(data), actionIdx);
		this.onHotbarActionChanged?.Invoke(actionIdx);
	}

	public void AddHotbarAction(object data, int actionIdx, int bankIdx)
	{
		hotbarController.AddAction(new HotbarAction_building(data), actionIdx, bankIdx);
		this.onHotbarActionChanged?.Invoke(actionIdx);
	}

	public void RemoveHotbarAction(int actionIdx)
	{
		hotbarController.RemoveAction(actionIdx);
		this.onHotbarActionChanged?.Invoke(actionIdx);
	}

	public void RemoveHotbarAction(int actionIdx, int bankIdx)
	{
		hotbarController.RemoveAction(actionIdx, bankIdx);
		this.onHotbarActionChanged?.Invoke(actionIdx);
	}

	public void SetHotbarBank(int bankIdx)
	{
		hotbarController.SetCurrentBank(bankIdx);
		this.onHotbarBankChanged?.Invoke(hotbarController.CurrentBank);
	}

	public void SetNextHotbarBank()
	{
		hotbarController.SetNextCurrentBank();
		this.onHotbarBankChanged?.Invoke(hotbarController.CurrentBank);
	}

	public void SetPreviousHotbarBank()
	{
		hotbarController.SetPreviousCurrentBank();
		this.onHotbarBankChanged?.Invoke(hotbarController.CurrentBank);
	}

	public void DoHotbarAction(int index)
	{
		if (hotbarController.CanPerformActionAtIndex(index))
		{
			StopBuyingObject(playCancelSound: false);
			hotbarController.DoAction(index);
		}
	}

	private void DoHotbarActionFromPlayerController(int actionIdx)
	{
		if (!isPlayerInputLocked && !IsHotbarLocked)
		{
			DoHotbarAction(actionIdx);
			AudioSystem.Instance.PlaySound2D(HotbarActionSFX, AudioSystem.EAudioMixerGroup.UI);
		}
		this.onHotbarInputButtonPressed?.Invoke(actionIdx);
	}

	public Vector3 GetPointerWorldPosition()
	{
		return GetPointerWorldPosition(Input.mousePosition);
	}

	public Vector3 GetPointerWorldPosition(Vector3 customScreenPosition)
	{
		if (Physics.Raycast(MainCamera.ScreenPointToRay(customScreenPosition), out var hitInfo, 100f, LayerMask.GetMask("WorldStatic", "Ground")))
		{
			return hitInfo.point;
		}
		return Vector3.right * -999999f;
	}

	public void ShowDirectionArrows(PlacementComponent editingObject)
	{
		HideDirectionArrows();
		ConveyorBelt[] componentsInChildren = editingObject.GetComponentsInChildren<ConveyorBelt>();
		foreach (ConveyorBelt conveyorBelt in componentsInChildren)
		{
			if (conveyorBelt.InputOrientation != EOrientation.None)
			{
				CreateDirectionArrow(editingObject.MainObject.Model.transform).SetupArrow(conveyorBelt, isInputOrientation: true);
			}
			if (conveyorBelt.OutputOrientation != EOrientation.None)
			{
				CreateDirectionArrow(editingObject.MainObject.Model.transform).SetupArrow(conveyorBelt, isInputOrientation: false);
			}
		}
	}

	public void HideDirectionArrows()
	{
		for (int num = currentDirectionArrows.Count - 1; num >= 0; num--)
		{
			if ((bool)currentDirectionArrows[num])
			{
				UnityEngine.Object.Destroy(currentDirectionArrows[num].gameObject);
			}
		}
		currentDirectionArrows.Clear();
	}

	private PlacementDirectionArrow CreateDirectionArrow(Transform parent)
	{
		PlacementDirectionArrow newArrow = UnityEngine.Object.Instantiate(placementDirectionArrowPrefab);
		currentDirectionArrows.Add(newArrow);
		if (DOTween.IsTweening(parent))
		{
			Tween tween = DOTween.TweensByTarget(parent, playingOnly: true)[0];
			tween.onComplete = (TweenCallback)Delegate.Combine(tween.onComplete, (TweenCallback)delegate
			{
				newArrow.transform.SetParent(parent);
			});
		}
		else
		{
			newArrow.transform.SetParent(parent);
		}
		return currentDirectionArrows[currentDirectionArrows.Count - 1];
	}

	public void PlayPlaceObjectVFX(PlacementComponent placeingObject)
	{
		UnityEngine.Object.Instantiate(PlaceObjectVFX, placeingObject.GetCenter(), placeingObject.transform.rotation, null).transform.localScale = new Vector3(placeingObject.Width, 1f, placeingObject.Length);
	}

	private void OnPlayerBuildingAdded(GameplayObject addedBuilding)
	{
		if (addedBuilding.TryGetComponent<TooltipComponent>(out var component))
		{
			buildingsTooltips.Add(component);
		}
	}

	private void OnPlayerBuildingRemoved(GameplayObject removedBuilding)
	{
		if (removedBuilding.TryGetComponent<TooltipComponent>(out var component))
		{
			buildingsTooltips.Remove(component);
		}
	}

	private void OnMoveCamera(InputValue inputValue)
	{
		if (!IsPlayerInputLocked)
		{
			movementInput = inputValue.Get<Vector2>().XZ().normalized * WasdMovementSpeed;
			movingWithWasd = movementInput.sqrMagnitude > 0f;
		}
	}

	private void OnDragCamera(InputValue inputValue)
	{
		if (IsPlayerInputLocked)
		{
			return;
		}
		if (!movingWithDrag && currentDragCameraDistance < dragCameraMinStartDistance * (float)Screen.width / 1920f)
		{
			currentDragCameraDistance += inputValue.Get<Vector2>().XZ().magnitude;
			return;
		}
		if (inputValue.Get<Vector2>().sqrMagnitude < 4f)
		{
			movementInput = Vector3.zero;
		}
		else
		{
			movementInput = -inputValue.Get<Vector2>().XZ() * DragMovementSpeed / Time.unscaledDeltaTime;
		}
		if (movementInput.sqrMagnitude != 0f)
		{
			movingWithDrag = true;
		}
	}

	public void OnRotateCamera(InputValue inputValue)
	{
		if (!IsPlayerInputLocked)
		{
			float direction = inputValue.Get<float>();
			RotateCamera(direction, applyDeltaTime: false);
			ltCamera.WorldRotationSmooth = mouseRotationSmooth;
			isRotatingCameraWithMouse = true;
		}
	}

	public void OnSnapRotateCamera(InputValue inputValue)
	{
		if (!IsPlayerInputLocked && !isRotatingCameraWithMouse)
		{
			constantRotationDirection = inputValue.Get<float>();
			float worldRotation = 0f;
			float num = Mathf.Repeat(ltCamera.WorldRotation, 360f);
			if (constantRotationDirection > 0f)
			{
				worldRotation = Mathf.Round(44.99f + (float)(Mathf.CeilToInt((num - 44.99f) / 90f) * 90)) - num;
			}
			else if (constantRotationDirection < 0f)
			{
				worldRotation = Mathf.Round(45.01f + (float)(Mathf.FloorToInt((num - 45.01f) / 90f) * 90)) - num;
			}
			AddCameraRotation(worldRotation);
			AudioSystem.Instance.PlaySound2D(RotateCameraSFX, AudioSystem.EAudioMixerGroup.UI);
		}
	}

	private void OnZoomCamera(InputValue inputValue)
	{
		if (!IsPlayerInputLocked && !isMouseOverUI)
		{
			float num = inputValue.Get<float>();
			CurrentCameraZoom = Mathf.Clamp01(CurrentCameraZoom + num * 0.1f);
		}
	}

	private void OnResetCamera()
	{
		if (!IsPlayerInputLocked && (base.ControlledCharacter.transform.position != LTFunctionLibrary.GetLTLevelController().SpawnTransform.position || ltCamera.WorldRotation != startCameraRotation || CurrentCameraZoom != startCameraZoom))
		{
			base.ControlledCharacter.transform.position = LTFunctionLibrary.GetLTLevelController().SpawnTransform.position;
			ResetCameraRotation();
			ResetCameraZoom();
			AudioSystem.Instance.PlaySound2D(ResetCameraSFX, AudioSystem.EAudioMixerGroup.UI);
		}
	}

	public void OnSecondaryInteractMouse(InputValue inputValue)
	{
		if (inputValue.Get<float>() <= 0f)
		{
			movingWithDrag = false;
			currentDragCameraDistance = 0f;
		}
	}

	public void OnTertiaryInteractMouse(InputValue inputValue)
	{
		if (inputValue.Get<float>() <= 0f)
		{
			isRotatingCameraWithMouse = false;
			ltCamera.WorldRotationSmooth = defaultRotationSmooth;
		}
	}

	private void OnShowGrid()
	{
		if (!IsPlayerInputLocked)
		{
			LTFunctionLibrary.GetLTGameManager().ToggleShowFullGrid();
			AudioSystem.Instance.PlaySound2D(toggleGridSFX, AudioSystem.EAudioMixerGroup.UI);
		}
	}

	private void OnOpenStore()
	{
		if (!IsPlayerInputLocked)
		{
			LTHUD.OpenStore();
			CursorController.SetCursor(CursorController.ECursor.Default);
		}
	}

	private void OnMoveToIdle()
	{
		if (!IsPlayerInputLocked)
		{
			CenterCameraOnNextIdleBuilding();
		}
	}

	private void OnHotbar1()
	{
		DoHotbarActionFromPlayerController(0);
	}

	private void OnHotbar2()
	{
		DoHotbarActionFromPlayerController(1);
	}

	private void OnHotbar3()
	{
		DoHotbarActionFromPlayerController(2);
	}

	private void OnHotbar4()
	{
		DoHotbarActionFromPlayerController(3);
	}

	private void OnHotbar5()
	{
		DoHotbarActionFromPlayerController(4);
	}

	private void OnHotbar6()
	{
		DoHotbarActionFromPlayerController(5);
	}

	private void OnHotbar7()
	{
		DoHotbarActionFromPlayerController(6);
	}

	private void OnHotbar8()
	{
		DoHotbarActionFromPlayerController(7);
	}

	private void OnHotbar9()
	{
		DoHotbarActionFromPlayerController(8);
	}

	private void OnHotbar10()
	{
		DoHotbarActionFromPlayerController(9);
	}

	private void OnHotbarChangeBank(InputValue inputValue)
	{
		if (!IsPlayerInputLocked)
		{
			float num = inputValue.Get<float>();
			if (num > 0f)
			{
				SetNextHotbarBank();
				AudioSystem.Instance.PlaySound2D(HotbarActionSFX, AudioSystem.EAudioMixerGroup.UI);
			}
			else if (num < 0f)
			{
				SetPreviousHotbarBank();
				AudioSystem.Instance.PlaySound2D(HotbarActionSFX, AudioSystem.EAudioMixerGroup.UI);
			}
		}
	}

	private void OnPauseSpeed()
	{
		if (!IsPlayerInputLocked)
		{
			if (!allowPause)
			{
				string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantPause", null, FallbackBehavior.UseProjectSettings);
				LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
			}
			else
			{
				LTFunctionLibrary.GetTimeManager().ToggleGamePause();
			}
		}
	}

	private void OnIncreaseSpeed()
	{
		if (!IsPlayerInputLocked)
		{
			LTFunctionLibrary.GetTimeManager().IncreaseSpeed();
		}
	}

	private void OnDecreaseSpeed()
	{
		if (!IsPlayerInputLocked)
		{
			LTFunctionLibrary.GetTimeManager().DecreaseSpeed(allowPause);
		}
	}
}
