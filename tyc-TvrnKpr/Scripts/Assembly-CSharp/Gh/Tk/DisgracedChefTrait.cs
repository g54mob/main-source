using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ChefSkill) })]
	[TraitNotValidWith(new Type[] { typeof(FamousChefTrait) })]
	public class DisgracedChefTrait : DisgracedTraitBase
	{
		protected DisgracedChefTrait()
		{
		}

		public DisgracedChefTrait(Staff owner)
		{
		}

		protected override string GetReputationCategory()
		{
			return null;
		}
	}
}
