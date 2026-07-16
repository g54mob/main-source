using System;

[Serializable]
public class ShopCard
{
	public int Index;

	public Enhancement Enhancement;

	public ShopCard(int index, Enhancement en)
	{
		Index = index;
		Enhancement = en;
	}

	public override bool Equals(object obj)
	{
		if (obj is ShopCard shopCard)
		{
			if (Index == shopCard.Index)
			{
				return Enhancement.Name.Equals(shopCard.Enhancement.Name);
			}
			return false;
		}
		return false;
	}
}
