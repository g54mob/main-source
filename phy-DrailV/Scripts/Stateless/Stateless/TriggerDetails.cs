using System.Collections.Generic;

namespace Stateless
{
	public sealed class TriggerDetails<TState, TTrigger>
	{
		public TTrigger Trigger { get; }

		public bool HasParameters { get; }

		public StateMachine<TState, TTrigger>.TriggerWithParameters Parameters { get; }

		internal TriggerDetails(TTrigger trigger, IDictionary<TTrigger, StateMachine<TState, TTrigger>.TriggerWithParameters> triggerConfiguration)
		{
			Trigger = trigger;
			HasParameters = triggerConfiguration.ContainsKey(trigger);
			Parameters = (HasParameters ? triggerConfiguration[trigger] : null);
		}
	}
}
