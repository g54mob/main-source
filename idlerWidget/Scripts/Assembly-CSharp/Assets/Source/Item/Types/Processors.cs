namespace Assets.Source.Item.Types
{
	public class Processors
	{
		static Processors()
		{
			ItemType.Add(new ItemType("circuit_board")
			{
				DisplayName = "Circuit Board",
				IconName = "Items_40",
				Description = "A powerful self-contained circuit, capable of executing one calculation per second."
			});
			ItemType.Add(new ItemType("microprocessor")
			{
				DisplayName = "Microprocessor",
				IconName = "Items_41",
				Description = "A refined circuit design, 740KHz clock rate."
			});
			ItemType.Add(new ItemType("nanoprocessor")
			{
				DisplayName = "Nanoprocessor",
				IconName = "Items_42",
				Description = "As circuits grow smaller they, paradoxically, gain more computational power."
			});
			ItemType.Add(new ItemType("picoprocessor")
			{
				DisplayName = "Picoprocessor",
				IconName = "Items_43",
				Description = "The smallest details on these circuits are now at the sub-atomic scale. Terrifyingly fast."
			});
			ItemType.Add(new ItemType("processor_amalgamation")
			{
				DisplayName = "Processor Amalgamation",
				IconName = "Items_44",
				Description = "Past any limits, breaking any boundaries. Physical reality is no obstacle to the pinnacle of circuit engineering."
			});
		}
	}
}
