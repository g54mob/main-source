using System;
using Pathfinding.Util;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Properties;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	public class AgentOffMeshLinkTraversalContext : ICloneable
	{
		public class AbortOffMeshLinkTraversal : Exception
		{
		}

		internal unsafe AgentOffMeshLinkTraversal* linkInfoPtr;

		internal unsafe MovementControl* movementControlPtr;

		internal unsafe MovementSettings* movementSettingsPtr;

		internal unsafe LocalTransform* transformPtr;

		internal unsafe AgentMovementPlane* movementPlanePtr;

		internal EnabledRefRW<AgentOffMeshLinkMovementDisabled> movementDisabled;

		internal EnabledRefRW<AgentOffMeshLinkLocalAvoidanceDisabled> localAvoidanceDisabled;

		public Entity entity;

		[DontCreateProperty]
		public ManagedState managedState;

		[DontCreateProperty]
		internal OffMeshLinks.OffMeshLinkConcrete concreteLink;

		protected float backupRotationSmoothing;

		public float deltaTime;

		protected GameObject gameObjectCache;

		public virtual GameObject gameObject => null;

		public ref LocalTransform transform
		{
			get
			{
				throw null;
			}
		}

		public ref MovementSettings movementSettings
		{
			get
			{
				throw null;
			}
		}

		public ref MovementControl movementControl
		{
			get
			{
				throw null;
			}
		}

		public OffMeshLinks.OffMeshLinkTracer link => default(OffMeshLinks.OffMeshLinkTracer);

		[Obsolete("Use the link property instead")]
		public AgentOffMeshLinkTraversal linkInfo => default(AgentOffMeshLinkTraversal);

		public ref NativeMovementPlane movementPlane
		{
			get
			{
				throw null;
			}
		}

		public bool enableBuiltInMovement
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AgentOffMeshLinkTraversalContext(OffMeshLinks.OffMeshLinkConcrete link)
		{
		}

		public virtual void SetInternalData(Entity entity, ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref MovementControl movementControl, ref MovementSettings movementSettings, ref AgentOffMeshLinkTraversal linkInfo, EnabledRefRW<AgentOffMeshLinkMovementDisabled> movementDisabled, EnabledRefRW<AgentOffMeshLinkLocalAvoidanceDisabled> localAvoidanceDisabled, ManagedState state, float deltaTime)
		{
		}

		public void DisableLocalAvoidance()
		{
		}

		public void DisableRotationSmoothing()
		{
		}

		public virtual void Restore()
		{
		}

		public virtual void Teleport(float3 position)
		{
		}

		public virtual void Abort(bool teleportToStart = true)
		{
		}

		public virtual MovementTarget MoveTowards(float3 position, quaternion rotation, bool gravity, bool slowdown)
		{
			return default(MovementTarget);
		}

		public virtual object Clone()
		{
			return null;
		}
	}
}
