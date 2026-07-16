using UnityEngine;

public static class Extensions
{
	public static bool ContainsLayer(this LayerMask mask, int layer)
	{
		return (int)mask == ((int)mask | (1 << layer));
	}
}
