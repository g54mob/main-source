using System;
using Pathfinding.PID;
using Unity.Entities;
using UnityEngine;

namespace Pathfinding.ECS
{
	[Serializable]
	public struct MovementSettings : IComponentData, IQueryTypeParameter
	{
		public PIDMovement follower;

		public PIDMovement.DebugFlags debugFlags;

		public float stopDistance;

		public float rotationSmoothing;

		public float positionSmoothing;

		public LayerMask groundMask;

		public bool isStopped;

		[Obsolete("Use the AgentMovementPlaneSource component instead, or the movementPlaneSource property on the FollowerEntity component", true)]
		public MovementPlaneSource movementPlaneSource { get; set; }
	}
}
