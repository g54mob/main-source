using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[]
	{
		typeof(MessyTrait),
		typeof(FilthyTrait)
	})]
	public class DirtDodgerTrait : StaffTrait
	{
		protected DirtDodgerTrait()
		{
		}

		public DirtDodgerTrait(Staff owner)
		{
		}

		public override void Update()
		{
		}
	}
}
