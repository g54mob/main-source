namespace Assets.Source.Item.Types
{
	public class Processors
	{
		static Processors()
		{
			ItemType.Add(new ItemType("circuit_board")
			{
				IconName = "Items_40"
			});
			ItemType.Add(new ItemType("microprocessor")
			{
				IconName = "Items_41"
			});
			ItemType.Add(new ItemType("nanoprocessor")
			{
				IconName = "Items_42"
			});
			ItemType.Add(new ItemType("picoprocessor")
			{
				IconName = "Items_43"
			});
			ItemType.Add(new ItemType("processor_amalgamation")
			{
				IconName = "Items_44"
			});
		}
	}
}
