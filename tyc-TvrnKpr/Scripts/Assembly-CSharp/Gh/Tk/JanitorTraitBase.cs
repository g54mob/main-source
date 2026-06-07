using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(JanitorSkill) })]
	public abstract class JanitorTraitBase : SkillTraitBase
	{
		protected JanitorTraitBase()
		{
		}

		public JanitorTraitBase(Staff owner)
		{
		}

		public virtual void OnPropCleaned(Prop prop)
		{
		}
	}
}
