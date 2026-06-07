using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class StandardInputMode : InputMode
{
	private const float SELL_MOUSE_DISTANCE = 20f;

	private readonly string[] INTERACTIVE_LAYERS = new string[2] { "Gameplay", "Enemy" };

	private MouseInteractive cursorInteractive;

	private GameplayObject highlightedObject;

	private ISelectable selectedObject;

	private Vector2 lastSellMousePosition = Vector2.zero;

	private Camera mainCamera;

	private bool onSellBuildingStarted;

	private bool isInteracting;

	private bool isMouseOverUI;

	private bool lockClicks;

	private PlacementComponent auxPlacementComponent;

	public GameplayObject HighlightedObject
	{
		get
		{
			return highlightedObject;
		}
		set
		{
			if (!(highlightedObject == value))
			{
				if ((bool)highlightedObject && (SelectedObject.IsUnityNull() || (SelectedObject as MonoBehaviour).gameObject != highlightedObject.gameObject))
				{
					LtPlayerController.HighlightObject(highlightedObject.gameObject, highlight: false);
				}
				highlightedObject = value;
				if ((bool)highlightedObject)
				{
					LtPlayerController.HighlightObject(highlightedObject.gameObject, highlight: true);
				}
				UpdateCursorAspect(highlightedObject);
				this.onHighlightedObjectChanged?.Invoke(highlightedObject);
			}
		}
	}

	public MouseInteractive CursorInteractive
	{
		get
		{
			return cursorInteractive;
		}
		set
		{
			if (!(cursorInteractive == value))
			{
				if ((bool)cursorInteractive)
				{
					cursorInteractive.EndLeftClick();
				}
				cursorInteractive = value;
			}
		}
	}

	public LTPlayerController LtPlayerController => playerController as LTPlayerController;

	public ISelectable SelectedObject
	{
		get
		{
			return selectedObject;
		}
		set
		{
			if (value == selectedObject)
			{
				return;
			}
			if (!selectedObject.IsUnityNull())
			{
				selectedObject.Deselect();
				if (HighlightedObject == null || (SelectedObject as MonoBehaviour).gameObject != HighlightedObject.gameObject)
				{
					LtPlayerController.HighlightObject((selectedObject as MonoBehaviour).gameObject, highlight: false);
				}
			}
			selectedObject = value;
			if (!selectedObject.IsUnityNull())
			{
				selectedObject.Select();
				LtPlayerController.HighlightObject((selectedObject as MonoBehaviour).gameObject, highlight: true);
			}
			else
			{
				selectedObject = null;
			}
			this.onSelectedObjectChanged?.Invoke(selectedObject);
		}
	}

	private bool IsInteracting
	{
		get
		{
			return isInteracting;
		}
		set
		{
			isInteracting = value;
			if ((bool)CursorInteractive && CursorInteractive.TryGetComponent<Source>(out var component))
			{
				if (IsInteracting)
				{
					component.onClickFarmingPerformed += OnSourceClickPerformed;
				}
				else
				{
					component.onClickFarmingPerformed -= OnSourceClickPerformed;
				}
			}
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

	public event Action<ISelectable> onSelectedObjectChanged;

	public event Action<GameplayObject> onHighlightedObjectChanged;

	public event Action<Source> onSourceClickPerformed;

	private void Awake()
	{
		inputModeType = EInputMode.Standard;
	}

	private void Start()
	{
		LTFunctionLibrary.GetLTGameManager().ShowGrid(show: false, LTGameManager.EShowGridMode.Partial);
		BindEvents();
		StartCoroutine(DelayInputCoroutine());
	}

	private IEnumerator DelayInputCoroutine()
	{
		lockClicks = true;
		yield return null;
		lockClicks = false;
	}

	private void OnApplicationFocus(bool focus)
	{
		if (!focus && (bool)CursorInteractive && IsInteracting)
		{
			CursorInteractive.EndLeftClick();
			IsInteracting = false;
		}
	}

	private void OnDestroy()
	{
		IsInteracting = false;
		CursorInteractive = null;
		HighlightedObject = null;
		SelectedObject = null;
		LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Default);
		UnbindEvents();
	}

	private void BindEvents()
	{
		LtPlayerController.onPlayerInputLocked += OnPlayerInputLocked;
		LtPlayerController.PlayerInput.actions["InteractMouse"].started += OnInteractMouseStarted;
		LtPlayerController.PlayerInput.actions["InteractMouse"].canceled += OnInteractMouseCanceled;
		LtPlayerController.PlayerInput.actions["SecondaryInteractMouse"].started += OnSecondaryMouseStarted;
		LtPlayerController.PlayerInput.actions["SecondaryInteractMouse"].canceled += OnSecondaryMouseCanceled;
		LtPlayerController.PlayerInput.actions["SellBuilding"].started += OnSellBuildingStarted;
		LtPlayerController.PlayerInput.actions["SellBuilding"].canceled += OnSellBuildingCanceled;
		LtPlayerController.PlayerInput.actions["ShowTooltips"].started += OnShowTooltipsStarted;
		LtPlayerController.PlayerInput.actions["ShowTooltips"].canceled += OnShowTooltipsCanceled;
	}

	private void UnbindEvents()
	{
		LtPlayerController.onPlayerInputLocked -= OnPlayerInputLocked;
		LtPlayerController.PlayerInput.actions["InteractMouse"].started -= OnInteractMouseStarted;
		LtPlayerController.PlayerInput.actions["InteractMouse"].canceled -= OnInteractMouseCanceled;
		LtPlayerController.PlayerInput.actions["SecondaryInteractMouse"].started -= OnSecondaryMouseStarted;
		LtPlayerController.PlayerInput.actions["SecondaryInteractMouse"].canceled -= OnSecondaryMouseCanceled;
		LtPlayerController.PlayerInput.actions["SellBuilding"].started -= OnSellBuildingStarted;
		LtPlayerController.PlayerInput.actions["SellBuilding"].canceled -= OnSellBuildingCanceled;
		LtPlayerController.PlayerInput.actions["ShowTooltips"].started -= OnShowTooltipsStarted;
		LtPlayerController.PlayerInput.actions["ShowTooltips"].canceled -= OnShowTooltipsCanceled;
	}

	private void Update()
	{
		if (LtPlayerController.IsPlayerInputLocked || lockClicks)
		{
			return;
		}
		isMouseOverUI = EventSystem.current.IsPointerOverGameObject();
		if (IsInteracting)
		{
			if (CursorInteractive == null)
			{
				IsInteracting = false;
			}
		}
		else
		{
			UpdateCursorObject();
		}
	}

	public void OnInteractMouseStarted(InputAction.CallbackContext context)
	{
		if (isMouseOverUI || LtPlayerController.IsPlayerInputLocked || lockClicks)
		{
			return;
		}
		if ((bool)CursorInteractive)
		{
			if (CheckIsGamePausedFarm())
			{
				return;
			}
			IsInteracting = true;
			CursorInteractive.StartLeftClick();
		}
		if (Physics.Raycast(MainCamera.ScreenPointToRay(Mouse.current.position.value), out var hitInfo, 100f, LayerMask.GetMask(INTERACTIVE_LAYERS)) && FogOfWarController.instance.IsPositionVisible(hitInfo.collider.transform.position))
		{
			SelectedObject = hitInfo.collider.gameObject.GetComponentInParent<ISelectable>();
			if (!SelectedObject.IsUnityNull())
			{
				AudioSystem.Instance.PlaySound2D(LtPlayerController.SelectObjectSFX, AudioSystem.EAudioMixerGroup.UI);
			}
		}
		else
		{
			SelectedObject = null;
		}
	}

	public void OnInteractMouseCanceled(InputAction.CallbackContext context)
	{
		if (IsInteracting && (bool)CursorInteractive)
		{
			CursorInteractive.EndLeftClick();
			IsInteracting = false;
		}
	}

	public void OnSecondaryMouseStarted(InputAction.CallbackContext context)
	{
		if (isMouseOverUI || LtPlayerController.IsPlayerInputLocked || lockClicks)
		{
			return;
		}
		SelectedObject = null;
		if (!HighlightedObject || !FogOfWarController.instance.IsPositionVisible(HighlightedObject.transform.position) || !HighlightedObject.TryGetComponent<PlacementComponent>(out var component))
		{
			return;
		}
		if (LTFunctionLibrary.GetPlayerData().PlayerBuildingsAndTowers.Contains(HighlightedObject))
		{
			if (!CheckIsGamePausedBuild())
			{
				if (!component.CanBeMovedByPlayer)
				{
					string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantBeMoved", null, FallbackBehavior.UseProjectSettings);
					LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
				}
				else
				{
					LtPlayerController.StartEditingObject(component);
				}
			}
		}
		else
		{
			OnInteractMouseStarted(default(InputAction.CallbackContext));
		}
	}

	public void OnSecondaryMouseCanceled(InputAction.CallbackContext context)
	{
		if (IsInteracting && (bool)CursorInteractive)
		{
			CursorInteractive.EndLeftClick();
			IsInteracting = false;
		}
	}

	public void OnRotate(InputValue inputValue)
	{
		if (lockClicks)
		{
			return;
		}
		float num = inputValue.Get<float>();
		if (!HighlightedObject || !FogOfWarController.instance.IsPositionVisible(HighlightedObject.transform.position) || !HighlightedObject.TryGetComponent<PlacementComponent>(out var placementComponent) || CheckIsGamePausedBuild())
		{
			return;
		}
		if (!placementComponent.CanBeMovedByPlayer)
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantBeMoved", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
			return;
		}
		placementComponent.Unplace();
		placementComponent.onDestroyAndSubstitute += delegate(PlacementComponent newPlacementComponent)
		{
			placementComponent = newPlacementComponent;
		};
		for (int num2 = 0; num2 < 4; num2++)
		{
			placementComponent.Rotate(num * 90f, doAnimation: true);
			AudioSystem.Instance.PlaySound2D(LtPlayerController.RotateObjectSFX, AudioSystem.EAudioMixerGroup.UI);
			if (placementComponent.Place(checkCanBuildOnCurrentPosition: true, allowAutoSellableObjects: false))
			{
				break;
			}
		}
		LtPlayerController.LastObjectRotation = placementComponent.transform.rotation;
	}

	private void OnSellBuildingStarted(InputAction.CallbackContext context)
	{
		if (!lockClicks && !CheckIsGamePausedBuild())
		{
			onSellBuildingStarted = true;
			CheckHasToSellBuilding(isSingleClickSell: true);
		}
	}

	private void OnSellBuildingCanceled(InputAction.CallbackContext context)
	{
		onSellBuildingStarted = false;
		LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Default);
	}

	private void OnShowTooltipsStarted(InputAction.CallbackContext context)
	{
		if (!lockClicks)
		{
			LtPlayerController.ShowTooltips(show: true);
		}
	}

	private void OnShowTooltipsCanceled(InputAction.CallbackContext context)
	{
		LtPlayerController.ShowTooltips(show: false);
	}

	private void OnSampleBuilding(InputValue inputValue)
	{
		if (lockClicks || !Physics.Raycast(MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()), out var hitInfo, 100f, LayerMask.GetMask("Gameplay")))
		{
			return;
		}
		GameplayObject componentInParent = hitInfo.collider.gameObject.GetComponentInParent<GameplayObject>();
		if (!componentInParent || !componentInParent.ObjectData)
		{
			return;
		}
		GameplayObjectData gameplayObjectData = (componentInParent.ObjectData.IsUpgrade() ? componentInParent.ObjectData.BaseObject : componentInParent.ObjectData);
		if (componentInParent.gameObject.TryGetComponent<ConveyorBelt_curve>(out var component))
		{
			gameplayObjectData = component.ConveyorBelt_StraightPrefab.ObjectData;
		}
		if (LTFunctionLibrary.GetPlayerData().IsBuildingUnlocked(gameplayObjectData))
		{
			ISampleableData sampleableData = null;
			if (componentInParent.TryGetComponent<ISampleableData>(out var component2))
			{
				sampleableData = component2;
			}
			LTFunctionLibrary.GetLTPlayerController().StartBuyingObject(gameplayObjectData, null, componentInParent.transform.rotation, sampleableData);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowBuyModeUI();
			AudioSystem.Instance.PlaySound2D(LtPlayerController.SampleObjectSFX, AudioSystem.EAudioMixerGroup.UI);
		}
	}

	private void CheckHasToSellBuilding(bool isSingleClickSell)
	{
		PlacementComponent placementComponent = null;
		if (!isSingleClickSell && Vector2.Distance(lastSellMousePosition, Mouse.current.position.ReadValue()) < 20f)
		{
			return;
		}
		if (Physics.Raycast(MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()), out var hitInfo, 100f, LayerMask.GetMask("Gameplay")))
		{
			placementComponent = hitInfo.collider.gameObject.GetComponentInParent<PlacementComponent>();
		}
		if (!placementComponent || !LTFunctionLibrary.GetPlayerData().PlayerBuildingsAndTowers.Contains(placementComponent.MainObject))
		{
			return;
		}
		if (!isSingleClickSell)
		{
			GameplayObject gameplayObject = placementComponent?.MainObject;
			if ((object)gameplayObject != null && (bool)gameplayObject && placementComponent.MainObject.ObjectData.Type == EGameplayObjectType.Tower)
			{
				return;
			}
		}
		if ((bool)placementComponent && placementComponent.MainObject.ObjectData != null && FogOfWarController.instance.IsPositionVisible(placementComponent.transform.position))
		{
			if (LTFunctionLibrary.GetLTGameManager().SellBuilding(placementComponent.MainObject))
			{
				SelectedObject = null;
				HighlightedObject = null;
				lastSellMousePosition = Mouse.current.position.ReadValue();
				AudioSystem.Instance.PlaySound2D(LtPlayerController.SellObjectSFX, AudioSystem.EAudioMixerGroup.UI);
			}
			else if (isSingleClickSell)
			{
				string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantBeSold", null, FallbackBehavior.UseProjectSettings);
				LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
			}
		}
	}

	private void UpdateCursorObject()
	{
		RaycastHit hitInfo;
		if (isMouseOverUI)
		{
			CursorInteractive = null;
			HighlightedObject = null;
		}
		else if (onSellBuildingStarted)
		{
			CheckHasToSellBuilding(isSingleClickSell: false);
			HighlightedObject = null;
			LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Sell);
		}
		else if (Physics.Raycast(MainCamera.ScreenPointToRay(Mouse.current.position.value), out hitInfo, 100f, LayerMask.GetMask(INTERACTIVE_LAYERS)))
		{
			auxPlacementComponent = hitInfo.collider.gameObject.GetComponentInParent<PlacementComponent>();
			if (((bool)auxPlacementComponent && auxPlacementComponent.IsVisible()) || FogOfWarController.instance.IsPositionVisible(hitInfo.collider.transform.position))
			{
				CursorInteractive = hitInfo.collider.gameObject.GetComponentInParent<MouseInteractive>();
				if ((bool)CursorInteractive || hitInfo.collider.gameObject.GetComponentInParent<ISelectable>() != null || ((bool)auxPlacementComponent && auxPlacementComponent.CanBeMovedByPlayer))
				{
					HighlightedObject = hitInfo.collider.gameObject.GetComponentInParent<GameplayObject>();
				}
				else
				{
					HighlightedObject = null;
				}
			}
		}
		else
		{
			CursorInteractive = null;
			HighlightedObject = null;
		}
	}

	private void UpdateCursorAspect(GameplayObject highlightedObject)
	{
		if (!highlightedObject)
		{
			LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Default);
			return;
		}
		Source component = highlightedObject.GetComponent<Source>();
		if ((bool)component)
		{
			if (component.Resource.Id == "wood")
			{
				LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Axe);
			}
			else if (component.Resource.Id == "stone")
			{
				LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Pickaxe);
			}
			else if (component.Resource.Id == "coal")
			{
				LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Pickaxe);
			}
			else if (component.Resource.Id == "iron")
			{
				LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Pickaxe);
			}
		}
		else if ((bool)highlightedObject.ObjectData && (highlightedObject.ObjectData.Type == EGameplayObjectType.Tower || highlightedObject.ObjectData.Type == EGameplayObjectType.Extractor || highlightedObject.ObjectData.Type == EGameplayObjectType.Processor))
		{
			LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Config);
		}
		else
		{
			LtPlayerController.CursorController.SetCursor(CursorController.ECursor.Highlight);
		}
	}

	private void OnPlayerInputLocked(bool locked)
	{
		if (locked)
		{
			if ((bool)CursorInteractive && IsInteracting)
			{
				CursorInteractive.EndLeftClick();
				IsInteracting = false;
			}
			lockClicks = true;
			CursorInteractive = null;
			HighlightedObject = null;
			SelectedObject = null;
		}
		else
		{
			lockClicks = false;
		}
	}

	private void OnSourceClickPerformed(Source source)
	{
		this.onSourceClickPerformed?.Invoke(source);
	}

	private bool CheckIsGamePausedFarm()
	{
		if (LTFunctionLibrary.GetTimeManager().GetGameSpeed() == TimeManager.ETimeSpeed.Pause)
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantFarmWhilePause", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
			return true;
		}
		return false;
	}

	private bool CheckIsGamePausedBuild()
	{
		if (!MatchInfo.instance.CurrentMatchSettings.BuildDuringPause && LTFunctionLibrary.GetTimeManager().GetGameSpeed() == TimeManager.ETimeSpeed.Pause)
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_notification_cantBuildWhilePause", null, FallbackBehavior.UseProjectSettings);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error, 0.75f);
			return true;
		}
		return false;
	}
}
