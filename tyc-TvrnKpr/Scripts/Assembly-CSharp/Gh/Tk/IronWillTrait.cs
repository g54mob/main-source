using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(ScaredyCatTrait),
		typeof(SqueamishTrait),
		typeof(TickingTimeBombTrait)
	})]
	public class IronWillTrait : ActorTrait
	{
		protected IronWillTrait()
		{
		}

		public IronWillTrait(Actor owner)
		{
		}
	}
}
