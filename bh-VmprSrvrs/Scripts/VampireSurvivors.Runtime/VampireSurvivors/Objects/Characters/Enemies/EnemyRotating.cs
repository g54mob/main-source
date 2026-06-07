using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyRotating : EnemyController
	{
		private float _previousDistance;

		private bool _isRotating;

		private Tween _onEnterTween;

		private Tween _onFireTimer;

		private Tween _rotateTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void ProcessWiggle()
		{
		}

		private void StartRotate()
		{
		}
	}
}
