using UnityEngine;

public class UITextEditor
{
	public delegate void EditorEvent();

	public EditorEvent canceled;

	private Rect _inputArea = default(Rect);

	private Rect inputDrawableArea;

	private int _textSize = 15;

	private Vector2 scrollPos = Vector2.zero;

	private GUIStyle textStyle;

	private GUIStyle noteStyle;

	private int topPos;

	private int bottomPos;

	private int bottomBasePos;

	private int bottomPosLowest;

	private int selectionRow;

	private int selectionCharacter;

	private bool isSpecialKeyDown;

	private bool isFirstFocus;

	private bool isSkippingFrame;

	private bool isInTextSelectMode;

	public bool IsDirty
	{
		get
		{
			return Text != OriginalText;
		}
	}

	public bool DelayInputUntilFirstFrame { get; set; }

	public bool DelayInputUntilKeyNoKeyDown { get; set; }

	public Rect InputArea
	{
		get
		{
			return _inputArea;
		}
		set
		{
			_inputArea = value;
			Rect rect = value;
			rect.y += 15f;
			rect.height -= 20f;
			inputDrawableArea = rect;
			_inputArea.x -= 8f;
			bottomPos = (int)((InputArea.height - 30f) / textStyle.lineHeight) - 1;
			bottomBasePos = bottomPos;
			bottomPosLowest = bottomBasePos;
		}
	}

	public char[] ExcludedCharacters { get; set; }

	public string Text { get; private set; }

	public string OriginalText { get; private set; }

	public int MaxCharacters { get; set; }

	public int TextSize
	{
		get
		{
			return _textSize;
		}
		set
		{
			_textSize = value;
			if (textStyle != null)
			{
				textStyle.fontSize = value;
			}
		}
	}

	public bool HandleEscape { get; set; }

	public bool MaintainFocus { get; set; }

	public bool ShowFilteredValues { get; set; }

	public UITextEditor()
	{
		if (!ResourceManager.OneTimeGalaxyLoadPerformed)
		{
			ResourceManager.OneTimeGalaxyResourceLoad();
		}
		textStyle = new GUIStyle();
		textStyle.fontSize = TextSize;
		textStyle.normal.textColor = Color.white;
		noteStyle = new GUIStyle();
		noteStyle.fontSize = 10;
		noteStyle.normal.textColor = Color.gray;
		noteStyle.alignment = TextAnchor.UpperRight;
		Text = string.Empty;
		Initialize();
	}

	public void Initialize()
	{
		isFirstFocus = true;
	}

	public void SetText(string text)
	{
		Text = text;
		OriginalText = text;
	}

