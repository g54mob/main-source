using System;
using Restory.Constants;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.Ultrasonic;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.UserInterface;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class EmptyDisassembleState : IState, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<EmptyDisassembleState>
		{
		}

		private readonly RaycastHit[] raycastHits = new RaycastHit[4];

		private readonly IPlayerInput playerInput;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly UltrasonicService ultrasonicService;

		private readonly DeviceService deviceService;

		private readonly WorkSurface workSurface;

		private readonly GUI_DisassembleObjectGameModeCanvas disassembleCanvas;

		private readonly DisassembleRotationController rotationController;

		private readonly DisassembleStateMachine stateMachine;

		private readonly LayerMask detectionLayerMask;

		private ElementBase selectedElement;

		[Inject]
		public EmptyDisassembleState(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, UltrasonicService ultrasonicService, DeviceService deviceService, WorkSurface workSurface, GUI_DisassembleObjectGameModeCanvas disassembleCanvas, DisassembleRotationController rotationController, DisassembleStateMachine stateMachine)
		{
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.ultrasonicService = ultrasonicService;
			this.deviceService = deviceService;
			this.workSurface = workSurface;
			this.disassembleCanvas = disassembleCanvas;
			this.rotationController = rotationController;
			this.stateMachine = stateMachine;
			detectionLayerMask = ProjectConstants.Layers.ElementsMask | ProjectConstants.Layers.ClickableObjectsMask;
		}

		public void Enter()
		{
			if ((bool)deviceService.PlacedDeviceContainer)
			{
				Debug.LogError("Placed device " + deviceService.PlacedDeviceContainer.Device.Info.ID + " exists on EmptyDisassembleState");
				stateMachine.Enter<DetectionDisassembleState>();
				return;
			}
			workSurface.ToggleNoDeviceOnSurfaceSign(isActive: true);
			disassembleCanvas.SetDevice(null);
			rotationController.TargetTransform = null;
			SubscribeInputEvents();
		}

		public void OnUpdate(float deltaTime)
		{
			int hitCount;
			if (cursorDetectorService.UIDetector.TryToDetect(playerInput.GetMousePosition(), out var hitObject))
			{
				ResetSelectedElement();
				cursorSelectionService.SetDetection(hitObject, uiObjectDetected: true);
			}
			else if (cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), detectionLayerMask, raycastHits, out hitCount))
			{
				HandleDetectionResult(hitCount);
			}
			else
			{
				ResetSelectedElement();
				cursorSelectionService.ClearDetection();
			}
		}

		public void Exit()
		{
			workSurface.ToggleNoDeviceOnSurfaceSign(isActive: false);
			UnsubscribeInputEvents();
			ResetSelectedElement();
			cursorSelectionService.ClearDetection();
		}

		public void Dispose()
		{
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
		}

		private void UnsubscribeInputEvents()
		{
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
		}

		private void HandleDetectionResult(int hitCount)
		{
			bool flag = false;
			RaycastHit raycastHit = raycastHits[0];
			for (int i = 0; i < hitCount; i++)
			{
				if (raycastHits[i].collider.gameObject.layer == ProjectConstants.Layers.Elements)
				{
					if (!flag)
					{
						raycastHit = raycastHits[i];
						flag = true;
					}
					else if (raycastHits[i].distance < raycastHit.distance)
					{
						raycastHit = raycastHits[i];
					}
				}
				else if (!flag && raycastHits[i].distance < raycastHit.distance)
				{
					raycastHit = raycastHits[i];
				}
			}
			cursorSelectionService.SetDetection(raycastHit.collider.gameObject);
			if (!raycastHit.transform.TryGetComponent<ElementBase>(out var component))
			{
				ResetSelectedElement();
			}
			else if (selectedElement != component)
			{
				SetSelectedElement(component);
			}
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			if ((bool)selectedElement && !selectedElement.IsBlocked && ultrasonicService.TryRetrieveElementFromSonicBath(selectedElement))
			{
				stateMachine.Enter<DraggingDisassembleState, ElementBase>(selectedElement);
			}
		}

		private void SetSelectedElement(ElementBase element)
		{
			ResetSelectedElement();
			selectedElement = element;
			selectedElement.IsSelected = true;
			cursorSelectionService.SetDetection(selectedElement.gameObject);
		}

		private void ResetSelectedElement()
		{
			if ((bool)selectedElement)
			{
				selectedElement.IsSelected = false;
				selectedElement = null;
			}
		}
	}
}
