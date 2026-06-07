using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class EditModeInputMode : InputMode
{
	public Action<PlacementComponent> onEditingObjectChanged;

	[HideInInspector]
	private PlacementComponent editingObject;

	private Vector2 pointerPosition;

	private Vector3 originalPosition;

	private Quaternion originalRotation;

	private PlacementAreaMarker currentPlacementAreaMarker;

	private bool lockClicks;

	private bool isMouseOverUI;

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

	public PlacementComponent EditingObject
	{
		get
		{
			return editingObject;
		}
		set
		{
			ISelectable component;
			if ((bool)editingObject)
			{
				LtPlayerController.HighlightObject(editingObject.gameObject, highlight: false);
				editingObject.onDestroyAndSubstitute -= OnDestroyAndSubstituteEditingObject;
				if (editingObject.TryGetComponent<ISelectable>(out component))
				{
					component.Deselect();
				}
				LtPlayerController.HideDirectionArrows();
				UnityEngine.Object.Destroy(currentPlacementAreaMarker.gameObject);
			}
			editingObject = value;
			component = null;
			if ((bool)editingObject)
			{
				LtPlayerController.HighlightObject(editingObject.gameObject, highlight: true);
				editingObject.onDestroyAndSubstitute += OnDestroyAndSubstituteEditingObject;
				if (editingObject.TryGetComponent<ISelectable>(out component))
				{
					component.Select();
				}
				LtPlayerController.ShowDirectionArrows(editingObject);
				currentPlacementAreaMarker = UnityEngine.Object.Instantiate(LtPlayerController.PlacementAreaMakerPrefab);
				currentPlacementAreaMarker.CurrentPlacementComponent = EditingObject;
			}
			onEditingObjectChanged?.Invoke(editingObject);
		}
	}

	private void Awake()
	{
		inputModeType = EInputMode.EditMode;
	}

	private void Start()
	{
		LTFunctionLibrary.GetLTGameManager().ShowGrid(show: true, LTGameManager.EShowGridMode.Partial);
		LtPlayerController.PlayerInput.actions["ShowTooltips"].started += OnShowTooltipsStarted;
		LtPlayerController.PlayerInput.actions["ShowTooltips"].canceled += OnShowTooltipsCanceled;
		(LtPlayerController.PlayerCamera as IsometricCamera).onCameraMoved += OnCameraMoved;
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged += OnGameSpeedChanged;
		StartCoroutine(DelayInputCoroutine());
	}

	private IEnumerator DelayInputCoroutine()
	{
		lockClicks = true;
		yield return null;
		lockClicks = false;
	}

	private void Update()
	{
		if (!LtPlayerController.IsPlayerInputLocked)
		{
			isMouseOverUI = EventSystem.current.IsPointerOverGameObject();
			MovePointer(Mouse.current.position.value);
		}
	}

	private void OnDestroy()
	{
		LtPlayerController.PlayerInput.actions["ShowTooltips"].started -= OnShowTooltipsStarted;
		LtPlayerController.PlayerInput.actions["ShowTooltips"].canceled -= OnShowTooltipsCanceled;
		(LtPlayerController.PlayerCamera as IsometricCamera).onCameraMoved -= OnCameraMoved;
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged -= OnGameSpeedChanged;
		Cancel(playSound: false, switchMode: false);
	}

	private void OnDestroyAndSubstituteEditingObject(PlacementComponent newEditingObject)
	{
		EditingObject.MainObject.Model.transform.DOKill(complete: true);
		EditingObject = newEditingObject;
		EditingObject.MainObject.Model.transform.DOLocalMoveY(LtPlayerController.EditingObjectHeight, 0f).SetUpdate(isIndependentUpdate: true);
	}

	private void OnShowTooltipsStarted(InputAction.CallbackContext context)
	{
		LtPlayerController.ShowTooltips(show: true);
	}

	private void OnShowTooltipsCanceled(InputAction.CallbackContext context)
	{
		LtPlayerController.ShowTooltips(show: false);
	}

	public void StartEditingObject(PlacementComponent objectToEdit)
	{
		EditingObject = objectToEdit;
		EditingObject.Unplace();
		AudioSystem.Instance.PlaySound2D(LtPlayerController.UnplaceObjectSFX, AudioSystem.EAudioMixerGroup.UI);
		EditingObject.MainObject.Model.transform.DOLocalMoveY(LtPlayerController.EditingObjectHeight, LtPlayerController.EditingObjectHeightTime).SetEase(Ease.OutSine).SetUpdate(isIndependentUpdate: true);
		originalPosition = EditingObject.transform.position;
		originalRotation = EditingObject.transform.rotation;
	}

	private void OnConfirm()
	{
		if (!lockClicks && !isMouseOverUI && (bool)EditingObject)
		{
			if (EditingObject.CanBuildOnCurrentPosition())
			{
				EditingObject.Place();
				LtPlayerController.PlayPlaceObjectVFX(EditingObject);
				EditingObject.MainObject.Model.transform.DOLocalMoveY(0f, LtPlayerController.EditingObjectHeightTime).SetEase(Ease.OutSine).SetUpdate(isIndependentUpdate: true);
				AudioSystem.Instance.PlaySound2D(LtPlayerController.PlaceObjectSFX, AudioSystem.EAudioMixerGroup.UI);
				Physics.SyncTransforms();
				EditingObject = null;
				LtPlayerController.SwitchInputMode(EInputMode.Standard);
			}
			else
			{
				EditingObject.MainObject.Model.transform.DOLocalMoveY(LtPlayerController.EditingObjectHeight * 0.25f, LtPlayerController.EditingObjectHeightTime).SetEase(Ease.InSine).SetLoops(2, LoopType.Yoyo)
					.SetUpdate(isIndependentUpdate: true);
				AudioSystem.Instance.PlaySound2D(LtPlayerController.PlaceObjectErrorSFX, AudioSystem.EAudioMixerGroup.UI);
			}
		}
	}

	public void OnCancel(InputValue inputValue)
	{
		if (!lockClicks)
		{
			Cancel();
		}
	}

	private void OnSellBuilding(InputValue inputValue)
	{
		if (!lockClicks && (bool)EditingObject)
		{
			GameplayObjectData objectData = EditingObject.MainObject.ObjectData;
			if ((object)objectData != null && objectData.CanBeSold && FogOfWarController.instance.IsPositionVisible(EditingObject.transform.position) && LTFunctionLibrary.GetLTGameManager().SellBuilding(EditingObject.MainObject))
			{
				EditingObject = null;
				AudioSystem.Instance.PlaySound2D(LtPlayerController.SellObjectSFX, AudioSystem.EAudioMixerGroup.UI);
				LtPlayerController.SwitchInputMode(EInputMode.Standard);
			}
		}
	}

	private void Cancel(bool playSound = true, bool switchMode = true)
	{
		if ((bool)EditingObject)
		{
			EditingObject.SetPositon(originalPosition);
			EditingObject.SetRotation(originalRotation);
			EditingObject.MainObject.Model.transform.DOLocalMoveY(0f, 0f).SetUpdate(isIndependentUpdate: true);
			EditingObject.Place();
			EditingObject = null;
			if (playSound)
			{
				AudioSystem.Instance.PlaySound2D(LtPlayerController.CancelEditSFX, AudioSystem.EAudioMixerGroup.UI);
			}
			if (switchMode)
			{
				LtPlayerController.SwitchInputMode(EInputMode.Standard);
			}
		}
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
		if ((bool)EditingObject && !CheckIsGamePaused())
		{
			EditingObject.Rotate(num * 90f, doAnimation: true);
			LtPlayerController.LastObjectRotation = EditingObject.transform.rotation;
			AudioSystem.Instance.PlaySound2D(LtPlayerController.RotateObjectSFX, AudioSystem.EAudioMixerGroup.UI);
		}
	}

	private void MovePointer(Vector2 position)
	{
		if (!lockClicks && (bool)EditingObject)
		{
			Vector3 pointerWorldPosition = LtPlayerController.GetPointerWorldPosition();
			if (EditingObject.IsSquared())
			{
				pointerWorldPosition -= EditingObject.GetCenter(localSpace: true);
			}
			pointerWorldPosition = LTFunctionLibrary.GetGrid().SnapPositionToGrid(pointerWorldPosition);
			EditingObject.SetPositon(pointerWorldPosition);
		}
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

	private void OnGameSpeedChanged(TimeManager.ETimeSpeed timeSpeed, float speed)
	{
		if (timeSpeed == TimeManager.ETimeSpeed.Pause)
		{
			Cancel(playSound: false);
			Physics.SyncTransforms();
		}
	}

	private void OnShowTooltipsStarted()
	{
		LtPlayerController.ShowTooltips(show: true);
	}

	private void OnShowTooltipsCanceled()
	{
		LtPlayerController.ShowTooltips(show: false);
	}

	private void OnCameraMoved()
	{
		MovePointer(Mouse.current.position.value);
	}
}
