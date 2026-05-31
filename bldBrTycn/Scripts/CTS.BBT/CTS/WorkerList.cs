using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;

namespace CTS
{
	public static class WorkerList
	{
		private static readonly HashSet<Worker> Workers = new HashSet<Worker>();

		public static readonly Func<Worker, WorkerPowerFeature.e_PowerFeatures, bool> HasPower = (Worker worker, WorkerPowerFeature.e_PowerFeatures power) => worker.PowerFeatures.HavePower(power);

		public static readonly Func<Worker, ChoreCategory, bool> HasChoreHigherPriorityActive = (Worker worker, ChoreCategory chore) => worker.ChoreAssigner.TryGetPriority(chore, out var selfEnabled, out var priority) && selfEnabled && priority == 0;

		public static readonly Func<Worker, ChoreCategory, bool> HasChorePriorityActive = (Worker worker, ChoreCategory priority) => worker.ChoreAssigner.TryGetPrioritySelfActive(priority, out var selfEnabled) && selfEnabled;

		public static readonly Func<Worker, ChoreCategory, bool> HasChorePriorityGloballyActive = (Worker worker, ChoreCategory priority) => worker.ChoreAssigner.TryGetPriorityGloballyActive(priority, out var globalEnabled) && globalEnabled;

		public static int Count => Workers.Count;

		public static ReadOnlyHashSet<Worker> All => new ReadOnlyHashSet<Worker>(Workers);

		public static event Action<int> WorkerListUpdated;

		public static void Add(Worker worker)
		{
			if (Workers.Add(worker))
			{
				WorkerList.WorkerListUpdated?.Invoke(Count);
			}
		}

		public static void Remove(Worker worker)
		{
			if (Workers.Remove(worker))
			{
				WorkerList.WorkerListUpdated?.Invoke(Count);
			}
		}

		public static bool DoesAnyExist()
		{
			return Workers.Any();
		}

		public static void Get(List<Worker> workers)
		{
			foreach (Worker worker in Workers)
			{
				workers.Add(worker);
			}
		}

		public static bool DoesAnyExist(Func<Worker, bool> filter)
		{
			foreach (Worker worker in Workers)
			{
				if (filter(worker))
				{
					return true;
				}
			}
			return false;
		}

		public static bool DoesAnyExist<TArg>(Func<Worker, TArg, bool> filter, TArg arg)
		{
			foreach (Worker worker in Workers)
			{
				if (filter(worker, arg))
				{
					return true;
				}
			}
			return false;
		}

		public static bool DoesAnyExist<TArg1, TArg2>(Func<Worker, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			foreach (Worker worker in Workers)
			{
				if (filter(worker, arg1, arg2))
				{
					return true;
				}
			}
			return false;
		}

		public static bool TryGet(out Worker outWorker)
		{
			using (HashSet<Worker>.Enumerator enumerator = Workers.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Worker current = enumerator.Current;
					outWorker = current;
					return true;
				}
			}
			outWorker = null;
			return false;
		}

		public static bool TryGet(out Worker outWorker, Func<Worker, bool> filter)
		{
			foreach (Worker worker in Workers)
			{
				if (filter(worker))
				{
					outWorker = worker;
					return true;
				}
			}
			outWorker = null;
			return false;
		}

		public static bool TryGet<TArg>(out Worker outWorker, Func<Worker, TArg, bool> filter, TArg arg)
		{
			foreach (Worker worker in Workers)
			{
				if (filter(worker, arg))
				{
					outWorker = worker;
					return true;
				}
			}
			outWorker = null;
			return false;
		}

		public static bool TryGet<TArg1, TArg2>(out Worker outWorker, Func<Worker, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			foreach (Worker worker in Workers)
			{
				if (filter(worker, arg1, arg2))
				{
					outWorker = worker;
					return true;
				}
			}
			outWorker = null;
			return false;
		}
	}
}
