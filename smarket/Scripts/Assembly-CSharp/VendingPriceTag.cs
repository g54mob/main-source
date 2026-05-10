public class VendingPriceTag : PriceTag
{
	private VendingSlot m_VendingSlot;

	public VendingSlot VendingSlot => null;

	public void EnableTag(VendingSlot vendingSlot)
	{
	}

	public override void SetPrice(float price)
	{
	}

	public override void OccupyDisplay()
	{
	}
}
