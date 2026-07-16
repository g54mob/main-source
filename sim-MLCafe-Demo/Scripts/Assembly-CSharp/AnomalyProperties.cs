using System;

[Serializable]
public class AnomalyProperties
{
	public float customer_waitcount_multiplier = 1f;

	public float customer_spawnrate_multiplier = 1f;

	public float customer_dirt_rate = 1f;

	public float shop_item_price_multiplier = 1f;

	public float shop_delivery_duration = 1f;

	public static AnomalyProperties GetDefaultProperties()
	{
		return new AnomalyProperties
		{
			customer_waitcount_multiplier = 1f,
			customer_spawnrate_multiplier = 1f,
			customer_dirt_rate = 1f,
			shop_item_price_multiplier = 1f,
			shop_delivery_duration = 1f
		};
	}
}
