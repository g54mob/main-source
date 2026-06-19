using System;
using UnityEngine;

[Serializable]
public class GutFloraMutationEffectInfo
{
	public GutFloraMutationEffect effect;

	public Rarity rarity;

	public static bool RarityCheck(Rarity r)
	{
		float num = 0f;
		switch (r)
		{
		case Rarity.COMMON:
			num = 0.5f;
			break;
		case Rarity.UNCOMMON:
			num = 0.85f;
			break;
		case Rarity.RARE:
			num = 0.95f;
			break;
		case Rarity.ULTRA_RARE:
			num = 0.98f;
			break;
		}
		return UnityEngine.Random.value >= num;
	}
}
