public struct ModuleId
{
	public uint value;

	public static readonly ModuleId None;

	public static readonly ModuleId Builtin;

	public static readonly ModuleId MultitoolConnector;

	public static readonly IntRange reservedRange;

	public ModuleId(uint value)
	{
		this.value = 0u;
	}

	public static bool operator ==(ModuleId c1, ModuleId c2)
	{
		return false;
	}

	public static bool operator !=(ModuleId c1, ModuleId c2)
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
