namespace Assets.Source.World.Frames
{
	public class T5RecyclerAutocrafter : AutoCrafter
	{
		public T5RecyclerAutocrafter(T5Recycler parent, WorldAnchor slot)
			: base(parent, slot)
		{
		}

		public override bool InitStartCrafting()
		{
			if (!base.Parent.CanStartCrafting(Slot))
			{
				return false;
			}
			base.CraftCount = base.Parent.ConsumeReagentsForCraft(Slot);
			if (base.CraftCount == 0)
			{
				return false;
			}
			return true;
		}
	}
}
