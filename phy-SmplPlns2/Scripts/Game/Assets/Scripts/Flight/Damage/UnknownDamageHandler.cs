using System;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class UnknownDamageHandler : DamageHandler
	{
		public UnknownDamageHandler()
			: base(DamageType.Unknown)
		{
		}
	}
}
