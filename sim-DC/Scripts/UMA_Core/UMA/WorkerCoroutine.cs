using System.Collections;

namespace UMA
{
	public abstract class WorkerCoroutine
	{
		private IEnumerator workerInstance;

		private WorkerCoroutine subWorker;

		public int TimeHint;

		public WorkerCoroutine lastWorker;

		public int lastWorkerCount;

		protected abstract void Start();

		protected abstract IEnumerator workerMethod();

		protected abstract void Stop();

		public void Cancel()
		{
		}

		public bool Work()
		{
			return false;
		}
	}
}
