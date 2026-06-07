using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(EasilySickTrait),
		typeof(OftenSickTrait)
	})]
	public class ImmuneToDiseasesTrait : ActorTrait
	{
		protected ImmuneToDiseasesTrait()
		{
		}

		public ImmuneToDiseasesTrait(Actor owner)
		{
		}
	}
}
