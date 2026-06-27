using System;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.NPCs;
using Restory.Gameplay.Work.StateMachine;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Restory.UI.Presenters.PauseMenu;
using Restory.UserInterface.GameplayOverlay;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class PauseMenuActivator : IInitializable, IDisposable
	{
		private GUI_PauseMenu pauseMenu;

		private GUI_TooltipsLayerCanvas tooltipsLayerCanvas;

		private GUI_ErrorsLayerCanvas errorsLayerCanvas;

		private GUI_GameWorldTutorialIconsLayerCanvas gameWorldTutorialIconsLayerCanvas;

		private WorkStateMachine workStateMachine;

		private GlobalStateMachine globalStateMachine;

		private NpcServiceMain npcServiceMain;

		private ExitEventDispatcher exitEventDispatcher;

		[Inject]
		private void Construct(WorkStateMachine workStateMachine, GlobalStateMachine globalStateMachine, NpcServiceMain npcServiceMain, GUI_TooltipsLayerCanvas tooltipsLayerCanvas, GUI_ErrorsLayerCanvas errorsLayerCanvas, GUI_GameWorldTutorialIconsLayerCanvas gameWorldTutorialIconsLayerCanvas, GUI_PauseMenu pauseMenu, ExitEventDispatcher exitEventDispatcher)
		{
			this.workStateMachine = workStateMachine;
			this.globalStateMachine = globalStateMachine;
			this.npcServiceMain = npcServiceMain;
			this.tooltipsLayerCanvas = tooltipsLayerCanvas;
			this.errorsLayerCanvas = errorsLayerCanvas;
			this.gameWorldTutorialIconsLayerCanvas = gameWorldTutorialIconsLayerCanvas;
			this.pauseMenu = pauseMenu;
			this.exitEventDispatcher = exitEventDispatcher;
		}

		public void Initialize()
		{
			pauseMenu.OnIsShownChanged += ResolveOnPauseMenuShownChanged;
			exitEventDispatcher.OnNothingToExit += ResolveNothingToExit;
		}

		public void Dispose()
		{
			pauseMenu.OnIsShownChanged -= ResolveOnPauseMenuShownChanged;
			exitEventDispatcher.OnNothingToExit -= ResolveNothingToExit;
		}

		private bool DoesVisitsStateBlockDetection()
		{
			CurrentVisitState currentVisitState = npcServiceMain.CurrentVisitState;
			return currentVisitState == CurrentVisitState.VisitWithInteraction_Starting || currentVisitState == CurrentVisitState.VisitWithNoInteraction_Starting || currentVisitState == CurrentVisitState.VisitWithInteraction_InteractionInProgress;
		}

		private void ShowWindow()
		{
			if (globalStateMachine.ActiveState is GameLoopState && workStateMachine.ActiveState is DetectionWorkState && !DoesVisitsStateBlockDetection())
			{
				globalStateMachine.Enter<GamePauseState>();
				pauseMenu.Show();
				SwitchRelevantCanvassesVisibility(shouldCanvassesBeVisible: false);
			}
		}

		private void HideWindow()
		{
			if (globalStateMachine.ActiveState is GamePauseState)
			{
				globalStateMachine.Enter<GameLoopState>();
				pauseMenu.Hide();
				SwitchRelevantCanvassesVisibility(shouldCanvassesBeVisible: true);
			}
		}

		private void ResolveOnPauseMenuShownChanged(GUI_PauseMenu menu, bool isShown)
		{
			if (!isShown && globalStateMachine.ActiveState is GamePauseState)
			{
				globalStateMachine.Enter<GameLoopState>();
				SwitchRelevantCanvassesVisibility(shouldCanvassesBeVisible: true);
			}
		}

		private void ResolveNothingToExit()
		{
			if (pauseMenu.IsShown)
			{
				HideWindow();
			}
			else
			{
				ShowWindow();
			}
		}

		private void SwitchRelevantCanvassesVisibility(bool shouldCanvassesBeVisible)
		{
			tooltipsLayerCanvas.SwitchLayerActiveState(shouldCanvassesBeVisible);
			errorsLayerCanvas.SwitchLayerActiveState(shouldCanvassesBeVisible);
			gameWorldTutorialIconsLayerCanvas.SwitchLayerActiveState(shouldCanvassesBeVisible);
		}
	}
}
