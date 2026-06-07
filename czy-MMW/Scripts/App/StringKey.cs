using System.Collections.Generic;
using Factory.Pools;

public abstract class StringKey : IReusable
{
	public override bool Equals(object obj)
	{
		if (obj is StringKey)
		{
			return this == (StringKey)obj;
		}
		return false;
	}

	public static bool operator ==(StringKey x, StringKey y)
	{
		return x?.Equals(y) ?? ((object)y == null);
	}

	public static bool operator !=(StringKey x, StringKey y)
	{
		return !(x == y);
	}

	public abstract bool Equals(StringKey other);

	public abstract override int GetHashCode();

	public abstract string GetStringId();

	public abstract Dictionary<string, string> GetParameters();

	public abstract int GetCount();

	public abstract bool IsPlural();

	public abstract void InitWithStringId(StringId stringId);

	public abstract void InitWithStringId(StringId stringId, int newCount, Dictionary<string, string> newParameters = null);

	public abstract void InitWithStringId(StringId stringId, float newCount, Dictionary<string, string> newParameters = null);

	public abstract void InitWithString(string stringKey);

	public abstract void InitWithString(string stringKey, int newCount, Dictionary<string, string> newParameters = null);

	public abstract void InitWithString(string stringKey, float newCount, Dictionary<string, string> newParameters = null);

	public abstract void InitWithNonLocalizedString(string nonLocalizedString);

	public abstract void Reset();
}
