using System.Collections.Generic;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/AIPath (2D,3D)")]
	[UniqueComponent(tag = "ai")]
	[DisallowMultipleComponent]
	public class AIPath : AIBase, IAstarAI
	{
		public float maxAcceleration;

		[FormerlySerializedAs("turningSpeed")]
		public float rotationSpeed;

		public float slowdownDistance;

		public float pickNextWaypointDist;

		public bool alwaysDrawGizmos;

		public bool slowWhenNotFacingTarget;

		public bool preventMovingBackwards;

		public bool constrainInsideGraph;

		protected Path path;

		protected PathInterpolator.Cursor interpolator;

		protected PathInterpolator interpolatorPath;

		private Vector2 rotationFilterState;

		private Vector2 rotationFilterState2;

		public float remainingDistance => 0f;

		public override bool reachedDestination => false;

		public bool reachedEndOfPath { get; protected set; }

		public bool hasPath => false;

		public bool pathPending => false;

		public Vector3 steeringTarget => default(Vector3);

		public override Vector3 endOfPath => default(Vector3);

		float IAstarAI.radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float IAstarAI.height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float IAstarAI.maxSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		bool IAstarAI.canSearch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IAstarAI.simulateMovement
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		NativeMovementPlane IAstarAI.movementPlane => default(NativeMovementPlane);

		public override void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			stale = default(bool);
		}

		public void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale)
		{
			stale = default(bool);
		}

		protected override void OnDisable()
		{
		}

		public virtual void OnTargetReached()
		{
		}

		protected virtual void UpdateMovementPlane()
		{
		}

		protected override void OnPathComplete(Path newPath)
		{
		}

		protected override void ClearPath()
		{
		}

		protected override void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		protected virtual void CalculateNextRotation(float slowdown, bool avoidingOtherAgents, out Quaternion nextRotation)
		{
			nextRotation = default(Quaternion);
		}

		protected override Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			positionChanged = default(bool);
			return default(Vector3);
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
