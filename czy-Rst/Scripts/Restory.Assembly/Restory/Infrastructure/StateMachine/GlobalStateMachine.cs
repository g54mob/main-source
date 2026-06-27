using System;
using System.Collections.Generic;
using Restory.Infrastructure.StateMachine.States;
using Restory.Infrastructure.StateMachine.States.Base;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;

namespace Restory.Infrastructure.StateMachine
{
	public class GlobalStateMachine
	{
		private readonly Dictionary<Type, IExitableState> states;

		private readonly List<InitializationStateBase> initializationStates;

		private IExitableState activeState;

		public IExitableState ActiveState
		{
			get
			{
				return activeState;
			}
			private set
			{
				bool num = activeState != value;
				activeState = value;
				if (IsInStartInitializationState)
				{
					ResetInitializationStatesProgress();
				}
				if (num)
				{
					this.OnActiveStateChanged?.Invoke();
				}
			}
		}

		public bool IsInGameLoop => ActiveState is GameLoopState;

		public bool IsInGameResults => ActiveState is GameResultsState;

		public bool IsInInitializationState => ActiveState is InitializationStateBase;

		public bool IsInStartInitializationState => ActiveState is StartLoadingPresetListState;

		public float InitializationProgress
		{
			get
			{
				if (initializationStates.Count == 0)
				{
					return 0f;
				}
				float num = 0f;
				for (int i = 0; i < initializationStates.Count; i++)
				{
					num += initializationStates[i].Progress;
				}
				return Mathf.Clamp01(num / (float)initializationStates.Count);
			}
		}

		public event Action OnActiveStateChanged;

		public event Action OnStateEntered;

		public event Action OnStateExited;

		public event Action OnInitializationProgressChanged;

		public GlobalStateMachine(MainMenuState.Factory mainMenuStateFactory, GameIntroLogosState.Factory gameIntroLogosStateFactory, GameIntroState.Factory gameIntroStateFactory, GameResultsState.Factory gameResultsStateFactory, GameLauncherState.Factory gameLauncherStateFactory, GameLoopState.Factory gameLoopStateFactory, GamePauseState.Factory gamePauseStateFactory, BugReportFormState.Factory bugReportFormStateFactory, LoadProgressState.Factory loadProgressStateFactory, LoadPresetListState.Factory loadPresetListStateFactory, InstallServicesState.Factory installServicesStateFactory, StartLoadingPresetListState.Factory startLoadingPresetListStateFactory, DisposePresetListState.Factory disposePresetListStateFactory, FinalSelectionState.Factory forkGlobalStateFactory)
		{
			initializationStates = new List<InitializationStateBase>();
			states = new Dictionary<Type, IExitableState>
			{
				[typeof(MainMenuState)] = mainMenuStateFactory.Create(),
				[typeof(GameIntroLogosState)] = gameIntroLogosStateFactory.Create(),
				[typeof(GameIntroState)] = gameIntroStateFactory.Create(),
				[typeof(LoadPresetListState)] = loadPresetListStateFactory.Create(),
				[typeof(LoadProgressState)] = loadProgressStateFactory.Create(),
				[typeof(InstallServicesState)] = installServicesStateFactory.Create(),
				[typeof(GameResultsState)] = gameResultsStateFactory.Create(),
				[typeof(GameLauncherState)] = gameLauncherStateFactory.Create(),
				[typeof(GameLoopState)] = gameLoopStateFactory.Create(),
				[typeof(GamePauseState)] = gamePauseStateFactory.Create(),
				[typeof(BugReportFormState)] = bugReportFormStateFactory.Create(),
				[typeof(StartLoadingPresetListState)] = startLoadingPresetListStateFactory.Create(),
				[typeof(DisposePresetListState)] = disposePresetListStateFactory.Create(),
				[typeof(FinalSelectionState)] = forkGlobalStateFactory.Create()
			};
			InitializeStates();
		}

		private void InitializeStates()
		{
			foreach (IExitableState value in states.Values)
			{
				if (value is IStateMachineUser stateMachineUser)
				{
					stateMachineUser.SetGameStateMachine(this);
				}
				if (value is InitializationStateBase initializationStateBase)
				{
					initializationStates.Add(initializationStateBase);
					initializationStateBase.OnProgressChanged += ResolveOnInitializationStateProgressChanged;
				}
			}
		}

		public void Enter<TState>() where TState : class, IState
		{
			ChangeState<TState>().Enter();
			this.OnStateEntered?.Invoke();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
		{
			ChangeState<TState>().Enter(payload);
			this.OnStateEntered?.Invoke();
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			ActiveState?.Exit();
			this.OnStateExited?.Invoke();
			return (TState)(ActiveState = GetState<TState>());
		}

		public TState GetState<TState>() where TState : class, IExitableState
		{
			return states[typeof(TState)] as TState;
		}

		private void ResetInitializationStatesProgress()
		{
			foreach (InitializationStateBase initializationState in initializationStates)
			{
				initializationState?.ResetProgress();
			}
		}

		private void ResolveOnInitializationStateProgressChanged()
		{
			this.OnInitializationProgressChanged?.Invoke();
		}
	}
}
