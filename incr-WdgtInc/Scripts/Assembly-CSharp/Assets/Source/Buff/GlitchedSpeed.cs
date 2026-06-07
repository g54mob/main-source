using Assets.Source.Ability;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Source.Buff
{
	public class GlitchedSpeed : FrameBuff
	{
		public override Color WorldColor => new Color(0.27f, 0.31f, 1f, 0.8f);

		public override float BaseDuration => 20f;

		public GlitchedSpeed()
		{
		}

		public GlitchedSpeed(ActivatedAbility a)
			: base(a)
		{
		}

		public override bool AddStack(FrameBuff other)
		{
			if (other is GlitchedSpeed glitchedSpeed)
			{
				AddDuration(glitchedSpeed.BaseDuration, refresh: true);
				return true;
			}
			return false;
		}

		public override double GetSpeedMultiplier(WorldFrame frame, bool handCraft)
		{
			return SpeedMultiplier.EffectStrength;
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
