using System.Collections.Generic;

namespace NSMedieval.Almanac
{
	public class UndoRedoStack<TAction>
	{
		private Stack<TAction> undo;

		private Stack<TAction> redo;

		public int UndoCount => undo.Count;

		public int RedoCount => redo.Count;

		public UndoRedoStack()
		{
			Reset();
		}

		public void Reset()
		{
			undo = new Stack<TAction>();
			redo = new Stack<TAction>();
		}

		public TAction Do(TAction input)
		{
			undo.Push(input);
			redo.Clear();
			return input;
		}

		public TAction Undo()
		{
			if (UndoCount > 1)
			{
				redo.Push(undo.Pop());
				return undo.Peek();
			}
			return default(TAction);
		}

		public TAction Redo()
		{
			if (redo.Count > 0)
			{
				TAction val = redo.Pop();
				undo.Push(val);
				return val;
			}
			return default(TAction);
		}
	}
}
