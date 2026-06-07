using UnityEngine;

namespace DV.WorldTools
{
	public class CustomBiomeZone : MonoBehaviour
	{
		public Biome biome;

		public bool overrideWater;

		public int priority;

		private void Awake()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
