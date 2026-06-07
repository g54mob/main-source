using System.Collections.Generic;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class EnemyControllerBoss : EnemyController
	{
		[SerializeField]
		protected bool bossSpawnsBullets;

		[SerializeField]
		protected float bulletSpawnInterval;

		[SerializeField]
		protected bool bulletSpawnLooping;

		[SerializeField]
		protected EnemyType bulletType;

		protected Timer BulletSpawnTimer;

		[SerializeField]
		protected bool bossSpawnsMinions;

		[SerializeField]
		protected float minionSpawnInterval;

		[SerializeField]
		protected int minionSpawnAmount;

		[SerializeField]
		protected bool minionSpawnLooping;

		[SerializeField]
		protected EnemyType minionType;

		protected Timer MinionSpawnTimer;

		[SerializeField]
		protected bool bossSpawnsMinionsOnDeath;

		[SerializeField]
		protected int minionSpawnOnDeathAmount;

		[SerializeField]
		protected EnemyType minionOnDeathType;

		[SerializeField]
		protected bool bossSpawnsSwarms;

		[SerializeField]
		protected float swarmSpawnInterval;

		[SerializeField]
		protected bool swarmSpawnLooping;

		[SerializeField]
		protected EnemyType swarmType;

		[SerializeField]
		protected float swarmSpawnDelay;

		[SerializeField]
		protected int swarmRepeatAmount;

		[SerializeField]
		protected float swarmDistance;

		protected Timer SwarmSpawnTimer;

		[SerializeField]
		protected bool bossSpawnsWave;

		[SerializeField]
		protected float waveSpawnInterval;

		[SerializeField]
		protected bool waveSpawnLooping;

		[SerializeField]
		protected EnemyType waveType;

		[SerializeField]
		protected float waveSpawnDuration;

		[SerializeField]
		protected int waveAmount;

		protected Timer WaveSpawnTimer;

		[SerializeField]
		protected bool bossSpawnsCircle;

		[SerializeField]
		protected bool spawnCircleInstant;

		[SerializeField]
		protected float circleSpawnInterval;

		[SerializeField]
		protected bool circleSpawnLooping;

		[SerializeField]
		protected float circleDuration;

		[SerializeField]
		protected EnemyType circleEnemy;

		[SerializeField]
		protected int circleEnemyAmount;

		[SerializeField]
		protected float circleDiameter;

		protected Timer CircleSpawnTimer;

		protected Timer CircleInstantSpawnTimer;

		[SerializeField]
		protected bool bossHasDamageZones;

		[SerializeField]
		private bool sequentialZoneSpawns;

		[SerializeField]
		private List<DamagingZonePrefab> damagingZones;

		[Header("Rewards")]
		[SerializeField]
		private WeaponType _weaponToDrop;

		[SerializeField]
		private bool _hasTreasureChest;

		[SerializeField]
		private List<float> _treasureChances;

		[Header("Death VFX")]
		[SerializeField]
		private bool _playRingDeathVfx;

		[SerializeField]
		private bool _playPosterDeathVfx;

		[SerializeField]
		private bool _playFireballDeath;

		private List<float> _zoneTimers;

		private List<float> _zoneRespawnTimers;

		private float _sequentialRespawnTimer;

		private int _currentZoneIndex;

		private int _zoneLongestRespawner;

		private readonly List<PrizeType?> _treasurePrizeTypes;

		private bool _hasDroppedTreasure;

		private SpriteRenderer _ringSprite;

		private MultiTargetTween _deathVfxRingTween;

		private SpriteRenderer _posterSprite;

		private SpriteMask _posterMask;

		private Tween _posterTween;

		private ParticleSystem _deathVfxParticleSystem1;

		private ParticleSystem _deathVfxParticleSystem2;

		private Timer _deathAnimTimer;

		protected MultiTargetTween _deathScaleTween;

		private Timer exploTimer1;

		private Timer exploTimer2;

		private Timer deathTimer1;

		private Timer deathTimer2;

		protected uint _damagingZoneSeed;

		private const string VfxTextureName = "vfx";

		private const string PosterSpriteName = "CirclePoster01";

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint DamagingZoneSeed
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected virtual void InitSpawnBossBullets()
		{
		}

		protected virtual void InitSpawnBossMinions()
		{
		}

		protected virtual void InitSpawnBossSwarm()
		{
		}

		protected virtual void InitSpawnBossCircle()
		{
		}

		protected virtual void InitSpawnWaveEvent()
		{
		}

		protected virtual void InitSpawnDamageZones(bool asRemote)
		{
		}

		private void InitDeathVfx()
		{
		}

		protected virtual void SpawnBossBullets()
		{
		}

		protected virtual void SpawnBossMinions(EnemyType type, int spawnAmount)
		{
		}

		private static void ScaleSpawnedEnemy(EnemyController spawned)
		{
		}

		protected virtual void SpawnBossSwarms()
		{
		}

		protected virtual void SpawnBossWave()
		{
		}

		protected virtual void SpawnBossCircle()
		{
		}

		protected virtual void UpdateSpawnDamageZones()
		{
		}

		protected override void Die()
		{
		}

		private void DropTreasure()
		{
		}

		private void DropWeapon()
		{
		}

		private void PlayDeathVfx()
		{
		}

		protected virtual void DoDeathAnimation()
		{
		}

		private void PlayPosterAnimation(Transform t)
		{
		}

		public override void Despawn()
		{
		}
	}
}
