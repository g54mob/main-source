using System.Collections.Generic;
using Pathfinding.Jobs;
using Unity.Jobs;
using Unity.Profiling;

namespace Pathfinding
{
	public class GraphUpdateProcessor
	{
		private readonly AstarPath astar;

		private bool anyGraphUpdateInProgress;

		private readonly Queue<GraphUpdateObject> graphUpdateQueue;

		private readonly List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> pendingPromises;

		private readonly List<GraphUpdateObject> pendingGraphUpdates;

		private static readonly ProfilerMarker MarkerSleep;

		private static readonly ProfilerMarker MarkerCalculate;

		private static readonly ProfilerMarker MarkerApply;

		public bool IsAnyGraphUpdateQueued => false;

		public bool IsAnyGraphUpdateInProgress => false;

		public GraphUpdateProcessor(AstarPath astar)
		{
		}

		public AstarWorkItem GetWorkItem()
		{
			return default(AstarWorkItem);
		}

		public void AddToQueue(GraphUpdateObject ob)
		{
		}

		public void DiscardQueued()
		{
		}

		private void QueueGraphUpdatesInternal(IWorkItemContext context)
		{
		}

		private bool ProcessGraphUpdates(IWorkItemContext context, bool force)
		{
			return false;
		}

		public static int ProcessGraphUpdatePromises(List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> promises, IGraphUpdateContext context, TimeSlice timeSlice)
		{
			return 0;
		}

		public static int PrepareGraphUpdatePromises(List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> promises, TimeSlice timeSlice)
		{
			return 0;
		}

		public static void ApplyGraphUpdatePromises(List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> promises, IGraphUpdateContext context)
		{
		}
	}
}
