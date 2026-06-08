using System;
using UnityEngine;

public class NoteBaseWindow
{
	protected Rect windowRect = default(Rect);

	protected UITextEditor noteEditor;

	public string windowTitle { get; set; }

	protected bool showValidateButton { get; set; }

	private NoteBaseWindow()
	{
	}

	public NoteBaseWindow(char[] excludedChars, float width, float height)
	{
		windowRect.width = width;
		windowRect.height = height;
		noteEditor = new UITextEditor
		{
			InputArea = new Rect(5f, 15f, windowRect.width - 15f, windowRect.height - 60f),
			MaxCharacters = 500,
			MaintainFocus = true,
			ShowFilteredValues = true,
			ExcludedCharacters = excludedChars,
			DelayInputUntilFirstFrame = true
		};
		UITextEditor uITextEditor = noteEditor;
		uITextEditor.canceled = (UITextEditor.EditorEvent)Delegate.Combine(uITextEditor.canceled, new UITextEditor.EditorEvent(CanceledEditor));
		Initialize();
	}

	public virtual void Initialize()
	{
		noteEditor.Initialize();
	}

	public bool Update()
	{
		bool result = false;
		if (!DialogUI.Instance.IsShowing && Input.GetKeyDown(KeyCode.Escape))
		{
			result = true;
		}
		return result;
	}

	protected void DrawWindow(int id)
	{
		noteEditor.Draw();
		string text = "Save";
		string text2 = "Revert";
		string text3 = "Cancel";
		string text4 = "Validate";
		if (Event.current.alt)
		{
			text = "[S]ave";
			text2 = "[R]evert";
			text3 = "[C]ancel";
			text4 = "[V]alidate";
			if (noteEditor.IsDirty)
			{
				if (Event.current.keyCode == KeyCode.S)
				{
					CloseButtonPressed();
					return;
				}
				if (Event.current.keyCode == KeyCode.R)
				{
					UndoButtonPressed();
					return;
				}
			}
			if (Event.current.keyCode == KeyCode.C)
			{
				CancelButtonPressed();
				return;
			}
			if (showValidateButton && Event.current.keyCode == KeyCode.V)
			{
				ValidateButtonPressed();
				return;
			}
		}
		if (!noteEditor.IsDirty)
		{
			GUI.enabled = false;
		}
		if (GUI.Button(new Rect(5f, windowRect.height - 30f, 100f, 25f), text))
		{
			CloseButtonPressed();
		}
		if (GUI.Button(new Rect(120f, windowRect.height - 30f, 100f, 25f), text2))
		{
			UndoButtonPressed();
		}
		if (!noteEditor.IsDirty)
		{
			GUI.enabled = true;
		}
		if (showValidateButton && GUI.Button(new Rect(windowRect.width - 220f, windowRect.height - 30f, 100f, 25f), text4))
		{
			ValidateButtonPressed();
		}
		if (GUI.Button(new Rect(windowRect.width - 105f, windowRect.height - 30f, 100f, 25f), text3))
		{
			CancelButtonPressed();
		}
		GUI.DragWindow();
	}

	public void ShowWindow()
	{
		windowRect = GUI.Window(33, windowRect, DrawWindow, windowTitle);
	}

	protected virtual void CloseButtonPressed()
	{
		noteEditor.SaveEditor();
	}

	protected virtual bool ValidateButtonPressed()
	{
		return true;
	}

	protected virtual void UndoButtonPressed()
	{
		noteEditor.UndoEditor();
	}

	protected virtual void CancelButtonPressed()
	{
	}

	protected virtual void CanceledEditor()
	{
	}
}
