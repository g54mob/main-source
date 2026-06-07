using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_AlucardSword1_Projectile : Projectile
	{
		private SpriteAnimation _anim;

		private bool _cachedFlipX;

		private const int AnimFPS = 50;

		private const float XOffset = 0.14f;

		private const float XRepeatOffset = 0.16f;

		private const float YOffset = 0.26f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected virtual void OnAnimAttackComplete()
		{
		}
	}
}
