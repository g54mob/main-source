using System;

[Serializable]
public struct StatModifier
{
	public EStats stat;

	public ModifierOperation operation;

	public float value;

	public StatModifier(EStats inStat, ModifierOperation inOperation, float inValue)
	{
		stat = inStat;
		operation = inOperation;
		value = inValue;
	}
}
