using System.Collections.Generic;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class Transition
	{
		public List<ActionInfo> DestinationEntryActions = new List<ActionInfo>();

		public TriggerInfo Trigger { get; private set; }

		public bool ExecuteEntryExitActions { get; protected set; } = true;

		public State SourceState { get; private set; }

		public Transition(State sourceState, TriggerInfo trigger)
		{
			SourceState = sourceState;
			Trigger = trigger;
		}
	}
}
