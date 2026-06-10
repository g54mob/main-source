using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;

namespace NSMedieval.Goap
{
	public class ThreadSequenceExecutor
	{
		public delegate void CompletedListener(ThreadSequenceJobCompleteStatus status, ThreadSequenceJob job);

		private class ThreadedTask
		{
			private readonly ThreadSequenceJob job;

			private readonly ThreadingJobSystem.ThreadedTaskData task;

			public ThreadSequenceJob Job => job;

			public ThreadingJobSystem.ThreadedTaskData Task => task;

			public ThreadedTask(ThreadSequenceJob job, ThreadingJobSystem.ThreadedTaskData task)
			{
				this.job = job;
				this.task = task;
			}
		}

		private readonly HashSet<ThreadedTask> threadedTasks = new HashSet<ThreadedTask>();

		private bool isSequenceExecuting;

		public bool IsSequenceExecuting => isSequenceExecuting;

		public event CompletedListener CompletedListenerEvent;

		public void Abort()
		{
			if (threadedTasks.Count == 0)
			{
				return;
			}
			foreach (ThreadedTask item in new HashSet<ThreadedTask>(threadedTasks))
			{
				item.Task.ResultFailOverride = true;
				JobCompleted(ThreadSequenceJobCompleteStatus.Abort, item.Job);
			}
			threadedTasks.Clear();
		}

		public ThreadSequenceExecuteStatus ExecuteSequence(ThreadSequenceJob job)
		{
			if (threadedTasks.Count > 0)
			{
				Log.Warning("Tried to execute new sequence while previous was already running", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadSequenceExecutor.cs");
				return ThreadSequenceExecuteStatus.Aborting;
			}
			job.Start();
			if (!job.HasNextStep())
			{
				return ThreadSequenceExecuteStatus.NothingToDo;
			}
			isSequenceExecuting = true;
			ThreadSequenceStep nextStep = job.GetNextStep();
			ExecuteSequenceStep(job, nextStep);
			return ThreadSequenceExecuteStatus.Started;
		}

		private void ExecuteSequenceStep(ThreadSequenceJob job, ThreadSequenceStep step)
		{
			if (step.OnStart != null && !step.OnStart())
			{
				JobCompleted(ThreadSequenceJobCompleteStatus.Fail, job);
				return;
			}
			if (step.OnThread == null)
			{
				if (step.OnFinish != null && !step.OnFinish())
				{
					JobCompleted(ThreadSequenceJobCompleteStatus.Fail, job);
				}
				else if (!job.HasNextStep())
				{
					JobCompleted(ThreadSequenceJobCompleteStatus.Success, job);
				}
				else
				{
					ExecuteSequenceStep(job, job.GetNextStep());
				}
				return;
			}
			ThreadingJobSystem.ThreadedTaskData task = null;
			task = MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(() => step.OnThread(), delegate(bool result)
			{
				if (!threadedTasks.All((ThreadedTask item) => item.Task != task))
				{
					threadedTasks.RemoveWhere((ThreadedTask item) => item.Task == task);
					if (!result)
					{
						JobCompleted(ThreadSequenceJobCompleteStatus.Fail, job);
					}
					else if (step.OnFinish != null && !step.OnFinish())
					{
						JobCompleted(ThreadSequenceJobCompleteStatus.Fail, job);
					}
					else if (job.HasNextStep())
					{
						ExecuteSequenceStep(job, job.GetNextStep());
					}
					else
					{
						JobCompleted(ThreadSequenceJobCompleteStatus.Success, job);
					}
				}
			});
			threadedTasks.Add(new ThreadedTask(job, task));
		}

		private void JobCompleted(ThreadSequenceJobCompleteStatus status, ThreadSequenceJob job)
		{
			job.OnCurrentStepFailed(status);
			this.CompletedListenerEvent?.Invoke(status, job);
			threadedTasks.Clear();
			isSequenceExecuting = false;
		}
	}
}
