using System;
using Restory.Constants;
using Restory.Data.Localization;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Equipment.DevicePaintingTools.DeviceAdditionalProperties;
using Restory.Gameplay.Equipment.Ultrasonic;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.GameView;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.Quests;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class DetectionDisassembleState : IState, IExitableState, IDisposable, IUpdatableState, IConfirmationRequester
	{
		public class Factory : PlaceholderFactory<DetectionDisassembleState>
		{
		}

		private readonly RaycastHit[] raycastHits = new RaycastHit[8];

		private readonly IPlayerInput playerInput;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly CameraDirectionSwitcher cameraDirectionSwitcher;

		private readonly DisassembleRotationController rotationController;

		private readonly UltrasonicService ultrasonicService;

		private readonly DeviceService deviceService;

		private readonly ConfirmationService confirmationService;

		private readonly SpecifiedLocalizationKeysDatabase specifiedLocalizationKeysDatabase;

		private readonly DisassembleStateMachine stateMachine;

		private readonly LayerMask detectionLayerMask;

		private ElementBase selectedElement;

		private ElementProjection selectedProjection;

		private ElementButton selectedButton;

		private bool isWaitingForConfirmation;

		[Inject]
		public DetectionDisassembleState(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, CameraDirectionSwitcher cameraDirectionSwitcher, DisassembleRotationController rotationController, UltrasonicService ultrasonicService, DeviceService deviceService, ConfirmationService confirmationService, SpecifiedLocalizationKeysDatabase specifiedLocalizationKeysDatabase, DisassembleStateMachine stateMachine)
		{
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.rotationController = rotationController;
			this.ultrasonicService = ultrasonicService;
			this.deviceService = deviceService;
			this.confirmationService = confirmationService;
			this.specifiedLocalizationKeysDatabase = specifiedLocalizationKeysDatabase;
			this.stateMachine = stateMachine;
			detectionLayerMask = ProjectConstants.Layers.DeviceMask | ProjectConstants.Layers.ElementsMask | ProjectConstants.Layers.ProjectionsMask | ProjectConstants.Layers.ClickableObjectsMask;
		}

		public void Enter()
		{
			isWaitingForConfirmation = false;
			SubscribeInputEvents();
		}

		public void OnUpdate(float deltaTime)
		{
			if (isWaitingForConfirmation)
			{
				return;
			}
			cameraDirectionSwitcher.OnUpdate();
			rotationController.OnUpdate();
			if (!playerInput.GetButton(71))
			{
				int hitCount;
				if (cursorDetectorService.UIDetector.TryToDetect(playerInput.GetMousePosition(), out var hitObject))
				{
					ResetDetection();
					cursorSelectionService.SetDetection(hitObject, uiObjectDetected: true);
				}
				else if (!rotationController.IsRotationButtonPressed && cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), detectionLayerMask, raycastHits, out hitCount))
				{
					HandleDetectionResult(hitCount);
				}
				else
				{
					ResetDetection();
					cursorSelectionService.ClearDetection();
				}
			}
		}

		public void Exit()
		{
			UnsubscribeInputEvents();
			ResetDetection();
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
				RaycastHit raycastHit2 = raycastHits[i];
				if (raycastHit2.transform.gameObject.layer == ProjectConstants.Layers.Projections)
				{
					ElementProjection component = raycastHit2.transform.gameObject.GetComponent<ElementProjection>();
					cursorSelectionService.SetDetection(raycastHit2.collider.gameObject);
					ResetSelectedElement();
					ResetSelectedButton();
					if (!(selectedProjection == component))
					{
						if ((bool)selectedProjection)
						{
							ResetSelectedProjection();
						}
						if ((bool)component)
						{
							selectedProjection = component;
							selectedProjection.MakeBright();
						}
					}
					return;
				}
				if (raycastHit2.collider.gameObject.layer == ProjectConstants.Layers.Elements || raycastHit2.collider.gameObject.layer == ProjectConstants.Layers.Device)
				{
					if (!flag)
					{
						raycastHit = raycastHit2;
						flag = true;
					}
					else if (raycastHit2.distance < raycastHit.distance)
					{
						raycastHit = raycastHit2;
					}
				}
				else if (!flag && raycastHit2.distance < raycastHit.distance)
				{
					raycastHit = raycastHit2;
				}
			}
			ResetSelectedProjection();
			cursorSelectionService.SetDetection(raycastHit.collider.gameObject);
			if (raycastHit.collider.TryGetComponent<ElementButton>(out var component2))
			{
				ResetSelectedElement();
				if (selectedButton != component2)
				{
					SetSelectedButton(component2);
				}
				return;
			}
			ResetSelectedButton();
			if (!raycastHit.transform.TryGetComponent<ElementBase>(out var component3))
			{
				ResetSelectedElement();
			}
			else if (selectedElement != component3)
			{
				SetSelectedElement(component3);
			}
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			if (isWaitingForConfirmation)
			{
				return;
			}
			if ((bool)selectedProjection)
			{
				selectedProjection.Activate();
			}
			else if ((bool)selectedButton)
			{
				selectedButton.Press();
			}
			else if (!selectedElement || selectedElement.IsBlocked)
			{
				if (selectedElement is ISwitchableElement switchableElement)
				{
					switchableElement.InitSwitchInteraction();
					ResetSelectedElement();
				}
			}
			else if (selectedElement is QuestItem questItem)
			{
				questItem.Discover();
				stateMachine.Enter<DraggingDisassembleState, ElementBase>(selectedElement);
			}
			else if (ultrasonicService.TryRetrieveElementFromSonicBath(selectedElement))
			{
				stateMachine.Enter<DraggingDisassembleState, ElementBase>(selectedElement);
			}
			else if (!selectedElement.InSocket)
			{
				selectedElement.PlacementPositionHandler.LastPlacementPosition = selectedElement.transform.position;
				stateMachine.Enter<DraggingDisassembleState, ElementBase>(selectedElement);
			}
			else if (deviceService.PlacedDeviceContainer.AdditionalProperties.ContainsProperty<DevicePaintedAdditionalProperty>())
			{
				isWaitingForConfirmation = true;
				confirmationService.RequestConfirmation(this, specifiedLocalizationKeysDatabase.ResetDeviceCustomizationConfirmationDialogue);
			}
			else
			{
				selectedElement.PlacementPositionHandler.LastPlacementPosition = Vector3.zero;
				stateMachine.Enter<DismantleDisassembleState, ElementBase>(selectedElement);
			}
		}

		public void OnConfirmationResponse(bool isConfirmed)
		{
			if (isConfirmed && deviceService.PlacedDeviceContainer.Device.TryGetComponent<PaintableDevice>(out var component))
			{
				component.CleanPaintingTexture();
				component.ClearRegisteredPalettes();
				deviceService.PlacedDeviceContainer.AdditionalProperties.RemoveProperty<DevicePaintedAdditionalProperty>();
			}
			isWaitingForConfirmation = false;
		}

		private void ResetDetection()
		{
			ResetSelectedProjection();
			ResetSelectedElement();
			ResetSelectedButton();
		}

		private void ResetSelectedProjection()
		{
			if ((bool)selectedProjection)
			{
				selectedProjection.MakeDim();
				selectedProjection = null;
			}
		}

		private void ResetSelectedElement()
		{
			if ((bool)selectedElement)
			{
				selectedElement.IsSelected = false;
				selectedElement = null;
			}
		}

		private void ResetSelectedButton()
		{
			if ((bool)selectedButton)
			{
				selectedButton.IsSelected = false;
				selectedButton = null;
			}
		}

		private void SetSelectedElement(ElementBase element)
		{
			ResetSelectedElement();
			selectedElement = element;
			selectedElement.IsSelected = true;
			cursorSelectionService.SetDetection(selectedElement.gameObject);
		}

		private void SetSelectedButton(ElementButton button)
		{
			ResetSelectedButton();
			selectedButton = button;
			selectedButton.IsSelected = true;
			cursorSelectionService.SetDetection(selectedButton.gameObject);
		}
	}
}
