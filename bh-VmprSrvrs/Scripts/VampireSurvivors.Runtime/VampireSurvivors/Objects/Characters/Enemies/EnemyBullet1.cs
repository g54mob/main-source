using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBullet1 : EnemyController
	{
		private float _originalScale;

		private float _lifetime;

		private const float DurationMillis = 5500f;

		private bool _isDespawning;

		private Tween _onEnterTween;

		private Tween _scaleTween;

		private Tween _onLifetimeTween;

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

		private void DeathTween()
		{
		}

		protected override void Die()
		{
		}
	}
}
