using System;
using Assets.Source.Buff;
using Assets.Source.Player;
using Assets.Source.Util;

namespace Assets.Source.Ability
{
	public class SpeedMultiplier : BuffAbility
	{
		public const float Duration = 20f;

		public static double EntropyScale = 0.25;

		public static double EffectStrength => 2.0 * Math.Pow(GamePlayer.Current.AbilityEntropy, EntropyScale);

		public override double Entropy => 1.02;

		public override int BaseCost => 20;

		public override string IconName => "Items_46";

		public override AbilityTargetType TargetType => AbilityTargetType.Frame;

		public override string DescriptionText => Translation.TranslateOnly(base.DescriptionText, GameMath.FormatPercentage(EffectStrength - 1.0), 20f);

		public override FrameBuff CreateBuff()
		{
			return new GlitchedSpeed(this);
		}
	}
}
