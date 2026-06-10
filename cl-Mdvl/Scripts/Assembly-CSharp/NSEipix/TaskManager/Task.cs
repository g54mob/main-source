using System;
using System.Collections.Generic;

namespace NSEipix.TaskManager
{
	public class Task
	{
		public bool IsRunning;

		private readonly Queue<Step> steps = new Queue<Step>();

		public bool IsComplete => steps.Count == 0;

		public Task Then(Action action)
		{
			steps.Enqueue(new StepAction(action));
			return this;
		}

		public Task ThenWaitFor(float seconds, bool isUnscaled = false)
		{
			steps.Enqueue(new StepTimeWait(seconds, isUnscaled));
			return this;
		}

		public Task ThenWaitUntil(UntilTaskPredicate condition)
		{
			steps.Enqueue(new StepConditionWait(condition));
			return this;
		}

		public Task WaitForNextFrame()
		{
			steps.Enqueue(new StepTimeWait(0.01f));
			return this;
		}

		public Task WaitForNextFrameUnscaled()
		{
			steps.Enqueue(new StepTimeWait(0.01f, isUnscaled: true));
			return this;
		}

		public Task DoForTime(Action<float> action, float duration)
		{
			steps.Enqueue(new StepDoForTime(action, duration));
			return this;
		}

		public Task DoUntil(Action action, Func<bool> condition)
		{
			steps.Enqueue(new StepDoUntil(action, condition));
			return this;
		}

		public void Stop()
		{
			IsRunning = false;
			steps.Clear();
		}

		public void Update()
		{
			if (IsComplete)
			{
				return;
			}
			Step step = steps.Peek();
			step.Update();
			if (step.IsCompleted())
			{
				step.OnCompleted();
				if (!IsComplete)
				{
					steps.Dequeue();
				}
			}
		}
	}
}
