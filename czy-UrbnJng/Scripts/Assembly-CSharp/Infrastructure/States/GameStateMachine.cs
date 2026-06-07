using System;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.States
{
	public class GameStateMachine : IGameStateMachine, IService
	{
		private Dictionary<Type, IExitableState> _states;

		private IExitableState _activeState;

		public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services)
		{
			_states = new Dictionary<Type, IExitableState>
			{
				[typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
				[typeof(MenuState)] = new MenuState(this, sceneLoader, loadingCurtain, services),
				[typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPersistentProgressService>(), services.Single<ISaveLoadService>()),
				[typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, services.Single<IGameFactory>(), services.Single<IPersistentProgressService>()),
				[typeof(GameLoopState)] = new GameLoopState(this, services.Single<ISaveLoadService>())
			};
		}

		public void Enter<TState>() where TState : class, IState
		{
			ChangeState<TState>().Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
		{
			ChangeState<TState>().Enter(payload);
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			_activeState?.Exit();
			return (TState)(_activeState = GetState<TState>());
		}

		private TState GetState<TState>() where TState : class, IExitableState
		{
			return _states[typeof(TState)] as TState;
		}
	}
}
