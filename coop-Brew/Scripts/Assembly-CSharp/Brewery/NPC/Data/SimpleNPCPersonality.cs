using System;
using UnityEngine;

namespace Brewery.NPC.Data
{
	[Serializable]
	public struct SimpleNPCPersonality
	{
		[Range(0f, 1f)]
		public float Aggression;

		[Range(0f, 1f)]
		public float Bravery;

		[Range(0f, 1f)]
		public float DrunkTolerance;

		public int Seed;

		public static SimpleNPCPersonality Default => default(SimpleNPCPersonality);

		public static SimpleNPCPersonality Coward => default(SimpleNPCPersonality);

		public static SimpleNPCPersonality Brawler => default(SimpleNPCPersonality);

		public SimpleNPCPersonality(float aggression, float bravery, float drunkTolerance, int seed)
		{
			Aggression = 0f;
			Bravery = 0f;
			DrunkTolerance = 0f;
			Seed = 0;
		}

		public static SimpleNPCPersonality FromSeed(int seed)
		{
			return default(SimpleNPCPersonality);
		}

		public static SimpleNPCPersonality Random()
		{
			return default(SimpleNPCPersonality);
		}

		public bool WillFightWhenAttacked(float damagePercent = 0f)
		{
			return false;
		}

		public bool WillFlee(float healthPercent)
		{
			return false;
		}

		public bool IsDrunkEnoughToBrawl(int drinksConsumed)
		{
			return false;
		}

		private float GetDeterministicRoll(string decisionType)
		{
			return 0f;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
