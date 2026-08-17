using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loot;

public class WeightedItem
{
	private ItemType _itemType;

	private float _weight;

	public ItemType ItemType => _itemType;

	public float Weight => _weight;

	public WeightedItem(ItemType itemType, float weight)
	{
		_weight = weight;
		_itemType = itemType;
	}
}
