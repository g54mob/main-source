using System.Text;

namespace Gh.Tk
{
	public class ChefSkill : StaffSkill
	{
		protected ChefSkill()
		{
		}

		public ChefSkill(Staff owner)
		{
		}

		private int GetBonusOrPenalty(float targetStars)
		{
			return 0;
		}

		public override float GetModifierForTargetTier(int tier)
		{
			return 0f;
		}

		protected override void AppendEffectDetailsForTooltip(StringBuilder sb)
		{
		}

		private int GetContaminationChanceInPercent()
		{
			return 0;
		}

		public void ApplyCookingEffects(Ingredient craftedItem)
		{
		}
	}
}
