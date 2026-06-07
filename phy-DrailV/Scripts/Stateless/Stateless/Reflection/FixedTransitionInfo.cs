using System.Collections.Generic;
using System.Linq;

namespace Stateless.Reflection
{
	public class FixedTransitionInfo : TransitionInfo
	{
		public StateInfo DestinationState { get; private set; }

		internal static FixedTransitionInfo Create<TState, TTrigger>(StateMachine<TState, TTrigger>.TriggerBehaviour behaviour, StateInfo destinationStateInfo)
		{
			FixedTransitionInfo obj = new FixedTransitionInfo
			{
				Trigger = new TriggerInfo(behaviour.Trigger),
				DestinationState = destinationStateInfo
			};
			IEnumerable<InvocationInfo> guardConditionsMethodDescriptions;
			if (behaviour.Guard != null)
			{
				guardConditionsMethodDescriptions = behaviour.Guard.Conditions.Select((StateMachine<TState, TTrigger>.GuardCondition c) => c.MethodDescription);
			}
			else
			{
				IEnumerable<InvocationInfo> enumerable = new List<InvocationInfo>();
				guardConditionsMethodDescriptions = enumerable;
			}
			obj.GuardConditionsMethodDescriptions = guardConditionsMethodDescriptions;
			obj.IsInternalTransition = behaviour is StateMachine<TState, TTrigger>.InternalTriggerBehaviour;
			return obj;
		}

		private FixedTransitionInfo()
		{
		}
	}
}
