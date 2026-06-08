public class EventTreasureItem : TreasureItem
{
	private int _maxEnchantmentBonus = 13;

	private int _maxTreasureLevel = 11;

	public int maxEnchantmentBonus
	{
		get
		{
			return _maxEnchantmentBonus;
		}
		set
		{
			_maxEnchantmentBonus = value;
		}
	}

	public int maxTreasureLevel
	{
		get
		{
			return _maxTreasureLevel;
		}
		set
		{
			_maxTreasureLevel = value;
		}
	}

	public override AsciiSprite GetIcon()
	{
		AsciiSprite icon = base.GetIcon();
		EventTreasureIcon component = icon.GetComponent<EventTreasureIcon>();
		component.SetBonus(maxEnchantmentBonus);
		component.SetLevel(maxTreasureLevel);
		return icon;
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (itemsInTreasure != null && num3 < itemsInTreasure.Length)
		{
			Data.ItemInTreasure itemInTreasure = itemsInTreasure[num3];
			if (num < itemInTreasure.rarityBonus)
			{
				num = itemInTreasure.rarityBonus;
			}
			if (num2 < itemInTreasure.level)
			{
				num2 = itemInTreasure.level;
			}
			num3++;
		}
		maxEnchantmentBonus = num;
		maxTreasureLevel = num2;
	}
}
