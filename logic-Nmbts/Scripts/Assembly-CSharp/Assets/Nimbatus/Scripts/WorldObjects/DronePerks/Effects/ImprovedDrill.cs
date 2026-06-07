using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class ImprovedDrill : DroneEffect
	{
		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.ImprovedDrill;
			}
		}
	}
}
