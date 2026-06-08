using UnityEngine;

namespace Kitchen
{
	public abstract class RestaurantSystem : GameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SKitchenMarker>();
			DefaultArchetype = base.EntityManager.CreateArchetype();
		}

		protected FixedSeedContext Seed(int category_seed, int instance)
		{
			if (!Preferences.Get<bool>(Pref.SeedsAffectEverything) && !Has<CSpeedrun>())
			{
				return default(FixedSeedContext);
			}
			if (Require<SFixedSeed>(out var comp) && comp.Seed.IsSet)
			{
				return new FixedSeedContext(comp.Seed, category_seed * 1231231 + instance);
			}
			return default(FixedSeedContext);
		}

		protected Random.State GetState(int category_seed, int instance)
		{
			if (!Preferences.Get<bool>(Pref.SeedsAffectEverything) && !Has<CSpeedrun>())
			{
				return Random.state;
			}
			if (Require<SFixedSeed>(out var comp) && comp.Seed.IsSet)
			{
				using (new FixedSeedContext(comp.Seed, category_seed * 1231231 + instance))
				{
					return Random.state;
				}
			}
			return Random.state;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
