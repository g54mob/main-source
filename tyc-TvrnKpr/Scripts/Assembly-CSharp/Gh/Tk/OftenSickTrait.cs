using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitNotValidWith(new Type[] { typeof(ImmuneToDiseasesTrait) })]
	public class OftenSickTrait : ActorTrait
	{
		protected OftenSickTrait()
		{
		}

		public OftenSickTrait(Actor owner)
		{
		}

		public override void Update()
		{
		}
	}
}
