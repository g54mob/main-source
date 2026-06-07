using System;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Bullets;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class AntiAircraftMissileScript : MonoBehaviour, IBulletImpact, ITargetLockSource
	{
		public float AltitudeGainTime = 1f;

		public float LeadAccuracy = 0.5f;

		public float MaxSpeed = 400f;

		public float MaxTurningPerSecondDeg = 45f;

		private float _closestDistance = float.MaxValue;

		private Collider _collider;

		private float _lastBreakLockChance;

		private float _lifeTime;

		private NetworkBodyScript _networkBody;

		private Transform _orphanedParticleSystemTransform;

		private Rigidbody _rigidBody;

		private SignatureType _signatureType;

		[SerializeField]
		private ParticleSystem _smokeParticleSystem;

		public bool DieWhenFallingBehind { get; set; } = true;

		FlightScenePlayer ITargetLockSource.Player => null;

		public TrackedTarget Target { get; set; }

		ushort ITargetLockSource.TeamId => 0;

		public void Fire(TrackedTarget target, Transform orphanedParticleSystemTransform)
		{
			Target = target;
			_orphanedParticleSystemTransform = orphanedParticleSystemTransform;
		}

		public bool OnBulletImpact(in Bullet bullet, BulletData bulletData)
		{
			if (_networkBody.IsRemote)
			{
				return true;
			}
			Debug.Log("Bullet hit missile");
			DestroyMissileKeepParticleEffects(base.transform.position);
			return true;
		}

		public virtual void OnEnterWater()
		{
			if (!_networkBody.IsRemote)
			{
				DestroyMissileKeepParticleEffects(new Vector3(base.transform.position.x, 2f, base.transform.position.z));
			}
		}

		protected virtual void Awake()
		{
			_collider = GetComponent<Collider>();
			_collider.enabled = false;
			_rigidBody = GetComponent<Rigidbody>();
			_networkBody = GetComponent<NetworkBodyScript>();
		}

		protected virtual void FixedUpdate()
		{
			if (_networkBody.IsRemote || PauseManager.Paused)
			{
				return;
			}
			_lifeTime += Time.deltaTime;
			if (_lifeTime > 0.5f)
			{
				_collider.enabled = true;
			}
			if (Target != null && !Target.Target.IsDead)
			{
				float num = 1f;
				float num2 = 0f;
				float breakLockProbability = Target.Target.GetBreakLockProbability(_signatureType);
				if (breakLockProbability > _lastBreakLockChance)
				{
					num -= breakLockProbability;
					num2 = UnityEngine.Random.Range(0.1f, 1f);
				}
				if (num < num2)
				{
					Target = null;
				}
				else
				{
					_lastBreakLockChance = breakLockProbability;
				}
			}
			if (Target != null)
			{
				Vector3 targetPosition;
				if (_lifeTime < AltitudeGainTime)
				{
					targetPosition = Target.Target.Position;
					targetPosition.y += 2500f;
				}
				else
				{
					targetPosition = GetOptimumTargetingPoint(LeadAccuracy);
					float magnitude = (base.transform.position - Target.Target.Position).magnitude;
					if (magnitude < _closestDistance)
					{
						_closestDistance = magnitude;
					}
					if (DieWhenFallingBehind && magnitude > _closestDistance + 500f)
					{
						DestroyMissileKeepParticleEffects(base.transform.position);
					}
				}
				RotateRocketTowardTarget(targetPosition, MathF.PI / 180f * MaxTurningPerSecondDeg);
			}
			_rigidBody.linearVelocity = base.transform.forward * MaxSpeed;
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (!_networkBody.IsRemote)
			{
				Vector3 zero = Vector3.zero;
				ContactPoint[] contacts = collision.contacts;
				foreach (ContactPoint contactPoint in contacts)
				{
					zero += contactPoint.point;
				}
				zero /= (float)collision.contacts.Length;
				if (collision.transform.GetComponent<Terrain>() != null)
				{
					zero.y += 5f;
				}
				NetworkAircraftScript componentInParent = collision.gameObject.GetComponentInParent<NetworkAircraftScript>();
				DestroyMissileKeepParticleEffects(zero, componentInParent);
			}
		}

		protected virtual void Update()
		{
			if (!_networkBody.IsRemote)
			{
				float num = GameWorld.Instance.SeaLevel.GetValueOrDefault() - GameWorld.Instance.FloatingOriginOffset.y;
				if (base.transform.position.y <= num)
				{
					OnEnterWater();
				}
				if (Target != null)
				{
					Target.Target.Alert(locked: true, this, Target);
				}
				if (_lifeTime > 25f)
				{
					DestroyMissileKeepParticleEffects(base.transform.position);
				}
			}
		}

		private void DestroyMissileKeepParticleEffects(Vector3 explosionPosition, INetworkAircraft aircraft = null)
		{
			ParticleSystem.MainModule main = _smokeParticleSystem.main;
			main.loop = false;
			ParticleSystem.EmissionModule emission = _smokeParticleSystem.emission;
			emission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
			_smokeParticleSystem.transform.parent = _orphanedParticleSystemTransform;
			if (aircraft != null)
			{
				aircraft.CreateTargetedExplosion("MissileExplosion", explosionPosition, 4f, Vector3.up, null, null, null, ExplosiveWeaponImpactType.Air);
			}
			else
			{
				FlightSceneScript.Instance.CreateExplosion("MissileExplosion", explosionPosition, 4f, Vector3.up, null, null, ExplosiveWeaponImpactType.Air);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private Vector3 GetOptimumTargetingPoint(float leadAccuracy)
		{
			float num = 0f;
			Vector3 position = Target.Target.Position;
			Vector3 velocity = Target.Target.Velocity;
			Vector3 targetPosition = position;
			for (int i = 0; i < 3; i++)
			{
				num = Utilities.TimeToPosition(base.transform.position, targetPosition, MaxSpeed);
				targetPosition = Utilities.PredictPositionInFuture(position, velocity, num * leadAccuracy);
			}
			return Utilities.PredictPositionInFuture(position, velocity, num * leadAccuracy);
		}

		private void RotateRocketTowardTarget(Vector3 targetPosition, float maxRadPerSecond)
		{
			float maxRadiansDelta = maxRadPerSecond * Time.deltaTime;
			Vector3 normalized = (targetPosition - base.transform.position).normalized;
			Vector3 forward = Vector3.RotateTowards(base.transform.forward, normalized, maxRadiansDelta, 0f);
			base.transform.rotation = Quaternion.LookRotation(forward);
		}

		bool IBulletImpact.OnBulletImpact(in Bullet bullet, BulletData bulletData)
		{
			return OnBulletImpact(in bullet, bulletData);
		}
	}
}
