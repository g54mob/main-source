public class EnchantmentWeapon : Weapon
{
	private void Start()
	{
		OnRarityChanged();
	}

	protected override void OnRarityChanged()
	{
		ItemData.Rarity.Type rarityType = GetRarityType();
		displayName = GetEnchantmentDisplayName(rarityType);
	}

	public static string GetEnchantmentDisplayName(ItemData.Rarity.Type rarityType)
	{
		return rarityType switch
		{
			ItemData.Rarity.Type.Uncommon => "Common Enchantment", 
			ItemData.Rarity.Type.Rare => "Rare Enchantment", 
			ItemData.Rarity.Type.Heroic => "Heroic Enchantment", 
			ItemData.Rarity.Type.Epic => "Epic Enchantment", 
			ItemData.Rarity.Type.Legendary => "Legendary Enchantment", 
			_ => "Transcendent Enchantment", 
		};
	}
}
