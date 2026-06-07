using System;
using System.Collections.Generic;
using IntervalTree;
using UnityEngine;

public class RetroUICodeEditor : RetroUITextInput, RetroUIText.ITextListener
{
	public interface IListener
	{
		void OnSourceChange(RetroUICodeEditor codeEditor);

		void OnBreakpointsChanged(RetroUICodeEditor codeEditor);
	}

	public RectTransform resizableArea;

	public RectTransform lineNumbersRect;

	public RectTransform bottomLine1;

	public RectTransform bottomLine2;

	public RectTransform horizontalScrollbarRect;

	public RectTransform verticalScrollbarRect;

	[NonSerialized]
	[HideInInspector]
	public IListener listener;

	private bool _showLineNumbers;

	private bool _isHorizontalScrollbarVisible;

	private bool _isVerticalScrollbarVisible;

	private bool _isCommandBarVisible;

	private bool textChanged;

	private RetroUIText.TextData.Line _highlightedLine;

	private List<RetroUIText.TextData.Line> _breakpoints;

	private IntervalTree<RetroUIText.TextCoord, (RetroUIText.TextAreaCoord, Color)> underlines;

	public bool showLineNumbers
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool isHorizontalScrollbarVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool isVerticalScrollbarVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool isCommandBarVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public HashSet<int> breakPoints
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected override void InitInputManager()
	{
	}

	protected override void Awake()
	{
	}

	public override void OnVisibleTextChanged(RetroUIText uiText)
	{
	}

	public override void OnTextChanged(RetroUIText uiText)
	{
	}

	public override void OnNewLineInput()
	{
	}

	protected override void OnLineNumberClick(RetroUIText.TextData.VisibleLine visibleLine)
	{
	}

	private bool IsEmpty(string str, out int whiteChars, out int whiteColumns)
	{
		whiteChars = default(int);
		whiteColumns = default(int);
		return false;
	}

	private bool CheckPattern(string str, string pattern, int offset)
	{
		return false;
	}

	private bool CheckPatternCaseInsensitive(string str, string pattern, int offset)
	{
		return false;
	}

	protected override void LateUpdate()
	{
	}

	private void RefreshLayout()
	{
	}

	public override void ShowCommandBar()
	{
	}

	public override void HideCommandBar()
	{
	}

	public void SetHighlightedLine(int line, Color color)
	{
	}

	public void HideHighlitedLine()
	{
	}

	public void AddBreakpoint(int line)
	{
	}

	public void RemoveBreakpoint(int line)
	{
	}

	public void SetUnderlineAreas(ICollection<RetroUIText.TextAreaCoord> areas)
	{
	}

	private void LineBecameBreakpoint(RetroUIText.TextData.Line line)
	{
	}

	private void LineIsNotBreakpointAnymore(RetroUIText.TextData.Line line)
	{
	}

	private void OnBreakpointsChanged()
	{
	}

	public void OnAddedLine(RetroUIText renderer, int line)
	{
	}

	public void OnResettingTextData(RetroUIText renderer, string oldText, string newText)
	{
	}

	public void OnRemovingLine(RetroUIText renderer, int line)
	{
	}

	public void OnEditedLine(RetroUIText renderer, int line, string previusText)
	{
	}

	public void OnRenderVisibleLines(RetroUIText renderer, int startI, int endI)
	{
	}

	public void TEST_ToggleLineNumbers()
	{
	}

	public void TEST_ToggleVerticalScrollbar()
	{
	}

	public void TEST_ToggleHorizontalScrollbar()
	{
	}

	public void TEST_ToggleCommandBar()
	{
	}
}
