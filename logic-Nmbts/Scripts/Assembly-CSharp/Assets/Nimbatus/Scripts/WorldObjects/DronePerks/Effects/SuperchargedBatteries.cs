using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class SuperchargedBatteries : DroneEffect
	{
		public int RechargeIncrease;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.SuperchargedBatteries;
			}
		}
	}
}
