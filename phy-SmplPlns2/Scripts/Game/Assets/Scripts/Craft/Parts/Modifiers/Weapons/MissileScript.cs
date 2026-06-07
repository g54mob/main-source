using System;
using System.Collections;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Multiplayer;
using FishNet.Serializing;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class MissileScript : ExplosiveWeaponScriptBase<MissileData>, IMissile, IWeapon, ITargetLockSource, IVariableOutput
	{
		public class FrameStats
		{
			public Vector3 AdjustedTargetAngles { get; set; }

			public Vector3 LocalToAdjustedTarget { get; set; }

			public Vector3 LocalToLeadTarget { get; set; }

			public Vector3 LocalVelocity { get; set; }

			public float PredictedTimeToTarget { get; set; }

			public float Speed { get; set; }

			public Vector3 ToLeadTarget { get; set; }

			public Vector3 ToTarget { get; set; }

			public float ToTargetDistance { get; set; }

			public Vector2 VelocityToTargetAngles { get; set; }
		}

		private static class MessageTypes
		{
			public const byte StartEngineEffects = 1;

			public const byte StopEngineEffects = 2;
		}

		[SerializeField]
		protected Transform _centerOfThrust;

		[SerializeField]
		protected ParticleSystem _engineFireParticles;

		[SerializeField]
		protected ParticleSystem _engineSmokeParticles;

		private const float LoftRangeMax = 15000f;

		private const float LoftRangeMin = 2500f;

		private const float LoftTerminalPhaseDistance = 2000f;

		private const float MaxLoftAltitudeGain = 10000f;

		private AudioSource _audio;

		private float _audioVolume;

		private PartDamageEffect _damageEffect;

		private bool _engineEffectsPlaying;

		private ParticleSystem.EmissionModule _engineSmokeParticlesEmission;

		private float _killCamCooldown;

		private float _killCamTime;

		private bool _lofting;

		private float _loftingInitialLaunchAsl;

		private float _loftingInitialTargetDistance;

		private IMissileFlightPhysics _missilePhysics;

		private TargetingStyle _targetingStyle;

		public override WeaponFunction Function => base.Modifier.Function;

		public override bool IsArmed
		{
			get
			{
				if (!base.PartScript.Aircraft.DisableMissiles)
				{
					return base.IsArmed;
				}
				return false;
			}
		}

		public bool IsLocked { get; private set; }

		public bool LaunchedViaDetacher { get; set; }

		public float MaxRange => base.Modifier.MaxRange;

		public float MaxTargetingAngle => base.Modifier.MaxTargetingAngle;

		public float MinRange => base.Modifier.MinRange;

		public virtual bool OutOfFuel { get; protected set; }

		FlightScenePlayer ITargetLockSource.Player => base.PartScript.Aircraft.Player;

		public IMissileSeeker Seeker { get; private set; }

		public override TargetingStyle TargetingStyle => _targetingStyle;

		public Transform TargetingTransform
		{
			get
			{
				if (base.Modifier.Seeker == SeekerType.Unguided || base.Modifier.Seeker == SeekerType.SemiActiveRadar)
				{
					return null;
				}
				return base.transform;
			}
		}

		ushort ITargetLockSource.TeamId => base.PartScript.Aircraft.Player?.TeamId ?? 0;

		public override WeaponType Type => WeaponType.Missile;

		protected float IgnitionTimer { get; private set; }

		protected FrameStats PStats { get; private set; }

		protected bool StartedDetached { get; set; }

		protected FrameStats Stats { get; private set; }

		protected float TimeSinceLaunch { get; private set; }

		[VariableOutput("Fired")]
		private float VariableFired
		{
			get
			{
				if (!Fired)
				{
					return 0f;
				}
				return 1f;
			}
		}

		public event EventHandler<MissileExplodedEventArgs> Exploded;

		public MissileScript()
			: base("MissileExplosion")
		{
		}

		public override void OnDamaged(float damage, Vector3 position, Vector3 direction)
		{
			base.OnDamaged(damage, position, direction);
			if (Fired && damage > 10f)
			{
				Detonate(Vector3.up);
			}
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			float value = UnityEngine.Random.value;
			if (value < 0.05f)
			{
				Detonate(Vector3.up);
			}
			else if (value < 0.15f && _damageEffect == null)
			{
				_damageEffect = base.PartScript.Aircraft.DamageEffects.CreateFireSmall(base.PartScript, null);
				_damageEffect.RequiresFuel = false;
				StartCoroutine(DelayedExplosionCoroutine());
			}
			else if (value < 0.4f && !base.IsDamaged)
			{
				base.IsDamaged = true;
			}
			else
			{
				base.Modifier.MaxFuelTime *= 0.05f;
			}
		}

		public override void OnEnterWater()
		{
			base.OnEnterWater();
			if (!base.Modifier.Waterproof && !base.PartScript.Aircraft.RemoteAircraft)
			{
				OnFuelExhausted();
			}
		}

		public override void OnReceiveNetworkMessage(byte messageType, PooledReader reader)
		{
			base.OnReceiveNetworkMessage(messageType, reader);
			switch (messageType)
			{
			case 1:
				StartEngineEffectsLocal();
				break;
			case 2:
				StopEngineEffectsLocal();
				break;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			Stats = new FrameStats();
			PStats = new FrameStats();
			_engineSmokeParticlesEmission = _engineSmokeParticles.emission;
		}

		protected virtual bool CheckProximityDetonation()
		{
			if (Stats.ToTargetDistance <= base.Modifier.ProximityDetonationRangeMin || (Stats.ToTargetDistance < base.Modifier.ProximityDetonationRangeMax && Stats.ToTargetDistance > PStats.ToTargetDistance))
			{
				return true;
			}
			return false;
		}

		protected virtual void OnDrawGizmos()
		{
			if (CurrentTarget != null && !CurrentTarget.Target.IsDead)
			{
				Vector3 position = _centerOfThrust.position;
				Func<Vector3, Vector3> func = (Vector3 x) => _centerOfThrust.TransformVector(x);
				Gizmos.color = Color.black;
				Gizmos.DrawLine(position, CurrentTarget.Target.Position);
				Gizmos.color = Color.gray;
				Gizmos.DrawRay(position, Stats.ToLeadTarget);
				Gizmos.color = Color.blue;
				Gizmos.DrawRay(position, func(Stats.LocalVelocity));
				Gizmos.color = Color.yellow;
				Gizmos.DrawRay(position, _centerOfThrust.forward * Stats.ToLeadTarget.magnitude);
				Gizmos.color = Color.green;
				Gizmos.DrawRay(position, func(Stats.LocalToAdjustedTarget));
			}
		}

		protected override void OnExplode(Rigidbody responsibleBody, Vector3? impactDirection, Vector3 blastDirection, ExplosiveWeaponImpactType impactType, ITarget target)
		{
			if (target is PlayerTarget playerTarget)
			{
				playerTarget.Player.GetNetworkAircraft().CreateTargetedExplosion(base.ExplosionPrefabName, base.transform.position, base.Modifier.ExplosionScale, blastDirection, base.PartScript.Aircraft, responsibleBody, impactDirection, impactType);
			}
			else
			{
				FlightSceneScript.Instance.CreateExplosion(base.ExplosionPrefabName, base.transform.position, base.Modifier.ExplosionScale, blastDirection, base.PartScript.Aircraft.NetworkAircraft?.PlayerId, impactDirection, impactType);
			}
			this.Exploded?.Invoke(this, new MissileExplodedEventArgs(this, blastDirection, impactType));
		}

		protected override void OnFire()
		{
			if (base.PartScript.Aircraft.RemoteAircraft)
			{
				return;
			}
			if (!Launched)
			{
				DisconnectPart();
			}
			Fired = true;
			if (base.PartScript.Body.RigidBody != null)
			{
				base.PartScript.Body.RigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			}
			IgnitionTimer = base.Modifier.IgnitionDelay;
			if (!OutOfFuel && IgnitionTimer <= 0f)
			{
				StartEngineEffects();
			}
			Vector3 toTarget = Vector3.zero;
			if (CurrentTarget != null)
			{
				toTarget = CurrentTarget.Target.Position - base.PartScript.Body.RigidBody.position;
				float magnitude = toTarget.magnitude;
				if (magnitude > 2500f && base.Modifier.LoftPercentage > 0f)
				{
					_lofting = true;
					_loftingInitialLaunchAsl = base.transform.position.y - GameWorld.Instance.FloatingOriginSeaLevel.Value;
					_loftingInitialTargetDistance = magnitude;
				}
			}
			_missilePhysics.OnFire(toTarget);
			base.PartScript.Aircraft.TargetingSystem.OnMissileFired(this, CurrentTarget?.Target);
		}

		protected override void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			base.OnFixedUpdate(in frame);
			if (frame.IsRemoteCraft || !Launched || Detonated)
			{
				return;
			}
			if (!Fired && IsArmed && LaunchedViaDetacher && !StartedDetached && base.PartScript.Body.Joints.Count == 0)
			{
				TrackedTarget currentTrackedTarget = frame.Craft.TargetingSystem.CurrentTrackedTarget;
				Fire((currentTrackedTarget != null && currentTrackedTarget.IsLocked) ? currentTrackedTarget : null);
			}
			if (IgnitionTimer > 0f)
			{
				IgnitionTimer -= frame.DeltaTime;
				if (IgnitionTimer < 0f)
				{
					StartEngineEffects();
				}
				return;
			}
			TimeSinceLaunch += frame.DeltaTime;
			float num = base.Modifier.MaxFuelTime - TimeSinceLaunch;
			if (num < 1f && _audio != null)
			{
				_audio.volume = Mathf.Lerp(_audioVolume, 0f, 1f - num);
			}
			if (num < 0f)
			{
				OnFuelExhausted();
			}
			IRigidBody rigidBody = base.PartScript.Body.RigidBody;
			float magnitude = rigidBody.velocity.magnitude;
			if (_engineSmokeParticlesEmission.rateOverTime.constantMax != 0f)
			{
				bool flag = (CameraManagerScript.Instance.transform.position - base.transform.position).sqrMagnitude < 350000f;
				_engineSmokeParticlesEmission.rateOverTime = new ParticleSystem.MinMaxCurve(Mathf.Max(200f, magnitude) / (flag ? 1f : 2f));
			}
			bool flag2 = Seeker.MaintainLock();
			if (IsLocked != flag2)
			{
				IsLocked = flag2;
				if (!flag2 && base.PartScript.Aircraft.IsPrimaryLocalPlayer)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage("Target broke lock on " + base.PartScript.Part.Name);
				}
			}
			if (IsLocked)
			{
				UpdateStats(magnitude, CurrentTarget);
				if (CheckProximityDetonation())
				{
					Detonate(Vector3.zero, CurrentTarget.Target);
				}
				else
				{
					CameraManagerScript instance = CameraManagerScript.Instance;
					if (base.Modifier.KillCam && Stats.PredictedTimeToTarget < 0.25f && _killCamCooldown <= 0.001f && !instance.IsKillCam)
					{
						instance.EnterKillCam(base.PartScript);
						_killCamTime = 0f;
						_killCamCooldown = 5f;
					}
				}
			}
			_missilePhysics.UpdatePhysics(IsLocked, rigidBody.PhysxRigidBody, Stats, PStats, frame.DeltaTime);
		}

		protected virtual void OnFuelExhausted()
		{
			OutOfFuel = true;
			StopEngineEffects();
		}

		protected override void OnPreExplode()
		{
			base.OnPreExplode();
			StopEngineEffects();
			if (base.Modifier.KillCam && CameraManagerScript.Instance.IsKillCam)
			{
				CameraManagerScript.Instance.ExitKillCam(1.5f);
			}
		}

		protected override void OnStart(in CraftUpdateFrameData frame)
		{
			base.OnStart(in frame);
			if (base.Modifier.Seeker == SeekerType.ActiveRadar || base.Modifier.Seeker == SeekerType.SemiActiveRadar)
			{
				Seeker = new RadarSeeker(this);
			}
			else if (base.Modifier.Seeker == SeekerType.Infrared)
			{
				Seeker = new IRSeeker(this);
			}
			else if (base.Modifier.Seeker == SeekerType.Laser)
			{
				Seeker = new LaserSeeker(this);
			}
			else if (base.Modifier.Seeker == SeekerType.AntiRadiation)
			{
				Seeker = new AntiRadiationSeeker(this);
			}
			else if (base.Modifier.Seeker == SeekerType.Unguided)
			{
				Seeker = new UnguidedSeeker(this);
			}
			Transform parent = _engineSmokeParticles.transform.parent;
			ProceduralMissileData modifier = base.PartScript.Part.GetModifier<ProceduralMissileData>();
			if (modifier != null)
			{
				_targetingStyle = modifier.Seeker.Style;
				parent.transform.localPosition = new Vector3(0f, 0f, (0f - modifier.Length) / 2f);
			}
			else
			{
				_targetingStyle = base.Modifier.TargetingStyle;
			}
			if (base.Modifier.SmokeOpacity != 1f)
			{
				SetParticleSystemOpacity(_engineSmokeParticles, base.Modifier.SmokeOpacity);
				_engineSmokeParticles.transform.localScale *= base.Modifier.SmokeScale;
			}
			_missilePhysics = new MissileFlightPhysicsLegacy(this, _centerOfThrust);
			StartedDetached = !base.PartScript.ConnectedToMainCockpit;
		}

		protected override void OnUpdate(in CraftUpdateFrameData frame)
		{
			base.OnUpdate(in frame);
			if (Launched)
			{
				CameraManagerScript instance = CameraManagerScript.Instance;
				bool isKillCam = instance.IsKillCam;
				if (isKillCam)
				{
					_killCamTime += frame.DeltaTime;
				}
				else
				{
					_killCamCooldown -= frame.DeltaTime;
				}
				if (isKillCam && _killCamTime >= 0.5f)
				{
					instance.ExitKillCam();
				}
			}
		}

		protected virtual void UpdateStats(float speed, TrackedTarget target)
		{
			FrameStats pStats = PStats;
			PStats = Stats;
			Stats = pStats;
			Stats.Speed = speed;
			if (target != null)
			{
				IRigidBody rigidBody = base.PartScript.Body.RigidBody;
				Utilities.LeadPositionResult targetLeadPrediction = Utilities.GetTargetLeadPrediction(base.transform.position, rigidBody.velocity, target.Target.Position, target.Target.Velocity, 1f);
				Stats.PredictedTimeToTarget = targetLeadPrediction.TimeToTarget;
				Vector3 vector = targetLeadPrediction.Position;
				Stats.ToTarget = target.Target.Position - _centerOfThrust.position;
				Stats.ToTargetDistance = Stats.ToTarget.magnitude;
				if (_lofting)
				{
					float t = Mathf.InverseLerp(_loftingInitialTargetDistance, 2000f, Stats.ToTargetDistance);
					float t2 = Mathf.InverseLerp(2500f, 15000f, _loftingInitialTargetDistance);
					float num = Mathf.Lerp(Mathf.Lerp(0f, 10000f, t2) * base.Modifier.LoftPercentage, 0f, t);
					float num2 = _loftingInitialLaunchAsl + GameWorld.Instance.FloatingOriginSeaLevel.Value;
					Vector3 a = new Vector3(vector.x, num2 + num, vector.z);
					a.y = Mathf.Max(a.y, vector.y);
					vector = Vector3.Lerp(a, vector, t);
				}
				Stats.ToLeadTarget = vector - _centerOfThrust.position;
				Stats.LocalToLeadTarget = _centerOfThrust.InverseTransformVector(Stats.ToLeadTarget);
				Stats.LocalVelocity = _centerOfThrust.InverseTransformVector(rigidBody.velocity);
				Stats.VelocityToTargetAngles = GetAngles(Stats.LocalVelocity, Stats.LocalToLeadTarget);
				Vector2 vector2 = (Stats.VelocityToTargetAngles * 0.5f).Clamp(-30f, 30f);
				Stats.LocalToAdjustedTarget = Quaternion.Euler(0f - vector2.y, vector2.x, 0f) * Stats.LocalToLeadTarget;
				Stats.AdjustedTargetAngles = GetAnglesFromForward(Stats.LocalToAdjustedTarget) * -1f;
				Stats.AdjustedTargetAngles = new Vector3(Stats.AdjustedTargetAngles.y, 0f - Stats.AdjustedTargetAngles.x, Stats.AdjustedTargetAngles.z);
				Stats.AdjustedTargetAngles = rigidBody.InverseTransformVector(_centerOfThrust.TransformVector(Stats.AdjustedTargetAngles));
			}
		}

		private static void SetParticleSystemOpacity(ParticleSystem ps, float alphaMultiplier)
		{
			ParticleSystem.MainModule main = ps.main;
			ParticleSystem.MinMaxGradient startColor = main.startColor;
			switch (startColor.mode)
			{
			case ParticleSystemGradientMode.Color:
			{
				Color color = startColor.color;
				color.a = Mathf.Clamp01(color.a * alphaMultiplier);
				startColor = new ParticleSystem.MinMaxGradient(color);
				break;
			}
			case ParticleSystemGradientMode.Gradient:
			{
				Gradient gradient = startColor.gradient;
				GradientAlphaKey[] alphaKeys3 = gradient.alphaKeys;
				for (int k = 0; k < alphaKeys3.Length; k++)
				{
					alphaKeys3[k].alpha = Mathf.Clamp01(alphaKeys3[k].alpha * alphaMultiplier);
				}
				gradient.SetKeys(gradient.colorKeys, alphaKeys3);
				startColor = new ParticleSystem.MinMaxGradient(gradient);
				break;
			}
			case ParticleSystemGradientMode.TwoColors:
			{
				Color colorMin = startColor.colorMin;
				Color colorMax = startColor.colorMax;
				colorMin.a = Mathf.Clamp01(colorMin.a * alphaMultiplier);
				colorMax.a = Mathf.Clamp01(colorMax.a * alphaMultiplier);
				startColor = new ParticleSystem.MinMaxGradient(colorMin, colorMax);
				break;
			}
			case ParticleSystemGradientMode.TwoGradients:
			{
				Gradient gradientMin = startColor.gradientMin;
				Gradient gradientMax = startColor.gradientMax;
				GradientAlphaKey[] alphaKeys = gradientMin.alphaKeys;
				for (int i = 0; i < alphaKeys.Length; i++)
				{
					alphaKeys[i].alpha = Mathf.Clamp01(alphaKeys[i].alpha * alphaMultiplier);
				}
				gradientMin.SetKeys(gradientMin.colorKeys, alphaKeys);
				GradientAlphaKey[] alphaKeys2 = gradientMax.alphaKeys;
				for (int j = 0; j < alphaKeys2.Length; j++)
				{
					alphaKeys2[j].alpha = Mathf.Clamp01(alphaKeys2[j].alpha * alphaMultiplier);
				}
				gradientMax.SetKeys(gradientMax.colorKeys, alphaKeys2);
				startColor = new ParticleSystem.MinMaxGradient(gradientMin, gradientMax);
				break;
			}
			}
			main.startColor = startColor;
		}

		private IEnumerator DelayedExplosionCoroutine()
		{
			yield return new WaitForSeconds(5f + 15f * UnityEngine.Random.value);
			_damageEffect.DestroyEffect();
			_damageEffect = null;
			Detonate(Vector3.up);
		}

		private void StartEngineEffects()
		{
			if (!_engineEffectsPlaying)
			{
				StartEngineEffectsLocal();
				base.PartScript.Aircraft.NetworkAircraft.SendPartNetworkMessage(1, base.PartScript.Part, delegate
				{
				});
			}
		}

		private void StartEngineEffectsLocal()
		{
			if (!_engineEffectsPlaying)
			{
				_engineEffectsPlaying = true;
				_audio = _engineFireParticles.GetComponent<AudioSource>();
				if (_audio != null)
				{
					_audioVolume = _audio.volume;
				}
				_engineFireParticles.gameObject.SetActive(value: true);
				_engineFireParticles.Play();
				_engineSmokeParticles.Play();
				if (_engineSmokeParticlesEmission.rateOverTime.constantMax != 0f)
				{
					ParticleSystem.MainModule main = _engineSmokeParticles.main;
					main.maxParticles = (int)(base.Modifier.MaxSpeed * main.duration * 2f);
				}
			}
		}

		private void StopEngineEffects()
		{
			if (_engineEffectsPlaying)
			{
				StopEngineEffectsLocal();
				base.PartScript.Aircraft.NetworkAircraft.SendPartNetworkMessage(2, base.PartScript.Part, delegate
				{
				});
			}
		}

		private void StopEngineEffectsLocal()
		{
			if (_engineEffectsPlaying)
			{
				_engineEffectsPlaying = false;
				_engineFireParticles.Stop();
				_engineFireParticles.gameObject.SetActive(value: false);
				_engineSmokeParticlesEmission.rateOverTime = 0f;
				_engineSmokeParticlesEmission.rateOverDistance = 0f;
				_engineSmokeParticles.transform.parent = null;
				UnityEngine.Object.Destroy(_engineSmokeParticles.gameObject, 15f);
			}
		}
	}
}
