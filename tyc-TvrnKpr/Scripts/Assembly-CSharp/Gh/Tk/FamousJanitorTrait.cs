using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(JanitorSkill) })]
	[TraitNotValidWith(new Type[] { typeof(DisgracedJanitorTrait) })]
	public class FamousJanitorTrait : FamousTraitBase
	{
		protected FamousJanitorTrait()
		{
		}

		public FamousJanitorTrait(Staff owner)
		{
		}

		protected override string GetReputationCategory()
		{
			return null;
		}
	}
}
