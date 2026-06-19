using UnityEngine;

namespace PugWorldGen
{
	[DisallowMultipleComponent]
	public class DungeonAuthoring : MonoBehaviour
	{
		public uint seed;

		public int radius = 50;

		public bool dontBlockOtherSpawns;
	}
}
