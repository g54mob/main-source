public struct LocParam
{
	public string Name;

	public string Value;

	public int PluralCount;

	private LocParam(string name, string value)
	{
		Name = name;
		PluralCount = -1;
		Value = value;
	}

	private LocParam(string name, int pluralCount)
	{
		Name = name;
		Value = pluralCount.ToString();
		PluralCount = pluralCount;
	}

	public static LocParam Plural(string name, int pluralCount)
	{
		return new LocParam(name, pluralCount);
	}

	public static LocParam Create(string name, string value)
	{
		return new LocParam(name, value);
	}

	public override int GetHashCode()
	{
		return ((17 * 23 + Name.GetHashCode()) * 23 + Value.GetHashCode()) * 23 + PluralCount.GetHashCode();
	}
}
