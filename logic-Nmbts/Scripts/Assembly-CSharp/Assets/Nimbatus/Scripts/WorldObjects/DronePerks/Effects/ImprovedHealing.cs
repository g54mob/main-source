namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	public class ImprovedHealing : DroneEffect
	{
		public int HealPercentage = 10;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.ImprovedHealing;
			}
		}
	}
}
