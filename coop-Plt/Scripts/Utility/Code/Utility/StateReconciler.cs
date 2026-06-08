using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code.Utility
{
	public abstract class StateReconciler<TIntendedState, TTargetState> where TIntendedState : new() where TTargetState : new()
	{
		public TIntendedState IntendedState = new TIntendedState();

		protected TTargetState TargetState = new TTargetState();

		private List<Func<TIntendedState, TTargetState, Task>> Reconciliations = new List<Func<TIntendedState, TTargetState, Task>>();

		private Task ReconciliationTask;

		private int ReconciliationGeneration;

		protected void AddReconciliation(Func<TIntendedState, TTargetState, Task> rs_func)
		{
			Reconciliations.Add(rs_func);
		}

		public void CheckAndReconcile(bool force_new_task = false)
		{
			if (!force_new_task)
			{
				Task reconciliationTask = ReconciliationTask;
				if (reconciliationTask != null && !reconciliationTask.IsCompleted && !reconciliationTask.IsCanceled && !reconciliationTask.IsFaulted)
				{
					return;
				}
			}
			ReconciliationTask = StartCheckAndReconcile();
		}

		private async Task StartCheckAndReconcile()
		{
			int generation = ++ReconciliationGeneration;
			try
			{
				await FetchState();
				if (ReconciliationGeneration != generation)
				{
					return;
				}
				await Reconcile(generation);
			}
			finally
			{
				await Task.Delay(TimeSpan.FromSeconds(3.0));
			}
		}

		private async Task Reconcile(int generation)
		{
			foreach (Func<TIntendedState, TTargetState, Task> reconciliation in Reconciliations)
			{
				if (ReconciliationGeneration != generation)
				{
					break;
				}
				await reconciliation(IntendedState, TargetState);
			}
		}

		protected abstract Task<bool> FetchState();
	}
}
