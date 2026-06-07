using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[] { typeof(ImmuneToDiseasesTrait) })]
	public class EasilySickTrait : ActorTrait
	{
		protected EasilySickTrait()
		{
		}

		public EasilySickTrait(Actor owner)
		{
		}

		public override void Update()
		{
		}
	}
}
