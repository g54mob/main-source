using System;

[Serializable]
public class PriceRating
{
	public int minPrice;

	public int maxPrice;

	public int basePrice;

	public PriceRating(int minPrice, int maxPrice, int basePrice)
	{
		this.minPrice = minPrice;
		this.maxPrice = maxPrice;
		this.basePrice = basePrice;
	}
}
