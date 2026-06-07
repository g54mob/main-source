using Assets.Source.Ability;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Source.Buff
{
	public class GlitchedProductivity : FrameBuff
	{
		public override Color WorldColor => new Color(1f, 0.66f, 0.27f, 0.8f);

		public override float BaseDuration => 20f;

		public GlitchedProductivity()
		{
		}

		public GlitchedProductivity(ActivatedAbility a)
			: base(a)
		{
		}

		public override bool AddStack(FrameBuff other)
		{
			if (other is GlitchedProductivity glitchedProductivity)
			{
				AddDuration(glitchedProductivity.BaseDuration, refresh: true);
				return true;
			}
			return false;
		}

		public override double GetProductivityMultiplier(WorldFrame frame, bool handCraft)
		{
			return ProductionMultiplier.EffectStrength;
		}

		public override bool CanCoexistWith(FrameBuff other)
		{
			return true;
		}

		public override bool IsValidTarget(WorldFrame frame)
		{
			return frame is CraftingFrame;
		}
	}
}
