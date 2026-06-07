using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class Parallel
	{
		public static void For(int iterations, Action<int> function)
		{
			int iterationsPassed = 0;
			ManualResetEvent resetEvent = new ManualResetEvent(false);
			for (int i = 0; i < iterations; i++)
			{
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					int obj = (int)state;
					try
					{
						function(obj);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					if (Interlocked.Increment(ref iterationsPassed) == iterations)
					{
						resetEvent.Set();
					}
				}, i);
			}
			resetEvent.WaitOne();
		}

		public static void ForEach<T>(IEnumerable<T> collection, Action<T> function)
		{
			int iterations = 0;
			int iterationsPassed = 0;
			ManualResetEvent resetEvent = new ManualResetEvent(false);
			foreach (T item in collection)
			{
				Interlocked.Increment(ref iterations);
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					T obj = (T)state;
					try
					{
						function(obj);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					if (Interlocked.Increment(ref iterationsPassed) == iterations)
					{
						resetEvent.Set();
					}
				}, item);
			}
			resetEvent.WaitOne();
		}
	}
}
