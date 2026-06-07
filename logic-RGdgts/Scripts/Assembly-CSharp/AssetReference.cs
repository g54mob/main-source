public struct AssetReference
{
	public AssetType type;

	public AssetSelector assetSelector;

	public static AssetReference None;

	public AssetReference(AssetSelector assetSelector, AssetType type)
	{
		this.type = default(AssetType);
		this.assetSelector = default(AssetSelector);
	}

	public static implicit operator AssetReference(Asset asset)
	{
		return default(AssetReference);
	}

	public static bool operator ==(AssetReference c1, AssetReference c2)
	{
		return false;
	}

	public static bool operator !=(AssetReference c1, AssetReference c2)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override string ToString()
	{
		return null;
	}
}
