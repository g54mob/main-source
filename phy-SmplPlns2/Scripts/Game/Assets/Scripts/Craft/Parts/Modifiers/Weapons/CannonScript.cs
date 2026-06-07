using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Multiplayer.SyncData;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class CannonScript : PartModifierScript, IWeapon
	{
		private Func<bool> _activateFunc;

		private bool _active;

		private AudioSource _audio;

		private AudioSource _audioAlt;

		private Transform _barrel;

		private Transform _barrelBase;

		private Collider _barrelBaseCollider;

		private Collider _barrelCollider;

		private Vector3 _barrelReadyPosition;

		private Vector3 _barrelRecoilPosition;

		private Vector3 _barrelTargetPosition;

		private float _barrelTimeInTargetPosition;

		private Transform _base;

		private Collider _baseCollider;

		private CannonProjectileScript _cameraProjectile;

		private CameraVantageScript _cameraVantage;

		private CannonData _cannon;

		private int _currentAmmo;

		private ITarget _currentTarget;

		private Func<float> _fuseFunc;

		private float? _fuseOverride;

		private float _launchSoundPitch;

		private GameObject _muzzleBrake;

		private Collider _muzzleBrakeCollider;

		private Transform _muzzleTip;

		private ParticleSystem _particleSystem;

		private bool _projectileClearedLastFrame = true;

		private Transform _projectileInBarrel;

		private Collider[] _projectileInBarrelColliders;

		private GameObject _projectilePrefab;

		private GameObject _projectiles;

		private Transform _projectileSpawnPoint;

		private int _shotsUntilTracer = -1;

		private bool _showRemoteMuzzleFlash;

		public bool CanFire
		{
			get
			{
				if ((_barrelTimeInTargetPosition > MaxRecoilTime * 0.25f || Mathf.Approximately(_cannon.BarrelRecoil, 0f)) && CheckLastProjectileClearOfBarrel())
				{
					return true;
				}
				return false;
			}
		}

		int IWeapon.CurrentAmmo => _currentAmmo;

		TrackedTarget IWeapon.CurrentTarget { get; set; }

		string IWeapon.CustomName => _cannon.CustomName;

		public float FiringDelay => _cannon.FiringDelay;

		WeaponFunction IWeapon.Function => _cannon.Function;

		public bool IsArmed
		{
			get
			{
				if (!base.PartScript.Aircraft.DisableCannons)
				{
					return _active;
				}
				return false;
			}
		}

		bool IWeapon.IsDestroyed => !base.gameObject.activeInHierarchy;

		public float ProjectileVelocity => _cannon.ProjectileVelocity;

		TargetingStyle IWeapon.TargetingStyle => TargetingStyle.None;

		public Vector3 TipPosition => _muzzleTip.position;

		int IWeapon.TotalAmmo => _cannon.AmmoCount;

		WeaponType IWeapon.Type => WeaponType.Cannon;

		private Func<bool> ActivateFunc => _activateFunc ?? (_activateFunc = base.Controls.GetActivatorGetter(_cannon.ActivationGroup, base.PartScript, valueIfZero: true));

		private float MaxRecoilTime => Mathf.Min(FiringDelay, 0.2f);

		public event EventHandler<EventArgs> Destroyed;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public bool CheckLastProjectileClearOfBarrel(bool includeMuzzleBrake = true)
		{
			bool result = true;
			if (_projectileInBarrel != null)
			{
				Bounds bounds = new Bounds(_projectileInBarrel.position, Vector3.zero);
				Collider[] projectileInBarrelColliders = _projectileInBarrelColliders;
				foreach (Collider collider in projectileInBarrelColliders)
				{
					bounds.Encapsulate(collider.bounds);
				}
				if (_baseCollider.bounds.Intersects(bounds) || _barrelCollider.bounds.Intersects(bounds) || _barrelBaseCollider.bounds.Intersects(bounds))
				{
					result = false;
				}
				else if (_cannon.MuzzleBrake && _muzzleBrakeCollider.bounds.Intersects(bounds))
				{
					if (includeMuzzleBrake)
					{
						result = false;
					}
				}
				else if (Utilities.CompareVector3s(_barrel.localPosition, _barrelReadyPosition))
				{
					projectileInBarrelColliders = _projectileInBarrelColliders;
					foreach (Collider collider2 in projectileInBarrelColliders)
					{
						if (collider2 != null)
						{
							Physics.IgnoreCollision(_baseCollider, collider2, ignore: false);
							Physics.IgnoreCollision(_barrelCollider, collider2, ignore: false);
							Physics.IgnoreCollision(_barrelBaseCollider, collider2, ignore: false);
							Physics.IgnoreCollision(_muzzleBrakeCollider, collider2, ignore: false);
						}
					}
					_projectileInBarrel = null;
					_projectileInBarrelColliders = null;
				}
			}
			return result;
		}

		public void Fire()
		{
			Transform transform = UnityEngine.Object.Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation, FlightSceneScript.Instance.transform).transform;
			float num = _cannon.Diameter * 0.5f;
			transform.localScale = new Vector3(num, num, num);
			transform.gameObject.SetActive(value: true);
			if (CameraManagerScript.Instance.Controller.CameraVantage == _cameraVantage)
			{
				base.PartScript.Aircraft.MoveWindAudio(transform);
			}
			Collider[] components = transform.GetComponents<Collider>();
			Bounds bounds = new Bounds(transform.position, Vector3.zero);
			Collider[] array = components;
			foreach (Collider collider in array)
			{
				Physics.IgnoreCollision(_baseCollider, collider, ignore: true);
				Physics.IgnoreCollision(_barrelCollider, collider, ignore: true);
				Physics.IgnoreCollision(_barrelBaseCollider, collider, ignore: true);
				Physics.IgnoreCollision(_muzzleBrakeCollider, collider, ignore: true);
				bounds.Encapsulate(collider.bounds);
			}
			Vector3 pointVelocity = base.PartScript.Body.RigidBody.GetPointVelocity(_muzzleTip.position);
			pointVelocity += base.transform.forward * ProjectileVelocity;
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.mass = _cannon.ProjectileVolume * 11342f * 0.01f;
			component.isKinematic = false;
			component.useGravity = true;
			component.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			component.linearVelocity = pointVelocity;
			CannonProjectileScript component2 = transform.GetComponent<CannonProjectileScript>();
			component2.Died += OnProjectileDied;
			component2.ExplosionScalar = _cannon.ExplosionScalar;
			component2.ImpactDamageScalar = _cannon.ImpactDamageScalar;
			bool isTracer = false;
			if (_shotsUntilTracer == 0)
			{
				isTracer = true;
			}
			component2.Initialize(this, _fuseOverride.GetValueOrDefault(_cannon.ProjectileLifetime), isTracer, _cannon.TracerLength, _cannon.TracerColour);
			_projectileInBarrel = transform;
			_projectileInBarrelColliders = components;
			_currentAmmo--;
			if (_cannon.TracerSpacing > -1)
			{
				_shotsUntilTracer = ((_shotsUntilTracer > 0) ? (_shotsUntilTracer - 1) : _cannon.TracerSpacing);
			}
			_barrelTargetPosition = _barrelRecoilPosition;
			_barrelTimeInTargetPosition = 0f;
			base.PartScript.Body.RigidBody.AddForceAtPosition(-base.transform.forward * (ProjectileVelocity / 2.23694f * component.mass * 0.02f * Mathf.Clamp(_cannon.RecoilForce, 0f, 100000f)), _projectileSpawnPoint.position, ForceMode.Impulse);
			if (_cameraProjectile != null && _cameraProjectile.IsDead)
			{
				_cameraProjectile.Destroy();
			}
			_cameraProjectile = component2;
			_cameraVantage.TransformToTrack = transform;
		}

		void IWeapon.Fire(TrackedTarget trackedTarget)
		{
			if (CheckLastProjectileClearOfBarrel())
			{
				Fire();
			}
		}

		public void Initialize(CannonData cannon)
		{
			_cannon = cannon;
			_base = Utilities.FindFirstGameObjectMyselfOrChildren("Base", base.gameObject).transform;
			_barrelBase = Utilities.FindFirstGameObjectMyselfOrChildren("BarrelBase", _base.gameObject).transform;
			_barrel = Utilities.FindFirstGameObjectMyselfOrChildren("Barrel", _barrelBase.gameObject).transform;
			_barrelReadyPosition = _barrel.localPosition;
			_barrelRecoilPosition = _barrelReadyPosition - _barrelReadyPosition * (2f * _cannon.BarrelRecoil);
			_muzzleBrake = Utilities.FindFirstGameObjectMyselfOrChildren("MuzzleBrake", _barrel.gameObject);
			_muzzleTip = Utilities.FindFirstGameObjectMyselfOrChildren("MuzzleTip", _barrel.gameObject).transform;
			_projectileSpawnPoint = Utilities.FindFirstGameObjectMyselfOrChildren("SpawnPoint", _barrel.gameObject).transform;
			_projectiles = Utilities.FindFirstGameObjectMyselfOrChildren("Projectiles", base.gameObject);
			_projectiles.SetActive(value: false);
			string text = _cannon.AmmoStyle.ToString() + _cannon.AmmoType;
			Rigidbody[] componentsInChildren = _projectiles.GetComponentsInChildren<Rigidbody>(includeInactive: true);
			foreach (Rigidbody rigidbody in componentsInChildren)
			{
				rigidbody.isKinematic = true;
				rigidbody.useGravity = false;
				if (rigidbody.gameObject.name == text)
				{
					_projectilePrefab = rigidbody.gameObject;
				}
			}
			MeshRenderer componentInChildren = _projectilePrefab.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			if (componentInChildren != null)
			{
				PartMaterialScript.RendererMaterialMap rendererMap = base.PartScript.PartMaterialScript.AddRenderer(componentInChildren, excludeFromCombine: true, excludedFromDrag: true);
				base.PartScript.PartMaterialScript.InitializeMaterial(rendererMap);
			}
			_baseCollider = _base.GetComponent<Collider>();
			_barrelBaseCollider = _barrelBase.GetComponent<Collider>();
			_barrelCollider = _barrel.GetComponent<Collider>();
			_muzzleBrakeCollider = _muzzleBrake.GetComponent<Collider>();
			_currentAmmo = _cannon.AmmoCount;
			_particleSystem = _muzzleTip.GetComponentInChildren<ParticleSystem>();
			float num = 5f;
			int num2 = 2500;
			float num3 = (_cannon.Diameter * _cannon.ProjectileVelocity - num) / ((float)num2 - num);
			num3 *= (_cannon.MuzzleBrake ? 0.7f : 1f);
			num3 = Mathf.Lerp(0.2f, 0.8f, Mathf.Clamp01(num3));
			float a = Mathf.Clamp01((_cannon.BarrelLength - 0.5f) / 2f);
			float f = Mathf.Clamp01((_cannon.Diameter - 0.1f) / 1.9f);
			float num4 = Mathf.Lerp(a, Mathf.Pow(f, 0.25f), 0.5f);
			_launchSoundPitch = Mathf.Lerp(0.3f, 2f, 1f - num4);
			_audio = Utilities.FindFirstGameObjectMyselfOrChildren("LaunchSound", base.gameObject).GetComponent<AudioSource>();
			_audio.volume = _cannon.LaunchVolume * num3;
			_audio.pitch = _launchSoundPitch;
			_audio.minDistance = num3 * 100f;
			_audio.maxDistance = num3 * (_cannon.MuzzleBrake ? 7000f : 15000f);
			if (_cannon.TracerSpacing != int.MaxValue)
			{
				_shotsUntilTracer = _cannon.TracerSpacing;
			}
			if (ProjectileVelocity < 250f)
			{
				ParticleSystem.MainModule main = _particleSystem.main;
				main.simulationSpeed -= Mathf.Min(12.5f, (250f - ProjectileVelocity) / 40f);
			}
			_barrelTargetPosition = _barrelReadyPosition;
			UpdateScales();
			SetMuzzleBrakeActive(_cannon.MuzzleBrake);
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			base.InitializePartSyncData(syncData);
			syncData.RegisterValue(new SyncBool
			{
				DeltaWhenOff = 0f,
				DeltaWhenTrue = 1E+09f,
				Serialized = delegate
				{
					_showRemoteMuzzleFlash = false;
				},
				Value = () => _showRemoteMuzzleFlash,
				ValueRead = delegate(bool x)
				{
					if (x)
					{
						PlayMuzzleFlash();
					}
				}
			});
		}

		public void SetMuzzleBrakeActive(bool active)
		{
			_muzzleBrake.SetActive(active);
		}

		public void UpdateScales()
		{
			_projectiles.transform.localScale = new Vector3(_cannon.Diameter, _cannon.Diameter, _cannon.Diameter);
			_base.localScale = new Vector3(_cannon.Diameter, _cannon.Diameter, _cannon.BaseLength);
			_barrelBase.localScale = new Vector3(1f, 1f, 1f / _cannon.BaseLength);
			_barrel.localScale = new Vector3(1f, 1f, _cannon.BarrelLength);
			_muzzleBrake.transform.localScale = new Vector3(1f, 1f, _cannon.Diameter / _cannon.BarrelLength);
			_muzzleTip.localScale = new Vector3(1f, 1f, 1f / _cannon.BarrelLength);
			float num = _cannon.Diameter * 0.5f;
			ParticleSystem.MainModule main = _particleSystem.main;
			main.startSize = 7.5f * Mathf.Pow(_cannon.MuzzleFlashScale, 0.57f);
			if (_cannon.MuzzleFlashSpace == ParticleSystemSimulationSpace.Local)
			{
				main.simulationSpace = ParticleSystemSimulationSpace.Custom;
				main.customSimulationSpace = base.transform;
				main.emitterVelocityMode = ParticleSystemEmitterVelocityMode.Transform;
			}
			else
			{
				main.simulationSpace = ParticleSystemSimulationSpace.World;
				main.emitterVelocityMode = ParticleSystemEmitterVelocityMode.Rigidbody;
			}
			ParticleSystem.ShapeModule shape = _particleSystem.shape;
			shape.radius = num / 2f;
			ParticleSystem.NoiseModule noise = _particleSystem.noise;
			noise.frequency = 1.4f / _cannon.MuzzleFlashScale;
			noise.strengthMultiplier = 0.5f * Mathf.Pow(_cannon.MuzzleFlashScale, 0.57f);
			ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetime = _particleSystem.limitVelocityOverLifetime;
			limitVelocityOverLifetime.drag = 0.8f + 0.1f / Mathf.Pow(_cannon.MuzzleFlashScale, 0.57f);
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = _particleSystem.velocityOverLifetime;
			velocityOverLifetime.xMultiplier = _cannon.MuzzleFlashScale * 10f;
			velocityOverLifetime.yMultiplier = _cannon.MuzzleFlashScale * 10f;
			velocityOverLifetime.zMultiplier = _cannon.MuzzleFlashScale * 10f;
			ParticleSystem.SizeOverLifetimeModule sizeOverLifetime = _particleSystem.sizeOverLifetime;
			ParticleSystem.MinMaxCurve size = sizeOverLifetime.size;
			Keyframe key = size.curve.keys[0];
			Keyframe key2 = size.curve.keys[1];
			key.value = num / 2f;
			key2.value = key.value;
			size.curve.MoveKey(0, key);
			size.curve.MoveKey(1, key2);
			sizeOverLifetime.size = size;
		}

		protected virtual void OnDestroy()
		{
			if (CameraManagerScript.Instance != null)
			{
				CameraManagerScript.Instance.SwitchedToNewViewMode -= OnSwitchedToNewViewMode;
			}
			this.Destroyed?.Invoke(this, EventArgs.Empty);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocal);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = ActivateFunc();
			if (_active != flag)
			{
				_active = flag;
				frame.Craft.TargetingSystem.OnQueueUpdateWeaponsList();
			}
			if (_fuseFunc != null)
			{
				float num = _fuseFunc();
				if (num < 0f)
				{
					_fuseOverride = null;
				}
				else
				{
					_fuseOverride = num;
				}
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_cameraVantage = base.PartScript.GetComponent<CameraVantageScript>();
			_cameraVantage.UseGravityAsUp = true;
			if (loadContext == CraftLoadContext.Flight)
			{
				CameraManagerScript.Instance.SwitchedToNewViewMode += OnSwitchedToNewViewMode;
				if (!string.IsNullOrWhiteSpace(_cannon.FuseInput))
				{
					_fuseFunc = base.PartScript.Aircraft.Controls.GetAxisGetter(_cannon.FuseInput, -1f, base.PartScript, returnNull: true);
				}
			}
			return UniTask.CompletedTask;
		}

		private void OnProjectileDied(CannonProjectileScript sender)
		{
			if (sender != _cameraProjectile)
			{
				sender.Destroy();
			}
			else if (CameraManagerScript.Instance.Controller.CameraVantage == _cameraVantage)
			{
				base.PartScript.Aircraft.MoveWindAudio(base.transform);
			}
		}

		private void OnSwitchedToNewViewMode(CameraController oldController, CameraController newController)
		{
			bool num = oldController != null && oldController.CameraVantage == _cameraVantage;
			bool flag = _cameraProjectile != null && _cameraProjectile.IsDead;
			if (num && flag)
			{
				_cameraVantage.TransformToTrack = base.transform;
				_cameraProjectile.Destroy();
				_cameraProjectile = null;
				CameraManagerScript.Instance.SwitchToCamera(oldController);
			}
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = CheckLastProjectileClearOfBarrel(includeMuzzleBrake: false);
			if (flag && !_projectileClearedLastFrame)
			{
				_showRemoteMuzzleFlash = true;
				PlayMuzzleFlash();
			}
			if (Utilities.CompareVector3s(_barrel.localPosition, _barrelTargetPosition))
			{
				_barrelTimeInTargetPosition += frame.DeltaTime;
			}
			if (_cannon.BarrelRecoil > 0f)
			{
				float num = _barrelReadyPosition.z * 2f / MaxRecoilTime;
				float num2 = Time.deltaTime * 3f * _cannon.BarrelRecoil;
				bool flag2 = false;
				if (Utilities.CompareVector3s(_barrelTargetPosition, _barrelRecoilPosition))
				{
					num2 *= 3f;
					flag2 = true;
				}
				_barrel.localPosition = Vector3.MoveTowards(_barrel.localPosition, _barrelTargetPosition, num * num2);
				if (flag2 && _barrelTimeInTargetPosition >= MaxRecoilTime * 0.25f)
				{
					_barrelTargetPosition = _barrelReadyPosition;
					_barrelTimeInTargetPosition = 0f;
				}
			}
			_projectileClearedLastFrame = flag;
			_audio.pitch = _launchSoundPitch;
		}

		private void PlayMuzzleFlash()
		{
			_particleSystem.Play();
			if (_audio.isPlaying)
			{
				if (_audioAlt == null && _audio.time > 0.4f)
				{
					_audio.timeSamples = 0;
					return;
				}
				if (_audioAlt == null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(_audio.gameObject);
					gameObject.name = "LaunchSoundAlt";
					gameObject.transform.parent = _audio.transform.parent;
					_audioAlt = gameObject.GetComponent<AudioSource>();
				}
				if (_audioAlt.isPlaying)
				{
					if (_audio.timeSamples > _audioAlt.timeSamples)
					{
						_audio.timeSamples = 0;
					}
					else
					{
						_audioAlt.timeSamples = 0;
					}
				}
				else
				{
					_audioAlt.Play();
				}
			}
			else
			{
				_audio.Play();
			}
		}
	}
}
