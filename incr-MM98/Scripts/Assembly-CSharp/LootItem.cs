using UnityEngine;

public readonly struct LootItem
{
	public readonly LootItemQuality Quality;

	public readonly LootItemCategory Category;

	public readonly string Name;

	public readonly int IconIndex;

	public readonly double Value;

	public Sprite Sprite => Category.Value()[IconIndex];

	public double Cut => Value * (double)ModifierType.AuctionCut.Float();

	public LootItem(LootItemQuality quality, LootItemCategory category, string name, int iconIndex, double value)
	{
		Quality = quality;
		Category = category;
		Name = name;
		IconIndex = iconIndex;
		Value = value;
	}
}
