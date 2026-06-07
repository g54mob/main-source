using System.Collections.Generic;
using System.Linq;

namespace Stateless.Reflection
{
	public class IgnoredTransitionInfo : TransitionInfo
	{
		internal static IgnoredTransitionInfo Create<TState, TTrigger>(StateMachine<TState, TTrigger>.IgnoredTriggerBehaviour behaviour)
		{
			IgnoredTransitionInfo obj = new IgnoredTransitionInfo
			{
				Trigger = new TriggerInfo(behaviour.Trigger)
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
			return obj;
		}

		private IgnoredTransitionInfo()
		{
		}
	}
}
