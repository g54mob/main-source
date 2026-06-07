public struct AssetSelector
{
	public ModuleId moduleId;

	public AssetId id;

	public static AssetSelector None;

	public AssetSelector(ModuleId moduleId, AssetId id)
	{
		this.moduleId = default(ModuleId);
		this.id = default(AssetId);
	}

	public static bool operator ==(AssetSelector c1, AssetSelector c2)
	{
		return false;
	}

	public static bool operator !=(AssetSelector c1, AssetSelector c2)
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
