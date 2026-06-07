using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct Modifier : IEquatable<Modifier>
{
	public ModifierType type;

	[Tooltip("Math operation used by the modifier")]
	public CalculationType calculation;

	[Tooltip("Value of the modifier")]
	public double value;

	[Tooltip("Formatting of the modifier in UI")]
	public ModifierFormat format;

	[Tooltip("Rounding of the modifier in UI")]
	public int digits;

	[Tooltip("Show the preview in UI")]
	public bool hidePreview;

	private int _origin;

	public double Handle(double baseValue)
	{
		return calculation.GetOperation()(baseValue, value);
	}

	public static Modifier Origin(Modifier modifier, object origin)
	{
		modifier._origin = origin.GetHashCode();
		return modifier;
	}

	private static IEnumerable GetValues()
	{
		return ModifierTypeExtensions.GroupedModifierTypes();
	}

	public bool Equals(Modifier other)
	{
		if (type == other.type && calculation == other.calculation)
		{
			return _origin == other._origin;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is Modifier other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine((int)type, (int)calculation, _origin);
	}
}
