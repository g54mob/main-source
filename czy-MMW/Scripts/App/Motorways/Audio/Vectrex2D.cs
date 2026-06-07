using UnityEngine;

namespace Motorways.Audio
{
	public static class Vectrex2D
	{
		public static Vector2 Swap(this Vector2 v2)
		{
			return new Vector2(v2.y, v2.x);
		}
	}
}
