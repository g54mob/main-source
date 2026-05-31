namespace Assets.Source.Item.Types
{
	public class Materials
	{
		static Materials()
		{
			ItemType.Add(new ItemType("iron_ore")
			{
				DisplayName = "Iron Ore",
				IconName = "Items_0",
				Description = "Raw iron ore needs to be refined before use."
			});
			ItemType.Add(new ItemType("sand")
			{
				DisplayName = "Sand",
				IconName = "Items_1",
				Description = "Annoyingly fine grains with a surprising number of uses."
			});
			ItemType.Add(new ItemType("oil")
			{
				DisplayName = "Oil",
				IconName = "Items_2",
				Description = "The energy source of choice for the less discerning manufacturer."
			});
			ItemType.Add(new ItemType("copper_ore")
			{
				DisplayName = "Copper Ore",
				IconName = "Items_3",
				Description = "Raw copper ore needs to be refined before use."
			});
			ItemType.Add(new ItemType("uranium")
			{
				DisplayName = "Uranium",
				IconName = "Items_4",
				Description = "A near limitless source of energy. Just don't eat it."
			});
			ItemType.Add(new ItemType("helium")
			{
				DisplayName = "Helium",
				IconName = "Items_5",
				Description = "An inert gas used for cooling delicate electronics."
			});
		}
	}
}
