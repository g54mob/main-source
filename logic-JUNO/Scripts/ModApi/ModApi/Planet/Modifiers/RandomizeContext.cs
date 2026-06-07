using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Planet.Modifiers
{
	public class RandomizeContext
	{
		private Dictionary<string, int> _randomInts = new Dictionary<string, int>();

		public PlanetModifierRandomizationFlags Flags { get; }

		public RandomizeContext(PlanetModifierRandomizationFlags flags)
		{
			Flags = flags;
		}

		public int GetRandomInt(string seedSyncId)
		{
			int num = Random.Range(int.MinValue, int.MaxValue);
			if (!string.IsNullOrWhiteSpace(seedSyncId))
			{
				if (_randomInts.ContainsKey(seedSyncId))
				{
					num = _randomInts[seedSyncId];
				}
				else
				{
					_randomInts[seedSyncId] = num;
				}
			}
			return num;
		}
	}
}
