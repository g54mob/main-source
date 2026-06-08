using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NotepadUndo : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField inputField;

	[SerializeField]
	private Notepad notepad;

	private List<TextHistory>[] noteCache;

	private int[] cacheSize;

	private int[] currentIndex;

	private PlayerInput panelInput;

	private void Awake()
	{
		panelInput = GetComponent<PlayerInput>();
		InputAction inputAction = panelInput.actions["Undo"];
		InputAction inputAction2 = panelInput.actions["Redo"];
		inputAction.performed += delegate
		{
			Undo();
		};
		inputAction2.performed += delegate
		{
			Redo();
		};
		InputAction inputAction3 = panelInput.actions["Undo Hold"];
		InputAction inputAction4 = panelInput.actions["Redo Hold"];
		inputAction3.performed += UndoHold;
		inputAction4.performed += RedoHold;
	}

	private void Start()
	{
		noteCache = InitializeNoteCache();
		UIUtils.LogCollection("Init -> ", GetCurrentHistory());
		currentIndex = new int[Notepad.TOTAL_PAGES];
		cacheSize = InitializeArray(1);
	}

	private int[] InitializeArray(int value)
	{
		int[] array = new int[Notepad.TOTAL_PAGES];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = value;
		}
		return array;
	}

	private List<TextHistory>[] InitializeNoteCache()
	{
		List<TextHistory>[] array = new List<TextHistory>[Notepad.TOTAL_PAGES];
		for (int i = 0; i < Notepad.TOTAL_PAGES; i++)
		{
			string note = notepad.GetNote(i);
			array[i] = new List<TextHistory>
			{
				new TextHistory(note, note.Length)
			};
		}
		return array;
	}

	public bool ShouldSkipCache()
	{
		int currentPage = notepad.GetCurrentPage();
		if (inputField.text == GetCurrentHistory()[currentIndex[currentPage]].text)
		{
			return true;
		}
		if (inputField.text.Length <= 0)
		{
			return false;
		}
		if (inputField.text[inputField.text.Length - 1] == '\0')
		{
			return true;
		}
		return false;
	}

	public void AddQueryToQueue()
	{
		UIUtils.LogCollection("AddQueryToQueue -> ", GetCurrentHistory());
		if (ShouldSkipCache())
		{
			Debug.Log("Skipping cache");
			return;
		}
		int currentPage = notepad.GetCurrentPage();
		currentIndex[currentPage]++;
		cacheSize[currentPage] = currentIndex[currentPage] + 1;
		GetCurrentHistory().Insert(currentIndex[currentPage], new TextHistory(inputField.text, inputField.caretPosition));
	}

	public void UndoHold(InputAction.CallbackContext context)
	{
		if (inputField.isFocused)
		{
			StartCoroutine(HoldImpl(context, Undo));
		}
	}

	public void RedoHold(InputAction.CallbackContext context)
	{
		if (inputField.isFocused)
		{
			StartCoroutine(HoldImpl(context, Redo));
		}
	}

	private IEnumerator HoldImpl(InputAction.CallbackContext context, Action action)
	{
		while (IsHeld(context))
		{
			action();
			yield return new WaitForSeconds(0.05f);
		}
	}

	private bool IsHeld(InputAction.CallbackContext context)
	{
		try
		{
			return context.control.IsPressed();
		}
		catch (IndexOutOfRangeException)
		{
			return false;
		}
	}

	private List<TextHistory> GetCurrentHistory()
	{
		return noteCache[notepad.GetCurrentPage()];
	}

	public void Undo()
	{
		UIUtils.LogCollection("Undo -> ", GetCurrentHistory());
		if (!inputField.isFocused)
		{
			Debug.Log("Not focused");
			return;
		}
		int currentPage = notepad.GetCurrentPage();
		if (cacheSize[currentPage] <= 0 || currentIndex[currentPage] <= 0)
		{
			Debug.Log("Cannot undo");
			return;
		}
		Debug.Log($"Caret Position: {inputField.caretPosition} / {inputField.text.Length}");
		inputField.text = GetCurrentHistory()[--currentIndex[currentPage]].text;
		inputField.caretPosition = GetCurrentHistory()[currentIndex[currentPage]].caretIndex;
		Debug.Log($"{currentIndex[currentPage]}: {inputField.text}");
	}

	public void Redo()
	{
		if (inputField.isFocused)
		{
			int currentPage = notepad.GetCurrentPage();
			if (cacheSize[currentPage] <= 0 || currentIndex[currentPage] >= cacheSize[currentPage] - 1)
			{
				Debug.Log("Cannot redo");
				return;
			}
			inputField.text = GetCurrentHistory()[++currentIndex[currentPage]].text;
			inputField.caretPosition = GetCurrentHistory()[currentIndex[currentPage]].caretIndex;
			Debug.Log($"{currentIndex}: {inputField.text}");
		}
	}
}
