using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Biomes
{
	public static class UnityExtensions
	{
		public static bool Contains(this LayerMask mask, int layer)
		{
			return (int)mask == ((int)mask | (1 << layer));
		}
	}
}
