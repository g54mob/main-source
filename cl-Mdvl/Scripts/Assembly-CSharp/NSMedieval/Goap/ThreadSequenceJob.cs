using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;

namespace NSMedieval.Goap
{
	public class ThreadSequenceJob
	{
		private readonly List<ThreadSequenceStep> sequence = new List<ThreadSequenceStep>();

		private int sequenceCurStep;

		public event Action<ThreadSequenceJobCompleteStatus> OnStepFailedEvent;

		public ThreadSequenceJob()
		{
		}

		public ThreadSequenceJob(ThreadSequenceStep step)
		{
			AddStep(step);
		}

		public void AddStep(ThreadSequenceStep step)
		{
			sequence.Add(step);
		}

		internal void Start()
		{
			sequenceCurStep = 0;
		}

		internal bool HasNextStep()
		{
			if (sequenceCurStep < sequence.Count)
			{
				return sequence.Count > 0;
			}
			return false;
		}

		internal ThreadSequenceStep GetNextStep()
		{
			if (!HasNextStep())
			{
				Log.Warning("This should never be reached. Use @HasNextStep() before using this method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadSequenceJob.cs");
				return default(ThreadSequenceStep);
			}
			sequenceCurStep++;
			return sequence[sequenceCurStep - 1];
		}

		internal void OnCurrentStepFailed(ThreadSequenceJobCompleteStatus status)
		{
			this.OnStepFailedEvent?.Invoke(status);
		}
	}
}
