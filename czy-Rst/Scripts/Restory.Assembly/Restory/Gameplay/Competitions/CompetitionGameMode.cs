using System;
using System.Collections;
using Restory.Data.Devices.Quality;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Disassemble.Tooltips;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.SaveLoad.Services;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Competitions
{
	public sealed class CompetitionGameMode : MonoBehaviour, ITimeChangeReceiver
	{
		private GameCalendar gameCalendar;

		private DeviceService deviceService;

		private WorkplaceRugSwitcher rugSwitcher;

		private CompetitionTimerView competitionTimerView;

		private PlacedElementsHandler placedElementsHandler;

		private DragElementRegistrator dragElementRegistrator;

		private DisassembleStateMachine disassembleStateMachine;

		private CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker;

		private CompetitionsResultsTrackingService competitionsResultsTrackingService;

		private GameplaySaveLoadService gameplaySaveLoadService;

		private ElementAssembleController elementAssembleController;

		private DisassembleTooltipService disassembleTooltipService;

		private DeviceShadow deviceShadow;

		private DateTime lastCheckTime;

		private float gameSecondsTimer;

		private bool wasCompetitionCompleted;

		private DeviceContainer currentDeviceInCompetition;

		private ElementBase currentDraggedElement;

		private Coroutine resetDeviceAfterEndOfFrameCoroutine;

		public bool HasDeviceInCompetition => currentDeviceInCompetition;

		public bool WasDeviceInCompetitionSuccessfullyAssembled
		{
			get
			{
				if ((bool)currentDeviceInCompetition)
				{
					return currentDeviceInCompetition.Quality is IdealDeviceQuality;
				}
				return false;
			}
		}

		public DeviceContainer CurrentDeviceInCompetition => currentDeviceInCompetition;

		public event Action OnCompetitionPrepared;

		public event Action OnCompetitionSuccessfullyCompleted;

		[Inject]
		private void Construct(GameCalendar gameCalendar, DeviceService deviceService, WorkplaceRugSwitcher rugSwitcher, CompetitionTimerView competitionTimerView, PlacedElementsHandler placedElementsHandler, DragElementRegistrator dragElementRegistrator, DisassembleStateMachine disassembleStateMachine, CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker, CompetitionsResultsTrackingService competitionsResultsTrackingService, GameplaySaveLoadService gameplaySaveLoadService, ElementAssembleController elementAssembleController, DisassembleTooltipService disassembleTooltipService, DeviceShadow deviceShadow)
		{
			this.gameplaySaveLoadService = gameplaySaveLoadService;
			this.competitionsResultsTrackingService = competitionsResultsTrackingService;
			this.competitionsDeviceContainersTracker = competitionsDeviceContainersTracker;
			this.disassembleStateMachine = disassembleStateMachine;
			this.dragElementRegistrator = dragElementRegistrator;
			this.placedElementsHandler = placedElementsHandler;
			this.competitionTimerView = competitionTimerView;
			this.deviceService = deviceService;
			this.gameCalendar = gameCalendar;
			this.rugSwitcher = rugSwitcher;
			this.elementAssembleController = elementAssembleController;
			this.disassembleTooltipService = disassembleTooltipService;
			this.deviceShadow = deviceShadow;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)deviceService)
			{
				Init();
			}
		}

		private void Init()
		{
			gameplaySaveLoadService.OnLoadCompleted += ResolveGameLoadingCompleted;
		}

		private void ResolveGameLoadingCompleted()
		{
			gameplaySaveLoadService.OnLoadCompleted -= ResolveGameLoadingCompleted;
			ResolvePlacedDeviceChanged();
			deviceService.OnPlacedDeviceChanged += ResolvePlacedDeviceChanged;
		}

		private void OnDisable()
		{
			if (gameplaySaveLoadService.MonoShellExists())
			{
				gameplaySaveLoadService.OnLoadCompleted -= ResolveGameLoadingCompleted;
			}
			if (resetDeviceAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(resetDeviceAfterEndOfFrameCoroutine);
				resetDeviceAfterEndOfFrameCoroutine = null;
			}
			if (deviceService.MonoShellExists())
			{
				deviceService.OnPlacedDeviceChanged -= ResolvePlacedDeviceChanged;
			}
			if (dragElementRegistrator != null)
			{
				dragElementRegistrator.OnElementStartDrag -= ResolveElementStartedDragging;
				dragElementRegistrator.OnElementStopDrag -= ResolveElementStoppedDragging;
			}
		}

		private bool TryToPrepareCompetition()
		{
			if (!deviceService.PlacedDeviceContainer || !deviceService.PlacedDeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) || !foundProperty.DeviceCondition.IsPartOfCompetition)
			{
				return false;
			}
			currentDeviceInCompetition = deviceService.PlacedDeviceContainer;
			if (competitionsDeviceContainersTracker.TryGetCompetitionData(currentDeviceInCompetition, out var currentTimeInGameSeconds, out var wasCompleted, out var wasPreviousTimeBested, out var _))
			{
				gameSecondsTimer = currentTimeInGameSeconds;
				wasCompetitionCompleted = wasCompleted;
			}
			else
			{
				competitionsDeviceContainersTracker.TryAddNewCompetition(currentDeviceInCompetition, placedElementsHandler.GetPlacedElements().GetData());
				gameSecondsTimer = 0f;
				wasCompetitionCompleted = false;
			}
			competitionTimerView.SetPreviousBestTime(competitionsResultsTrackingService.TryGetBestTimeForDevice(currentDeviceInCompetition.Device.Info, out var bestTime) ? bestTime : ((float)currentDeviceInCompetition.Device.Info.CompetitionDefaultBestTimeInGameSeconds));
			CompetitionState competitionState = (wasCompetitionCompleted ? (wasPreviousTimeBested ? CompetitionState.Success_NewBestTime : CompetitionState.Success_WorseThanPreviousTime) : CompetitionState.None);
			competitionTimerView.UpdateView(gameSecondsTimer, competitionState);
			if (wasCompetitionCompleted)
			{
				DisableDisassemblyOfElements();
			}
			this.OnCompetitionPrepared?.Invoke();
			return true;
		}

		public bool TryStartCompetition()
		{
			DeviceContainer placedDeviceContainer = deviceService.PlacedDeviceContainer;
			if (!placedDeviceContainer || !placedDeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) || !foundProperty.DeviceCondition.IsPartOfCompetition || placedDeviceContainer.Quality is IdealDeviceQuality || wasCompetitionCompleted)
			{
				return false;
			}
			Debug.Log("COMPETITION STARTED");
			elementAssembleController.AdjustRotationEnabled = false;
			elementAssembleController.ProjectionEnabled = false;
			disassembleTooltipService.IsActive = false;
			lastCheckTime = gameCalendar.CurrentDateTime;
			gameCalendar.AddSubscriber(this);
			disassembleStateMachine.OnStateEntered.AddListener(ResolveDisassembleStateChanged);
			dragElementRegistrator.OnElementStartDrag += ResolveElementStartedDragging;
			dragElementRegistrator.OnElementStopDrag += ResolveElementStoppedDragging;
			return true;
		}

		public void StopCompetition()
		{
			if ((bool)currentDeviceInCompetition)
			{
				Stop();
				currentDraggedElement = null;
			}
		}

		public void UnpauseCompetitionTimer()
		{
			lastCheckTime = gameCalendar.CurrentDateTime;
			gameCalendar.AddSubscriber(this);
		}

		public void ProcessTimeChanged()
		{
			if ((bool)currentDeviceInCompetition && !(currentDeviceInCompetition.Quality is IdealDeviceQuality))
			{
				gameSecondsTimer += (float)(gameCalendar.CurrentDateTime - lastCheckTime).TotalSeconds;
				lastCheckTime = gameCalendar.CurrentDateTime;
				competitionTimerView.UpdateView(gameSecondsTimer);
			}
		}

		private void SuccessfullyCompleteCompetition()
		{
			Debug.Log("COMPETITION COMPLETED!");
			wasCompetitionCompleted = true;
			bool flag = competitionsResultsTrackingService.TryRecordNewTime(currentDeviceInCompetition.Device.Info, gameSecondsTimer);
			bool flag2 = gameSecondsTimer < (float)currentDeviceInCompetition.Device.Info.CompetitionDefaultBestTimeInGameSeconds && flag;
			competitionsDeviceContainersTracker.TrySetNewCompetitionTimeForExistingCompetition(currentDeviceInCompetition, gameSecondsTimer, wasCompetitionCompleted, flag2);
			competitionTimerView.UpdateView(gameSecondsTimer, flag2 ? CompetitionState.Success_NewBestTime : CompetitionState.Success_WorseThanPreviousTime);
			DisableDisassemblyOfElements();
			Stop();
			currentDraggedElement = null;
			this.OnCompetitionSuccessfullyCompleted?.Invoke();
		}

		private void StopAndRemoveDevice()
		{
			Stop();
			currentDeviceInCompetition = null;
			currentDraggedElement = null;
		}

		private void Stop()
		{
			Debug.Log("COMPETITION STOPPED");
			if (resetDeviceAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(resetDeviceAfterEndOfFrameCoroutine);
				resetDeviceAfterEndOfFrameCoroutine = null;
			}
			elementAssembleController.AdjustRotationEnabled = true;
			elementAssembleController.ProjectionEnabled = true;
			disassembleTooltipService.IsActive = true;
			gameCalendar.RemoveSubscriber(this);
			disassembleStateMachine.OnStateEntered.RemoveListener(ResolveDisassembleStateChanged);
			dragElementRegistrator.OnElementStartDrag -= ResolveElementStartedDragging;
			dragElementRegistrator.OnElementStopDrag -= ResolveElementStoppedDragging;
		}

		private void ResolvePlacedDeviceChanged()
		{
			if ((bool)currentDeviceInCompetition && currentDeviceInCompetition != deviceService.PlacedDeviceContainer)
			{
				competitionsDeviceContainersTracker.TrySetNewCompetitionTimeForExistingCompetition(currentDeviceInCompetition, gameSecondsTimer, setCompetitionToCompleted: false, setCompetitionToHaveBeatenPreviousBestTime: false);
				StopAndRemoveDevice();
			}
			if (TryToPrepareCompetition())
			{
				rugSwitcher.SwitchRug(shouldUseMainRug: false);
				deviceShadow.SetCompetitionDeviceShadow();
			}
			else
			{
				rugSwitcher.SwitchRug(shouldUseMainRug: true);
				deviceShadow.SetDefaultDeviceShadow();
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			if (disassembleStateMachine.ActiveState is CheckDeviceDisassembleState && currentDeviceInCompetition.Quality is IdealDeviceQuality)
			{
				SuccessfullyCompleteCompetition();
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is EmptyDisassembleState || activeState is DisabledDisassembleState)
			{
				competitionsDeviceContainersTracker.TrySetNewCompetitionTimeForExistingCompetition(currentDeviceInCompetition, gameSecondsTimer, setCompetitionToCompleted: false, setCompetitionToHaveBeatenPreviousBestTime: false);
			}
		}

		private void ResolveElementStartedDragging()
		{
			currentDraggedElement = dragElementRegistrator.DraggingElement;
		}

		private void ResolveElementStoppedDragging()
		{
			if (!currentDraggedElement)
			{
				return;
			}
			if (!currentDraggedElement.InSocket)
			{
				competitionTimerView.UpdateView(gameSecondsTimer, CompetitionState.Failure);
				if (resetDeviceAfterEndOfFrameCoroutine == null)
				{
					resetDeviceAfterEndOfFrameCoroutine = StartCoroutine(ResetDeviceAfterEndOfFrameCoroutine());
				}
			}
			currentDraggedElement = null;
		}

		private IEnumerator ResetDeviceAfterEndOfFrameCoroutine()
		{
			yield return new WaitForEndOfFrame();
			resetDeviceAfterEndOfFrameCoroutine = null;
			ResetDevice();
		}

		private void ResetDevice()
		{
			if (!currentDeviceInCompetition || !competitionsDeviceContainersTracker.TryGetElementsInitialPlacement(currentDeviceInCompetition, out var elementsInitialPlacement))
			{
				return;
			}
			foreach (ElementSocket elementSocket in currentDeviceInCompetition.Device.ElementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					elementSocket.DetachAndUnblockElementWithoutNotifyingLinkedSockets();
				}
				elementSocket.Deactivate();
			}
			placedElementsHandler.RestorePlacedElementsToInitialPositions(elementsInitialPlacement);
		}

		private void DisableDisassemblyOfElements()
		{
			foreach (ElementSocket elementSocket in currentDeviceInCompetition.Device.ElementSockets)
			{
				if ((bool)elementSocket && (bool)elementSocket.NestedElement)
				{
					elementSocket.NestedElement.BehaviorSwitcher.SwitchToPackedBehavior();
				}
			}
		}
	}
}
