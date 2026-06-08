using System;
using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;

namespace Jobberwocky.GeometryAlgorithms.Source.API
{
	public abstract class ThreadingAPI
	{
		protected class ThreadingResult
		{
			public Action<Geometry> Callback;

			public Geometry Output;

			public ThreadingResult(Action<Geometry> callback, Geometry output)
			{
				Callback = callback;
				Output = output;
			}
		}

		protected static List<ThreadingResult> ThreadingResultQueue = new List<ThreadingResult>();

		public void ActivateCallbacks()
		{
			for (int i = 0; i < ThreadingResultQueue.Count; i++)
			{
				lock (ThreadingResultQueue)
				{
					ThreadingResult threadingResult = ThreadingResultQueue[i];
					threadingResult.Callback(threadingResult.Output);
					ThreadingResultQueue.RemoveAt(i);
				}
			}
		}

		protected static void StartWorker(Func<IParameters, Action<Geometry>, ThreadingResult> method, IParameters parameters, Action<Geometry> callback)
		{
			method.BeginInvoke(parameters, callback, WorkerCompleted, method);
		}

		protected static void WorkerCompleted(IAsyncResult method)
		{
			ThreadingResult item = ((Func<IParameters, Action<Geometry>, ThreadingResult>)method.AsyncState).EndInvoke(method);
			ThreadingResultQueue.Add(item);
		}
	}
}
