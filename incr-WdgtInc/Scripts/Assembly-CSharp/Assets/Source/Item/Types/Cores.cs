namespace Assets.Source.Item.Types
{
	public class Cores
	{
		static Cores()
		{
			ItemType.Add(new ItemType("thinking_core")
			{
				IconName = "Items_32"
			});
			ItemType.Add(new ItemType("ai_core")
			{
				IconName = "Items_33"
			});
			ItemType.Add(new ItemType("sentient_core")
			{
				IconName = "Items_34"
			});
			ItemType.Add(new ItemType("core_amalgamation")
			{
				IconName = "Items_35"
			});
		}
	}
}
