using Restory.Data.Devices.Quality;
using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Gameplay.Work.StateMachine;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class WorkOrderShipmentTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly DeviceRegistry deviceRegistry;

		private readonly DeviceService deviceService;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly ShipmentService shipmentService;

		private readonly PackageStacker packageStacker;

		private readonly WorkStateMachine workStateMachine;

		private readonly Transform tutorialIconsCanvas;

		private readonly WorkOrderShipmentTutorialSettings settings;

		private DeviceContainer trackedDevice;

		private GUI_MouseTooltip mouseTooltip;

		[Inject]
		public WorkOrderShipmentTutorialHandler(DiContainer diContainer, DeviceRegistry deviceRegistry, DeviceService deviceService, DragObjectRegistrator dragObjectRegistrator, ShipmentService shipmentService, PackageStacker packageStacker, WorkStateMachine workStateMachine, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, WorkOrderShipmentTutorial tutorial)
			: base(tutorial)
		{
			this.diContainer = diContainer;
			this.deviceRegistry = deviceRegistry;
			this.deviceService = deviceService;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.shipmentService = shipmentService;
			this.packageStacker = packageStacker;
			this.workStateMachine = workStateMachine;
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			deviceService.OnPlacedDeviceQualityChanged += ResolvePlacedDeviceQualityChanged;
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
			shipmentService.OnShipmentStorageContentChanged += ResolveShipmentStorageContentChanged;
			workStateMachine.OnStateChanged.AddListener(ResolveWorkStateChanged);
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (item.Quality is IdealDeviceQuality)
				{
					trackedDevice = item;
					ActivateTooltips();
					break;
				}
			}
		}

		public override void Cleanup()
		{
			deviceService.OnPlacedDeviceQualityChanged -= ResolvePlacedDeviceQualityChanged;
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
			shipmentService.OnShipmentStorageContentChanged -= ResolveShipmentStorageContentChanged;
			workStateMachine.OnStateChanged.RemoveListener(ResolveWorkStateChanged);
			trackedDevice = null;
			DestroyMouseTooltip();
		}

		private void ResolvePlacedDeviceQualityChanged()
		{
			if (!base.IsCompleted && (bool)deviceService.PlacedDeviceContainer)
			{
				if (deviceService.PlacedDeviceContainer.Quality is IdealDeviceQuality)
				{
					trackedDevice = deviceService.PlacedDeviceContainer;
				}
				else if ((bool)trackedDevice && trackedDevice == deviceService.PlacedDeviceContainer)
				{
					trackedDevice = null;
				}
			}
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			if (!base.IsCompleted && (bool)trackedDevice && dragObjectRegistrator.DraggingObject == trackedDevice)
			{
				packageStacker.ToggleIndicator(isActive: true);
			}
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			if (!base.IsCompleted)
			{
				packageStacker.ToggleIndicator(isActive: false);
			}
		}

		private void ResolveWorkStateChanged()
		{
			if (!base.IsCompleted && (bool)trackedDevice)
			{
				if (workStateMachine.ActiveState is DetectionWorkState)
				{
					ActivateTooltips();
					return;
				}
				trackedDevice.ToggleIndicator(isActive: false);
				DestroyMouseTooltip();
			}
		}

		private void ResolveShipmentStorageContentChanged()
		{
			if (base.IsCompleted || !trackedDevice)
			{
				return;
			}
			foreach (IShipmentPack item in shipmentService.ShipmentStorageContent)
			{
				if (item is ShipmentDevicePack shipmentDevicePack && !(shipmentDevicePack.DeviceContainer != trackedDevice))
				{
					packageStacker.ToggleIndicator(isActive: false);
					trackedDevice = null;
					CompleteTutorial();
				}
			}
		}

		private void ActivateTooltips()
		{
			trackedDevice.ToggleIndicator(isActive: true);
			mouseTooltip = CreateMouseTooltip(trackedDevice.transform);
			mouseTooltip.PlayDragDownTopAnimation();
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
