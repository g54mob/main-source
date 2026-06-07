using Stateless.Reflection;

namespace Stateless.Graph
{
	public class DynamicTransition : Transition
	{
		public State DestinationState { get; private set; }

		public string Criterion { get; private set; }

		public DynamicTransition(State sourceState, State destinationState, TriggerInfo trigger, string criterion)
			: base(sourceState, trigger)
		{
			DestinationState = destinationState;
			Criterion = criterion;
		}
	}
}
