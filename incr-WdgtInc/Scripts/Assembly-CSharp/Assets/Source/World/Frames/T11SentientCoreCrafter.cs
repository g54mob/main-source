using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T11SentientCoreCrafter : AutoCrafter
	{
		public new T11SentientCore Parent => base.Parent as T11SentientCore;

		public T11SentientCoreCrafter(T11SentientCore parent, WorldAnchor slot)
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
