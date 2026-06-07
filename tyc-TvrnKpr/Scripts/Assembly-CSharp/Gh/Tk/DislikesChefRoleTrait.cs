using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ChefSkill) })]
	public class DislikesChefRoleTrait : DislikesRoleTrait
	{
		protected DislikesChefRoleTrait()
		{
		}

		public DislikesChefRoleTrait(Staff owner)
		{
		}
	}
}
