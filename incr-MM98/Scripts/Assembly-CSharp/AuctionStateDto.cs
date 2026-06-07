using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class AuctionStateDto
{
	[MessagePackObject(false)]
	public class LootItemDto
	{
		[Key(0)]
		public LootItemQuality Quality;

		[Key(1)]
		public LootItemCategory Category;

		[Key(2)]
		public string Name;

		[Key(3)]
		public int IconIndex;

		[Key(4)]
		public double Value;
	}

	[MessagePackObject(false)]
	public class AuctionLogDto
	{
		[Key(0)]
		public string Username;

		[Key(1)]
		public string Item;

		[Key(2)]
		public double Value;

		[Key(3)]
		public double Cut;

		[Key(4)]
		public float CutPercentage;
	}

	[Key(0)]
	public int AvailableLootchests;

	[Key(1)]
	public float TimeNextLootchestCurrent;

	[Key(2)]
	public float TimeNextLootchestDuration;

	[Key(3)]
	public LootItemDto CurrentLootItem;

	[Key(4)]
	public float CommonDropchance;

	[Key(5)]
	public float UncommonDropchance;

	[Key(6)]
	public float RareDropchance;

	[Key(7)]
	public float LegendaryDropchance;

	[Key(8)]
	public List<AuctionLogDto> AuctionLog;

	[Key(9)]
	public double EscrowMoney;

	[Key(10)]
	public float EscrowInterestIntervalCurrent;

	[Key(11)]
	public float EscrowInterestIntervalDuration;

	[Key(12)]
	public float HiddenCommonDropchance;

	[Key(13)]
	public float HiddenUncommonDropchance;

	[Key(14)]
	public float HiddenRareDropchance;

	[Key(15)]
	public float HiddenLegendaryDropchance;

	[Key(16)]
	public float HiddenSentiment;

	[Key(17)]
	public float HiddenSentimentTarget;
}
