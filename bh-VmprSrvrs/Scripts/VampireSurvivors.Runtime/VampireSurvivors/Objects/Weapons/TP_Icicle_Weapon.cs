using System;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Icicle_Weapon : Weapon
	{
		[NonSerialized]
		public float angleTime;

		[NonSerialized]
		public float AimTime;

		[NonSerialized]
		public float AimUnit;

		public int Spawned()
		{
			return 0;
		}

		protected override void Awake()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
