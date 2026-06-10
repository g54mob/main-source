using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;

namespace NSMedieval.Util
{
	public class RecurringThreadJob
	{
		private bool isRunning;

		private bool hasDisposed;

		public ThreadingJobSystem.TaskDelegate ThreadCallback { get; private set; }

		public ThreadingJobSystem.DoneCallback DoneCallback { get; private set; }

		public float IntervalSeconds { get; private set; }

		public bool ScheduleInUnscaledTime { get; private set; }

		public RecurringThreadJob(float intervalSeconds, ThreadingJobSystem.TaskDelegate threadCallback, ThreadingJobSystem.DoneCallback doneCallback = null, bool scheduleInUnscaledTime = false)
		{
			ThreadCallback = threadCallback;
			DoneCallback = doneCallback;
			IntervalSeconds = intervalSeconds;
			ScheduleInUnscaledTime = scheduleInUnscaledTime;
		}

		public RecurringThreadJob(float intervalSeconds, ThreadingJobSystem.TaskDelegate threadCallback, bool scheduleInUnscaledTime)
			: this(intervalSeconds, threadCallback, null, scheduleInUnscaledTime)
		{
		}

		public void ScheduleTask()
		{
			if (!isRunning && !hasDisposed)
			{
				isRunning = true;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(ThreadCallback, OnDone);
			}
		}

		private void OnDone(bool wasSuccessful)
		{
			if (!hasDisposed)
			{
				DoneCallback?.Invoke(wasSuccessful);
				isRunning = false;
				(ScheduleInUnscaledTime ? MonoSingleton<TaskController>.Instance.WaitForUnscaled(IntervalSeconds) : MonoSingleton<TaskController>.Instance.WaitFor(IntervalSeconds)).Then(ScheduleTask);
			}
		}

		public void Dispose()
		{
			hasDisposed = true;
			ThreadCallback = null;
			DoneCallback = null;
		}
	}
}
