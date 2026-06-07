using System;
using System.Collections.Generic;
using System.Linq;

namespace Stateless.Reflection
{
	public class StateMachineInfo
	{
		public StateInfo InitialState { get; }

		public IEnumerable<StateInfo> States { get; }

		public Type StateType { get; private set; }

		public Type TriggerType { get; private set; }

		internal StateMachineInfo(IEnumerable<StateInfo> states, Type stateType, Type triggerType, StateInfo initialState)
		{
			InitialState = initialState;
			States = states?.ToList() ?? throw new ArgumentNullException("states");
			StateType = stateType;
			TriggerType = triggerType;
		}
	}
}
