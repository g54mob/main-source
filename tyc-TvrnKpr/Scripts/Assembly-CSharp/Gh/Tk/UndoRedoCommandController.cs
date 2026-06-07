using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class UndoRedoCommandController
	{
		private readonly List<IUndoRedoCommand> _commands;

		private int _nextIndex;

		public EventHandler<EventArgs> StateChanged;

		public void ClearCommands()
		{
		}

		public void AddCommand(IUndoRedoCommand command, bool autoExecute = true)
		{
		}

		public void UndoCommand()
		{
		}

		public void RedoCommand()
		{
		}

		public bool CanRedo()
		{
			return false;
		}

		public bool CanUndo()
		{
			return false;
		}
	}
}
