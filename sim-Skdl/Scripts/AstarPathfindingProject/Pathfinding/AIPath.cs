using System;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/AIPath (2D,3D)")]
	public class AIPath : AIBase, IAstarAI
	{
		public float maxAcceleration;

		[FormerlySerializedAs("turningSpeed")]
		public float rotationSpeed;

		public float slowdownDistance;

		public float pickNextWaypointDist;

		public float endReachedDistance;

		public bool alwaysDrawGizmos;

		public bool slowWhenNotFacingTarget;

		public CloseToDestinationMode whenCloseToDestination;

		public bool constrainInsideGraph;

		protected Path path;

		protected PathInterpolator interpolator;

		private static NNConstraint cachedNNConstraint;

		public float remainingDistance => 0f;

		public bool reachedDestination => false;

		public bool reachedEndOfPath { get; protected set; }

		public bool hasPath => false;

		public bool pathPending => false;

		public Vector3 steeringTarget => default(Vector3);

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

		bool IAstarAI.canMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("When unifying the interfaces for different movement scripts, this property has been renamed to reachedEndOfPath.  [AstarUpgradable: 'TargetReached' -> 'reachedEndOfPath']")]
		public bool TargetReached => false;

		[Obsolete("This field has been renamed to #rotationSpeed and is now in degrees per second instead of a damping factor")]
		public float turningSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("This member has been deprecated. Use 'maxSpeed' instead. [AstarUpgradable: 'speed' -> 'maxSpeed']")]
		public float speed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("Only exists for compatibility reasons. Use desiredVelocity or steeringTarget instead.")]
		public Vector3 targetDirection => default(Vector3);

		public override void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			stale = default(bool);
		}

		protected override void OnDisable()
		{
		}

		public virtual void OnTargetReached()
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

		protected virtual void CalculateNextRotation(float slowdown, out Quaternion nextRotation)
		{
			nextRotation = default(Quaternion);
		}

		protected override Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			positionChanged = default(bool);
			return default(Vector3);
		}

		protected override int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}

		[Obsolete("This method no longer calculates the velocity. Use the desiredVelocity property instead")]
		public Vector3 CalculateVelocity(Vector3 position)
		{
			return default(Vector3);
		}
	}
}
