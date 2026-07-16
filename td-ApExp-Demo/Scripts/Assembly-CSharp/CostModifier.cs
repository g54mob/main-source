public class CostModifier
{
	public float Value { get; private set; }

	public ShopItemType ItemType { get; private set; }

	public CostModifier(ShopItemType itemType, float value)
	{
		ItemType = itemType;
		Value = value;
	}

	public bool CheckForMatch(ShopItemType itemType, float value)
	{
		if (itemType == ItemType && value == Value)
		{
			return true;
		}
		return false;
	}
}
