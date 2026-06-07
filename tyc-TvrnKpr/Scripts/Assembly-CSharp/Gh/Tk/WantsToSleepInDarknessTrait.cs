using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(NightOwlTrait),
		typeof(FearOfTheDarkTrait)
	})]
	public class WantsToSleepInDarknessTrait : StaffTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private HappinessStat _happinessStat;

		protected WantsToSleepInDarknessTrait()
		{
		}

		public WantsToSleepInDarknessTrait(Staff owner)
		{
		}

		public override void FirstInit()
		{
		}

		public override void Update()
		{
		}
	}
}
