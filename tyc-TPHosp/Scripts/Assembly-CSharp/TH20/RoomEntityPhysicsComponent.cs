using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomEntityPhysicsComponent : EntityTickComponent
	{
		public float Radius = 0.5f;

		public float Mass = 1f;

		public float Friction = 1f;

		public Vector3 Velocity;

		public float DestroyBelowVelocity;

		private const float Gravity = -9.8f;

		private const float FixedTimeStep = 0.008f;

		private Room _room;

		private float _remainingTime;

		public Room Room
		{
			set
			{
				_room = value;
			}
		}

		protected override Type ValidEntityType()
		{
			return typeof(Entity);
		}

		public override void Tick()
		{
			base.Tick();
			if (!(GetOwner() is IRoomPhysicsEntity roomPhysicsEntity) || _room == null)
			{
				return;
			}
			Transform transform = roomPhysicsEntity.GetTransform();
			if (!(transform != null))
			{
				return;
			}
			FloorPlan floorPlan = _room.FloorPlan;
			float deltaTime = Time.deltaTime;
			Vector3 vector = floorPlan.Anchor.ToWorldPosition();
			deltaTime += _remainingTime;
			int num = (int)Mathf.Floor(deltaTime / 0.008f);
			_remainingTime = deltaTime - (float)num * 0.008f;
			Vector3 position = transform.position;
			for (int i = 0; i < num; i++)
			{
				Velocity.y += -9.8f * Mass * 0.008f;
				position += Velocity * 0.008f;
				WallCoord closestWallToLocation = RoomItemAlgorithms.GetClosestWallToLocation(floorPlan, position, Radius);
				if (closestWallToLocation != null)
				{
					Vector3 localPos = position - vector;
					float num2 = Mathf.Sqrt(closestWallToLocation.DistanceSquared(localPos));
					if (num2 < Radius)
					{
						Vector3 vector2 = -closestWallToLocation._rotation.DirectionVector();
						position += vector2 * (Radius - num2);
						Velocity = Vector3.Reflect(Velocity * Friction, vector2);
					}
				}
				if (position.y < 0f)
				{
					position.y = 0f - position.y;
					Velocity = Vector3.Reflect(Velocity * Friction, Vector3.up);
				}
			}
			transform.position = position;
			transform.rotation = Quaternion.LookRotation(Velocity);
			if (Velocity.magnitude < DestroyBelowVelocity)
			{
				roomPhysicsEntity.DestroyEntity();
			}
		}
	}
}
