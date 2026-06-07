using System.Collections.Generic;

namespace Stateless.Reflection
{
	public abstract class TransitionInfo
	{
		public IEnumerable<InvocationInfo> GuardConditionsMethodDescriptions;

		public TriggerInfo Trigger { get; protected set; }

		public bool IsInternalTransition { get; protected set; }
	}
}
