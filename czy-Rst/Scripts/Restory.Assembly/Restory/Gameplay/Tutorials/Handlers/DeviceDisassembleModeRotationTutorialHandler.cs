using System.Collections;
using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class DeviceDisassembleModeRotationTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly DeviceService deviceService;

		private readonly DisassembleRotationController rotationController;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly Transform tutorialIconsCanvas;

		private readonly DeviceDisassembleModeRotationTutorialSettings settings;

		private Coroutine rotationTrackingCoroutine;

		private GUI_MouseTooltip mouseTooltip;

		public DeviceDisassembleModeRotationTutorialHandler(DiContainer diContainer, DisassembleStateMachine disassembleStateMachine, DeviceService deviceService, DisassembleRotationController rotationController, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, ICoroutineRunner coroutineRunner, DeviceDisassembleModeRotationTutorial tutorial)
			: base(tutorial)
		{
			this.deviceService = deviceService;
			this.coroutineRunner = coroutineRunner;
			this.rotationController = rotationController;
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
			if (rotationTrackingCoroutine != null)
			{
				coroutineRunner.Stop(rotationTrackingCoroutine);
				rotationTrackingCoroutine = null;
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
				if (rotationTrackingCoroutine == null)
				{
					Transform transform = deviceService.PlacedDeviceContainer.Device.transform;
					mouseTooltip = CreateMouseTooltip(transform);
					mouseTooltip.PlayRightButtonHoldAndDragAnimation();
					rotationTrackingCoroutine = coroutineRunner.Run(RotationTrackingCoroutine());
				}
			}
			else
			{
				if (rotationTrackingCoroutine != null)
				{
					coroutineRunner.Stop(rotationTrackingCoroutine);
					rotationTrackingCoroutine = null;
				}
				DestroyMouseTooltip();
			}
		}

		private IEnumerator RotationTrackingCoroutine()
		{
			Vector3? oldRotation = null;
			float angleChange = 0f;
			while (angleChange < settings.RotationAngleToCompleteTutorial)
			{
				if ((bool)rotationController.TargetTransform)
				{
					if (!oldRotation.HasValue)
					{
						oldRotation = rotationController.TargetTransform.rotation.eulerAngles;
					}
					else if (rotationController.IsRotating)
					{
						Vector3 eulerAngles = rotationController.TargetTransform.rotation.eulerAngles;
						angleChange += Mathf.Abs(Vector3.Angle(oldRotation.Value, eulerAngles));
						oldRotation = eulerAngles;
					}
				}
				yield return null;
			}
			rotationTrackingCoroutine = null;
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
