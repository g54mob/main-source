using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Gameplay.Work.StateMachine;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class ReplaceDeviceTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly WorkStateMachine workStateMachine;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly DeviceService deviceService;

		private readonly Transform tutorialIconsCanvas;

		private readonly ReplaceDeviceTutorialSettings settings;

		private DeviceContainer trackedDevice;

		private GUI_MouseTooltip mouseTooltip;

		private bool isActivated;

		[Inject]
		public ReplaceDeviceTutorialHandler(DiContainer diContainer, DragObjectRegistrator dragObjectRegistrator, WorkStateMachine workStateMachine, DisassembleStateMachine disassembleStateMachine, DeviceService deviceService, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, ReplaceDeviceTutorial tutorial)
			: base(tutorial)
		{
			this.diContainer = diContainer;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.workStateMachine = workStateMachine;
			this.disassembleStateMachine = disassembleStateMachine;
			this.deviceService = deviceService;
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
			workStateMachine.OnStateChanged.AddListener(ResolveWorkStateChanged);
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		public override void Cleanup()
		{
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
			workStateMachine.OnStateChanged.RemoveListener(ResolveWorkStateChanged);
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			DestroyMouseTooltip();
			if ((bool)trackedDevice)
			{
				trackedDevice.ToggleIndicator(isActive: false);
			}
			trackedDevice = null;
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			if (!base.IsCompleted && isActivated && (bool)trackedDevice)
			{
				if (trackedDevice.State == InteractiveObjectState.Placed)
				{
					mouseTooltip = CreateMouseTooltip(trackedDevice.transform);
					mouseTooltip.PlayDragAnimation();
					trackedDevice.ToggleIndicator(isActive: true);
				}
				else
				{
					trackedDevice.ToggleIndicator(isActive: false);
					trackedDevice = null;
					Complete();
				}
			}
		}

		private void ResolveWorkStateChanged()
		{
			if (base.IsCompleted || !isActivated)
			{
				return;
			}
			if (!(workStateMachine.ActiveState is DetectionWorkState))
			{
				DestroyMouseTooltip();
				if ((bool)trackedDevice)
				{
					trackedDevice.ToggleIndicator(isActive: false);
				}
			}
			else if ((bool)deviceService.PlacedDeviceContainer && !(deviceService.PlacedDeviceContainer.Device.Info != settings.TargetDeviceInfo))
			{
				trackedDevice = deviceService.PlacedDeviceContainer;
				mouseTooltip = CreateMouseTooltip(trackedDevice.transform);
				mouseTooltip.PlayDragAnimation();
				trackedDevice.ToggleIndicator(isActive: true);
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!base.IsCompleted && (bool)deviceService.PlacedDeviceContainer && deviceService.PlacedDeviceContainer.Device.Info == settings.TargetDeviceInfo)
			{
				isActivated = true;
			}
		}

		private void Complete()
		{
			if (!base.IsCompleted)
			{
				CompleteTutorial();
			}
		}

		private GUI_MouseTooltip CreateMouseTooltip(Transform target)
		{
			DestroyMouseTooltip();
			GUI_MouseTooltip gUI_MouseTooltip = diContainer.InstantiatePrefabForComponent<GUI_MouseTooltip>(settings.TooltipPrefab.gameObject, tutorialIconsCanvas);
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
