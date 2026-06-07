using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, "elf")]
	[TraitRarityConfig(0.005f, "dwarf")]
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(NightOwlTrait),
		typeof(WantsToSleepInDarknessTrait)
	})]
	public class FearOfTheDarkTrait : StaffTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private HappinessStat _happinessStat;

		protected FearOfTheDarkTrait()
		{
		}

		public FearOfTheDarkTrait(Staff owner)
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
