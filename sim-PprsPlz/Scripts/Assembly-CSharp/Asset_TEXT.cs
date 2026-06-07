public sealed class Asset_TEXT : Asset
{
	public readonly string text;

	public Asset_TEXT(string text)
		: base(0)
	{
	}

	public override Array getParams()
	{
		return null;
	}

	public override string getTag()
	{
		return null;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object other)
	{
		return false;
	}

	public override string toString()
	{
		return null;
	}
}
