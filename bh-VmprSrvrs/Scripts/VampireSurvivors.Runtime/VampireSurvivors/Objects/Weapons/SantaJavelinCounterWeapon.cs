using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class SantaJavelinCounterWeapon : SantaJavelinWeapon
	{
		public Transform PublicTarget => null;

		public override float PitchCorrection => 0f;

		public override void CheckArcanas()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ForcedFire(bool hasTarget, Vector3 position, bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
