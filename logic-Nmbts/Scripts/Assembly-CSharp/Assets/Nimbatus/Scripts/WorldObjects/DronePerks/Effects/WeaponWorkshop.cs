using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class WeaponWorkshop : DroneEffect
	{
		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.WeaponWorkshop;
			}
		}
	}
}