	public void Draw()
	{
		if (DialogUI.Instance.IsShowing)
		{
			return;
		}
		if (HandleEscape && isSkippingFrame)
		{
			if (Event.current.keyCode == KeyCode.Escape)
			{
				isSkippingFrame = false;
			}
			return;
		}
		bool flag = false;
		TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
		if (isInTextSelectMode)
		{
			textEditor.MoveTextStart();
			for (int i = 0; i < selectionRow; i++)
			{
				textEditor.MoveDown();
			}
			if (selectionCharacter > -1)
			{
				for (int j = 0; j < selectionCharacter; j++)
				{
					textEditor.MoveRight();
				}
				textEditor.SelectParagraphForward();
			}
			selectionRow = -1;
			isInTextSelectMode = false;
		}
		GUI.DrawTexture(inputDrawableArea, ResourceManager.SemiTransparantBackground50);
		GUI.BeginGroup(InputArea);
		Vector2 vector = scrollPos;
		string text = Text;
		if (!DelayInputUntilFirstFrame && !DelayInputUntilKeyNoKeyDown)
		{
			scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(InputArea.width - 10f), GUILayout.Height(InputArea.height - 30f));
			if (HandleEscape && Event.current.keyCode == KeyCode.Escape)
			{
				if (CancelEditor() && canceled != null)
				{
					canceled();
				}
			}
			else if (Event.current.keyCode == KeyCode.Home)
			{
				if (!isSpecialKeyDown)
				{
					if (Event.current.control)
					{
						textEditor.MoveTextStart();
						scrollPos.y = 0f;
					}
					else
					{
						textEditor.MoveLineStart();
					}
					isSpecialKeyDown = true;
				}
			}
			else if (Event.current.keyCode == KeyCode.End)
			{
				if (!isSpecialKeyDown)
				{
					if (Event.current.control)
					{
						textEditor.MoveTextEnd();
						scrollPos.y = (float)(bottomPosLowest - 1) * textStyle.lineHeight;
					}
					else
					{
						textEditor.MoveLineEnd();
					}
					isSpecialKeyDown = true;
				}
			}
			else
			{
				isSpecialKeyDown = false;
				if (Event.current.isKey)
				{
					flag = true;
					isSpecialKeyDown = false;
				}
			}
			if (vector != scrollPos)
			{
				int num = (int)(scrollPos.y / textStyle.lineHeight) + bottomBasePos;
				int num2 = num - bottomPos;
				if (num2 != 0)
				{
					topPos += num2;
					bottomPos += num2;
					if (bottomPos > bottomPosLowest)
					{
						bottomPosLowest = bottomPos;
					}
				}
			}
			GUI.SetNextControlName("EditableText");
			text = GUILayout.TextArea(Text, textStyle, GUILayout.ExpandHeight(true));
			if (MaintainFocus && !isFirstFocus)
			{
				GUI.FocusControl("EditableText");
			}
			GUILayout.EndScrollView();
			if (!isFirstFocus)
			{
				if (ExcludedCharacters != null && ExcludedCharacters.Length > 0)
				{
					char[] excludedCharacters = ExcludedCharacters;
					foreach (char oldChar in excludedCharacters)
					{
						text = text.Replace(oldChar, '*');
					}
				}
				Text = text;
			}
			else if (Event.current.keyCode == KeyCode.None)
			{
				isFirstFocus = false;
			}
		}
		else if (DelayInputUntilFirstFrame)
		{
			DelayInputUntilFirstFrame = false;
		}
		else if (DelayInputUntilKeyNoKeyDown && Event.current.isKey && Event.current.character == '\0')
		{
			DelayInputUntilKeyNoKeyDown = false;
		}
		GUI.EndGroup();
		if (flag)
		{
			int num3 = (int)(textEditor.graphicalCursorPos.y / textStyle.lineHeight);
			if (num3 > bottomPos)
			{
				int num4 = num3 - bottomPos;
				topPos += num4;
				bottomPos += num4;
				if (bottomPos > bottomPosLowest)
				{
					bottomPosLowest = bottomPos;
				}
				scrollPos.y = (float)(bottomPos - bottomBasePos) * textStyle.lineHeight;
			}
			else if (num3 < topPos)
			{
				int num5 = topPos - num3;
				topPos -= num5;
				bottomPos -= num5;
				scrollPos.y = (float)topPos * textStyle.lineHeight;
			}
		}
		if (ShowFilteredValues && ExcludedCharacters != null && ExcludedCharacters.Length > 0)
		{
			string text2 = string.Empty;
			char[] excludedCharacters2 = ExcludedCharacters;
			foreach (char c in excludedCharacters2)
			{
				if (!string.IsNullOrEmpty(text2))
				{
					text2 += ", ";
				}
				text2 += string.Format("'{0}'", c);
			}
			GUI.Label(new Rect(InputArea.x + 5f, InputArea.y + InputArea.height - 7f, InputArea.width - 10f, 25f), text2, noteStyle);
		}
		vector = scrollPos;
	}

	public void SelectRow(int row, int col)
	{
		isInTextSelectMode = true;
		selectionRow = row;
		selectionCharacter = col;
	}

	public void SaveEditor()
	{
	}

	public void UndoEditor()
	{
		Text = OriginalText;
	}

	public bool CancelEditor()
	{
		if (Text != OriginalText)
		{
			DialogUI.Instance.ShowDialog("Unsaved Changes", "Do you want to save changed before closing the note?", ModalWindowType.YesNoCancel, CancelEditorConfirmResult);
			return false;
		}
		return true;
	}

	private void CancelEditorConfirmResult(ModalWindowResult result, string input)
	{
		switch (result)
		{
		case ModalWindowResult.Yes:
			SaveEditor();
			break;
		case ModalWindowResult.No:
			Text = OriginalText;
			break;
		case ModalWindowResult.Cancel:
			isFirstFocus = true;
			isSkippingFrame = true;
			return;
		}
		if (canceled != null)
		{
			canceled();
		}
	}

	private float CalcPosY(string text)
	{
		string[] array = text.Split('\n');
		return textStyle.lineHeight * (float)array.Length;
	}
}
