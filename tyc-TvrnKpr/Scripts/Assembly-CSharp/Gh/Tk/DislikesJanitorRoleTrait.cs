using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(JanitorSkill) })]
	public class DislikesJanitorRoleTrait : DislikesRoleTrait
	{
		protected DislikesJanitorRoleTrait()
		{
		}

		public DislikesJanitorRoleTrait(Staff owner)
		{
		}
	}
}
