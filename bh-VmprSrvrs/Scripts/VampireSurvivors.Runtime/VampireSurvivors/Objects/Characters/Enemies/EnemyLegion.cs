using System.Collections.Generic;
using Coherence.Toolkit;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyLegion : EnemyController
	{
		public enum LegionBossPhase
		{
			Unactivated = 0,
			Activating = 1,
			Normal = 2,
			Spewing = 3,
			Dying = 4,
			Dead = 5
		}

		private class Tentacle
		{
			public PhaserSprite _arm;

			public PhaserSprite _head;

			public float _aimCounter;

			public float _chargeCounter;

			public bool _isFiring;

			public PhaserSprite _laser;

			public PhaserSprite _laserCap;
		}

		private LegionBossPhase _phase;

		private ArcadeRect _activationRect;

		private List<EnemyLegionSection> _sections;

		private float _colourLerp;

		private float _colourLerpSpeed;

		private float2 _spawnLocation;

		private float2 _floorPosition;

		private float2 _startPosition;

		private float _movementTimer;

		private float _spawnTimer;

		private List<EnemyLegionZombie> _zombieList;

		private List<Tentacle> _tentacles;

		private MultiTargetTween _activationTween;

		public float _timeUntilSectionsVulnerable;

		public LegionBossPhase Phase => default(LegionBossPhase);

		public float FloorHeight => 0f;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void InstantiateSections()
		{
		}

		private void SetupTentacles()
		{
		}

		private void UpdateTentacles()
		{
		}

		private bool IsMiddleSectionDead()
		{
			return false;
		}

		[Command]
		public void ChangeTentacleHeadFrame(int tentacleIndex, string spriteName, string textureName, bool isFiring, bool stopFiring)
		{
		}

		[Command]
		public void FireTentacleLaser(int tentacleIndex)
		{
		}

		private void SpawnZombies()
		{
		}

		private void SpawnZombie(float2 position)
		{
		}

		public List<EnemyLegionSection> GetSections()
		{
			return null;
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		private void DoDeathAnimation()
		{
		}

		private void DropReward()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void Activate()
		{
		}

		private void ActivationFinish()
		{
		}

		public void ScreenShake(int repeats = 6)
		{
		}
	}
}
