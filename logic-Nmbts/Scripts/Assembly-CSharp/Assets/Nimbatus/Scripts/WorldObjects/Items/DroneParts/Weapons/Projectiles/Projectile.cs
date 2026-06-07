using System;
using System.Collections;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles
{
	public class Projectile : NimbatusObject
	{
		public string FlyingSound;

		public string HitSound;

		public bool ChangeProjectileColor;

		[ShowIf("ChangeProjectileColor", true)]
		public SpriteRenderer Sprite;

		public bool IgnoreAmmunitionColor;

		protected Ammunition Ammunition;

		protected ProjectileEmitter Emitter;

		protected float Damage;

		protected float LifeTime;

		protected EProjectileCollisionMode CollisionMode;

		private TrailRenderer _trail;

		private ParticleSystem _particleSystem;

		private GameObjectPoolManager<Projectile> _pool;

		private Renderer _renderer;

		private bool _hasExploded;

		private bool _hasCollided;

		protected EProjectileExplosionMode ExplosionMode;

		private FixedJoint _hinge;

		private GameObject _emptyGameObject;

		protected override void Start()
		{
			base.Start();
			if (RuntimeGlobals.WorldController != null && RuntimeGlobals.WorldController.ForeGroundTerrain != null)
			{
				NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(base.transform.position);
				if (data.HasValue && data.Value.Volume > 0.5f)
				{
					StartCoroutine(Explode());
				}
			}
		}

		public virtual void Init(ProjectileEmitter emitter, Ammunition ammunition, float damage, EProjectileCollisionMode collisionMode, float lifetime, EProjectileExplosionMode explosionMode)
		{
			Ammunition = ammunition;
			Damage = damage;
			CollisionMode = collisionMode;
			Emitter = emitter;
			LifeTime = lifetime;
			ExplosionMode = explosionMode;
			_particleSystem = GetComponent<ParticleSystem>();
			_trail = GetComponent<TrailRenderer>();
			_renderer = GetComponent<Renderer>();
		}

		public virtual void Reset()
		{
			CancelInvoke();
			_hasExploded = false;
			_hasCollided = false;
			EnableColliders(true);
			Rigidbody.isKinematic = false;
			Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			if (_renderer != null)
			{
				_renderer.enabled = true;
			}
			if (Sprite != null && ChangeProjectileColor && !IgnoreAmmunitionColor)
			{
				Sprite.color = Ammunition.ColorModifier;
			}
			if (_trail != null)
			{
				if (!IgnoreAmmunitionColor)
				{
					_trail.material.color = Ammunition.ColorModifier;
				}
				_trail.Clear();
			}
			if (_particleSystem != null)
			{
				ParticleSystem.MainModule main = _particleSystem.main;
				if (!IgnoreAmmunitionColor)
				{
					main.startColor = Ammunition.ColorModifier;
				}
			}
			StartSoundLoop(FlyingSound);
			StartCoroutine(Explode(LifeTime * UnityEngine.Random.Range(1f, 1.1f)));
		}

		public void SetPool(GameObjectPoolManager<Projectile> pool)
		{
			_pool = pool;
		}

		public float GetDamage()
		{
			return Damage;
		}

		public void OnCollisionEnter(Collision collision)
		{
			ContactPoint contactPoint = collision.contacts[0];
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
			Vector3 point = contactPoint.point;
			HandleCollision(contactPoint.otherCollider.gameObject, point, rotation, contactPoint.normal);
		}

		public IEnumerator Explode(float timer = 0f)
		{
			if (!_hasExploded)
			{
				if (timer > 0f)
				{
					yield return new WaitForSeconds(timer);
				}
				else
				{
					yield return true;
				}
				_hasExploded = true;
				float diggingStrength = Emitter.DiggingStrength.Value / 5f;
				float value = Emitter.ElementalStrength.Value;
				switch (ExplosionMode)
				{
				case EProjectileExplosionMode.SmallExplosion:
					Ammunition.TriggerExplosion(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, base.transform.position, 5f, Damage, Emitter.Damage.BaseValue, diggingStrength, value, Emitter.Collisionmask);
					break;
				case EProjectileExplosionMode.BigExplosion:
					Ammunition.TriggerBigExplosion(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, base.transform.position, 10, Damage, Emitter.Damage.BaseValue, diggingStrength, value, Emitter.Collisionmask);
					break;
				case EProjectileExplosionMode.SpawnProjectiles:
					StartCoroutine(Emitter.SpawnRandomProjectiles(base.transform.position));
					Ammunition.TriggerExplosion(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, base.transform.position, 5f, 0f, 0f, 0f, 0f, Emitter.Collisionmask);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case EProjectileExplosionMode.NoExplosion:
					break;
				}
				DestroyProjectile();
			}
		}

		public virtual void HandleCollision(GameObject other, Vector3 position, Quaternion rotation, Vector3 normal)
		{
			PlaySound(HitSound);
			float num = Emitter.DiggingStrength.Value / 10f;
			float value = Emitter.ElementalStrength.Value;
			switch (CollisionMode)
			{
			case EProjectileCollisionMode.Destroy:
				Ammunition.TriggerImpact(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, other, position, rotation, Damage, Emitter.Damage.BaseValue, num, value);
				StartCoroutine(Explode());
				break;
			case EProjectileCollisionMode.Stick:
				Ammunition.TriggerImpact(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, other, position, rotation, (ExplosionMode == EProjectileExplosionMode.NoExplosion) ? Damage : 0f, Emitter.Damage.BaseValue, (ExplosionMode == EProjectileExplosionMode.NoExplosion) ? num : 0f, value);
				EnableColliders(false);
				Rigidbody.velocity = Vector3.zero;
				Rigidbody.angularVelocity = Vector3.zero;
				_emptyGameObject = new GameObject();
				_emptyGameObject.transform.parent = other.transform;
				_emptyGameObject.transform.localPosition = position - other.transform.position;
				base.transform.parent = _emptyGameObject.transform;
				Rigidbody.isKinematic = true;
				break;
			case EProjectileCollisionMode.Reflect:
				Ammunition.TriggerImpact(Emitter.ParentObject, (!Emitter.UsedByEnemy) ? EDamageReason.Player : EDamageReason.Enemy, other, position, rotation, (Emitter.WeaponType == EWeaponType.GrenadeLauncher) ? 0f : Damage, Emitter.Damage.BaseValue, (ExplosionMode == EProjectileExplosionMode.NoExplosion) ? num : 0f, value);
				if (Emitter.WeaponType == EWeaponType.GrenadeLauncher && !_hasCollided)
				{
					Rigidbody.velocity *= 0.2f;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			_hasCollided = true;
		}

		internal void StickTo(Rigidbody other, Vector3 position)
		{
			if (_hinge != null)
			{
				UnityEngine.Object.Destroy(_hinge);
			}
			_hinge = base.transform.gameObject.AddComponent<FixedJoint>();
			_hinge.connectedBody = other;
		}

		protected virtual void DestroyProjectile()
		{
			EnableColliders(false);
			Rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
			Rigidbody.isKinematic = true;
			float num = 0f;
			if (_trail != null)
			{
				num = _trail.time;
			}
			if (_particleSystem != null)
			{
				num = Mathf.Max(num, _particleSystem.main.duration - _particleSystem.time);
			}
			if (_renderer != null && !(_renderer is ParticleSystemRenderer))
			{
				_renderer.enabled = false;
			}
			StopActiveSoundLoop();
			if (_emptyGameObject != null)
			{
				base.transform.parent = null;
				UnityEngine.Object.Destroy(_emptyGameObject);
			}
			if (_hinge != null)
			{
				UnityEngine.Object.Destroy(_hinge);
			}
			Invoke("DestroyMe", num);
		}

		protected void DestroyMe()
		{
			if (_emptyGameObject != null)
			{
				base.transform.parent = null;
				UnityEngine.Object.Destroy(_emptyGameObject);
			}
			if (_hinge != null)
			{
				UnityEngine.Object.Destroy(_hinge);
			}
			CancelInvoke();
			if (_pool != null)
			{
				_pool.Destroy(this);
			}
		}
	}
}
