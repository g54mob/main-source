namespace Stateless.Reflection
{
	public class ActionInfo
	{
		public InvocationInfo Method { get; internal set; }

		public string FromTrigger { get; internal set; }

		internal static ActionInfo Create<TState, TTrigger>(StateMachine<TState, TTrigger>.EntryActionBehavior entryAction)
		{
			if (entryAction is StateMachine<TState, TTrigger>.EntryActionBehavior.SyncFrom<TTrigger> syncFrom)
			{
				return new ActionInfo(entryAction.Description, syncFrom.Trigger.ToString());
			}
			if (entryAction is StateMachine<TState, TTrigger>.EntryActionBehavior.AsyncFrom<TTrigger> asyncFrom)
			{
				return new ActionInfo(entryAction.Description, asyncFrom.Trigger.ToString());
			}
			return new ActionInfo(entryAction.Description, null);
		}

		public ActionInfo(InvocationInfo method, string fromTrigger)
		{
			Method = method;
			FromTrigger = fromTrigger;
		}
	}
}
