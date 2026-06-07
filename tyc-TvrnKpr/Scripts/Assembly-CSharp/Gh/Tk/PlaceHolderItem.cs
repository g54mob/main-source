namespace Gh.Tk
{
	public class PlaceHolderItem : GameItem
	{
		public GameItem TargetItem { get; private set; }

		public override bool IgnoreInLarder => false;

		public PlaceHolderItem()
		{
		}

		public PlaceHolderItem(GameItem targetItem)
		{
		}
	}
}
