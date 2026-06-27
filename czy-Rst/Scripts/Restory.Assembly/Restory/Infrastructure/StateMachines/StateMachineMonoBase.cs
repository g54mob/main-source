using System;
using System.Collections.Generic;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Restory.Infrastructure.StateMachines
{
	public abstract class StateMachineMonoBase : MonoBehaviour, IInitializable, IDisposable
	{
		public readonly UnityEvent OnStateChanged = new UnityEvent();

		public readonly UnityEvent OnStateEntered = new UnityEvent();

		protected readonly Dictionary<Type, IExitableState> states = new Dictionary<Type, IExitableState>();

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
				if (num)
				{
					OnStateChanged.Invoke();
				}
			}
		}

		private void Update()
		{
			if (ActiveState is IUpdatableState updatableState)
			{
				updatableState.OnUpdate(Time.deltaTime);
			}
		}

		public void Enter<TState>() where TState : class, IState
		{
			TState val = ChangeState<TState>();
			Debug.Log($"[{GetType().Name}] is entering {ActiveState}.");
			val.Enter();
			OnStateEntered?.Invoke();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
		{
			TState val = ChangeState<TState>();
			Debug.Log($"[{GetType().Name}] is entering {ActiveState}.");
			val.Enter(payload);
			OnStateEntered?.Invoke();
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			Debug.Log($"[{GetType().Name}] is exiting {ActiveState}.");
			ActiveState?.Exit();
			return (TState)(ActiveState = GetState<TState>());
		}

		public TState GetState<TState>() where TState : class, IExitableState
		{
			return states[typeof(TState)] as TState;
		}

		public bool TryGetState<TState>(out TState state) where TState : class, IExitableState
		{
			IExitableState value;
			bool result = states.TryGetValue(typeof(TState), out value);
			state = value as TState;
			return result;
		}

		public void Enter<TState>(TState nextStateInstance) where TState : class, IState
		{
			TState val = ChangeState(nextStateInstance);
			Debug.Log($"[{GetType().Name}] is entering {ActiveState}.");
			val.Enter();
			OnStateEntered?.Invoke();
		}

		private TState ChangeState<TState>(TState nextStateInstance) where TState : class, IExitableState
		{
			Debug.Log($"[{GetType().Name}] is exiting {ActiveState}.");
			ActiveState?.Exit();
			return (TState)(ActiveState = GetState(nextStateInstance));
		}

		private TState GetState<TState>(TState instance) where TState : class, IExitableState
		{
			return states[instance.GetType()] as TState;
		}

		public abstract void ExitToDefaultState();

		public abstract void Initialize();

		protected virtual void PreDispose()
		{
		}

		public void Dispose()
		{
			PreDispose();
			activeState = null;
			foreach (IExitableState value in states.Values)
			{
				value.Dispose();
			}
			states.Clear();
			OnStateChanged.RemoveAllListeners();
			OnStateEntered.RemoveAllListeners();
			PostDispose();
		}

		protected virtual void PostDispose()
		{
		}
	}
}
