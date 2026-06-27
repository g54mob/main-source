using System.Collections.Generic;
using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Gameplay.Visits;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class FirstDeviceInteractionTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly DeviceRegistry deviceRegistry;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly CurrentDayVisitsQueueService visitsService;

		private readonly DeviceService deviceService;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly WorkSurface workSurface;

		private readonly Transform tutorialIconsCanvas;

		private readonly FirstDeviceInteractionTutorialSettings settings;

		private DeviceContainer trackedDevice;

		private GUI_MouseTooltip mouseTooltip;

		private bool wasDevicePlacedOnSurface;

		[Inject]
		public FirstDeviceInteractionTutorialHandler(DiContainer diContainer, DeviceRegistry deviceRegistry, DragObjectRegistrator dragObjectRegistrator, CurrentDayVisitsQueueService visitsService, DeviceService deviceService, DisassembleStateMachine disassembleStateMachine, WorkSurface workSurface, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, FirstDeviceInteractionTutorial tutorial)
			: base(tutorial)
		{
			this.diContainer = diContainer;
			this.deviceRegistry = deviceRegistry;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.visitsService = visitsService;
			this.deviceService = deviceService;
			this.disassembleStateMachine = disassembleStateMachine;
			this.workSurface = workSurface;
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
			visitsService.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			StartTrackingAnyExistingDevice();
		}

		public override void Cleanup()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
			visitsService.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			StopTrackingDevice();
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (!base.IsCompleted)
			{
				StartTrackingAnyExistingDevice();
			}
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			if (!base.IsCompleted)
			{
				StopTrackingDevice();
				if (dragObjectRegistrator.DraggingObject is DeviceContainer && !deviceService.PlacedDeviceContainer)
				{
					workSurface.ToggleIndicator(isActive: true);
				}
			}
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			if (!base.IsCompleted)
			{
				workSurface.ToggleIndicator(isActive: false);
				if ((bool)deviceService.PlacedDeviceContainer)
				{
					wasDevicePlacedOnSurface = true;
					StartTrackingDevice(deviceService.PlacedDeviceContainer, isPlaced: true);
				}
				else
				{
					StartTrackingAnyExistingDevice();
				}
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!base.IsCompleted)
			{
				IExitableState activeState = disassembleStateMachine.ActiveState;
				if (activeState is DetectionDisassembleState || activeState is PaintingDisassembleState)
				{
					StopTrackingDevice();
					CompleteTutorial();
				}
			}
		}

		private void StartTrackingAnyExistingDevice()
		{
			if ((bool)trackedDevice)
			{
				return;
			}
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (item.State == InteractiveObjectState.Placed)
				{
					StartTrackingDevice(item, isPlaced: true);
					return;
				}
			}
			using IEnumerator<DeviceContainer> enumerator = deviceRegistry.All.GetEnumerator();
			if (enumerator.MoveNext())
			{
				DeviceContainer current2 = enumerator.Current;
				StartTrackingDevice(current2, isPlaced: false);
			}
		}

		private void StartTrackingDevice(DeviceContainer deviceContainer, bool isPlaced)
		{
			StopTrackingDevice();
			trackedDevice = deviceContainer;
			trackedDevice.ToggleIndicator(isActive: true);
			if (!wasDevicePlacedOnSurface || isPlaced)
			{
				mouseTooltip = CreateMouseTooltip(deviceContainer.transform);
				if (isPlaced)
				{
					mouseTooltip.PlayLeftClickAnimation();
				}
				else
				{
					mouseTooltip.PlayDragTopDownAnimation();
				}
			}
		}

		private void StopTrackingDevice()
		{
			if ((bool)trackedDevice)
			{
				trackedDevice.ToggleIndicator(isActive: false);
				trackedDevice = null;
				DestroyMouseTooltip();
			}
		}

		private GUI_MouseTooltip CreateMouseTooltip(Transform target)
		{
			DestroyMouseTooltip();
			GUI_MouseTooltip gUI_MouseTooltip = diContainer.InstantiatePrefabForComponent<GUI_MouseTooltip>(settings.MouseTooltipPrefab.gameObject, tutorialIconsCanvas);
			gUI_MouseTooltip.Init(target);
			return gUI_MouseTooltip;
		}

		private void DestroyMouseTooltip()
		{
			if ((bool)mouseTooltip)
			{
				Object.Destroy(mouseTooltip.gameObject);
			}
		}
	}
}
