using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class BuyModeInputMode : InputMode
{
	public Action<PlacementComponent> onBuyingObjectChanged;

	[HideInInspector]
	private PlacementComponent buyingObject;

	private Vector2 pointerPosition;

	private bool onConfirmStarted;

	private PlacementComponent lastPlacedConveyorBelt;

	private bool autoRotationLocked;

	private bool lockClicks;

	private bool mouseOverUI;

	private bool straightModifierEnabled;

	private Vector3? straightModifierStartClickPosition;

	private Vector3? straightModifierFirstObjectPosition;

	private Vector3? straightModifierAxis;

	private Vector3Int? lastGridPosition;

	private Tween lastTween;

	private PlacementAreaMarker currentPlacementAreaMarker;

	public LTPlayerController LtPlayerController => playerController as LTPlayerController;

	public bool LockClicks
	{
		get
		{
			return lockClicks;
		}
		set
		{
			lockClicks = value;
		}
	}

	public PlacementComponent BuyingObject
	{
		get
		{
			return buyingObject;
		}
		set
		{
			ISelectable component;
			if ((bool)buyingObject)
			{
				buyingObject.onDestroyAndSubstitute -= OnDestroyAndSubstituteBuyingObject;
				LtPlayerController.HighlightObject(buyingObject.gameObject, highlight: false);
				if (buyingObject.TryGetComponent<ISelectable>(out component))
				{
					component.Deselect();
				}
				LtPlayerController.HideDirectionArrows();
				UnityEngine.Object.Destroy(currentPlacementAreaMarker.gameObject);
			}
			buyingObject = value;
			component = null;
			if ((bool)buyingObject)
			{
				buyingObject.onDestroyAndSubstitute += OnDestroyAndSubstituteBuyingObject;
				LtPlayerController.HighlightObject(buyingObject.gameObject, highlight: true);
				if (buyingObject.TryGetComponent<ISelectable>(out component))
				{
					component.Select();
				}
				LtPlayerController.ShowDirectionArrows(buyingObject);
				currentPlacementAreaMarker = UnityEngine.Object.Instantiate(LtPlayerController.PlacementAreaMakerPrefab);
				currentPlacementAreaMarker.CurrentPlacementComponent = BuyingObject;
			}
			onBuyingObjectChanged?.Invoke(buyingObject);
		}
	}

	private PlacementComponent LastPlacedConveyorBelt
	{
		get
		{
			return lastPlacedConveyorBelt;
		}
		set
		{
			if ((bool)lastPlacedConveyorBelt)
			{
				lastPlacedConveyorBelt.onDestroyAndSubstitute -= OnDestroyAndSubstituteLastPlacedConveyorBelt;
			}
			lastPlacedConveyorBelt = value;
			if ((bool)lastPlacedConveyorBelt)
			{
				lastPlacedConveyorBelt.onDestroyAndSubstitute += OnDestroyAndSubstituteLastPlacedConveyorBelt;
			}
		}
	}

	public bool StraightModifierEnabled
	{
		get
		{
			return straightModifierEnabled;
		}
		set
		{
			straightModifierEnabled = value;
			if (straightModifierEnabled)
			{
				LtPlayerController.CursorController.SetCursor(CursorController.ECursor.StraightModifier);
				return;
			}
			ResetStraightModifierVariables();
			if ((bool)BuyingObject)
			{
				Vector3Int vector3Int = LTFunctionLibrary.GetGrid().SnapPositionToGrid(LtPlayerController.GetPointerWorldPosition() - BuyingObject.GetCenter(localSpace: true));
				ShowBuyingObject(show: true);
				BuyingObject.SetPositon(vector3Int);
			}
			LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Default);
		}
	}

	private Tween LastTween
	{
		get
		{
			return lastTween;
		}
		set
		{
			if (lastTween != null && lastTween.IsActive() && lastTween.IsPlaying())
			{
				lastTween.Complete();
			}
			lastTween = value;
		}
	}

	private void Awake()
	{
		inputModeType = EInputMode.BuyMode;
	}

	private void Start()
	{
		LTFunctionLibrary.GetLTGameManager().ShowGrid(show: true, LTGameManager.EShowGridMode.Partial);
		PlayerInput component = GetComponent<PlayerInput>();
		component.actions["Confirm"].started += OnConfirmStarted;
		component.actions["Confirm"].canceled += OnConfirmCanceled;
		component.actions["ShowTooltips"].started += OnShowTooltipsStarted;
		component.actions["ShowTooltips"].canceled += OnShowTooltipsCanceled;
		component.actions["StraightModifier"].started += OnStraightModifierChanged;
		component.actions["StraightModifier"].canceled += OnStraightModifierChanged;
		(LtPlayerController.PlayerCamera as IsometricCamera).onCameraMoved += OnCameraMoved;
		StartCoroutine(DelayInputCoroutine());
	}

	private IEnumerator DelayInputCoroutine()
	{
		lockClicks = true;
		yield return null;
		lockClicks = false;
	}

	private void OnDestroy()
	{
		PlayerInput component = GetComponent<PlayerInput>();
		StopBuyingObject();
		component.actions["Confirm"].started -= OnConfirmStarted;
		component.actions["Confirm"].canceled -= OnConfirmCanceled;
		component.actions["ShowTooltips"].started -= OnShowTooltipsStarted;
		component.actions["ShowTooltips"].canceled -= OnShowTooltipsCanceled;
		component.actions["StraightModifier"].started -= OnStraightModifierChanged;
		component.actions["StraightModifier"].canceled -= OnStraightModifierChanged;
		(LtPlayerController.PlayerCamera as IsometricCamera).onCameraMoved -= OnCameraMoved;
	}

	private void Update()
	{
		mouseOverUI = EventSystem.current.IsPointerOverGameObject();
	}

	private void OnShowTooltipsStarted(InputAction.CallbackContext context)
	{
		LtPlayerController.ShowTooltips(show: true);
	}

	private void OnShowTooltipsCanceled(InputAction.CallbackContext context)
	{
		LtPlayerController.ShowTooltips(show: false);
	}

	private void OnCameraMoved()
	{
		MovePointer(Input.mousePosition);
	}

	private void ShowBuyingObject(bool show)
	{
		BuyingObject.MainObject.Model.gameObject.SetActive(show);
		currentPlacementAreaMarker.gameObject.SetActive(show);
		LtPlayerController.HighlightObject(buyingObject.gameObject, show);
	}

	private bool CheckIsGamePaused()
	{
		if (!MatchInfo.instance.CurrentMatchSettings.BuildDuringPause && LTFunctionLibrary.GetTimeManager().GetGameSpeed() == TimeManager.ETimeSpeed.Pause)
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantBuildWhilePause", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
			return true;
		}
		return false;
	}

	private void OnConfirmStarted(InputAction.CallbackContext context)
	{
		if (lockClicks || mouseOverUI || !BuyingObject)
		{
			return;
		}
		if (CheckIsGamePaused())
		{
			onConfirmStarted = false;
			return;
		}
		ShowBuyingObject(show: true);
		if (StraightModifierEnabled && !straightModifierFirstObjectPosition.HasValue)
		{
			straightModifierStartClickPosition = LtPlayerController.GetPointerWorldPosition();
			straightModifierFirstObjectPosition = LTFunctionLibrary.GetGrid().SnapPositionToGrid(straightModifierStartClickPosition.Value - BuyingObject.GetCenter(localSpace: true));
		}
		if (!autoRotationLocked && LastPlacedConveyorBelt != null && buyingObject.transform.position != LastPlacedConveyorBelt.transform.position)
		{
			Quaternion quaternion = Quaternion.LookRotation(buyingObject.transform.position.XZ().XZ() - LastPlacedConveyorBelt.transform.position.XZ().XZ());
			if (LTFunctionLibrary.GetGrid().GetAdjacentBuiltObjects<ConveyorBelt>(buyingObject.transform).Contains(LastPlacedConveyorBelt.GetComponent<ConveyorBelt>()) && quaternion != LastPlacedConveyorBelt.transform.rotation && (int)quaternion.eulerAngles.y % 90 == 0)
			{
				if (LastTween != null && LastTween.IsActive() && LastTween.IsPlaying())
				{
					LastTween.Complete();
				}
				LastPlacedConveyorBelt.Unplace();
				LastPlacedConveyorBelt.SetRotation(quaternion);
				LastPlacedConveyorBelt.Place();
				BuyingObject.SetRotation(quaternion);
				LtPlayerController.LastObjectRotation = quaternion;
			}
			if (IsStraightModifierAxisSet())
			{
				autoRotationLocked = true;
			}
		}
		if (LTFunctionLibrary.CanBuyObject(BuyingObject, !onConfirmStarted))
		{
			LTFunctionLibrary.GetLTGameManager().PayCost(BuyingObject.MainObject.ObjectData.BuyCost);
			LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(BuyingObject.MainObject);
			BuyingObject.Place();
			LastTween = BuyingObject.MainObject.Model.transform.DOLocalMoveY(0f, LtPlayerController.EditingObjectHeightTime).SetEase(Ease.OutSine).SetUpdate(isIndependentUpdate: true);
			LtPlayerController.PlayPlaceObjectVFX(BuyingObject);
			AudioSystem.Instance.PlaySound2D(LtPlayerController.BuyObjectSFX, AudioSystem.EAudioMixerGroup.UI);
			Physics.SyncTransforms();
			if ((bool)BuyingObject.GetComponent<ConveyorBelt>())
			{
				LastPlacedConveyorBelt = BuyingObject.GetComponent<PlacementComponent>();
			}
			else
			{
				LastPlacedConveyorBelt = null;
			}
			ISampleableData sampleableData = null;
			if (buyingObject.TryGetComponent<ISampleableData>(out var component))
			{
				sampleableData = component;
			}
			LtPlayerController.StartBuyingObject(BuyingObject.MainObject.ObjectData, BuyingObject.GetCenter(), BuyingObject.transform.rotation, sampleableData);
			ShowBuyingObject(show: false);
		}
		else if (!onConfirmStarted)
		{
			LastTween = BuyingObject.MainObject.Model.transform.DOLocalMoveY(LtPlayerController.EditingObjectHeight * 0.25f, LtPlayerController.EditingObjectHeightTime).SetEase(Ease.InSine).SetLoops(2, LoopType.Yoyo)
				.SetUpdate(isIndependentUpdate: true);
			AudioSystem.Instance.PlaySound2D(LtPlayerController.PlaceObjectErrorSFX, AudioSystem.EAudioMixerGroup.UI);
		}
		onConfirmStarted = true;
	}

	private void OnConfirmCanceled(InputAction.CallbackContext context)
	{
		LastPlacedConveyorBelt = null;
		ResetStraightModifierVariables();
		onConfirmStarted = false;
	}

	public void OnCancel(InputValue inputValue)
	{
		if (!lockClicks)
		{
			LtPlayerController.SwitchInputMode(EInputMode.Standard);
		}
	}

	public void StopBuyingObject(bool playSound = true)
	{
		if (BuyingObject != null)
		{
			if (LastTween != null && LastTween.IsActive() && LastTween.IsPlaying())
			{
				LastTween.Kill();
			}
			UnityEngine.Object.Destroy(currentPlacementAreaMarker.gameObject);
			UnityEngine.Object.Destroy(BuyingObject.gameObject);
			BuyingObject = null;
			if (playSound)
			{
				AudioSystem.Instance.PlaySound2D(LtPlayerController.CancelBuySFX, AudioSystem.EAudioMixerGroup.UI);
			}
		}
	}

	public void StartBuyingObject(PlacementComponent placementComponent)
	{
		BuyingObject = placementComponent;
		BuyingObject.MainObject.Model.transform.position += Vector3.up * LtPlayerController.EditingObjectHeight;
		if ((bool)BuyingObject && onConfirmStarted && StraightModifierEnabled && IsStraightModifierAxisSet())
		{
			BuyingObject.SetPositon(ApplyStraightAxis(BuyingObject.transform.position));
		}
	}

	private void OnDestroyAndSubstituteBuyingObject(PlacementComponent newEditingObject)
	{
		BuyingObject = newEditingObject;
		LastTween = BuyingObject.MainObject.Model.transform.DOLocalMoveY(LtPlayerController.EditingObjectHeight, 0f).SetUpdate(isIndependentUpdate: true);
	}

	private void OnDestroyAndSubstituteLastPlacedConveyorBelt(PlacementComponent newEditingObject)
	{
		LastPlacedConveyorBelt = newEditingObject;
	}

	private void OnStraightModifierChanged(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Started)
		{
			StraightModifierEnabled = true;
		}
		else if (context.phase == InputActionPhase.Canceled)
		{
			StraightModifierEnabled = false;
		}
	}

	public void OnMovePointerMouse(InputValue inputValue)
	{
		pointerPosition = inputValue.Get<Vector2>();
		pointerPosition.x = Mathf.Clamp(pointerPosition.x, 0f, Screen.width);
		pointerPosition.y = Mathf.Clamp(pointerPosition.y, 0f, Screen.height);
		MovePointer(pointerPosition);
	}

	public void OnMovePointerJoystick(InputValue inputValue)
	{
		pointerPosition += inputValue.Get<Vector2>() * LtPlayerController.JoystickPointerSpeed * Time.unscaledDeltaTime;
		pointerPosition.x = Mathf.Clamp(pointerPosition.x, 0f, Screen.width);
		pointerPosition.y = Mathf.Clamp(pointerPosition.y, 0f, Screen.height);
		MovePointer(pointerPosition);
	}

	public void OnRotate(InputValue inputValue)
	{
		float num = inputValue.Get<float>();
		ShowBuyingObject(show: true);
		BuyingObject.Rotate(num * 90f, doAnimation: true);
		LtPlayerController.LastObjectRotation = BuyingObject.transform.rotation;
		AudioSystem.Instance.PlaySound2D(LtPlayerController.RotateObjectSFX, AudioSystem.EAudioMixerGroup.UI);
	}

	private void MovePointer(Vector2 position)
	{
		if (lockClicks)
		{
			return;
		}
		if (StraightModifierEnabled && straightModifierFirstObjectPosition.HasValue && !IsStraightModifierAxisSet())
		{
			Vector3 vector = LtPlayerController.GetPointerWorldPosition(position) - straightModifierStartClickPosition.Value;
			if ((double)vector.sqrMagnitude > Math.Pow(0.25, 2.0))
			{
				straightModifierAxis = vector.normalized;
				if (Mathf.Abs(straightModifierAxis.Value.x) >= Mathf.Abs(straightModifierAxis.Value.z))
				{
					Vector3 value = straightModifierAxis.Value;
					value.x = 1f;
					value.z = 0f;
					straightModifierAxis = value;
				}
				else
				{
					Vector3 value2 = straightModifierAxis.Value;
					value2.x = 0f;
					value2.z = 1f;
					straightModifierAxis = value2;
				}
			}
		}
		if (!BuyingObject)
		{
			return;
		}
		ShowBuyingObject(show: true);
		Vector3Int vector3Int = LTFunctionLibrary.GetGrid().SnapPositionToGrid(LtPlayerController.GetPointerWorldPosition(position) - BuyingObject.GetCenter(localSpace: true));
		if (lastGridPosition.HasValue && lastGridPosition.Value != vector3Int)
		{
			foreach (Vector3 item in LTFunctionLibrary.GetGridCellsBetween(lastGridPosition.Value, vector3Int))
			{
				Vector3 vector2 = item;
				if (onConfirmStarted && StraightModifierEnabled && IsStraightModifierAxisSet())
				{
					vector2 = ApplyStraightAxis(vector2);
				}
				if (vector2 != BuyingObject.transform.position)
				{
					BuyingObject.SetPositon(vector2);
					if (onConfirmStarted)
					{
						OnConfirmStarted(default(InputAction.CallbackContext));
					}
				}
			}
		}
		lastGridPosition = vector3Int;
	}

	private Vector3 ApplyStraightAxis(Vector3 position)
	{
		Vector3 value = straightModifierFirstObjectPosition.Value;
		value.Scale(Vector3.one - straightModifierAxis.Value);
		Vector3 vector = position;
		vector.Scale(straightModifierAxis.Value);
		return value + vector;
	}

	private bool IsStraightModifierAxisSet()
	{
		if (StraightModifierEnabled)
		{
			return straightModifierAxis.HasValue;
		}
		return false;
	}

	private void ResetStraightModifierVariables()
	{
		straightModifierFirstObjectPosition = null;
		straightModifierAxis = null;
		autoRotationLocked = false;
	}
}
