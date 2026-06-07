using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class EffectReceivableSettings : BaseReceivableSettings
	{
		public DroneEffectSetting Setting;

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			return new EffectReceivable
			{
				Effect = Setting.Effect
			};
		}
	}
}
