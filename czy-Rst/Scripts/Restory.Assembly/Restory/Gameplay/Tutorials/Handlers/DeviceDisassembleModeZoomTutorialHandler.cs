using System.Collections;
using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class DeviceDisassembleModeZoomTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly DeviceService deviceService;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly Transform tutorialIconsCanvas;

		private readonly DeviceDisassembleModeZoomTutorialSettings settings;

		private Coroutine zoomTrackingCoroutine;

		private GUI_MouseTooltip mouseTooltip;

		public DeviceDisassembleModeZoomTutorialHandler(DiContainer diContainer, DisassembleStateMachine disassembleStateMachine, DeviceService deviceService, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, ICoroutineRunner coroutineRunner, DeviceDisassembleModeZoomTutorial tutorial)
			: base(tutorial)
		{
			this.deviceService = deviceService;
			this.coroutineRunner = coroutineRunner;
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			this.disassembleStateMachine = disassembleStateMachine;
			this.diContainer = diContainer;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			ResolveStateMachineChangedState();
			disassembleStateMachine.OnStateChanged.AddListener(ResolveStateMachineChangedState);
		}

		public override void Cleanup()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveStateMachineChangedState);
			DestroyMouseTooltip();
			if (zoomTrackingCoroutine != null)
			{
				coroutineRunner.Stop(zoomTrackingCoroutine);
				zoomTrackingCoroutine = null;
			}
		}

		private void ResolveStateMachineChangedState()
		{
			if (base.IsCompleted)
			{
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if ((activeState is DetectionDisassembleState || activeState is PaintingDisassembleState) && deviceService.PlacedDeviceContainer.Device.HasAnyInstalledElement())
			{
				if (zoomTrackingCoroutine == null)
				{
					Transform transform = deviceService.PlacedDeviceContainer.Device.transform;
					mouseTooltip = CreateMouseTooltip(transform);
					mouseTooltip.PlayMouseWheelAnimation();
					zoomTrackingCoroutine = coroutineRunner.Run(ZoomTrackingCoroutine(transform));
				}
			}
			else
			{
				if (zoomTrackingCoroutine != null)
				{
					coroutineRunner.Stop(zoomTrackingCoroutine);
					zoomTrackingCoroutine = null;
				}
				DestroyMouseTooltip();
			}
		}

		private IEnumerator ZoomTrackingCoroutine(Transform target)
		{
			Vector3 objectStartingPosition = target.position;
			float oldDistance = Vector3.Distance(objectStartingPosition, target.position);
			float distanceChange = 0f;
			while (distanceChange < settings.ZoomAmountToCompleteTutorial)
			{
				yield return null;
				float num = Vector3.Distance(objectStartingPosition, target.position);
				distanceChange += Mathf.Abs(oldDistance - num);
				oldDistance = num;
			}
			zoomTrackingCoroutine = null;
			DestroyMouseTooltip();
			CompleteTutorial();
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
