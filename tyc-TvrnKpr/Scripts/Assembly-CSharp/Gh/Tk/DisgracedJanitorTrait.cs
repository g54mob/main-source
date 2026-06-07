using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(JanitorSkill) })]
	[TraitNotValidWith(new Type[] { typeof(FamousJanitorTrait) })]
	public class DisgracedJanitorTrait : DisgracedTraitBase
	{
		protected DisgracedJanitorTrait()
		{
		}

		public DisgracedJanitorTrait(Staff owner)
		{
		}

		protected override string GetReputationCategory()
		{
			return null;
		}
	}
}
