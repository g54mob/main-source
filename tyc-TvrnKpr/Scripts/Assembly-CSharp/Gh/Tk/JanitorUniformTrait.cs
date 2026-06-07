using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(JanitorSkill) })]
	public class JanitorUniformTrait : StaffUniformTrait
	{
		protected JanitorUniformTrait()
		{
		}

		public JanitorUniformTrait(Staff owner)
		{
		}
	}
}
