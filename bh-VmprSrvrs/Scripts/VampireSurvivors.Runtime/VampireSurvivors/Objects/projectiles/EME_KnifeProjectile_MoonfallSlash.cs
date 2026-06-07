using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KnifeProjectile_MoonfallSlash : EME_KnifeProjectile
	{
		public override bool DoExplosions => false;

		public override float DurationMultiplier => 0f;

		protected override void Awake()
		{
		}

		public override Color[][] GetTints()
		{
			return null;
		}

		public override void FireSpecialBullets()
		{
		}
	}
}
