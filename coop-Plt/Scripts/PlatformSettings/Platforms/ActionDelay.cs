using System;
using System.Collections.Generic;

namespace Platforms
{
	public class ActionDelay
	{
		private Action Action;

		private Action PreAction;

		private Action PostAction;

		private ActionBatcher Batcher;

		private Dictionary<string, Action> QueuedActions = new Dictionary<string, Action>();

		public ActionDelay(Action pre, Action post)
		{
			Batcher = new ActionBatcher(Flush);
			PreAction = pre;
			PostAction = post;
		}

		public void Enqueue(string key, Action action)
		{
			QueuedActions[key] = action;
			Batcher.RequestCommit();
		}

		public void Flush()
		{
			if (QueuedActions.Count == 0)
			{
				return;
			}
			PreAction?.Invoke();
			try
			{
				foreach (KeyValuePair<string, Action> queuedAction in QueuedActions)
				{
					queuedAction.Value();
				}
			}
			finally
			{
				PostAction?.Invoke();
				QueuedActions.Clear();
			}
		}
	}
}
