public struct AssetId
{
	public uint mainId;

	public uint subId;

	public static AssetId None;

	public bool isSubAsset => false;

	public AssetId(uint mainId, uint subId)
	{
		this.mainId = 0u;
		this.subId = 0u;
	}

	public static bool operator ==(AssetId c1, AssetId c2)
	{
		return false;
	}

	public static bool operator !=(AssetId c1, AssetId c2)
	{
		return false;
	}

	public override string ToString()
	{
		return null;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}
}
