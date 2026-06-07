using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SinistroCustos_Projectile : TP_Custos_Projectile
	{
		private TP_SinistroCustos_Weapon _baseWeapon;

		private Timer _timer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		public override void Bite()
		{
		}

		public override void Despawn()
		{
		}
	}
}
