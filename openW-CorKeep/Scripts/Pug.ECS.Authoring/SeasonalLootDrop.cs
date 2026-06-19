using System;

[Serializable]
public struct SeasonalLootDrop
{
	public ObjectID lootDropID;

	public int amount;

	public float chance;

	public float multiplayerAmountAdditionScaling;
}
