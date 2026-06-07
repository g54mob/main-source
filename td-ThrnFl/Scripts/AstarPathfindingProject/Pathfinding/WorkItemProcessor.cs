using System;
using Pathfinding.Jobs;
using UnityEngine;

namespace Pathfinding
{
	internal class WorkItemProcessor : IWorkItemContext, IGraphUpdateContext
	{
		private class IndexedQueue<T>
		{
			private T[] buffer = new T[4];

			private int start;

			public T this[int index]
			{
				get
				{
					if (index < 0 || index >= Count)
					{
						throw new IndexOutOfRangeException();
					}
					return buffer[(start + index) % buffer.Length];
				}
				set
				{
					if (index < 0 || index >= Count)
					{
						throw new IndexOutOfRangeException();
					}
					buffer[(start + index) % buffer.Length] = value;
				}
			}

			public int Count { get; private set; }

			public void Enqueue(T item)
			{
				if (Count == buffer.Length)
				{
					T[] array = new T[buffer.Length * 2];
					for (int i = 0; i < Count; i++)
					{
						array[i] = this[i];
					}
					buffer = array;
					start = 0;
				}
				buffer[(start + Count) % buffer.Length] = item;
				Count++;
			}

			public T Dequeue()
			{
				if (Count == 0)
				{
					throw new InvalidOperationException();
				}
				T result = buffer[start];
				start = (start + 1) % buffer.Length;
				Count--;
				return result;
			}
		}

		private readonly AstarPath astar;

		private readonly IndexedQueue<AstarWorkItem> workItems = new IndexedQueue<AstarWorkItem>();

		private bool anyGraphsDirty = true;

		private bool preUpdateEventSent;

		public bool workItemsInProgressRightNow { get; private set; }

		public bool anyQueued => workItems.Count > 0;

		public bool workItemsInProgress { get; private set; }

		public event Action OnGraphsUpdated;

		void IWorkItemContext.QueueFloodFill()
		{
		}

		void IWorkItemContext.PreUpdate()
		{
			if (!preUpdateEventSent && !astar.isScanning)
			{
				preUpdateEventSent = true;
				GraphModifier.TriggerEvent(GraphModifier.EventType.PreUpdate);
			}
		}

		void IWorkItemContext.SetGraphDirty(NavGraph graph)
		{
			astar.DirtyBounds(graph.bounds);
		}

		void IGraphUpdateContext.DirtyBounds(Bounds bounds)
		{
			astar.DirtyBounds(bounds);
		}

		internal void DirtyGraphs()
		{
			anyGraphsDirty = true;
		}

		public void EnsureValidFloodFill()
		{
			astar.hierarchicalGraph.RecalculateIfNecessary();
		}

		public WorkItemProcessor(AstarPath astar)
		{
			this.astar = astar;
		}

		public void AddWorkItem(AstarWorkItem item)
		{
			workItems.Enqueue(item);
		}

		private bool ProcessWorkItems(bool force, bool sendEvents)
		{
			if (workItemsInProgressRightNow)
			{
				throw new Exception("Processing work items recursively. Please do not wait for other work items to be completed inside work items. If you think this is not caused by any of your scripts, this might be a bug.");
			}
			RWLock.LockSync lockSync = astar.LockGraphDataForWritingSync();
			astar.data.LockGraphStructure(allowAddingGraphs: true);
			Physics.SyncTransforms();
			Physics2D.SyncTransforms();
			workItemsInProgressRightNow = true;
			try
			{
				bool flag = false;
				bool flag2 = false;
				while (workItems.Count > 0)
				{
					if (!workItemsInProgress)
					{
						workItemsInProgress = true;
					}
					AstarWorkItem value = workItems[0];
					bool flag3;
					try
					{
						if (value.init != null)
						{
							value.init();
							value.init = null;
						}
						if (value.initWithContext != null)
						{
							value.initWithContext(this);
							value.initWithContext = null;
						}
						workItems[0] = value;
						flag3 = ((value.update != null) ? value.update(force) : (value.updateWithContext == null || value.updateWithContext(this, force)));
					}
					catch
					{
						workItems.Dequeue();
						throw;
					}
					if (!flag3)
					{
						if (force)
						{
							Debug.LogError("Misbehaving WorkItem. 'force'=true but the work item did not complete.\nIf force=true is passed to a WorkItem it should always return true.");
						}
						flag = true;
						break;
					}
					workItems.Dequeue();
					flag2 = true;
				}
				if (sendEvents && flag2)
				{
					if (anyGraphsDirty)
					{
						GraphModifier.TriggerEvent(GraphModifier.EventType.PostUpdateBeforeAreaRecalculation);
					}
					astar.offMeshLinks.Refresh();
					EnsureValidFloodFill();
					if (anyGraphsDirty)
					{
						GraphModifier.TriggerEvent(GraphModifier.EventType.PostUpdate);
						if (this.OnGraphsUpdated != null)
						{
							this.OnGraphsUpdated();
						}
					}
				}
				if (flag)
				{
					return false;
				}
			}
			finally
			{
				lockSync.Unlock();
				astar.data.UnlockGraphStructure();
				workItemsInProgressRightNow = false;
			}
			anyGraphsDirty = false;
			preUpdateEventSent = false;
			workItemsInProgress = false;
			return true;
		}

		public bool ProcessWorkItemsForScan(bool force)
		{
			return ProcessWorkItems(force, sendEvents: false);
		}

		public bool ProcessWorkItemsForUpdate(bool force)
		{
			return ProcessWorkItems(force, sendEvents: true);
		}
	}
}
