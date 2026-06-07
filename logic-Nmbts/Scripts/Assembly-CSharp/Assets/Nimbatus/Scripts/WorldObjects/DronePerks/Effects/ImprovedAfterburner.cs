using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class ImprovedAfterburner : DroneEffect
	{
		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.ImprovedAfterburner;
			}
		}
	}
}
