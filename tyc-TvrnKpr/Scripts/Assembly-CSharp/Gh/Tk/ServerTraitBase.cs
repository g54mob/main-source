using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ServerSkill) })]
	public abstract class ServerTraitBase : SkillTraitBase
	{
		protected ServerTraitBase()
		{
		}

		public ServerTraitBase(Staff owner)
		{
		}

		public virtual void OnTakingPatronOrder(Patron patron)
		{
		}
	}
}
