using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ChefSkill) })]
	public abstract class ChefTraitBase : SkillTraitBase
	{
		protected ChefTraitBase()
		{
		}

		public ChefTraitBase(Staff owner)
		{
		}

		public virtual void ApplyEffectToCraftedIngredient(Ingredient ingredient)
		{
		}
	}
}
