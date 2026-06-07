using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ServerSkill) })]
	[TraitNotValidWith(new Type[] { typeof(DisgracedBarkeepTrait) })]
	public class FamousBarkeepTrait : FamousTraitBase
	{
		protected FamousBarkeepTrait()
		{
		}

		public FamousBarkeepTrait(Staff owner)
		{
		}

		protected override string GetReputationCategory()
		{
			return null;
		}
	}
}
