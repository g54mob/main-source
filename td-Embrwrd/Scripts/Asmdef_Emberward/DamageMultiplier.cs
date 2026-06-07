using System;

[Serializable]
public class DamageMultiplier
{
	public float multiplier;

	public float duration;

	public bool doLimitDamageType;

	public eDamageType element;

	public int sourceID;

	public DamageMultiplier(float multiplier, float duration, int sourceID, bool doLimitDamageType = false, eDamageType element = eDamageType.NONE)
	{
	}
}
