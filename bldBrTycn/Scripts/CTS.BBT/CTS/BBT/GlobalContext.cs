using System;
using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.BBT
{
	public static class GlobalContext
	{
		private static readonly Dictionary<Type, List<WorkerChore>> globalContext = new Dictionary<Type, List<WorkerChore>>();

		public static void AddChore<TContext>(WorkerChore p_chore) where TContext : IContextActor
		{
			Type typeFromHandle = typeof(TContext);
			ValidatePool(typeFromHandle);
			globalContext[typeFromHandle].Add(p_chore);
		}

		public static void RemoveChore<TContext>(WorkerChore p_chore) where TContext : IContextActor
		{
			Type typeFromHandle = typeof(TContext);
			if (globalContext.ContainsKey(typeFromHandle))
			{
				globalContext[typeFromHandle].Remove(p_chore);
			}
		}

		public static IEnumerator<WorkerChore> Values<TContext>() where TContext : IContextActor
		{
			Type typeFromHandle = typeof(TContext);
			if (!globalContext.ContainsKey(typeFromHandle) || globalContext[typeFromHandle].Count <= 0)
			{
				yield break;
			}
			foreach (WorkerChore item in globalContext[typeFromHandle])
			{
				yield return item;
			}
		}

		private static void ValidatePool(Type p_key)
		{
			if (!globalContext.ContainsKey(p_key))
			{
				globalContext.Add(p_key, new List<WorkerChore>());
			}
		}
	}
}
