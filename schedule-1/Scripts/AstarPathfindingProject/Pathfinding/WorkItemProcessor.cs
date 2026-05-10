namespace Pathfinding
{
	internal class WorkItemProcessor : IWorkItemContext
	{
		private class IndexedQueue<T>
		{
			private T[] buffer;

			private int start;

			public T this[int index]
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			public int Count { get; private set; }

			public void Enqueue(T item)
			{
			}

			public T Dequeue()
			{
				return default(T);
			}
		}

		private readonly AstarPath astar;

		private readonly IndexedQueue<AstarWorkItem> workItems;

		private bool queuedWorkItemFloodFill;

		private bool anyGraphsDirty;

		public bool workItemsInProgressRightNow { get; private set; }

		public bool anyQueued => false;

		public bool workItemsInProgress { get; private set; }

		void IWorkItemContext.QueueFloodFill()
		{
		}

		void IWorkItemContext.SetGraphDirty(NavGraph graph)
		{
		}

		public void EnsureValidFloodFill()
		{
		}

		public WorkItemProcessor(AstarPath astar)
		{
		}

		public void OnFloodFill()
		{
		}

		public void AddWorkItem(AstarWorkItem item)
		{
		}

		public bool ProcessWorkItems(bool force)
		{
			return false;
		}
	}
}
