using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UndoRedo : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField queryInput;

	private List<TextHistory> queryCache;

	private int cacheSize;

	private int currentIndex;

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
		queryCache = new List<TextHistory>
		{
			new TextHistory()
		};
		currentIndex = 0;
		cacheSize = 1;
	}

	public bool ShouldSkipCache()
	{
		if (queryInput.text == queryCache[currentIndex].text)
		{
			return true;
		}
		if (queryInput.text.Length <= 0)
		{
			return false;
		}
		if (queryInput.text[queryInput.text.Length - 1] == '\0')
		{
			return true;
		}
		return false;
	}

	public void AddQueryToQueue()
	{
		if (!ShouldSkipCache())
		{
			currentIndex++;
			cacheSize = currentIndex + 1;
			queryCache.Insert(currentIndex, new TextHistory(queryInput.text, queryInput.caretPosition));
		}
	}

	public void UndoHold(InputAction.CallbackContext context)
	{
		if (queryInput.isFocused)
		{
			StartCoroutine(HoldImpl(context, Undo));
		}
	}

	public void RedoHold(InputAction.CallbackContext context)
	{
		if (queryInput.isFocused)
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

	public void Undo()
	{
		if (queryInput.isFocused)
		{
			if (cacheSize <= 0 || currentIndex <= 0)
			{
				Debug.Log("Cannot undo");
				return;
			}
			Debug.Log($"Caret Position: {queryInput.caretPosition} / {queryInput.text.Length}");
			queryInput.text = queryCache[--currentIndex].text;
			queryInput.caretPosition = queryCache[currentIndex].caretIndex;
			Debug.Log($"{currentIndex}: {queryInput.text}");
		}
	}

	public void Redo()
	{
		if (queryInput.isFocused)
		{
			if (cacheSize <= 0 || currentIndex >= cacheSize - 1)
			{
				Debug.Log("Cannot redo");
				return;
			}
			queryInput.text = queryCache[++currentIndex].text;
			queryInput.caretPosition = queryCache[currentIndex].caretIndex;
			Debug.Log($"{currentIndex}: {queryInput.text}");
		}
	}
}
