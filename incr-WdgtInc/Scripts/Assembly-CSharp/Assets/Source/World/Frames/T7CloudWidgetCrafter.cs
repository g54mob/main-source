using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T7CloudWidgetCrafter : AutoCrafter
	{
		public new T7CloudWidget Parent => base.Parent as T7CloudWidget;

		public T7CloudWidgetCrafter(T7CloudWidget parent, WorldAnchor slot)
			: base(parent, slot)
		{
		}

		public override bool InitStartCrafting()
		{
			if (GamePlayer.Current.GetInventoryCount(ItemType.Power) < 300L)
			{
				Parent.ActiveFrame?.ShowNeedItem(Slot, ItemType.Power, 1);
				return false;
			}
			return base.InitStartCrafting();
		}
	}
}
