using Assets.Source.Buff;
using Assets.Source.Player;

namespace Assets.Source.Ability
{
	public class HandcraftMultiplier : ActivatedAbility
	{
		public const double EffectStrength = 3.0;

		public override double Entropy => 1.2;

		public override int BaseCost => 20;

		public override string IconName => "Items2_12";

		public override AbilityTargetType TargetType => AbilityTargetType.None;

		protected override bool ActivateAbility(object target)
		{
			GamePlayer.Current.AddBuff(new GlitchedHandcraft(this));
			return true;
		}
	}
}
