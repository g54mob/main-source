using UnityEngine;

public class Undo : MonoBehaviour
{
	public static StackList<string> undoStack = new StackList<string>();

	public static StackList<string> redoStack = new StackList<string>();

	public static string currentItem;

	public static void AddState()
	{
		string text = Project.SaveFile("", save: false);
		bool flag = false;
		if (currentItem != null)
		{
			if (text != currentItem)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			if (currentItem != null)
			{
				undoStack.Push(currentItem);
			}
			currentItem = text;
			redoStack.Clear();
			if (undoStack.Count() > 16)
			{
				LimitStates();
			}
		}
	}

	public static void UndoState()
	{
		if (CanUndo())
		{
			redoStack.Push(currentItem);
			currentItem = undoStack.Pop();
			SetState();
		}
	}

	public static void RedoState()
	{
		if (CanRedo())
		{
			undoStack.Push(currentItem);
			currentItem = redoStack.Pop();
			SetState();
		}
	}

	public static void ClearStates()
	{
		undoStack.Clear();
		redoStack.Clear();
		currentItem = null;
	}

	public static void SetState()
	{
		Project.LoadFile("", merge: true, Global.elements["workbench"], currentItem);
	}

	public static void LimitStates()
	{
		undoStack.Shift();
	}

	public static bool CanUndo()
	{
		return undoStack.Count() > 0;
	}

	public static bool CanRedo()
	{
		return redoStack.Count() > 0;
	}
}
