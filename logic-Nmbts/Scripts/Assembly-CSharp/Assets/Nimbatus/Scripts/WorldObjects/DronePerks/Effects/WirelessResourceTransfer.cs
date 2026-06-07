using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class WirelessResourceTransfer : DroneEffect
	{
		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.WirelessResourceTransfer;
			}
		}
	}
}
