using System;
using System.Collections.Generic;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.GameCursor;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public class UltrasonicStateMachine : IUltrasonicStateSwitcher
	{
		private readonly Dictionary<Type, IUltrasonicState> states;

		public IUltrasonicState CurrentState { get; private set; }

		public UltrasonicStateMachine(SonicBath sonicBath, CursorSelectionService cursorSelectionService, DisassembleStateMachine disassembleStateMachine)
		{
			UltrasonicStateContext stateContext = new UltrasonicStateContext(sonicBath, cursorSelectionService, disassembleStateMachine);
			UltrasonicStateFactory ultrasonicStateFactory = new UltrasonicStateFactory();
			states = ultrasonicStateFactory.Create(stateContext, this);
		}

		public void Dispose()
		{
			ExitCurrentState();
			states.Clear();
		}

		public void EnterDisabledState()
		{
			Enter<DisabledUltrasonicState>();
		}

		public void EnterIdleState()
		{
			Enter<IdleUltrasonicState>();
		}

		public void EnterLaunchedState()
		{
			Enter<LaunchedUltrasonicState>();
		}

		private void Enter<TState>() where TState : class, IUltrasonicState
		{
			if (!states.TryGetValue(typeof(TState), out var value))
			{
				throw new InvalidOperationException("State " + typeof(TState).Name + " was not registered in UltrasonicStateMachine");
			}
			if (CurrentState != value)
			{
				ExitCurrentState();
				Debug.Log("UltrasonicStateMachine Enter [" + value.GetType().Name + "]");
				CurrentState = value;
				CurrentState.Enter();
			}
		}

		private void ExitCurrentState()
		{
			if (CurrentState != null)
			{
				Debug.Log("UltrasonicStateMachine Exit [" + CurrentState.GetType().Name + "]");
				CurrentState.Exit();
				CurrentState = null;
			}
		}
	}
}
