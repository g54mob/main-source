namespace Humanizer
{
	public interface ITruncator
	{
		string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right);
	}
}
