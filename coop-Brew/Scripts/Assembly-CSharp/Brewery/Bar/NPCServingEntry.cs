using Brewery.NPC.Simple;

namespace Brewery.Bar
{
	public class NPCServingEntry
	{
		public ulong npcNetworkId;

		public SimpleNPCController npcController;

		public string npcName;

		public float registrationTime;

		public int assignedDrinkSlotIndex;

		public string assignedDrinkName;

		public float calculatedPrice;
	}
}
