using System;

[Serializable]
public class FoodOrder : IProductOrder, IReferenceFix
{
	public Holdable.HoldableData Data;

	public FoodOrder()
	{
	}

	public FoodOrder(Holdable hold)
	{
		Data = hold.Serialize();
	}

	public IReferenceFix FixReferences()
	{
		return this;
	}

	public void RemoveFromStorage()
	{
	}

	public int GetAtlasIndex()
	{
		return MarketSimulation.Active.GetManufacturingIndex("Food");
	}
}
