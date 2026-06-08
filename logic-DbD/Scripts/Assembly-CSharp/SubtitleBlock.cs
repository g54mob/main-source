public class SubtitleBlock
{
	private static SubtitleBlock _blank;

	public static SubtitleBlock Blank => _blank ?? (_blank = new SubtitleBlock(0, 0.0, 0.0, string.Empty));

	public int Index { get; }

	public double Length { get; }

	public double From { get; }

	public double To { get; }

	public string Text { get; }

	public SubtitleBlock(int index, double from, double to, string text)
	{
		Index = index;
		From = from;
		To = to;
		Length = to - from;
		Text = text;
	}
}
