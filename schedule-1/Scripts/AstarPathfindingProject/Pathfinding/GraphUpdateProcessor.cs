using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.Profiling;

namespace Pathfinding
{
	internal class GraphUpdateProcessor
	{
		private enum GraphUpdateOrder
		{
			GraphUpdate = 0
		}

		private struct GUOSingle
		{
			public GraphUpdateOrder order;

			public IUpdatableGraph graph;

			public GraphUpdateObject obj;
		}

		private readonly AstarPath astar;

		private Thread graphUpdateThread;

		private bool anyGraphUpdateInProgress;

		private CustomSampler asyncUpdateProfilingSampler;

		private readonly Queue<GraphUpdateObject> graphUpdateQueue;

		private readonly Queue<GUOSingle> graphUpdateQueueAsync;

		private readonly Queue<GUOSingle> graphUpdateQueuePost;

		private readonly Queue<GUOSingle> graphUpdateQueueRegular;

		private readonly ManualResetEvent asyncGraphUpdatesComplete;

		private readonly AutoResetEvent graphUpdateAsyncEvent;

		private readonly AutoResetEvent exitAsyncThread;

		public bool IsAnyGraphUpdateQueued => false;

		public bool IsAnyGraphUpdateInProgress => false;

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

		public GraphUpdateProcessor(AstarPath astar)
		{
		}

		public AstarWorkItem GetWorkItem()
		{
			return default(AstarWorkItem);
		}

		public void EnableMultithreading()
		{
		}

		public void DisableMultithreading()
		{
		}

		public void AddToQueue(GraphUpdateObject ob)
		{
		}

		private void QueueGraphUpdatesInternal()
		{
		}

		private bool ProcessGraphUpdates(bool force)
		{
			return false;
		}

		private bool ProcessRegularUpdates(bool force)
		{
			return false;
		}

		private bool StartAsyncUpdatesIfQueued()
		{
			return false;
		}

		private void ProcessPostUpdates()
		{
		}

		private void ProcessGraphUpdatesAsync()
		{
		}
	}
}
