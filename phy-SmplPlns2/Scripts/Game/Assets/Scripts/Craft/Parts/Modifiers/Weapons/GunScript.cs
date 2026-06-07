using System;
using System.Collections;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Bullets;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class GunScript : PartModifierScript, IWeapon
	{
		private Func<bool> _activateFunc;

		private bool _active = true;

		private AudioSource _audio;

		private float _barrelSpinSpeed;

		private BulletPool _bulletPool;

		private Transform _bulletStartPoint;

		private int _burstCount;

		private float _burstTimer;

		private float _fireEffectsTimer;

		private WaitForFixedUpdate _fireGunCoroutineYield = new WaitForFixedUpdate();

		private float _fireTimer;

		private bool _isArmedThisFrame;

		private GameObject _muzzleFlashParticleSystem;

		private bool _shotWaitingSound;

		private Transform _spinningBarrels;

		public bool AdjustFireDelay => base.PartScript.Part.PartType.PartTypeId == "Gun-1";

		public int CurrentAmmo { get; private set; }

		public TrackedTarget CurrentTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CustomName => null;

		public float FireDelay { get; set; }

		public WeaponFunction Function => WeaponFunction.MultiRole;

		public GunData Gun { get; set; }

		public bool IsArmed
		{
			get
			{
				if (!base.PartScript.Aircraft.DisableGuns)
				{
					return _active;
				}
				return false;
			}
		}

		public bool IsDamaged { get; protected set; }

		public bool IsDestroyed => false;

		public TargetingStyle TargetingStyle => TargetingStyle.None;

		public int TotalAmmo => int.MaxValue;

		public WeaponType Type => WeaponType.Gun;

		private Func<bool> ActivateFunc => _activateFunc ?? (_activateFunc = base.Controls.GetActivatorGetter(Gun.ActivationGroup, base.PartScript, valueIfZero: true));

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault);
		}

		public void Fire(TrackedTarget trackedTarget)
		{
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light && !IsDamaged && UnityEngine.Random.value < 0.3f * (float)level)
			{
				IsDamaged = true;
			}
		}

		protected virtual void OnDestroy()
		{
			_bulletPool?.Dispose();
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightDefault);
		}

		private void FireGun()
		{
			if (CurrentAmmo > 0 && !IsDamaged)
			{
				StartCoroutine(FireGunAfterPhysics());
			}
		}

		private IEnumerator FireGunAfterPhysics()
		{
			yield return _fireGunCoroutineYield;
			Vector3 forward = base.PartScript.transform.forward;
			Vector3 velocity = forward * Gun.MuzzleVelocity + base.PartScript.Body.Velocity;
			velocity += UnityEngine.Random.insideUnitSphere * (10f * Gun.Spread);
			_bulletPool.CreateBullet(_bulletStartPoint.position, velocity, forward);
			CurrentAmmo--;
			_shotWaitingSound = true;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = ActivateFunc();
			if (_active != flag)
			{
				_active = flag;
				base.PartScript.Aircraft.TargetingSystem.OnQueueUpdateWeaponsList();
			}
			if (_fireTimer > 0f)
			{
				_fireTimer -= frame.DeltaTime;
			}
			if (_burstTimer > 0f)
			{
				_burstTimer -= frame.DeltaTime;
				_fireTimer = 0f;
			}
			if (frame.Craft.Controls.FireGuns && _isArmedThisFrame && !frame.Paused)
			{
				_barrelSpinSpeed = 1000f;
				if (_burstTimer <= 0f)
				{
					if (_fireTimer <= 0f)
					{
						_fireEffectsTimer = Gun.MinTimeBetweenRounds * 1.5f;
						FireGun();
						_burstCount++;
						_fireTimer = Gun.MinTimeBetweenRounds;
					}
					if (_burstCount >= Gun.BurstCount)
					{
						_burstCount = 0;
						_burstTimer = Gun.TimeBetweenBursts;
					}
				}
			}
			else
			{
				_burstCount = 0;
				_fireTimer = FireDelay;
			}
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			_isArmedThisFrame = IsArmed;
			if (_fireEffectsTimer > 0f && !IsDamaged)
			{
				_fireEffectsTimer -= frame.DeltaTime;
				if (_muzzleFlashParticleSystem.activeSelf)
				{
					_muzzleFlashParticleSystem.SetActive(Gun.MuzzleFlash);
				}
				if (_spinningBarrels != null)
				{
					if (!_audio.isPlaying)
					{
						_audio.timeSamples = (int)(UnityEngine.Random.value * (float)_audio.clip.samples);
						_audio.Play();
					}
				}
				else if (_shotWaitingSound)
				{
					_shotWaitingSound = false;
					_audio.pitch = 2f + 0.25f * UnityEngine.Random.value;
					if (_audio.isPlaying)
					{
						_audio.timeSamples = (int)(UnityEngine.Random.value * 50f);
					}
					else
					{
						_audio.Play();
					}
				}
			}
			else if (_audio.isPlaying)
			{
				_muzzleFlashParticleSystem.SetActive(value: false);
				_audio.Stop();
			}
			if (_spinningBarrels != null && !IsDamaged)
			{
				_spinningBarrels.Rotate(0f, 0f, _barrelSpinSpeed * frame.DeltaTime);
				_barrelSpinSpeed *= 1f - frame.DeltaTime;
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_muzzleFlashParticleSystem = Utilities.FindFirstGameObjectMyselfOrChildren("MuzzleFlash", base.PartScript.gameObject);
			_bulletStartPoint = Utilities.FindFirstGameObjectMyselfOrChildren("BulletStartPoint", base.PartScript.gameObject).GetComponent<Transform>();
			_audio = base.PartScript.GetComponent<AudioSource>();
			BulletData bulletData = new BulletData(base.PartScript.Aircraft, base.PartScript.Part.DisableAircraftCollisions, Gun.Lifetime, Gun.TracerColor, Gun.BulletScale, Gun.Damage, Gun.ImpactForce);
			_bulletPool = BulletPoolManager.Instance.CreatePool(bulletData);
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("SpinningBarrels", base.PartScript.gameObject);
			if (gameObject != null)
			{
				_spinningBarrels = gameObject.GetComponent<Transform>();
			}
			CurrentAmmo = TotalAmmo;
			return UniTask.CompletedTask;
		}
	}
}
