using System.Text;

public class StringFormatter
{
	private StringBuilder _stringBuilder;

	public StringFormatter(int capacity)
	{
		_stringBuilder = new StringBuilder(capacity);
	}

	public string Format(string format, params object[] args)
	{
		_stringBuilder.Remove(0, _stringBuilder.Length);
		_stringBuilder.AppendFormat(format, args);
		return _stringBuilder.ToString();
	}
}
