using System;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public sealed class DisassembleTooltipService : IInitializable, IDisposable
	{
		private readonly IPlayerInput playerInput;

		private readonly DeviceService deviceService;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly IDisassembleTooltipHandler disassembleTooltipHandler;

		private readonly ICleanAndRepairTooltipHandler cleanAndRepairTooltipHandler;

		private readonly SmallElementTooltipHandler smallElementTooltipHandler;

		private bool isActive = true;

		private Device targetDevice;

		private bool isDisassembling;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				isActive = value;
			}
		}

		[Inject]
		public DisassembleTooltipService(IPlayerInput playerInput, DeviceService deviceService, DisassembleStateMachine disassembleStateMachine, IDisassembleTooltipHandler disassembleTooltipHandler, ICleanAndRepairTooltipHandler cleanAndRepairTooltipHandler, SmallElementTooltipHandler smallElementTooltipHandler)
		{
			this.playerInput = playerInput;
			this.deviceService = deviceService;
			this.disassembleStateMachine = disassembleStateMachine;
			this.disassembleTooltipHandler = disassembleTooltipHandler;
			this.cleanAndRepairTooltipHandler = cleanAndRepairTooltipHandler;
			this.smallElementTooltipHandler = smallElementTooltipHandler;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			playerInput.AddInputEventDelegate(ResolveGetTooltipButtonPressed, InputActionEventType.ButtonJustPressed, 99);
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			playerInput.RemoveInputEventDelegate(ResolveGetTooltipButtonPressed, InputActionEventType.ButtonJustPressed, 99);
			ClearTargetDevice();
		}

		private void SetTargetDevice()
		{
			ClearTargetDevice();
			if (!deviceService.PlacedDeviceContainer)
			{
				return;
			}
			targetDevice = deviceService.PlacedDeviceContainer.Device;
			targetDevice.OnDisabled += ResolveDeviceDisabled;
			isDisassembling = false;
			foreach (ElementSocket elementSocket in targetDevice.ElementSockets)
			{
				elementSocket.OnNestedElementChanged += ResolveDeviceSocketChanged;
				if ((bool)elementSocket.NestedElement && !(elementSocket.NestedElement.ConditionHandler.ElementData.Condition is PerfectElementCondition))
				{
					isDisassembling = true;
				}
			}
			if (targetDevice.CheckIntegrity())
			{
				isDisassembling = true;
			}
		}

		private void ClearTargetDevice()
		{
			if (!targetDevice)
			{
				return;
			}
			foreach (ElementSocket elementSocket in targetDevice.ElementSockets)
			{
				elementSocket.OnNestedElementChanged -= ResolveDeviceSocketChanged;
			}
			targetDevice.OnDisabled -= ResolveDeviceDisabled;
			targetDevice = null;
			cleanAndRepairTooltipHandler.HideTooltip();
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is DisabledDisassembleState || activeState is EmptyDisassembleState)
			{
				ClearTargetDevice();
			}
			else if (!targetDevice)
			{
				SetTargetDevice();
			}
		}

		private void ResolveDeviceDisabled()
		{
			if (!targetDevice)
			{
				Debug.LogError("DisassembleTooltipService still subscribed to Device, but reference to targetDevice is lost");
			}
			else
			{
				ClearTargetDevice();
			}
		}

		private void ResolveDeviceSocketChanged(ElementSocket socket)
		{
			if (targetDevice.CheckIntegrity())
			{
				isDisassembling = true;
				return;
			}
			if (!targetDevice.HasAnyInstalledElement())
			{
				isDisassembling = false;
				return;
			}
			isDisassembling = !socket.NestedElement;
			smallElementTooltipHandler.OnSocketChanged(socket);
		}

		private void ResolveGetTooltipButtonPressed(InputActionEventData eventData)
		{
			if (IsActive && disassembleStateMachine.ActiveState is DetectionDisassembleState)
			{
				cleanAndRepairTooltipHandler.ShowTooltip();
				if (isDisassembling)
				{
					disassembleTooltipHandler.ShowDisassemblingTooltip(targetDevice);
				}
				else
				{
					disassembleTooltipHandler.ShowAssemblingTooltip(targetDevice);
				}
			}
		}
	}
}
