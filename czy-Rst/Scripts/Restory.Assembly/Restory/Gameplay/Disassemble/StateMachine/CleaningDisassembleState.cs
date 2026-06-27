using System;
using Mandragora.PWS;
using Restory.Audio;
using Restory.Constants;
using Restory.Data.Elements.Condition;
using Restory.Data.Equipment;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.UserInterface;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.CleaningToolsSelectionWindow;
using Restory.Utils;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class CleaningDisassembleState : IPayloadedState<ElementBase>, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<CleaningDisassembleState>
		{
		}

		private readonly IPlayerInput playerInput;

		private readonly DeviceService deviceService;

		private readonly WorkSurface workSurface;

		private readonly ElementCleaner elementCleaner;

		private readonly SolderingService solderingService;

		private readonly GUI_ElementCleanerPanel cleanerPanel;

		private readonly GUI_CleaningToolsSelectionWindow cleaningToolsSelectionWindow;

		private readonly CleaningToolSelectionService cleaningToolSelectionService;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly DisassembleRotationController rotationController;

		private readonly DisassembleStateMachine stateMachine;

		private readonly AvailableToolsTrackingService availableToolsTrackingService;

		private readonly DefaultElementConditions defaultElementConditions;

		private readonly IAudioPlayerService audioPlayer;

		private ElementBase selectedElement;

		private Quaternion disassembleRotationCache;

		private bool isExecuteButtonPressed;

		private bool isCleaningComplete;

		[Inject]
		public CleaningDisassembleState(IPlayerInput playerInput, DeviceService deviceService, WorkSurface workSurface, ElementCleaner elementCleaner, SolderingService solderingService, GUI_ElementCleanerPanel cleanerPanel, GUI_CleaningToolsSelectionWindow cleaningToolsSelectionWindow, CleaningToolSelectionService cleaningToolSelectionService, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, DisassembleRotationController rotationController, DisassembleStateMachine stateMachine, AvailableToolsTrackingService availableToolsTrackingService, DefaultElementConditions defaultElementConditions, IAudioPlayerService audioPlayer)
		{
			this.playerInput = playerInput;
			this.deviceService = deviceService;
			this.workSurface = workSurface;
			this.elementCleaner = elementCleaner;
			this.solderingService = solderingService;
			this.cleanerPanel = cleanerPanel;
			this.cleaningToolsSelectionWindow = cleaningToolsSelectionWindow;
			this.cleaningToolSelectionService = cleaningToolSelectionService;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.rotationController = rotationController;
			this.stateMachine = stateMachine;
			this.availableToolsTrackingService = availableToolsTrackingService;
			this.defaultElementConditions = defaultElementConditions;
			this.audioPlayer = audioPlayer;
		}

		public void Enter(ElementBase selectedElement)
		{
			this.selectedElement = selectedElement;
			isCleaningComplete = false;
			disassembleRotationCache = deviceService.PlacedDeviceContainer.DisassemblePoint.rotation;
			selectedElement.transform.SetParent(deviceService.PlacedDeviceContainer.DisassemblePoint);
			elementCleaner.SetCleaningTool(cleaningToolSelectionService.CurrentlySelectedTool);
			elementCleaner.SetTarget(selectedElement);
			CleaningProgressInPercentage cleaningProgress = elementCleaner.CalculateProgress();
			InitSoldering(cleaningProgress);
			SolderingProgressInPercentage currentProgress = solderingService.GetCurrentProgress();
			cleanerPanel.UpdateCleaningProgress(cleaningProgress, currentProgress);
			SubscribeInputEvents();
			cleaningToolSelectionService.OnToolSwitched += ResolveCleaningToolSwitched;
		}

		public void OnUpdate(float deltaTime)
		{
			if (isCleaningComplete)
			{
				if (elementCleaner.IsElementReady)
				{
					Stop();
				}
				cursorSelectionService.ClearDetection();
				return;
			}
			Vector2 mousePosition = playerInput.GetMousePosition();
			rotationController.OnUpdate();
			if (cursorDetectorService.UIDetector.TryToDetect(mousePosition, out var hitObject) && cursorSelectionService.DetectedGameObject == hitObject)
			{
				return;
			}
			if (!isExecuteButtonPressed)
			{
				if ((bool)hitObject)
				{
					cursorSelectionService.SetDetection(hitObject);
				}
				else
				{
					UpdateCursorDetection(mousePosition);
				}
				return;
			}
			cursorSelectionService.ClearDetection();
			if (availableToolsTrackingService.GetToolTotalUsesRemaining(cleaningToolSelectionService.CurrentlySelectedTool) <= 0f)
			{
				if (cleaningToolSelectionService.CurrentlySelectedTool is CleaningToolInfo)
				{
					elementCleaner.CleanerBrushSFX.PlaySound(isEmpty: true);
				}
				PlayError();
			}
			else
			{
				TryConsumeTool(cleaningToolSelectionService.CurrentlySelectedTool, cleaningToolSelectionService.CurrentlySelectedTool.UsesPerSecond * deltaTime);
				if (solderingService.InSolderingMode)
				{
					ExecuteSoldering(mousePosition);
				}
				else
				{
					ExecuteCleaning(mousePosition);
				}
			}
		}

		public void Exit()
		{
			UnsubscribeInputEvents();
			isExecuteButtonPressed = false;
			isCleaningComplete = false;
			selectedElement = null;
			elementCleaner.ResetTarget();
			solderingService.Clear();
			if (cleaningToolSelectionService.MonoShellExists())
			{
				cleaningToolSelectionService.OnToolSwitched -= ResolveCleaningToolSwitched;
			}
		}

		public void Dispose()
		{
			if (cleaningToolSelectionService.MonoShellExists())
			{
				cleaningToolSelectionService.OnToolSwitched -= ResolveCleaningToolSwitched;
			}
		}

		public void Stop()
		{
			if (!selectedElement)
			{
				Debug.LogError("Selected element is null.");
				return;
			}
			workSurface.AddElement(selectedElement);
			deviceService.PlacedDeviceContainer.DisassemblePoint.rotation = disassembleRotationCache;
			stateMachine.Enter<TransitionFromCleaningDisassembleState, ElementBase>(selectedElement);
		}

		public void ForceCleaningComplete()
		{
			if (!isCleaningComplete)
			{
				elementCleaner.CompleteCleaning();
				cleanerPanel.UpdateCleaningProgress(CleaningProgressInPercentage.FullProgress, SolderingProgressInPercentage.FullProgress);
				if (solderingService.IsActive)
				{
					solderingService.ForceCompleteSoldering();
				}
				isCleaningComplete = true;
			}
		}

		private void InitSoldering(CleaningProgressInPercentage cleaningProgress)
		{
			if (selectedElement.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty { IsResoldered: false })
			{
				ContactLinesHandler componentInChildren = selectedElement.GetComponentInChildren<ContactLinesHandler>();
				if ((bool)componentInChildren && componentInChildren.AllPoints.Count != 0)
				{
					solderingService.Init(componentInChildren, cleaningProgress.IsFullyCleaned());
				}
			}
		}

		private void ExecuteSoldering(Vector2 screenPosition)
		{
			if (cleaningToolSelectionService.CurrentlySelectedTool is SolderingToolInfo)
			{
				elementCleaner.Solder(screenPosition);
				solderingService.UpdateSolderingProcess();
			}
			SolderingProgressInPercentage currentProgress = solderingService.GetCurrentProgress();
			cleanerPanel.UpdateSolderingProgress(currentProgress);
			if (!currentProgress.IsResoldered())
			{
				UpdateCursorDetection(screenPosition);
				return;
			}
			elementCleaner.CompleteCleaning();
			isCleaningComplete = true;
		}

		private void ExecuteCleaning(Vector2 screenPosition)
		{
			if (cleaningToolSelectionService.CurrentlySelectedTool is CleaningToolInfo)
			{
				CleaningProgressInPercentage cleaningProgress = elementCleaner.CleanAndCalculateProgress(screenPosition);
				SolderingProgressInPercentage currentProgress = solderingService.GetCurrentProgress();
				cleanerPanel.UpdateCleaningProgress(cleaningProgress, currentProgress);
				solderingService.UpdateCleaningProcess();
				elementCleaner.CleanerBrushSFX.PlaySound(isEmpty: false);
				if (cleaningProgress.IsFullyCleaned() && IsSolderingComplete(currentProgress))
				{
					elementCleaner.CompleteCleaning();
					isCleaningComplete = true;
				}
			}
		}

		private bool IsSolderingComplete(SolderingProgressInPercentage solderingProgress)
		{
			if (!solderingService.IsActive)
			{
				return true;
			}
			if (solderingProgress.Soot < 1f)
			{
				return false;
			}
			if (!solderingProgress.IsResoldered())
			{
				solderingService.SwitchFromCleaningToSolderingMode();
				selectedElement.ConditionHandler.UpdateCondition(defaultElementConditions.BurntElementCondition);
				return false;
			}
			return true;
		}

		private void PlayError()
		{
			foreach (GUI_CleaningTool cleaningTool in cleaningToolsSelectionWindow.CleaningTools)
			{
				if (cleaningTool.ToolInfo == cleaningToolSelectionService.CurrentlySelectedTool)
				{
					cleaningTool.ToolCountAndUsesLeft.PlayError();
					break;
				}
			}
		}

		private bool TryConsumeTool(ToolInfo toolToConsume, float usesToSpend)
		{
			if (!toolToConsume || usesToSpend <= 0f)
			{
				return false;
			}
			if (!availableToolsTrackingService.TryGetToolState(toolToConsume, out var state) || (float)state.Count <= 0f)
			{
				return false;
			}
			if (!toolToConsume.IsConsumable)
			{
				return true;
			}
			int num = state.Count;
			float num2 = state.CurrentUsesLeft;
			float num3 = usesToSpend;
			while (num3 > 0f && num > 0)
			{
				if (num2 > num3)
				{
					num2 -= num3;
					num3 = 0f;
					break;
				}
				num3 -= num2;
				num2 = toolToConsume.MaxUses;
				num--;
			}
			int num4 = state.Count - num;
			if (num4 > 0)
			{
				availableToolsTrackingService.RemoveTool(toolToConsume, num4);
				audioPlayer.PlaySoundEventOneShot(toolToConsume.RemoveToolSound);
			}
			if (num > 0)
			{
				availableToolsTrackingService.SetToolCurrentUsesLeft(toolToConsume, num2);
			}
			return true;
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
			playerInput.AddInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void UnsubscribeInputEvents()
		{
			playerInput.RemoveInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
			playerInput.RemoveInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			isExecuteButtonPressed = true;
			if (isCleaningComplete)
			{
				Stop();
			}
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			isExecuteButtonPressed = false;
			if (solderingService.InSolderingMode && cleaningToolSelectionService.CurrentlySelectedTool is SolderingToolInfo)
			{
				solderingService.StopSolderingProcess();
				SolderingProgressInPercentage currentProgress = solderingService.GetCurrentProgress();
				cleanerPanel.UpdateSolderingProgress(currentProgress);
			}
		}

		private void ResolveCleaningToolSwitched()
		{
			elementCleaner.SetCleaningTool(cleaningToolSelectionService.CurrentlySelectedTool);
			if (solderingService.InSolderingMode)
			{
				solderingService.StopSolderingProcess();
			}
		}

		private void UpdateCursorDetection(Vector2 screenPosition)
		{
			if (solderingService.InSolderingMode && cleaningToolSelectionService.CurrentlySelectedTool is SolderingToolInfo && cursorDetectorService.GameDetector.TryToDetect(screenPosition, ProjectConstants.Layers.SolderingMask, out var hit))
			{
				cursorSelectionService.SetDetection(hit.collider.gameObject);
			}
			else
			{
				cursorSelectionService.ClearDetection();
			}
		}
	}
}
