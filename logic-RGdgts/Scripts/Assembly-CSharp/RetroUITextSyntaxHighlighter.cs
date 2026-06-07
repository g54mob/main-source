using System.Runtime.CompilerServices;

public class RetroUITextSyntaxHighlighter : RetroUIText.ITextListener
{
	public class LineData
	{
		public enum MultilineState
		{
			None = 0,
			Begin = 1,
			Body = 2,
			End = 3
		}

		public bool fullRefresh;

		public MultilineState literalState;

		public MultilineState commentState;
	}

	private RetroLanguageDefinition languageDefinition;

	public RetroUITextSyntaxHighlighter(RetroLanguageDefinition languageDefinition)
	{
	}

	public void OnAddedLine(RetroUIText renderer, int lineIndex)
	{
	}

	public void OnEditedLine(RetroUIText renderer, int lineIndex, string previusText)
	{
	}

	public void OnResettingTextData(RetroUIText renderer, string oldText, string newText)
	{
	}

	public void OnRemovingLine(RetroUIText renderer, int lineIndex)
	{
	}

	public void OnRenderVisibleLines(RetroUIText renderer, int startI, int endI)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool IsKeywordDelimiter(char c)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool CheckPattern(string str, string pattern, int offset)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool CheckPatternCaseInsensitive(string str, string pattern, int offset)
	{
		return false;
	}

	private int CheckNumber(string str, int offset)
	{
		return 0;
	}

	private void RefreshLine(RetroUIText.TextData data, int lineIndex)
	{
	}

	private void _RefreshLine(RetroUIText.TextData data, int lineIndex, bool fullResfresh, out bool literalStateChange, out bool commentStateChange)
	{
		literalStateChange = default(bool);
		commentStateChange = default(bool);
	}
}
