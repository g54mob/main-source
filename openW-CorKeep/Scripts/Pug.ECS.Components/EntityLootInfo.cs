using Pug.UnityExtensions;

public struct EntityLootInfo
{
	public ObjectID objectID;

	public float accumulatedDropChance;

	public float weight;

	public RangeInt amount;

	public Biome onlyDropsInBiome;
}
