using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class CannonProjectileScript : MonoBehaviour
	{
		public delegate void ProjectileDestroyedHandler(CannonProjectileScript sender);

		private CannonScript _cannonScript;

		private float _flyTime;

		private bool _hasExploded;

		[SerializeField]
		private float _impactDetonationForce = 5f;

		[SerializeField]
		private bool _isExplosive = true;

		private ParticleSystem _particleSystem;

		private Vector3 _previousFrameVelocity;

		private Rigidbody _rigidBody;

		private CannonTracerScript _tracer;

		[SerializeField]
		private bool _weatherVanes = true;

		public float ExplosionScalar { get; set; } = 1f;

		public bool HasExploded => _hasExploded;

		public float ImpactDamageScalar { get; set; } = 1f;

		public bool IsDead { get; private set; }

		public bool IsTracer { get; set; }

		public AircraftScript Owner { get; set; }

		public Rigidbody Rigidbody => _rigidBody;

		public float SelfDestructTimer { get; set; } = 60f;

		public event ProjectileDestroyedHandler Died;

		public void Destroy()
		{
			UnparentTracer();
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void Explode(Vector3? blastDirection, ExplosiveWeaponImpactType impactType = ExplosiveWeaponImpactType.Air)
		{
			if (!_hasExploded)
			{
				_hasExploded = true;
				Vector3 normalized = _previousFrameVelocity.normalized;
				float num = 25f * ExplosionScalar;
				if (!_isExplosive)
				{
					num = 0.5f;
				}
				float explosionScale = Mathf.Pow(num * ((base.transform.localScale.x + base.transform.localScale.z) / 2f), 0.6f);
				FlightSceneScript.Instance.CreateExplosion("GeneralExplosion", base.transform.position, explosionScale, blastDirection, Owner.NetworkAircraft?.PlayerId, normalized, impactType);
				UnparentTracer();
				base.gameObject.SetActive(value: false);
				IsDead = true;
				this.Died?.Invoke(this);
			}
		}

		public void Initialize(CannonScript cannonScript, float projectileLifetime, bool isTracer, float tracerLength, Color tracerColour)
		{
			_cannonScript = cannonScript;
			Owner = cannonScript.PartScript.Aircraft;
			SelfDestructTimer = projectileLifetime;
			IsTracer = isTracer;
			_previousFrameVelocity = Vector3.zero;
			_rigidBody = GetComponent<Rigidbody>();
			_tracer = GetComponentInChildren<CannonTracerScript>(includeInactive: true);
			if (IsTracer && _tracer != null)
			{
				_tracer.Initialize(tracerLength, tracerColour, (base.transform.localScale.x + base.transform.localScale.y) / 2f);
				_tracer.gameObject.SetActive(value: true);
			}
			_cannonScript.Destroyed += OnCannonDestroyed;
		}

		protected virtual void FixedUpdate()
		{
			if (PauseManager.Paused || _hasExploded)
			{
				return;
			}
			_previousFrameVelocity = _rigidBody.linearVelocity;
			if (_weatherVanes)
			{
				_rigidBody.AddTorque(Vector3.Cross(base.transform.forward, _rigidBody.linearVelocity) / 100f * _rigidBody.mass, ForceMode.Force);
			}
			_flyTime += Time.fixedDeltaTime;
			if (_flyTime > SelfDestructTimer)
			{
				if (_isExplosive)
				{
					Explode(null);
				}
				else
				{
					IsDead = true;
					base.gameObject.SetActive(value: false);
					this.Died?.Invoke(this);
				}
			}
			if (GameWorld.Instance.FloatingOriginSeaLevel.HasValue && base.transform.position.y < GameWorld.Instance.FloatingOriginSeaLevel - 100f)
			{
				IsDead = true;
				base.gameObject.SetActive(value: false);
				this.Died?.Invoke(this);
				base.transform.position = new Vector3(base.transform.position.x, GameWorld.Instance.FloatingOriginSeaLevel.Value, base.transform.position.z);
			}
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			for (int i = 0; i < collision.contacts.Length; i++)
			{
				float num = Mathf.Abs(Vector3.Dot(collision.contacts[i].normal, collision.relativeVelocity));
				Rigidbody attachedRigidbody = collision.contacts[i].otherCollider.attachedRigidbody;
				float mass = _rigidBody.mass;
				if (attachedRigidbody != null && attachedRigidbody.mass < mass)
				{
					num *= attachedRigidbody.mass / mass;
				}
				if (!(num >= _impactDetonationForce))
				{
					continue;
				}
				ExplosiveWeaponImpactType impactType = collision.collider.gameObject.layer switch
				{
					20 => ExplosiveWeaponImpactType.Ground, 
					23 => ExplosiveWeaponImpactType.Boat, 
					4 => ExplosiveWeaponImpactType.Water, 
					11 => ExplosiveWeaponImpactType.Structure, 
					_ => ExplosiveWeaponImpactType.Air, 
				};
				float num2 = CalculateDamage(num);
				if (!FlightSceneScript.IsPeacefulMode)
				{
					IDamageableObject componentInParent = collision.contacts[i].otherCollider.gameObject.GetComponentInParent<IDamageableObject>();
					if (componentInParent != null)
					{
						componentInParent.OnDamageReceived(DamageType.CannonProjectile, num2, Owner?.NetworkAircraft?.PlayerId, collision.contacts[i].point, collision.contacts[i].normal);
					}
					else
					{
						PartScript componentInParent2 = collision.contacts[i].otherCollider.GetComponentInParent<PartScript>();
						if (componentInParent2 != null)
						{
							Vector3 point = collision.contacts[i].point;
							Vector3 normal = collision.contacts[i].normal;
							if (componentInParent2.Aircraft.RemoteAircraft)
							{
								componentInParent2.Aircraft.NetworkAircraft.DamagePart(Owner?.NetworkAircraft?.PlayerId, componentInParent2, num2, point, normal);
							}
							else
							{
								componentInParent2.OnDamaged(null, num2, point, normal);
							}
						}
					}
				}
				if (_isExplosive || num2 > _impactDetonationForce * 5f)
				{
					Explode(collision.contacts[i].normal, impactType);
				}
				break;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_cannonScript != null)
			{
				_cannonScript.Destroyed -= OnCannonDestroyed;
			}
		}

		private float CalculateDamage(float impactForce)
		{
			return 0.3f * impactForce * ImpactDamageScalar;
		}

		private void OnCannonDestroyed(object sender, EventArgs e)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void UnparentTracer(bool enableAutodestruct = true)
		{
			if (IsTracer && _tracer != null)
			{
				_tracer.transform.SetParent(null);
				_tracer.AutoDestruct = true;
			}
		}
	}
}
