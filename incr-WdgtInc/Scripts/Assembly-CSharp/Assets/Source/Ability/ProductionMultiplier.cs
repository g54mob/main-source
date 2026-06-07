using System;
using Assets.Source.Buff;
using Assets.Source.Player;
using Assets.Source.Util;

namespace Assets.Source.Ability
{
	public class ProductionMultiplier : BuffAbility
	{
		public const float Duration = 20f;

		public static double EntropyScale = 0.1;

		public static double EffectStrength => 1.25 * Math.Pow(GamePlayer.Current.AbilityEntropy, EntropyScale);

		public override double Entropy => 1.1;

		public override int BaseCost => 60;

		public override string IconName => "Items2_7";

		public override string DescriptionText => Translation.TranslateOnly(base.DescriptionText, GameMath.FormatPercentage(EffectStrength - 1.0), 20f);

		public override FrameBuff CreateBuff()
		{
			return new GlitchedProductivity(this);
		}
	}
}
