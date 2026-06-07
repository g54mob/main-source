using System;

namespace UI.Utilities
{
	public struct ActionWithPriority
	{
		public int priority;

		public Action action;

		public ActionWithPriority(int priority, Action action)
		{
			this.priority = 0;
			this.action = null;
		}
	}
}
