using System;

namespace Gh.Tk
{
	[TraitNotValidWith(new Type[] { typeof(MultiOrderServerTrait) })]
	public class ComedianTrait : ServerTraitBase
	{
		protected ComedianTrait()
		{
		}

		public ComedianTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}

		private int GetTriggerChance()
		{
			return 0;
		}

		public override void OnTakingPatronOrder(Patron patron)
		{
		}
	}
}
