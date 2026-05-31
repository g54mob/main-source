namespace Assets.Source.Item.Types
{
	public class Cores
	{
		static Cores()
		{
			ItemType.Add(new ItemType("thinking_core")
			{
				DisplayName = "Thinking Core",
				IconName = "Items_32",
				Description = "I think, therefore I am."
			});
			ItemType.Add(new ItemType("ai_core")
			{
				DisplayName = "AI Core",
				IconName = "Items_33",
				Description = "Two trillion parameters in the palm of your hand."
			});
			ItemType.Add(new ItemType("sentient_core")
			{
				DisplayName = "Sentience Core",
				IconName = "Items_34",
				Description = "Sentience was achieved when the first widget asked its creator about its purpose."
			});
			ItemType.Add(new ItemType("core_amalgamation")
			{
				DisplayName = "Core Amalgamation",
				IconName = "Items_35",
				Description = "No longer content with mere sentience, the machines sought to perfect their masters' creation."
			});
		}
	}
}
