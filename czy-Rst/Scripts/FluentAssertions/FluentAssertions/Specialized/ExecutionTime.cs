using System;
using System.Threading.Tasks;
using FluentAssertions.Common;

namespace FluentAssertions.Specialized
{
	public class ExecutionTime
	{
		private ITimer timer;

		internal TimeSpan ElapsedTime => timer?.Elapsed ?? TimeSpan.Zero;

		internal bool IsRunning { get; private set; }

		internal string ActionDescription { get; }

		internal Task Task { get; }

		internal Exception Exception { get; private set; }

		public ExecutionTime(Action action, StartTimer createTimer)
			: this(action, "the action", createTimer)
		{
		}

		public ExecutionTime(Func<Task> action, StartTimer createTimer)
			: this(action, "the action", createTimer)
		{
		}

		protected ExecutionTime(Action action, string actionDescription, StartTimer createTimer)
		{
			ExecutionTime executionTime = this;
			Guard.ThrowIfArgumentIsNull(action, "action");
			ActionDescription = actionDescription;
			IsRunning = true;
			Task = Task.Run(delegate
			{
				try
				{
					using (executionTime.timer = createTimer())
					{
						action();
					}
				}
				catch (Exception exception)
				{
					executionTime.Exception = exception;
				}
				finally
				{
					executionTime.IsRunning = false;
				}
			});
		}

		protected ExecutionTime(Func<Task> action, string actionDescription, StartTimer createTimer)
		{
			ExecutionTime executionTime = this;
			Guard.ThrowIfArgumentIsNull(action, "action");
			ActionDescription = actionDescription;
			IsRunning = true;
			Task = Task.Run(async delegate
			{
				try
				{
					using (executionTime.timer = createTimer())
					{
						await action();
					}
				}
				catch (Exception exception)
				{
					executionTime.Exception = exception;
				}
				finally
				{
					executionTime.IsRunning = false;
				}
			});
		}
	}
}
