using System;
using UnityEngine;

namespace Libs
{
	[Serializable]
	public class SRandom
	{
		[SerializeField]
		public UnityEngine.Random.State state;

		private SRandom()
		{
		}

		public SRandom(int seed)
		{
		}

		public SRandom(SRandom other)
		{
		}

		public void SetSeed(int seed)
		{
		}

		public void SetState(UnityEngine.Random.State otherState)
		{
		}

		public int Range(int minInclusive, int maxExclusive)
		{
			return 0;
		}

		public float Range(float minInclusive, float maxInclusive)
		{
			return 0f;
		}
	}
}
