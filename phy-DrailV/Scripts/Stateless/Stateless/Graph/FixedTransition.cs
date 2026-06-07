using System.Collections.Generic;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class FixedTransition : Transition
	{
		public State DestinationState { get; private set; }

		public IEnumerable<InvocationInfo> Guards { get; private set; }

		public FixedTransition(State sourceState, State destinationState, TriggerInfo trigger, IEnumerable<InvocationInfo> guards)
			: base(sourceState, trigger)
		{
			DestinationState = destinationState;
			Guards = guards;
		}
	}
}
