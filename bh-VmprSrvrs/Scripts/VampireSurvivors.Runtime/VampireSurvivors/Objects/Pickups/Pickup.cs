using System;
using Coherence.Toolkit;
using DG.Tweening;
using Rewired.Utils.Libraries.TinyJson;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Pickups
{
	public class Pickup : BasePoolableSpriteBehaviour, IDamageable
	{
		protected SignalBus _signalBus;

		protected PlayerOptions _playerOptions;

		protected DataManager _dataManager;

		protected GameSessionData _gameSessionData;

		protected GameManager _gameManager;

		protected SpriteRenderer _itemRenderer;

		public SpriteAnimation _spriteAnimation;

		protected Camera _mainCamera;

		private Vector2 _currentDirection;

		private const float Radius = 10f;

		private const float DefaultSpeed = 250f;

		[DoNotSerialize]
		public VampireSurvivors.Objects.Characters.CharacterController _targetPlayer;

		private static int _fps;

		private static double _frameTime;

		private double _frameTimeMS;

		private double _elapsed;

		protected string _frameName;

		protected string _textureName;

		[DoNotSerialize]
		public bool _ShowAboveAll;

		protected bool _doOnlineDespawn;

		public bool HasMapTokenData;

		public string MapTokenFrameName;

		public string MapTokenTexture;

		public float Time;

		private MultiTargetTween _vacuumTween;

		private bool _goToPlayer;

		private bool _disableDespawn;

		[DoNotSerialize]
		public bool IsInLavatrix;

		protected Tween lavatrixTween;

		[Sync]
		public int SyncedPickupType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public bool IsStagePickup { get; set; }

		[Sync]
		[OnValueSynced("OnSpriteChanged")]
		public string SpriteName { get; set; }

		public ItemType PickupType { get; protected set; }

		[Sync]
		public float Value { get; set; }

		public float ResRosary { get; set; }

		public float? LoopedSpawnX { get; set; }

		public float Speed { get; set; }

		public float FeverMS { get; set; }

		public bool GoToPlayer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool IgnoreMadGroove { get; set; }

		[Sync]
		public bool DisableGet { get; set; }

		public Action<Pickup> PickupCallback { get; set; }

		public int Depth => 0;

		public bool IsStationary { get; set; }

		public bool IgnoreForcedMovement { get; set; }

		public bool DespawnInteadOfResetPosition { get; set; }

		public bool AutoSafeXY { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController TargetPlayer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool DoOnlineDespawn => false;

		public virtual void StopFloat()
		{
		}

		public virtual bool CanCharacterCollectPickup(CharacterType characterType)
		{
			return false;
		}

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions playerOptions, DataManager dataManager, GameSessionData gameSessionData, GameManager gameManager)
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public virtual void SetData(ItemType itemType)
		{
		}

		public virtual void InternalUpdate()
		{
		}

		public virtual void UpdateDepth()
		{
		}

		public virtual bool Vacuum(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			return false;
		}

		public virtual void Despawn()
		{
		}

		public void SetFrame(string spriteName)
		{
		}

		public virtual void GetTaken()
		{
		}

		public void ForceDisableDespawn()
		{
		}

		public virtual void DisposeAsTaken()
		{
		}

		public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
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

		public void GoToLowestHealthPlayer()
		{
		}

		protected void RemovePhysics()
		{
		}

		protected void OnSpriteChanged(string oldSprite, string newSprite)
		{
		}

		private void InitRenderer()
		{
		}

		protected void InitPhysics()
		{
		}

		protected virtual void SetHasSeenItem()
		{
		}

		protected virtual void SetHasSeenItem(ItemType itemType)
		{
		}

		protected virtual void AddToRunPickups()
		{
		}

		protected virtual void AddToRunPickups(ItemType itemType)
		{
		}

		protected float2 SafeXY()
		{
			return default(float2);
		}

		protected float2 SafeXYWrapped()
		{
			return default(float2);
		}

		protected virtual void GoToThePlayer()
		{
		}

		protected virtual void TrackItemPickup(bool trackRunPickup = true)
		{
		}

		protected virtual void ToggleCursors(UISignals.ToggleGuidesSignal sig)
		{
		}

		public virtual void Bless(float value, HitVfxType hitVFXType = HitVfxType.Prism)
		{
		}

		public void GiveReward(Action<Pickup> onRewardGiven = null)
		{
		}

		public static Vector2 Spiral2D(Vector2 start, Vector2 center, float t, float turns = 2f, bool clockwise = true)
		{
			return default(Vector2);
		}
	}
}
