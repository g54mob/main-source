using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ServerSkill) })]
	public class DislikesServerRoleTrait : DislikesRoleTrait
	{
		protected DislikesServerRoleTrait()
		{
		}

		public DislikesServerRoleTrait(Staff owner)
		{
		}
	}
}
