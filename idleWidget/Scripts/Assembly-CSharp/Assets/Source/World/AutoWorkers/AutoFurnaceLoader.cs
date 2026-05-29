namespace Assets.Source.World.AutoWorkers
{
	public class AutoFurnaceLoader : AutoCrafter
	{
		public new readonly FurnaceFrame Parent;

		public AutoFurnaceLoader(FurnaceFrame parent, WorldAnchor slot)
			: base(parent, slot)
		{
			Parent = parent;
		}

		public override bool InitStartCrafting()
		{
			if (Parent.CurrentContents >= Parent.GetMaxContents())
			{
				return false;
			}
			if (Parent.IsSmelting)
			{
				return false;
			}
			if (!base.InitStartCrafting())
			{
				return false;
			}
			return true;
		}

		protected override bool DoCraftingResult()
		{
			if (Parent.IsSmelting || Parent.CurrentContents >= Parent.GetMaxContents())
			{
				return false;
			}
			Parent.AddContents(base.CraftCount);
			return true;
		}
	}
}
