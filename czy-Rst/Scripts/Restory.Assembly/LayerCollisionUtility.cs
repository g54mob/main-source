using System.Collections.Generic;
using UnityEngine;

public static class LayerCollisionUtility
{
	private static Dictionary<int, int> cachedCollisionMasks = new Dictionary<int, int>();

	public static int GetCollisionLayerMask(int layer)
	{
		if (cachedCollisionMasks.TryGetValue(layer, out var value))
		{
			return value;
		}
		value = 0;
		for (int i = 0; i < 32; i++)
		{
			if (!Physics.GetIgnoreLayerCollision(layer, i))
			{
				value |= 1 << i;
			}
		}
		cachedCollisionMasks[layer] = value;
		return value;
	}
}
