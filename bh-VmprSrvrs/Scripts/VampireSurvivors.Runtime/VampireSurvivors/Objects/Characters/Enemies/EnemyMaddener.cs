using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyMaddener : EnemyAlias
	{
		[SerializeField]
		private GameObject _SingleWarningPrefab;

		private bool _isSpinning;

		private bool _isRunning;

		private bool _isPursuing;

		private bool _rosaried;

		private float _spinAngle;

		private float _spinRadius;

		private float _runningTweenValue;

		private Tween _lowerScreenTween;

		private Tween _spinningTween;

		private Sequence _killTween;

		private Bounds _camBounds;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		public void Spinnn()
		{
		}

		public void StartLowerScreenMotion()
		{
		}

		public void StartPursuit()
		{
		}

		public void StartKill()
		{
		}

		public void StopAllTimers()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void UpdateDepth()
		{
		}

		private void StartRunningTween()
		{
		}

		private void ExecuteKill()
		{
		}

		private void SingleWarning(Vector2 pos)
		{
		}
	}
}
