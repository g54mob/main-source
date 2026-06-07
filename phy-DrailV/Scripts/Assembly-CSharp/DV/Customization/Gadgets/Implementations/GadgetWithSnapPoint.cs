namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetWithSnapPoint : GadgetBase
	{
		public SnapPointGadget snapPoint;

		public override GadgetRemovalMethod GetValidRemovalMethodsMask()
		{
			if (!(snapPoint.SnappedItem == null))
			{
				return GadgetRemovalMethod.None;
			}
			return base.GetValidRemovalMethodsMask();
		}

		public override GadgetItem ForceRemove(bool dontReparent = false)
		{
			if (snapPoint.SnappedItem != null)
			{
				snapPoint.UnsnapItem();
			}
			return base.ForceRemove(dontReparent);
		}
	}
}
