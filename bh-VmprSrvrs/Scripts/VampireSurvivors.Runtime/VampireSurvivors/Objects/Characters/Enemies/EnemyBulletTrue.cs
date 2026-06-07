using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBulletTrue : EnemyController
	{
		private float _lifetime;

		private float _myAngle;

		private bool _isDespawning;

		private Tween _onEnterTween;

		private Tween _scaleTween;

		private Tween _onLifetimeTween;

		private const float DurationMillis = 5500f;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
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

		protected override void OnUpdate()
		{
		}

		protected override void ProcessWiggle()
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
