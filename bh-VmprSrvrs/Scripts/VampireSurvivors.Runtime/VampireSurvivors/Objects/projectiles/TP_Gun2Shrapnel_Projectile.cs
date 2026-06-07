using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Gun2Shrapnel_Projectile : TP_Gun1Shrapnel_Projectile
	{
		private List<Color> colors;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
