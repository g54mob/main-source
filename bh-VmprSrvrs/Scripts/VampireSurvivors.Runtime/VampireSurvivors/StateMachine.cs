using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

namespace VampireSurvivors
{
	public class StateMachine : MonoBehaviour
	{
		public const string ENTER_DONE = "ENTER_DONE";

		protected readonly Dictionary<Type, StateMachineState> instanceCache;

		protected Dictionary<Type, Dictionary<string, Type>> overallTransitionMap;

		protected StateMachineState currentState;

		protected Dictionary<string, Type> currentTransitionMap;

		protected DiContainer Container;

		public string TransitionTriggerEvent { get; private set; }

		public StateMachineState CurrentState => null;

		public event Action ExitStateEntered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void Construct(DiContainer container)
		{
		}

		public void StartStateMachine<TInitialState>() where TInitialState : StateMachineState
		{
		}

		public virtual void Stop()
		{
		}

		protected void ResetTransitionMap()
		{
		}

		public void AddExitListener(Action listener)
		{
		}

		public void RemoveExitListener(Action listener)
		{
		}

		public virtual void ExitEntered()
		{
		}

		protected void GoToState(Type state)
		{
		}

		private void UpdateTransitionMap(Type state)
		{
		}

		protected virtual void SetCurrentState(Type stateType)
		{
		}

		public virtual void FireEvent(string eventStr)
		{
		}

		protected StateMachineState GetStateInstance(Type stateType)
		{
			return null;
		}

		protected void AddStateTransition<TFromState, TToState>(string eventStr) where TFromState : StateMachineState where TToState : StateMachineState
		{
		}
	}
}
