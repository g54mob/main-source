using System;

[Serializable]
public class PlayerStatusEffect
{
	public PlayerStatusEffectType Type;

	public float RemainingLen;

	public float RemainingCycleLen;

	public int MinIntensity;

	public int MaxIntensity;

	public PlayerStatusEffect(PlayerStatusEffectType t, float len = 0f)
	{
	}
}
