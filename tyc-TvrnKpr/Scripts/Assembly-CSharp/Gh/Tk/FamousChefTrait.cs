using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ChefSkill) })]
	[TraitNotValidWith(new Type[] { typeof(DisgracedChefTrait) })]
	public class FamousChefTrait : FamousTraitBase
	{
		protected FamousChefTrait()
		{
		}

		public FamousChefTrait(Staff owner)
		{
		}

		protected override string GetReputationCategory()
		{
			return null;
		}
	}
}
