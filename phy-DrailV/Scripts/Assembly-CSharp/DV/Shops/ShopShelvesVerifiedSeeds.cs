using Unity.Mathematics;
using UnityEngine;

namespace DV.Shops
{
	[CreateAssetMenu(menuName = "DV/Shop Shelves Seeds")]
	public class ShopShelvesVerifiedSeeds : ScriptableObject
	{
		public uint[] seeds;

		public Unity.Mathematics.Random GetRandom()
		{
			return new Unity.Mathematics.Random(seeds[UnityEngine.Random.Range(0, seeds.Length)]);
		}
	}
}
