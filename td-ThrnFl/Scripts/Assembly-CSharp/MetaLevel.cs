using System;

[Serializable]
public class MetaLevel
{
	public int requiredXp;

	public Equippable reward;

	public MetaLevel(int xp, Equippable eq)
	{
		requiredXp = xp;
		reward = eq;
	}
}
