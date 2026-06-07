using System;
using System.Collections.Generic;
using System.Threading;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	internal class GraphUpdateProcessor
	{
		private readonly AstarPath astar;

		private bool anyGraphUpdateInProgress;

		private readonly Queue<GraphUpdateObject> graphUpdateQueue = new Queue<GraphUpdateObject>();

		private readonly List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> pendingPromises = new List<(IGraphUpdatePromise, IEnumerator<JobHandle>)>();

		private readonly List<GraphUpdateObject> pendingGraphUpdates = new List<GraphUpdateObject>();

		private static readonly ProfilerMarker MarkerSleep = new ProfilerMarker(ProfilerCategory.Loading, "Sleep");

		private static readonly ProfilerMarker MarkerCalculate = new ProfilerMarker("Calculating Graph Update");

		private static readonly ProfilerMarker MarkerApply = new ProfilerMarker("Applying Graph Update");

		public bool IsAnyGraphUpdateQueued => graphUpdateQueue.Count > 0;

		public bool IsAnyGraphUpdateInProgress => anyGraphUpdateInProgress;

		public GraphUpdateProcessor(AstarPath astar)
		{
			this.astar = astar;
		}

		public AstarWorkItem GetWorkItem()
		{
			return new AstarWorkItem(QueueGraphUpdatesInternal, ProcessGraphUpdates);
		}

		public void AddToQueue(GraphUpdateObject ob)
		{
			graphUpdateQueue.Enqueue(ob);
		}

		public void DiscardQueued()
		{
			while (graphUpdateQueue.Count > 0)
			{
				graphUpdateQueue.Dequeue().internalStage = -3;
			}
		}

		private void QueueGraphUpdatesInternal(IWorkItemContext context)
		{
			while (graphUpdateQueue.Count > 0)
			{
				GraphUpdateObject graphUpdateObject = graphUpdateQueue.Dequeue();
				pendingGraphUpdates.Add(graphUpdateObject);
				if (graphUpdateObject.internalStage != -2)
				{
					Debug.LogError("Expected remaining graph update to be pending");
				}
			}
			foreach (IUpdatableGraph updateableGraph in astar.data.GetUpdateableGraphs())
			{
				NavGraph navGraph = updateableGraph as NavGraph;
				List<GraphUpdateObject> list = ListPool<GraphUpdateObject>.Claim();
				for (int i = 0; i < pendingGraphUpdates.Count; i++)
				{
					GraphUpdateObject graphUpdateObject2 = pendingGraphUpdates[i];
					if (graphUpdateObject2.nnConstraint == null || graphUpdateObject2.nnConstraint.SuitableGraph((int)navGraph.graphIndex, navGraph))
					{
						list.Add(graphUpdateObject2);
					}
				}
				if (list.Count > 0)
				{
					IGraphUpdatePromise graphUpdatePromise = updateableGraph.ScheduleGraphUpdates(list);
					if (graphUpdatePromise != null)
					{
						IEnumerator<JobHandle> item = graphUpdatePromise.Prepare();
						pendingPromises.Add((graphUpdatePromise, item));
					}
					else
					{
						ListPool<GraphUpdateObject>.Release(ref list);
					}
				}
				else
				{
					ListPool<GraphUpdateObject>.Release(ref list);
				}
			}
			context.PreUpdate();
			anyGraphUpdateInProgress = true;
		}

		private bool ProcessGraphUpdates(IWorkItemContext context, bool force)
		{
			if (pendingPromises.Count > 0)
			{
				if (!ProcessGraphUpdatePromises(pendingPromises, context, force))
				{
					return false;
				}
				pendingPromises.Clear();
			}
			anyGraphUpdateInProgress = false;
			for (int i = 0; i < pendingGraphUpdates.Count; i++)
			{
				pendingGraphUpdates[i].internalStage = 0;
			}
			pendingGraphUpdates.Clear();
			return true;
		}

		public static bool ProcessGraphUpdatePromises(List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> promises, IGraphUpdateContext context, bool force = false)
		{
			TimeSlice timeSlice = TimeSlice.MillisFromNow(2f);
			TimeSlice timeSlice2 = default(TimeSlice);
			while (true)
			{
				int num = -1;
				bool flag = false;
				for (int i = 0; i < promises.Count; i++)
				{
					var (item, enumerator) = promises[i];
					if (enumerator == null)
					{
						continue;
					}
					if (force)
					{
						enumerator.Current.Complete();
					}
					else
					{
						if (!enumerator.Current.IsCompleted)
						{
							if (num == -1)
							{
								num = i;
							}
							continue;
						}
						enumerator.Current.Complete();
					}
					flag = true;
					try
					{
						if (enumerator.MoveNext())
						{
							if (num == -1)
							{
								num = i;
							}
						}
						else
						{
							promises[i] = (item, null);
						}
					}
					catch (Exception innerException)
					{
						Debug.LogError(new Exception("Error while updating graphs.", innerException));
						promises[i] = (null, null);
					}
				}
				if (num == -1)
				{
					break;
				}
				if (force)
				{
					continue;
				}
				if (timeSlice.expired)
				{
					return false;
				}
				if (flag)
				{
					timeSlice2 = TimeSlice.MillisFromNow(0.1f);
					continue;
				}
				if (timeSlice2.expired)
				{
					return false;
				}
				if (!flag)
				{
					Thread.Yield();
				}
			}
			for (int j = 0; j < promises.Count; j++)
			{
				IGraphUpdatePromise item2 = promises[j].Item1;
				if (item2 != null)
				{
					try
					{
						item2.Apply(context);
					}
					catch (Exception innerException2)
					{
						Debug.LogError(new Exception("Error while updating graphs.", innerException2));
					}
				}
			}
			return true;
		}
	}
}
