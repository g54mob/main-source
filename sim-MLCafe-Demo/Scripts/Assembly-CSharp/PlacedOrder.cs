using System;

[Serializable]
public class PlacedOrder
{
	public int orderId;

	public int[] itemIds;

	public int[] amounts;

	public int totalPrice;

	public int packages;

	public PlacedOrder(int[] ids, int[] amounts, int totalPrice, int packages)
	{
		orderId = Guid.NewGuid().GetHashCode();
		itemIds = ids;
		this.amounts = amounts;
		this.totalPrice = totalPrice;
		this.packages = packages;
	}
}
