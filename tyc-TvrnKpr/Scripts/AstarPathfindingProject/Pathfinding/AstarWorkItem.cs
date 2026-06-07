using System;

namespace Pathfinding
{
	public struct AstarWorkItem
	{
		public Action init;

		public Action<IWorkItemContext> initWithContext;

		public Func<bool, bool> update;

		public Func<IWorkItemContext, bool, bool> updateWithContext;

		public AstarWorkItem(Func<bool, bool> update)
		{
			init = null;
			initWithContext = null;
			this.update = null;
			updateWithContext = null;
		}

		public AstarWorkItem(Func<IWorkItemContext, bool, bool> update)
		{
			init = null;
			initWithContext = null;
			this.update = null;
			updateWithContext = null;
		}

		public AstarWorkItem(Action init, Func<bool, bool> update = null)
		{
			this.init = null;
			initWithContext = null;
			this.update = null;
			updateWithContext = null;
		}

		public AstarWorkItem(Action<IWorkItemContext> init, Func<IWorkItemContext, bool, bool> update = null)
		{
			this.init = null;
			initWithContext = null;
			this.update = null;
			updateWithContext = null;
		}
	}
}
