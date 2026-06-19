using UnityEngine;

namespace WorldEnvironment.Islands
{
	[CreateAssetMenu(menuName = "World/World Parameters")]
	public class WorldParams : ScriptableObject
	{
		public int Seed;

		public WorldGridParams GridParams;
	}
}
