using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(DogsbodySkill) })]
	public abstract class DogsbodyTraitBase : SkillTraitBase
	{
		protected DogsbodyTraitBase()
		{
		}

		public DogsbodyTraitBase(Staff owner)
		{
		}
	}
}
