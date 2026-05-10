using System;
using System.Collections.Generic;

[Serializable]
public class CartData
{
	public List<ItemQuantity> ProductInCarts;

	public List<ItemQuantity> FurnituresInCarts;

	public List<ItemQuantity> BucketsInCarts;

	public List<ItemQuantity> FloorBoxesInCarts;
}
