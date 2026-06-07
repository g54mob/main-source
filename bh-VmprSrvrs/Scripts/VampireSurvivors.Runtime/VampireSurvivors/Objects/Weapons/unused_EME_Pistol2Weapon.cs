using UnityEngine;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class unused_EME_Pistol2Weapon : unused_EME_Pistol1Weapon
	{
		protected override int ComboIndexFinal => 0;

		protected override int GlimmerTier => 0;

		protected override void MakeLevelOne()
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}
	}
}
