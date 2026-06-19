using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class CollisionManager : NetworkEntityBehaviourBase
{
	private struct CollisionEvent
	{
		public VehicleController vehicleA;

		public VehicleController vehicleB;

		public CollisionEvent(VehicleController _vehicleA, VehicleController _vehicleB)
		{
			vehicleA = _vehicleA;
			vehicleB = _vehicleB;
		}
	}

	[Min(0f)]
	public float impulseThresholdForStress = 6f;

	public LayerMask playerCollisionMask;

	private ObjectQuery<VehicleController> vehicleQuery;

	public GameObject collisionVfxPrefab;

	private static List<VehicleController> allVehicles = new List<VehicleController>();

	private static List<CollisionEvent> collisionEvents = new List<CollisionEvent>();

	private static List<VehicleController> vehiclesInCollisions = new List<VehicleController>();

	private static Collider[] _colliders = new Collider[8];

	protected override void OnEntityCreated()
	{
		vehicleQuery = base.entityManager.CreateObjectQuery<VehicleController>();
	}

	protected override void OnUpdateSimulationLate()
	{
		if (!NetworkServer.active)
		{
			return;
		}
		vehicleQuery.Run();
		allVehicles.Clear();
		for (int i = 0; i < vehicleQuery.count; i++)
		{
			VehicleController vehicleController = vehicleQuery[i];
			allVehicles.Add(vehicleController);
			Transform transform = vehicleController.playerCrashCollider.transform;
			float num = (float)NetworkUtil.ServerGetPing(vehicleController.netIdentity.connectionToClient);
			if (vehicleController.isLocalPlayer)
			{
				num = 0f;
			}
			if (vehicleController.velocitySync.magnitude < vehicleController.playerCrashSpeedThreshold)
			{
				transform.localPosition = Vector3.zero;
			}
			else
			{
				transform.position = vehicleController.transform.position + num * 2f * vehicleController.velocitySync;
			}
		}
		collisionEvents.Clear();
		vehiclesInCollisions.Clear();
		foreach (VehicleController allVehicle in allVehicles)
		{
			if (allVehicle.velocitySync.magnitude < allVehicle.playerCrashSpeedThreshold || Time.time - allVehicle.timeAtLastCollision < 0.3f || vehiclesInCollisions.Contains(allVehicle))
			{
				continue;
			}
			BoxCollider playerCrashCollider = allVehicle.playerCrashCollider;
			Entity entity = allVehicle.entity;
			Vector3 center = allVehicle.transform.TransformPoint(playerCrashCollider.center);
			Vector3 halfExtents = playerCrashCollider.size / 2f;
			int num2 = Physics.OverlapBoxNonAlloc(center, halfExtents, _colliders, allVehicle.transform.rotation, playerCollisionMask);
			for (int j = 0; j < num2; j++)
			{
				if (_colliders[j].TryGetEntity(out var entity2) && !(entity2 == entity))
				{
					VehicleController vehicleController2 = entity2.GetObject<VehicleController>();
					if (!(Time.time - vehicleController2.timeAtLastCollision < 0.4f) && !vehiclesInCollisions.Contains(vehicleController2))
					{
						CollisionEvent item = new CollisionEvent(allVehicle, vehicleController2);
						collisionEvents.Add(item);
						vehiclesInCollisions.Add(allVehicle);
						vehiclesInCollisions.Add(vehicleController2);
						break;
					}
				}
			}
		}
		foreach (CollisionEvent collisionEvent in collisionEvents)
		{
			VehicleController vehicleA = collisionEvent.vehicleA;
			VehicleController vehicleB = collisionEvent.vehicleB;
			Vector3 normalized = (vehicleA.transform.position - vehicleB.transform.position).normalized;
			Vector3 velocitySync = vehicleA.velocitySync;
			Vector3 velocitySync2 = vehicleB.velocitySync;
			if (!(Vector3.Dot(normalized, velocitySync) > 0f) || !(Vector3.Dot(normalized, velocitySync2) < 0f))
			{
				Vector3 vector = new Vector3(0f - normalized.z, 0f, normalized.x);
				Vector3 vector2 = Vector3.Dot(normalized, velocitySync) * normalized;
				Vector3 vector3 = Vector3.Dot(vector, velocitySync) * vector;
				Vector3 vector4 = Vector3.Dot(normalized, velocitySync2) * normalized;
				Vector3 vector5 = Vector3.Dot(vector, velocitySync2) * vector;
				float num3 = 1f;
				float num4 = 1f;
				float num5 = num3 + num4;
				Vector3 vector6 = (vector2 * (num3 - num4) + 2f * num4 * vector4) / num5;
				Vector3 vector7 = (vector4 * (num4 - num3) + 2f * num3 * vector2) / num5;
				Vector3 vector8 = vector6 + vector3;
				Vector3 vector9 = vector7 + vector5;
				Vector3 force = vector8 - vehicleA.velocitySync;
				Vector3 force2 = vector9 - vehicleB.velocitySync;
				vehicleA.RpcTakeForce(force);
				vehicleA.timeAtLastCollision = Time.time;
				vehicleB.RpcTakeForce(force2);
				vehicleB.timeAtLastCollision = Time.time;
				if (force.sqrMagnitude >= impulseThresholdForStress * impulseThresholdForStress)
				{
					vehicleA.entity.GetObject<PlayerStress>().RequestBumpStress();
					vehicleA.entity.GetObject<PlayerAnimation>().RpcPlayBonk();
					vehicleA.entity.GetObject<PlayerColorManagerNetwork>().RpcPlayFlash();
				}
				if (force2.sqrMagnitude >= impulseThresholdForStress * impulseThresholdForStress)
				{
					vehicleB.entity.GetObject<PlayerStress>().RequestBumpStress();
					vehicleB.entity.GetObject<PlayerAnimation>().RpcPlayBonk();
					vehicleB.entity.GetObject<PlayerColorManagerNetwork>().RpcPlayFlash();
				}
				Vector3 position = (vehicleA.transform.position + vehicleB.transform.position) / 2f;
				NetworkAggroManagerBase<VFXManager>.instance.Play(collisionVfxPrefab, position);
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
