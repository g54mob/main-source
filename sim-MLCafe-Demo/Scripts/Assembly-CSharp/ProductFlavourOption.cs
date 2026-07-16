using System;

[Serializable]
public class ProductFlavourOption
{
	public AnomalyTag tag;

	public int unlockLevel;

	public bool locked;

	public int priceValue;

	public ProductFlavourOption(AnomalyTag tag, int unlockLevel, bool locked, int priceValue)
	{
		this.tag = tag;
		this.unlockLevel = unlockLevel;
		this.locked = locked;
		this.priceValue = priceValue;
	}
}
