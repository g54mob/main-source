using Unity.Mathematics;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Doppleganger_Knife : EnemyProjectile
	{
		private Timer _despawnTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(int index, float2 direction, EnemyBulletPool pool)
		{
		}

		public override void Despawn()
		{
		}
	}
}
