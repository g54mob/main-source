using UnityEngine;

public class CaughtFish
{
	public Fish fish;

	public string fishName;

	public string rarityName;

	public Sprite artwork;

	public double value;

	public int xpValue;

	public int baseClicks;

	public RarityData rarityData;

	public bool isPerfectCatch;

	public bool isDoubleCatch;

	public bool isTripleCatch;

	public CaughtFish(Fish species, RarityData rarityData)
	{
		fishName = species.speciesName;
		this.rarityData = rarityData;
		rarityName = rarityData.rarity.ToString();
		artwork = rarityData.artwork;
		value = rarityData.value;
		xpValue = rarityData.xpValue;
		fish = species;
		baseClicks = rarityData.clicks;
	}
}
