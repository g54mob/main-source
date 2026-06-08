using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Utility
{
	public class CachedTask<TResult> : ITaskDependency
	{
		private CancellationTokenSource CancellationTokenSource;

		private Task<TResult> CurrentTask;

		private Func<bool, CancellationToken, Task<TResult>> Function;

		private List<ITaskDependency> Dependencies;

		public bool IsReady
		{
			get
			{
				if (CurrentTask != null)
				{
					if (CurrentTask.Status != TaskStatus.RanToCompletion)
					{
						return CurrentTask.IsFaulted;
					}
					return true;
				}
				return false;
			}
		}

		public bool Succeeded
		{
			get
			{
				if (CurrentTask != null)
				{
					return CurrentTask.Status == TaskStatus.RanToCompletion;
				}
				return false;
			}
		}

		public bool Finished
		{
			get
			{
				if (CurrentTask != null)
				{
					if (!CurrentTask.IsCanceled && !CurrentTask.IsFaulted)
					{
						return CurrentTask.IsCompleted;
					}
					return true;
				}
				return false;
			}
		}

		public bool Started => CurrentTask != null;

		public bool IsRunning
		{
			get
			{
				if (Started)
				{
					return !Finished;
				}
				return false;
			}
		}

		public bool Failed
		{
			get
			{
				if (CurrentTask != null)
				{
					if (!CurrentTask.IsCanceled)
					{
						return CurrentTask.IsFaulted;
					}
					return true;
				}
				return false;
			}
		}

		public Task<TResult> State => Run();

		public TResult TryResult
		{
			get
			{
				if (!Succeeded)
				{
					return default(TResult);
				}
				return State.Result;
			}
		}

		public Exception TryError
		{
			get
			{
				Task<TResult> currentTask = CurrentTask;
				if (currentTask == null || currentTask.Status != TaskStatus.Faulted)
				{
					return null;
				}
				return CurrentTask.Exception?.Flatten().InnerExceptions.FirstOrDefault();
			}
		}

		public TaskAwaiter<TResult> GetAwaiter()
		{
			return State.GetAwaiter();
		}

		public CachedTask(Func<bool, CancellationToken, Task<TResult>> func)
		{
			Function = func;
			Dependencies = new List<ITaskDependency>();
		}

		public CachedTask<TResult> DependsOn(ITaskDependency dependency)
		{
			Dependencies.Add(dependency);
			return this;
		}

		public void Cancel()
		{
			CancellationTokenSource?.Cancel();
			CurrentTask = null;
		}

		public Task<TResult> Run(bool force_rerun = false)
		{
			if (force_rerun || CurrentTask == null || CurrentTask.IsCanceled || CancellationTokenSource.IsCancellationRequested)
			{
				CancellationTokenSource?.Cancel();
				CancellationTokenSource = new CancellationTokenSource();
				CurrentTask = Execute(force_rerun, CancellationTokenSource.Token);
			}
			return CurrentTask;
		}

		public async Task<bool> EnsureCompletion(bool force_rerun, CancellationToken token)
		{
			try
			{
				await Run(force_rerun);
				token.ThrowIfCancellationRequested();
				return IsReady;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private async Task<TResult> Execute(bool force_rerun, CancellationToken token)
		{
			foreach (ITaskDependency dep in Dependencies)
			{
				if (!(await dep.EnsureCompletion(force_rerun, token)))
				{
					throw new DependencyFailedException("Dependency " + dep.GetType().Name + " failed or was cancelled.");
				}
			}
			token.ThrowIfCancellationRequested();
			return await Function(force_rerun, token);
		}
	}
}
