public class TextHistory
{
	public string text;

	public int caretIndex;

	public TextHistory()
		: this("", 0)
	{
	}

	public TextHistory(string text, int caretIndex)
	{
		this.text = text;
		this.caretIndex = caretIndex;
	}

	public override string ToString()
	{
		return text ?? "";
	}
}
