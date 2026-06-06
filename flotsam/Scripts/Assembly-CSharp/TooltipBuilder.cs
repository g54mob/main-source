using System.Text;

public class TooltipBuilder
{
	public const string PARAGRPH = "\r\n\r\n";

	public const string FORMAT_BULLET = "\r\n<indent=1em>•</indent><indent=2em>{0}</indent>";

	public const string FORMAT_HEADER = "\r\n\r\n<b>{0}</b>";

	private TooltipBuilderProperties _properties;

	private StringBuilder _stringBuilder;

	private int _effectCount;

	public TooltipBuilder(TooltipBuilderProperties properties)
	{
		_properties = properties;
		_stringBuilder = new StringBuilder(properties.DefaultCapacity);
	}

	public void Clear()
	{
		_stringBuilder?.Clear();
		_effectCount = 0;
	}

	public void Append(string value)
	{
		_stringBuilder.Append(value);
	}

	public void AppendParagraph(string value)
	{
		_stringBuilder.Append("\r\n\r\n" + value);
	}

	public void AppendEffect(string effect)
	{
		if (_effectCount == 0)
		{
			AppendHeader(_properties.EffectHeader);
		}
		AppendBullet(effect);
		_effectCount++;
	}

	public void AppendBullet(string bullet)
	{
		_stringBuilder.AppendFormat("\r\n<indent=1em>•</indent><indent=2em>{0}</indent>", bullet);
	}

	private void AppendHeader(string header)
	{
		_stringBuilder.AppendFormat("\r\n\r\n<b>{0}</b>", header);
	}

	public override string ToString()
	{
		return _stringBuilder.ToString();
	}
}
