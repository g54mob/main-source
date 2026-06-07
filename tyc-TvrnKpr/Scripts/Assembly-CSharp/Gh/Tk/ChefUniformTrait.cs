using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ChefSkill) })]
	public class ChefUniformTrait : StaffUniformTrait
	{
		protected ChefUniformTrait()
		{
		}

		public ChefUniformTrait(Staff owner)
		{
		}
	}
}
