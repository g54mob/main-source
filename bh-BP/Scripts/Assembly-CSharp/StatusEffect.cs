using System;

[Serializable]
public class StatusEffect
{
	public StatusEffectType Type;

	public float RemainingLen;

	public float RemainingCycleLen;

	public int MinIntensity;

	public int MaxIntensity;

	public int NumStacks;

	public int MaxStacks;

	[NonSerialized]
	public HeroInst LastSrc;

	public StatusEffect(StatusEffectType t, float len = 0f)
	{
	}

	public StatusEffect(StatusEffectType t, HeroInst src)
	{
	}

	public StatusEffect(StatusEffect toCopy)
	{
	}

	public void MarkDamageDealt(int dmg, GridPieceInst p)
	{
	}
}
