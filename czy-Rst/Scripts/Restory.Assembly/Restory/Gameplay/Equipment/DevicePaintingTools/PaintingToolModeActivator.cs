using Restory.Data.Devices.Quality;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.Work.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingToolModeActivator : MonoBehaviour
	{
		private DisassembleStateMachine disassembleStateMachine;

		private WorkStateMachine workStateMachine;

		private DeviceService deviceService;

		private PaintingToolWorkplaceItem paintingTool;

		private GameWarningService gameWarningService;

		private GameWarningDatabase gameWarningDatabase;

		private DisassembleGameMode disassembleGameMode;

		[Inject]
		private void Construct(DisassembleStateMachine disassembleStateMachine, WorkStateMachine workStateMachine, DeviceService deviceService, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase, PaintingToolWorkplaceItem paintingTool, DisassembleGameMode disassembleGameMode)
		{
			this.gameWarningDatabase = gameWarningDatabase;
			this.workStateMachine = workStateMachine;
			this.disassembleStateMachine = disassembleStateMachine;
			this.deviceService = deviceService;
			this.gameWarningService = gameWarningService;
			this.paintingTool = paintingTool;
			this.disassembleGameMode = disassembleGameMode;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)paintingTool)
			{
				Init();
			}
		}

		private void Init()
		{
			paintingTool.Trigger.OnClick += ResolveTriggerClick;
		}

		private void OnDisable()
		{
			if (paintingTool.MonoShellExists() && paintingTool.Trigger.MonoShellExists())
			{
				paintingTool.Trigger.OnClick -= ResolveTriggerClick;
			}
		}

		private void ResolveTriggerClick()
		{
			PaintableDevice component;
			if (workStateMachine.ActiveState is DetectionWorkState)
			{
				if (!deviceService.PlacedDeviceContainer || !deviceService.PlacedDeviceContainer.Device)
				{
					gameWarningService.ShowWarning(gameWarningDatabase.NoPaintableDevicePlacedWarning);
					return;
				}
				if (!deviceService.PlacedDeviceContainer.Device.TryGetComponent<PaintableDevice>(out component))
				{
					gameWarningService.ShowWarning(gameWarningDatabase.PlacedDeviceIsUnpaintableWarning);
					return;
				}
				if (!(deviceService.PlacedDeviceContainer.Quality is IdealDeviceQuality))
				{
					gameWarningService.ShowWarning(gameWarningDatabase.DeviceQualityUnpaintableWarning);
					return;
				}
				deviceService.PlacedDeviceContainer.Activate();
				disassembleGameMode.PrepareEnteringStraightToPaintingMode();
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is EmptyDisassembleState))
			{
				if (!(activeState is DetectionDisassembleState))
				{
					if (activeState is PaintingDisassembleState)
					{
						disassembleStateMachine.Enter<DetectionDisassembleState>();
					}
				}
				else if ((bool)deviceService.PlacedDeviceContainer && (bool)deviceService.PlacedDeviceContainer.Device && deviceService.PlacedDeviceContainer.Device.TryGetComponent<PaintableDevice>(out component))
				{
					if (deviceService.PlacedDeviceContainer.Quality is IdealDeviceQuality)
					{
						disassembleStateMachine.Enter<PaintingDisassembleState>();
					}
					else
					{
						gameWarningService.ShowWarning(gameWarningDatabase.DeviceQualityUnpaintableWarning);
					}
				}
				else
				{
					gameWarningService.ShowWarning(gameWarningDatabase.PlacedDeviceIsUnpaintableWarning);
				}
			}
			else
			{
				gameWarningService.ShowWarning(gameWarningDatabase.NoPaintableDevicePlacedWarning);
			}
		}
	}
}
