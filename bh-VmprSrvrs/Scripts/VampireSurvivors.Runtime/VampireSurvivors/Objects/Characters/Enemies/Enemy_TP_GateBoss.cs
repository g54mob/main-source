using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_GateBoss : EnemyController
	{
		[Header("Gate Boss")]
		[SerializeField]
		public ItemType RelicToDrop;

		[SerializeField]
		public WeaponType WeaponToDrop;

		[SerializeField]
		public ItemType AlternativePrize;

		[SerializeField]
		public bool HasRelic;

		[SerializeField]
		public bool HasTreasureChest;

		[SerializeField]
		public List<float> TreasureChances;

		[SerializeField]
		public ItemType RequiresItem;

		[SerializeField]
		public List<PrizeType?> TreasurePrizeTypes;

		[FormerlySerializedAs("damageZone")]
		[Header("Damage Zone")]
		[SerializeField]
		private DamagingZonePrefab damagingZone;

		private float _damageZoneRespawnTimer;

		public bool DoWiggle;

		private SpriteRenderer _ringSprite;

		private float _shieldDamage;

		private int _deathScreamTimerLoopCount;

		private bool _hasShield;

		private bool _hasRunDeathLogic;

		private bool _hasRunOneHKOLogic;

		private Timer _shieldTimer;

		private Timer _aiTimer;

		private Timer _deathScreamTimer;

		protected bool _isRunningDeathAnimation;

		private SpriteRenderer _posterSprite;

		private SpriteMask _posterMask;

		private MultiTargetTween screamTween;

		protected MultiTargetTween scaleTween;

		private Timer deathTimer1;

		private Timer deathTimer2;

		private Timer exploTimer1;

		private Timer exploTimer2;

		private Timer animTimer;

		private Timer relicDropTimer;

		private Tween posterTween;

		private bool _hasDroppedTreasure;

		private Tween _onEnterTween;

		private SpriteRenderer _enterSprite;

		private SpriteRenderer _enterSprite2;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _rotTween;

		private ParticleSystem _deathVfxParticleSystem1;

		private ParticleSystem _deathVfxParticleSystem2;

		protected uint _damagingZoneSeed;

		[SerializeField]
		public WeaponType OHKOWeaponType;

		[SerializeField]
		public SecretType OHKOSecretUnlock;

		[SerializeField]
		public CharacterType OHKOCharacterUnlock;

		[SerializeField]
		public CharacterType Assassin;

		[SerializeField]
		public SecretType AssassinSecretUnlock;

		[SerializeField]
		public CharacterType AssassinCharacterUnlock;

		public Action OnDefeat { get; set; }

		public virtual bool DropRelic { get; set; }

		public virtual float ShieldTime { get; set; }

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

		private void OnRemoteItemInstantiated(Pickup pickup)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public virtual void CheckAssassin()
		{
		}

		public virtual void OnOHKO()
		{
		}

		[Command]
		public void OneHitKoOnline(long startingClientFrame)
		{
		}

		private void OneHitKoLogic()
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		private void KillGateBoss()
		{
		}

		[Command]
		public void DeathTrigger()
		{
		}

		protected virtual void DeathLogic()
		{
		}

		protected virtual void CustomDeathLogic()
		{
		}

		private void OnWeaponSpawned(Pickup p)
		{
		}

		private void OnRelicSpawned(PickupRelic p)
		{
		}

		private void DropTreasure()
		{
		}

		private void PlayPosterAnimation(Transform t)
		{
		}

		protected void DeathScream()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected virtual void DoDeathAnimation()
		{
		}

		public override void Despawn()
		{
		}
	}
}
