using System.Collections.Generic;
using Coherence.Toolkit;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class TP_ADV_BOSS_PhantomBat : EnemyControllerBoss
	{
		private enum BEHAVIOUR_MODE
		{
			SETUP = 0,
			MAIN = 1,
			SWARM_TRANSITION = 2,
			SWARM = 3
		}

		[SerializeField]
		private EnemyType swarmBat;

		[SerializeField]
		private int phantomBatsSpawned;

		private BEHAVIOUR_MODE _behaviour;

		private static readonly List<float> HealthPercentThresholds;

		private int _currentPercentThreshold;

		private float _healthThreshold;

		private bool _thresholdsCompleted;

		private bool _isInvulnerable;

		private List<EnemyController> _batSwarmTracker;

		private Vector3 finalBatDeathPosition;

		private SpriteTrail _spriteTrail;

		private Tween _moveTween;

		private MultiTargetTween _swarmTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void SpawnBossBullets()
		{
		}

		private void CheckForSplitIntoSwarm()
		{
		}

		[Command]
		public void SplitIntoSwarm(float randomValue)
		{
		}

		private void FinishSwarmTransition()
		{
		}

		private void IsSwarmDead()
		{
		}

		[Command]
		public void RecoverFromSwarm(Vector3 finalBatDeathPosition)
		{
		}

		protected virtual void SpawnPhantomSwarm(EnemyType type, int spawnAmount, Vector2 pos)
		{
		}

		private Vector2 GetBatSwarmSpawnPos(float randomValue)
		{
			return default(Vector2);
		}

		public void BatInSwarmKilled(EnemyController batKilled)
		{
		}

		private void EnableSpriteTrail(bool enable)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void Despawn()
		{
		}
	}
}
