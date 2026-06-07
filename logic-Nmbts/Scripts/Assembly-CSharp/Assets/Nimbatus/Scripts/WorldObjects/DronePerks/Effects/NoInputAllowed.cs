using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class NoInputAllowed : DroneEffect
	{
		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.NoInput;
			}
		}
	}
}
