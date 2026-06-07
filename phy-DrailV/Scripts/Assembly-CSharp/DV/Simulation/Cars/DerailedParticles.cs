using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class DerailedParticles
	{
		private static readonly int TERRAIN_LAYER = LayerMask.NameToLayer("Terrain");

		private const string DIRT_IMPACT_PARTICLES_PREFAB = "DirtImpact";

		private const int WET_FRAMES_BETWEEN_SPAWN = 200;

		private readonly ContactPoint[] points = new ContactPoint[5];

		private readonly TrainCar car;

		private bool subbedToColInfo;

		private int lastTickDragged = -1;

		public DerailedParticles(TrainCar car)
		{
			this.car = car;
			car.OnDerailed += OnDerailed;
			car.OnRerailed += OnRerailed;
			CheckState();
		}

		private void OnCollision(Collision collision, bool becausePause)
		{
			if (!becausePause && collision.gameObject.layer == TERRAIN_LAYER && (bool)SingletonBehaviour<DerailedParticleSystem>.Instance)
			{
				DoDrag(collision);
				DoImpact(collision);
			}
		}

		private void DoDrag(Collision collision)
		{
			DerailedParticleSystem instance = SingletonBehaviour<DerailedParticleSystem>.Instance;
			float num = NumberUtil.MapClamp(collision.relativeVelocity.magnitude, instance.dragSpeedThresholds.x, instance.dragSpeedThresholds.y, 0f, 1f);
			if (num <= 0f)
			{
				return;
			}
			float value = ((SingletonBehaviour<WeatherDriver>.Instance != null) ? ((float)SingletonBehaviour<WeatherDriver>.Instance.WetnessValue) : 0f);
			value = NumberUtil.MapClamp(value, instance.dragWetnessThresholds.x, instance.dragWetnessThresholds.y, 0f, 1f);
			if (value != 1f && !((float)SingletonBehaviour<FixedUpdateTick>.Instance.Tick <= (float)lastTickDragged + Mathf.Lerp(instance.dragFramesBetweenParticleSpawn, 200f, value)))
			{
				lastTickDragged = SingletonBehaviour<FixedUpdateTick>.Instance.Tick;
				Vector3 vector = -collision.relativeVelocity;
				vector *= instance.dragVelocityInherit;
				Vector3 vector2 = ((SingletonBehaviour<WorldMover>.Instance != null) ? WorldMover.currentMove : Vector3.zero);
				for (int i = 0; i < collision.GetContacts(points); i++)
				{
					ContactPoint contactPoint = points[i];
					Vector3 vector3 = Vector3.Cross(contactPoint.thisCollider.attachedRigidbody.velocity.normalized, Vector3.up);
					Quaternion quaternion = Quaternion.Euler(Random.Range(0f - instance.dragDirectionRandomness, instance.dragDirectionRandomness), Random.Range(0f - instance.dragDirectionRandomness, instance.dragDirectionRandomness), Random.Range(0f - instance.dragDirectionRandomness, instance.dragDirectionRandomness));
					Vector3 position = contactPoint.point - vector2 + new Vector3(Random.Range(0f - instance.dragPositionRandomness, instance.dragPositionRandomness), 0.3f, Random.Range(0f - instance.dragPositionRandomness, instance.dragPositionRandomness));
					Vector3 vector4 = vector + vector3 * Random.Range(-1f, 1f) * instance.dragSideForce * num;
					vector4 = quaternion * vector4;
					SingletonBehaviour<DerailedParticleSystem>.Instance.SpawnParticle(position, vector4);
				}
			}
		}

		private void DoImpact(Collision collision)
		{
			DerailedParticleSystem instance = SingletonBehaviour<DerailedParticleSystem>.Instance;
			if (!(NumberUtil.MapClamp(collision.impulse.magnitude / Time.fixedDeltaTime, instance.impactForceThresholds.x, instance.impactForceThresholds.y, 0f, 1f) <= 0f))
			{
				Vector3 vel = -collision.relativeVelocity;
				vel *= instance.impactVelocityInherit;
				Vector3 vector = ((SingletonBehaviour<WorldMover>.Instance != null) ? WorldMover.currentMove : Vector3.zero);
				for (int i = 0; i < collision.GetContacts(points); i++)
				{
					ContactPoint contactPoint = points[i];
					GameObject particle = SingletonBehaviour<ParticlePool>.Instance.GetParticle("DirtImpact");
					ParticleSystem componentInChildren = particle.GetComponentInChildren<ParticleSystem>();
					ParticleSystem.EmissionModule emission = componentInChildren.emission;
					emission.enabled = false;
					particle.GetComponent<ParticleVelocityAdd>().AddVelocityToSystem(vel);
					ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
					{
						position = contactPoint.point - vector + contactPoint.normal * instance.particleSpawnHeight,
						applyShapeToPosition = true
					};
					componentInChildren.Play();
					componentInChildren.Emit(emitParams, Mathf.RoundToInt(emission.GetBurst(0).count.constant));
				}
			}
		}

		private void OnDerailed(TrainCar derailedCar)
		{
			car.MovementStateChanged += CarOnMovementStateChanged;
			CheckState();
		}

		private void OnRerailed()
		{
			car.MovementStateChanged -= CarOnMovementStateChanged;
			CheckState();
		}

		public void ResetState()
		{
			car.MovementStateChanged -= CarOnMovementStateChanged;
			car.CollisionInfoDispenser.CollisionStayInfo -= OnCollision;
			car.CollisionInfoDispenser.CollisionEnterInfo -= OnCollision;
			subbedToColInfo = false;
		}

		private void CarOnMovementStateChanged(bool _)
		{
			CheckState();
		}

		private void CheckState()
		{
			bool flag = !car.isStationary && car.derailed;
			if (flag != subbedToColInfo)
			{
				subbedToColInfo = flag;
				if (flag)
				{
					car.CollisionInfoDispenser.CollisionStayInfo += OnCollision;
					car.CollisionInfoDispenser.CollisionEnterInfo += OnCollision;
				}
				else
				{
					car.CollisionInfoDispenser.CollisionStayInfo -= OnCollision;
					car.CollisionInfoDispenser.CollisionEnterInfo -= OnCollision;
				}
			}
		}
	}
}
