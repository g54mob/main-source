using System.Collections.Generic;

public class RetroUITextUndoQueue : RetroUIText.ITextListener
{
	private class UndoEntry
	{
		private List<Action> actions;

		public RetroUIText.TextCoord? newCaretCoord;

		public void AddAction(Action action)
		{
		}

		public void Undo(RetroUIText renderer)
		{
		}

		public void Redo(RetroUIText renderer)
		{
		}
	}

	private abstract class Action
	{
		public abstract void Undo(RetroUIText renderer);

		public abstract void Redo(RetroUIText renderer);
	}

	private class EmptyAction : Action
	{
		public override void Undo(RetroUIText renderer)
		{
		}

		public override void Redo(RetroUIText renderer)
		{
		}
	}

	private class ResetAction : Action
	{
		private string oldText;

		private string newText;

		public ResetAction(string oldText, string newText)
		{
		}

		public override void Undo(RetroUIText renderer)
		{
		}

		public override void Redo(RetroUIText renderer)
		{
		}
	}

	private class AddLineAction : Action
	{
		private int index;

		private string text;

		public AddLineAction(int index, string text)
		{
		}

		public override void Undo(RetroUIText renderer)
		{
		}

		public override void Redo(RetroUIText renderer)
		{
		}
	}

	private class EditLineAction : Action
	{
		private int index;

		private string previusText;

		private string newText;

		public EditLineAction(int index, string previusText, string newText)
		{
		}

		public override void Undo(RetroUIText renderer)
		{
		}

		public override void Redo(RetroUIText renderer)
		{
		}
	}

	private class RemoveLineAction : Action
	{
		private int index;

		private string text;

		public RemoveLineAction(int index, string text)
		{
		}

		public override void Undo(RetroUIText renderer)
		{
		}

		public override void Redo(RetroUIText renderer)
		{
		}
	}

	public bool recording;

	private LinkedList<UndoEntry> undoHistory;

	private LinkedListNode<UndoEntry> undoHistoryNode;

	private void AddAction(Action action, RetroUIText.TextCoord? caretPosition)
	{
	}

	public void Clear()
	{
	}

	public void NewEntry(RetroUIText renderer)
	{
	}

	public void OnAddedLine(RetroUIText renderer, int line)
	{
	}

	public void OnEditedLine(RetroUIText renderer, int line, string previusText)
	{
	}

	public void OnRemovingLine(RetroUIText renderer, int line)
	{
	}

	public void OnResettingTextData(RetroUIText renderer, string oldText, string newText)
	{
	}

	public void OnRenderVisibleLines(RetroUIText renderer, int startLine, int endLine)
	{
	}

	public bool Undo(RetroUIText renderer)
	{
		return false;
	}

	public bool Redo(RetroUIText renderer)
	{
		return false;
	}
}
