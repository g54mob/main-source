using System.Collections.Generic;
using UnityEngine;

public static class LootItemQualityDataExtension
{
	private static readonly Dictionary<LootItemQuality, Color> data = new Dictionary<LootItemQuality, Color>
	{
		{
			LootItemQuality.Common,
			new Color(0.4339623f, 0.4339623f, 0.4339623f, 1f)
		},
		{
			LootItemQuality.Uncommon,
			new Color(0.1851193f, 0.6037736f, 0.1851193f, 1f)
		},
		{
			LootItemQuality.Rare,
			new Color(0.4298796f, 0.3722855f, 0.8867924f, 1f)
		},
		{
			LootItemQuality.Legendary,
			new Color(0.9056604f, 0.5132362f, 0f, 1f)
		}
	};

	public static Color Value(this LootItemQuality key)
	{
		return data[key];
	}
}
