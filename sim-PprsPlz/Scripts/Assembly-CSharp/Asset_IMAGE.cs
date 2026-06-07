using app.vis;

public sealed class Asset_IMAGE : Asset
{
	public readonly Image image;

	public Asset_IMAGE(Image image)
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
