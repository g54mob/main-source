using System;
using UnityEngine;

namespace Kitchen
{
	public struct FixedSeedContext : IDisposable
	{
		private UnityEngine.Random.State CachedState;

		private bool IsInitialised;

		private int FixedSeed;

		private int InstanceSeed;

		public FixedSeedContext(Seed seed, int instance_seed)
			: this(seed.IntValue, instance_seed)
		{
		}

		public FixedSeedContext(int fixed_seed, int instance_seed)
		{
			FixedSeed = fixed_seed;
			InstanceSeed = instance_seed;
			CachedState = UnityEngine.Random.state;
			UnityEngine.Random.InitState(fixed_seed + 124192293 * instance_seed);
			IsInitialised = true;
		}

		public FixedSeedContext(UnityEngine.Random.State state, int fixed_seed, int instance_seed)
		{
			FixedSeed = fixed_seed;
			InstanceSeed = instance_seed;
			CachedState = UnityEngine.Random.state;
			UnityEngine.Random.state = state;
			IsInitialised = true;
		}

		public void Dispose()
		{
			if (IsInitialised)
			{
				UnityEngine.Random.state = CachedState;
			}
		}

		public FixedSeedContext UseSubcontext(int context_id)
		{
			if (!IsInitialised)
			{
				return default(FixedSeedContext);
			}
			return new FixedSeedContext(FixedSeed, 124192293 * context_id + InstanceSeed);
		}
	}
}
