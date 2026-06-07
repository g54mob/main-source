using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitNotValidWith(new Type[] { typeof(IronWillTrait) })]
	public class ScaredyCatTrait : ActorTrait
	{
		protected ScaredyCatTrait()
		{
		}

		public ScaredyCatTrait(Actor owner)
		{
		}
	}
}
