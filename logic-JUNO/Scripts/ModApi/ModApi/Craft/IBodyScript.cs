using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public interface IBodyScript
	{
		Vector3 Acceleration { get; }

		float AccelerationMagnitude { get; }

		bool ApplyStandardForces { get; set; }

		IBodyCollisionHandler BodyCollisionHandler { get; }

		Vector3 CenterOfMass { get; set; }

		bool CollidingWithTerrain { get; }

		ICraftScript CraftScript { get; }

		BodyData Data { get; }

		bool Disconnected { get; }

		Vector3 DragForce { get; }

		float FluidDensity { get; }

		GameObject GameObject { get; }

		bool IsDebris { get; }

		List<IBodyJoint> Joints { get; }

		float MachNumber { get; }

		IReadOnlyList<IPartGroupScript> PartGroups { get; }

		PartLookup PartIsland { get; }

		float ReEntryEffectStrength { get; }

		Rigidbody RigidBody { get; }

		Vector3 SurfaceVelocity { get; }

		Transform Transform { get; }

		float VelocityMagnitude { get; }

		Vector3 VelocityNormalized { get; }

		float VelocitySquared { get; }

		IBodyWaterPhysics WaterPhysics { get; }

		bool WaterPhysicsEnabled { get; }

		Vector3 WorldCenterOfMass { get; }

		event BodyScriptDelegate UnloadedFromGameView;

		void AddFrameDrag(Drag.DragDirection direction, float drag, Vector3 position);

		float EstimatePartDragForce(Drag partDrag);

		float EstimateWaterImpact(Drag partDrag);

		void ExplodePart(IPartScript part, float power);

		[Obsolete]
		void ExplodePart(IPartScript part, float power, int numCascades);

		void OnPartMassChanged();

		void QueuePartGroupForDestruction(IPartGroupScript partGroup);

		void QueuePartGroupForDisconnect(IPartGroupScript partGroup);

		void RecalculateMass();

		void SetBody(Rigidbody body);

		void SetCollidingWithTerrainFlag(bool? collidingWithTerrain);
	}
}
