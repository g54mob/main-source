using System;
using System.Collections.Generic;

namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public class UltrasonicStateFactory
	{
		public Dictionary<Type, IUltrasonicState> Create(UltrasonicStateContext stateContext, UltrasonicStateMachine stateMachine)
		{
			return new Dictionary<Type, IUltrasonicState>
			{
				{
					typeof(DisabledUltrasonicState),
					new DisabledUltrasonicState(stateContext, stateMachine)
				},
				{
					typeof(IdleUltrasonicState),
					new IdleUltrasonicState(stateContext, stateMachine)
				},
				{
					typeof(LaunchedUltrasonicState),
					new LaunchedUltrasonicState(stateContext, stateMachine)
				}
			};
		}
	}
}
