using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Projectiles
{
	public class Rocket : Projectile
	{
		public tk2dSprite RocketSprite;

		public Collider Trigger;

		public LayerMask HeatseekingLayers;

		protected float Force;

		protected ERocketSteeringMode SteeringMode;

		private Transform _rocketTransform;

		private bool _hasBeenExploded;

		private GameObject _nearestEnemy;

		private Renderer _rocketRenderer;

		private bool _shouldCheckInput;

		public void Init(ProjectileEmitter emitter, Ammunition ammunition, float damage, EProjectileCollisionMode collisionMode, float lifetime, EProjectileExplosionMode explosionMode, ERocketSteeringMode steeringMode, float force)
		{
			base.Init(emitter, ammunition, damage, collisionMode, lifetime, explosionMode);
			SteeringMode = steeringMode;
			Force = force;
			_rocketTransform = RocketSprite.transform;
			List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
			_shouldCheckInput = true;
			_shouldCheckInput = preconditions == null || !preconditions.Any((DronePrecondition c) => c is NoInputAllowed);
			_rocketRenderer = RocketSprite.GetComponent<Renderer>();
		}

		public override void Reset()
		{
			base.Reset();
			_hasBeenExploded = false;
			_nearestEnemy = null;
			_rocketRenderer.enabled = true;
			Trigger.enabled = SteeringMode == ERocketSteeringMode.HeatSeeking;
			StartCoroutine(UpdateRotation());
		}

		private IEnumerator UpdateRotation()
		{
			while (!_hasBeenExploded)
			{
				float seconds = Random.Range(0.05f, 0.1f);
				yield return new WaitForSeconds(seconds);
				float num = 10f;
				if (!Emitter.UsedByEnemy && SteeringMode == ERocketSteeringMode.LaserGuided && RuntimeGlobals.Camera != null && _shouldCheckInput)
				{
					base.transform.rotation = TransformHelper.Get2DRotationTowardsMouse(base.transform.position + base.transform.right * num, RuntimeGlobals.Camera.Camera);
				}
				if (SteeringMode == ERocketSteeringMode.HeatSeeking)
				{
					GameObject gameObject = ((!Emitter.UsedByEnemy) ? _nearestEnemy : RuntimeGlobals.NimbatusPlayer.gameObject);
					if (gameObject != null)
					{
						base.transform.rotation = TransformHelper.Get2DRotationTowardsTarget(base.transform.position + base.transform.right * num, gameObject.transform.position);
					}
				}
				if (!_hasBeenExploded)
				{
					_rocketTransform.rotation = TransformHelper.Get2DRotationTowardsTarget(_rocketTransform.position, _rocketTransform.position + Rigidbody.velocity);
				}
			}
		}

		public override void HandleCollision(GameObject other, Vector3 position, Quaternion rotation, Vector3 normal)
		{
			if (CollisionMode == EProjectileCollisionMode.Reflect)
			{
				base.transform.rotation = TransformHelper.Get2DRotationTowardsTarget(base.transform.position, position + normal);
				Rigidbody.AddRelativeForce(Vector3.right * 10f, ForceMode.VelocityChange);
			}
			base.HandleCollision(other, position, rotation, normal);
		}

		public override void FixedUpdate()
		{
			Rigidbody.AddRelativeForce(Vector3.right * Force * 0.1f, ForceMode.Force);
			base.FixedUpdate();
		}

		protected override void DestroyProjectile()
		{
			_hasBeenExploded = true;
			_rocketRenderer.enabled = false;
			base.DestroyProjectile();
		}

		public void OnTriggerEnter(Collider other)
		{
			if (HeatseekingLayers.Contains(other.gameObject.layer))
			{
				if (_nearestEnemy == null)
				{
					_nearestEnemy = other.gameObject;
				}
				else if (Vector3.Distance(base.transform.position, other.transform.position) <= Vector3.Distance(base.transform.position, _nearestEnemy.transform.position))
				{
					_nearestEnemy = other.gameObject;
				}
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (HeatseekingLayers.Contains(other.gameObject.layer) && _nearestEnemy == other.gameObject)
			{
				_nearestEnemy = null;
			}
		}
	}
}
