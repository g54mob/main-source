using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ServerSkill) })]
	[TraitNotValidWith(new Type[] { typeof(FamousBarkeepTrait) })]
	public class DisgracedBarkeepTrait : DisgracedTraitBase
	{
		protected DisgracedBarkeepTrait()
		{
		}

		public DisgracedBarkeepTrait(Staff owner)
		{
		}

		protected override string GetReputationCategory()
		{
			return null;
		}
	}
}
