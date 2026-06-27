using System;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.Painting;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.UserInterface.DeviceCustomizations;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.DevicePaintingTool;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class PaintingDisassembleState : IState, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<PaintingDisassembleState>
		{
		}

		private readonly IPlayerInput playerInput;

		private readonly GUI_DevicePainterPanel painterPanel;

		private readonly DeviceService deviceService;

		private readonly DevicePainter devicePainter;

		private readonly DisassembleStateMachine stateMachine;

		private readonly GUI_DeviceCustomizationPanel deviceCustomizationPanel;

		private readonly BrushMode brushMode;

		private readonly StickerMode stickerMode;

		private IPaintingMode paintingMode;

		[Inject]
		public PaintingDisassembleState(IPlayerInput playerInput, DeviceService deviceService, DevicePainter devicePainter, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, DisassembleRotationController rotationController, TextureSaveLoadService textureSaveLoadService, TextureCacheService textureCacheService, GUI_DevicePainterPanel painterPanel, DisassembleStateMachine stateMachine, GUI_DeviceCustomizationPanel deviceCustomizationPanel, PaintingBrushSFX paintingBrushSfx)
		{
			this.playerInput = playerInput;
			this.painterPanel = painterPanel;
			this.deviceService = deviceService;
			this.devicePainter = devicePainter;
			this.stateMachine = stateMachine;
			this.deviceCustomizationPanel = deviceCustomizationPanel;
			brushMode = new BrushMode(playerInput, deviceService, cursorDetectorService, cursorSelectionService, rotationController, textureSaveLoadService, textureCacheService, devicePainter, deviceCustomizationPanel, paintingBrushSfx);
			stickerMode = new StickerMode(playerInput, cursorDetectorService, cursorSelectionService, deviceCustomizationPanel);
		}

		public void Enter()
		{
			if (!deviceService.PlacedDeviceContainer)
			{
				Debug.LogError("There is no device to paint!");
				return;
			}
			devicePainter.SetTarget(deviceService.PlacedDeviceContainer);
			deviceCustomizationPanel.Init(deviceService.PlacedDeviceContainer);
			deviceCustomizationPanel.Show();
			if (paintingMode == null)
			{
				paintingMode = brushMode;
				painterPanel.SetBrushMode();
			}
			paintingMode.Enter();
			SubscribeInputEvents();
		}

		public void OnUpdate(float deltaTime)
		{
			paintingMode.OnUpdate(deltaTime);
		}

		public void Exit()
		{
			UnsubscribeInputEvents();
			deviceCustomizationPanel.Hide();
			if (paintingMode != null)
			{
				paintingMode.Exit();
			}
			devicePainter.ResetTarget();
		}

		public void Dispose()
		{
		}

		public void Stop()
		{
			stateMachine.Enter<DetectionDisassembleState>();
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
			playerInput.AddInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
			playerInput.AddInputEventDelegate(ResolveOnUnDoJustPressed, InputActionEventType.ButtonJustPressed, 140);
			playerInput.AddInputEventDelegate(ResolveOnReDoJustPressed, InputActionEventType.ButtonJustPressed, 141);
			painterPanel.OnSwitchRequested += ResolvePaintingModeSwitchRequested;
		}

		private void UnsubscribeInputEvents()
		{
			playerInput.RemoveInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
			playerInput.RemoveInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
			playerInput.RemoveInputEventDelegate(ResolveOnUnDoJustPressed, InputActionEventType.ButtonJustPressed, 140);
			playerInput.RemoveInputEventDelegate(ResolveOnReDoJustPressed, InputActionEventType.ButtonJustPressed, 141);
			painterPanel.OnSwitchRequested -= ResolvePaintingModeSwitchRequested;
		}

		private void ResolvePaintingModeSwitchRequested()
		{
			if (paintingMode == null)
			{
				Debug.LogError("paintingMode is null");
				return;
			}
			paintingMode.Exit();
			if (paintingMode == brushMode)
			{
				paintingMode = stickerMode;
				painterPanel.SetStickerMode();
			}
			else
			{
				paintingMode = brushMode;
				painterPanel.SetBrushMode();
			}
			paintingMode.Enter();
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			paintingMode.PressExecuteButton();
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			paintingMode.ReleaseExecuteButton();
		}

		private void ResolveOnReDoJustPressed(InputActionEventData eventData)
		{
			paintingMode.Redo();
		}

		private void ResolveOnUnDoJustPressed(InputActionEventData eventData)
		{
			paintingMode.Undo();
		}
	}
}
