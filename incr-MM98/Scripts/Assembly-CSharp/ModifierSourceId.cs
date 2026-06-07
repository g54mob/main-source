using System;
using Cysharp.Text;

public readonly struct ModifierSourceId : IEquatable<ModifierSourceId>
{
	public readonly ModifierSourceType Type;

	public readonly int Id;

	public ModifierSourceId(ModifierSourceType type, int id)
	{
		Type = type;
		Id = id;
	}

	public bool Equals(ModifierSourceId other)
	{
		if (Type == other.Type)
		{
			return Id == other.Id;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ModifierSourceId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine((int)Type, Id);
	}

	public override string ToString()
	{
		return ZString.Format("{0}:{1}", Type, Id);
	}

	public static ModifierSourceId OperationInstance(string guid)
	{
		int num = 23;
		foreach (char c in guid)
		{
			num = num * 31 + c;
		}
		return new ModifierSourceId(ModifierSourceType.Operation, num);
	}
}
