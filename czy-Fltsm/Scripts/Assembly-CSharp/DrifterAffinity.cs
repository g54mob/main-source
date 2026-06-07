using System;
using System.Collections.Generic;

[Serializable]
public class DrifterAffinity
{
	public int Amount;

	public DrifterAttributes.AttributeType Type;

	public DrifterAffinity(DrifterAttributes.AttributeType type)
		: this(type, 0)
	{
	}

	public DrifterAffinity(DrifterAttributes.AttributeType type, int amount)
	{
		Amount = amount;
		Type = type;
	}

	public static bool TryReturnAffinity(IReadOnlyList<DrifterAffinity> affinities, DrifterAttributes.AttributeType type, out DrifterAffinity affinity)
	{
		foreach (DrifterAffinity affinity2 in affinities)
		{
			if (affinity2.Type == type)
			{
				affinity = affinity2;
				return true;
			}
		}
		affinity = null;
		return false;
	}
}
