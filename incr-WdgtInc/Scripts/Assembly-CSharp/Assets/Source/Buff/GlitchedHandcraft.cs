using Assets.Source.Ability;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Source.Buff
{
	public class GlitchedHandcraft : FrameBuff
	{
		public override Color WorldColor => new Color(0.27f, 0.31f, 1f, 0.8f);

		public override float BaseDuration => 30f;

		public GlitchedHandcraft()
		{
		}

		public GlitchedHandcraft(ActivatedAbility a)
			: base(a)
		{
		}

		public override bool AddStack(FrameBuff other)
		{
			if (other is GlitchedHandcraft glitchedHandcraft)
			{
				AddDuration(glitchedHandcraft.BaseDuration, refresh: true);
				return true;
			}
			return false;
		}

		public override double GetParallelMultiplier(WorldFrame frame, bool handCraft)
		{
			if (handCraft)
			{
				return 3.0;
			}
			return 1.0;
		}

		public override bool CanCoexistWith(FrameBuff other)
		{
			return true;
		}

		public override bool IsValidTarget(WorldFrame frame)
		{
			return frame == null;
		}
	}
}
