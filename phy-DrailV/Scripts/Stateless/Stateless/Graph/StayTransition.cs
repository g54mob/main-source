using System.Collections.Generic;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class StayTransition : Transition
	{
		public IEnumerable<InvocationInfo> Guards { get; private set; }

		public StayTransition(State sourceState, TriggerInfo trigger, IEnumerable<InvocationInfo> guards, bool executeEntryExitActions)
			: base(sourceState, trigger)
		{
			base.ExecuteEntryExitActions = executeEntryExitActions;
			Guards = guards;
		}
	}
}
