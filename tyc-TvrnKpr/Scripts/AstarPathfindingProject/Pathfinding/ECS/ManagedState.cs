using System;
using Pathfinding.ECS.RVO;
using Unity.Entities;
using Unity.Properties;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace Pathfinding.ECS
{
	[Serializable]
	[TypeManager.TypeOverrides(true, true, true)]
	public class ManagedState : IComponentData, IQueryTypeParameter, IDisposable, ICloneable
	{
		public PathTracer pathTracer;

		[FormerlySerializedAs("rvoAgent")]
		[Obsolete("Use FollowerEntity.rvoSettings or the RVOAgent ECS component instead", false)]
		[DontCreateProperty]
		public RVOAgent rvoSettings;

		[NonSerialized]
		[Obsolete("Use ManagedSettings.onTraverseOffMeshLink instead", false)]
		[DontCreateProperty]
		public IOffMeshLinkHandler onTraverseOffMeshLink;

		[Obsolete("Use ManagedSettings.pathfindingSettings instead", false)]
		[DontCreateProperty]
		public PathRequestSettings pathfindingSettings;

		[FormerlySerializedAs("rvoEnabled")]
		[Obsolete("Use FollowerEntity.enableLocalAvoidance or remove/add the RVOAgent ECS component instead", false)]
		[DontCreateProperty]
		public bool enableLocalAvoidance;

		[Obsolete("Use FollowerEntity.enableGravity or toggle the enabled state of the GravityState ECS component instead", false)]
		[DontCreateProperty]
		public bool enableGravity;

		[Obsolete("Use FollowerEntity.autoRepath, or the Pathfinding.ECS.AutoRepathPolicy component instead", true)]
		public Pathfinding.AutoRepathPolicy autoRepath => null;

		public Path pendingPath { get; private set; }

		public Path activePath { get; private set; }

		public static void SetPath(Path path, ManagedState state, in AgentMovementPlane movementPlane, ref DestinationPoint destination)
		{
		}

		public void ClearPath()
		{
		}

		public void CancelCurrentPathRequest()
		{
		}

		public void Dispose()
		{
		}

		public void PopNextLinkFromPath()
		{
		}

		object ICloneable.Clone()
		{
			return null;
		}

		[Preserve]
		public ManagedState()
		{
		}
	}
}
