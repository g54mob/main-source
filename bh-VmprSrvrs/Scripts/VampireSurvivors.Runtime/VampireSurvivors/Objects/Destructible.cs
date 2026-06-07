using System;
using Coherence;
using Coherence.Toolkit;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class Destructible : BasePoolableSpriteBehaviour, IDamageable
	{
		[Sync]
		public uint _deathSeed;

		protected SpriteRenderer _destructibleRenderer;

		protected SpriteAnimation _spriteAnimation;

		private DataManager _dataManager;

		protected PlayerOptions _playerOptions;

		private LootManager _lootManager;

		private GameManager _gameManager;

		protected GameSessionData _gameSessionData;

		protected PropData _propData;

		private MaterialPropertyBlock _propBlock;

		protected Camera _mainCamera;

		protected PropType _destructibleType;

		protected float _hp;

		private float _maxHp;

		protected Timer _blinkTimer;

		private bool _receivingDamage;

		private bool _isCullable;

		private bool _isTeleportOnCull;

		protected bool _isDead;

		public float _blessedLevel;

		protected Light2D _light;

		protected CoherenceSync _coherenceSync;

		private Unity.Mathematics.Random _deathRng;

		[Sync]
		public int PropType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsStationary { get; set; }

		public PropType DestructibleType => default(PropType);

		public bool IgnoreForcedMovement { get; set; }

		[Inject]
		private void Construct(DataManager dataManager, PlayerOptions playerOptions, LootManager lootManager, GameManager gameManager, GameSessionData gameSessionData)
		{
		}

		public virtual void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		public virtual void OnDestructibleSpawned(SuperObject tiledScriptObject)
		{
		}

		protected override void OnUpdate()
		{
		}

		public virtual void Init(PropType destructibleType)
		{
		}

		public void UpdateLightPosition()
		{
		}

		protected virtual bool CanEmitLight()
		{
			return false;
		}

		public virtual void Despawn()
		{
		}

		protected void Pushback(GameObject value, float duration)
		{
		}

		public virtual void RemoteDestroy()
		{
		}

		public virtual void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void DestroyDestructible()
		{
		}

		public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
		{
		}

		public bool IsUnitDead()
		{
			return false;
		}

		public float MaxHp()
		{
			return 0f;
		}

		public float CurrentHealth()
		{
			return 0f;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		protected virtual void SetupAnimations()
		{
		}

		protected virtual void OnDestroyed()
		{
		}

		public void GiveReward(Action<Pickup> onRewardGiven = null)
		{
		}

		private void HandleArcanas()
		{
		}

		protected virtual void RestoreTint()
		{
		}

		public virtual bool DoesAllowVenting()
		{
			return false;
		}
	}
}
