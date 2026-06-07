using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class ImprovedEnergyShield : DroneEffect
	{
		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.ImprovedShield;
			}
		}
	}
}
