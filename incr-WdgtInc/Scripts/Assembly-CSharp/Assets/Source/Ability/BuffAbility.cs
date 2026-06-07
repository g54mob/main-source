using Assets.Source.Buff;
using Assets.Source.World;

namespace Assets.Source.Ability
{
	public abstract class BuffAbility : ActivatedAbility
	{
		public override AbilityTargetType TargetType => AbilityTargetType.Frame;

		public abstract FrameBuff CreateBuff();

		public override bool IsValidTarget(object target)
		{
			if (target is WorldFrame frame)
			{
				if (base.IsValidTarget(target))
				{
					return CreateBuff().IsValidTarget(frame);
				}
				return false;
			}
			return false;
		}

		protected override bool ActivateAbility(object target)
		{
			if (target is WorldFrame worldFrame)
			{
				return worldFrame.AddBuff(CreateBuff());
			}
			return false;
		}
	}
}
