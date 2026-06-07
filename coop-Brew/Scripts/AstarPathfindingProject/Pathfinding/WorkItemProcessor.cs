using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding
{
	internal class WorkItemProcessor : IWorkItemContext, IGraphUpdateContext
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

		private bool anyGraphsDirty;

		private bool preUpdateEventSent;

		public bool workItemsInProgressRightNow { get; private set; }

		public bool anyQueued => false;

		public bool workItemsInProgress { get; private set; }

		public event Action OnGraphsUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		void IWorkItemContext.QueueFloodFill()
		{
		}

		void IWorkItemContext.PreUpdate()
		{
		}

		void IWorkItemContext.SetGraphDirty(NavGraph graph)
		{
		}

		void IGraphUpdateContext.DirtyBounds(Bounds bounds)
		{
		}

		internal void DirtyGraphs()
		{
		}

		public void EnsureValidFloodFill()
		{
		}

		public WorkItemProcessor(AstarPath astar)
		{
		}

		public void AddWorkItem(AstarWorkItem item)
		{
		}

		private bool ProcessWorkItems(bool force, bool sendEvents)
		{
			return false;
		}

		public bool ProcessWorkItemsForScan(bool force)
		{
			return false;
		}

		public bool ProcessWorkItemsForUpdate(bool force)
		{
			return false;
		}
	}
}
