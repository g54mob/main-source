using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyKitsuneTailTip : EnemyController
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private float _minAngleRotDeg;

		private float _maxAngleRotDeg;

		private float _angleRng;

		private float _attackTime;

		private float _attackDelay;

		private const float ATTACK_DELAY = 15000f;

		private int _headIndex;

		private Vector2 _targetVector;

		private Vector2 _startingPosition;

		private Vector2 _currentVector;

		public float _AttackLerp;

		private Vector2 _neckPosition;

		private MultiTargetTween _attackTween;

		private MultiTargetTween _retreatTween;

		private MultiTargetTween _fadeTrailTween;

		private Vector2 _headOffset;

		private Vector2 _invHeadOffset;

		private EnemyKitsune _trueOwner;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void InitTrail()
		{
		}

		public override void SetOwner(GameObject owner)
		{
		}

		public void SetHeadIndex(int index)
		{
		}

		public void SetRandomStartingPosition()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void Attack()
		{
		}

		private void SetCurrentVector()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		protected void FadeTrails()
		{
		}

		private void SingleWarning(float x, float y)
		{
		}
	}
}
