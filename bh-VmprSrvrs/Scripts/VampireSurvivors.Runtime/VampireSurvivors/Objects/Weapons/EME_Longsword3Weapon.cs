using UnityEngine;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Longsword3Weapon : EME_Longsword2Weapon
	{
		protected override int ComboIndexFinal => 0;

		protected override int GlimmerTier => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}
	}
}
