using UnityEngine;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Greatsword2Weapon : EME_Greatsword1Weapon
	{
		protected override int GlimmerTier => 0;

		protected override int ComboIndexFinal => 0;

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}
	}
}
