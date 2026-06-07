using DG.Tweening;
using Unity.Mathematics;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyFBBulletFireball : EnemyController
	{
		private float _lifetime;

		private const float DurationMillis = 5500f;

		private bool _isDespawning;

		private Tween _onEnterTween;

		private Tween _scaleTween;

		private Tween _onLifetimeTween;

		private float2 _fixedVelocity;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void SetFixedVelocity(float2 velocity)
		{
		}

		public override void Disappear()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void OnPlayerOverlap(CharacterController player)
		{
		}

		private void DeathTween()
		{
		}

		protected override void Die()
		{
		}
	}
}
