using System;

namespace Gh.Tk
{
	public abstract class UndoRedoCommandWithState : IUndoRedoCommand, IDisposable
	{
		private bool _executed;

		private bool _undone;

		protected abstract void ExecuteInternal();

		public void Execute()
		{
		}

		protected abstract void UndoInternal();

		public void Undo()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void CleanUpWhenExecuted()
		{
		}

		protected virtual void CleanUpWhenUndone()
		{
		}
	}
}
