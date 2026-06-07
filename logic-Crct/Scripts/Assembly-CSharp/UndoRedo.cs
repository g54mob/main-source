using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UndoRedo : MonoBehaviour
{
	private static UndoRedo inst;

	public int undoLevels;

	[Header("Buttons")]
	public Button undoBtn;

	public Button redoBtn;

	public Image undoArrow;

	public Image redoArrow;

	public Color offColor;

	[Header("CTRL + command")]
	public KeyCode undoCmd;

	public KeyCode redoCmd;

	private List<Memento> undoStack { get; set; }

	private List<Memento> redoStack { get; set; }

	private int undoId { get; set; }

	private int redoId { get; set; }

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public static void ClearUndoRedo()
	{
	}

	public static void CallUndo()
	{
	}

	public void Undo()
	{
	}

	public static void CallRedo()
	{
	}

	public void Redo()
	{
	}

	public static int AddUndoValue(Action<object[]> m, params object[] v)
	{
		return 0;
	}

	public static void AddUndoValueMultiple(int id, Action<object[]> m, params object[] v)
	{
	}

	public static void AddUndoValue_RedoMultiple(int id, Action<object[]> m, params object[] v)
	{
	}

	public static int AddUndoValue_Redo(Action<object[]> m, params object[] v)
	{
		return 0;
	}

	public static void AddRedoValue(Action<object[]> m, params object[] v)
	{
	}

	private int LocalAddUndoValue(Action<object[]> m, params object[] v)
	{
		return 0;
	}

	private void LocalAddUndoValueMultiple(int id, Action<object[]> m, params object[] v)
	{
	}

	private void LocalAddUndoValue_RedoMultiple(int id, Action<object[]> m, params object[] v)
	{
	}

	private int LocalAddUndoValue_Redo(Action<object[]> m, params object[] v)
	{
		return 0;
	}

	private void LocalAddRedoValue(Action<object[]> m, params object[] v)
	{
	}

	private void TrimUndoStack()
	{
	}
}
