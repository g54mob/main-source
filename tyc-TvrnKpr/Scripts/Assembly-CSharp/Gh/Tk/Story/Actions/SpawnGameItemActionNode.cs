namespace Gh.Tk.Story.Actions
{
	public class SpawnGameItemActionNode : ConnectedStoryNode
	{
		public ScheduleStockDeliveryActionNode.StockDeliveryItemConfig[] itemsToSpawn;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
