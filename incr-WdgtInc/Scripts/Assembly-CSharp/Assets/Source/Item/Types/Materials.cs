namespace Assets.Source.Item.Types
{
	public class Materials
	{
		static Materials()
		{
			ItemType.Add(new ItemType("iron_ore")
			{
				IconName = "Items_0"
			});
			ItemType.Add(new ItemType("sand")
			{
				IconName = "Items_1"
			});
			ItemType.Add(new ItemType("oil")
			{
				IconName = "Items_2"
			});
			ItemType.Add(new ItemType("copper_ore")
			{
				IconName = "Items_3"
			});
			ItemType.Add(new ItemType("uranium")
			{
				IconName = "Items_4"
			});
			ItemType.Add(new ItemType("helium")
			{
				IconName = "Items_5"
			});
		}
	}
}
