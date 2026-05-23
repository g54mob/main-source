using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/AIPath (2D,3D)")]
	[UniqueComponent(tag = "ai")]
	public class AIPath : AIBase, IAstarAI
	{
		public float maxAcceleration = -2.5f;

		[FormerlySerializedAs("turningSpeed")]
		public float rotationSpeed = 360f;

		public float slowdownDistance = 0.6f;

		public float pickNextWaypointDist = 2f;

		public bool alwaysDrawGizmos;

		public bool slowWhenNotFacingTarget = true;

		public bool preventMovingBackwards;

		public bool constrainInsideGraph;

		protected Path path;

		protected PathInterpolator.Cursor interpolator;

		protected PathInterpolator interpolatorPath = new PathInterpolator();

		private Vector2 rotationFilterState;

		private Vector2 rotationFilterState2;

		private static NNConstraint cachedNNConstraint = NNConstraint.Walkable;

		public float remainingDistance
		{
			get
			{
				if (!interpolator.valid)
				{
					return float.PositiveInfinity;
				}
				return interpolator.remainingDistance + movementPlane.ToPlane(interpolator.position - base.position).magnitude;
			}
		}

		public override bool reachedDestination
		{
			get
			{
				if (!reachedEndOfPath)
				{
					return false;
				}
				if (!interpolator.valid || remainingDistance + movementPlane.ToPlane(base.destination - interpolator.endPoint).magnitude > endReachedDistance)
				{
					return false;
				}
				if (orientation != OrientationMode.YAxisForward)
				{
					movementPlane.ToPlane(base.destination - base.position, out var elevation);
					float num = tr.localScale.y * height;
					if (elevation > num || (double)elevation < (double)(0f - num) * 0.5)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool reachedEndOfPath { get; protected set; }

		public bool hasPath => interpolator.valid;

		public bool pathPending => waitingForPathCalculation;

		public Vector3 steeringTarget
		{
			get
			{
				if (!interpolator.valid)
				{
					return base.position;
				}
				return interpolator.position;
			}
		}

		public override Vector3 endOfPath
		{
			get
			{
				if (interpolator.valid)
				{
					return interpolator.endPoint;
				}
				if (float.IsFinite(base.destination.x))
				{
					return base.destination;
				}
				return base.position;
			}
		}

		float IAstarAI.radius
		{
			get
			{
				return radius;
			}
			set
			{
				radius = value;
			}
		}

		float IAstarAI.height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		float IAstarAI.maxSpeed
		{
			get
			{
				return maxSpeed;
			}
			set
			{
				maxSpeed = value;
			}
		}

		bool IAstarAI.canSearch
		{
			get
			{
				return base.canSearch;
			}
			set
			{
				base.canSearch = value;
			}
		}

		bool IAstarAI.canMove
		{
			get
			{
				return canMove;
			}
			set
			{
				canMove = value;
			}
		}

		NativeMovementPlane IAstarAI.movementPlane => new NativeMovementPlane(movementPlane);

		public override void Teleport(Vector3 newPosition, bool clearPath = true)
		{
			reachedEndOfPath = false;
			base.Teleport(newPosition, clearPath);
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			buffer.Clear();
			buffer.Add(base.position);
			if (!interpolator.valid)
			{
				stale = true;
				return;
			}
			stale = false;
			interpolator.GetRemainingPath(buffer);
		}

		public void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale)
		{
			GetRemainingPath(buffer, out stale);
			if (partsBuffer != null)
			{
				partsBuffer.Clear();
				partsBuffer.Add(new PathPartWithLinkInfo
				{
					startIndex = 0,
					endIndex = buffer.Count - 1
				});
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			rotationFilterState = Vector2.zero;
			rotationFilterState2 = Vector2.zero;
		}

		public virtual void OnTargetReached()
		{
		}

		protected virtual void UpdateMovementPlane()
		{
			if (path.path != null && path.path.Count != 0)
			{
				IMovementPlane movementPlane = ((AstarData.GetGraph(path.path[0]) is ITransformedGraph transformedGraph) ? transformedGraph.transform : ((orientation == OrientationMode.YAxisForward) ? new GraphTransform(Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(-90f, 270f, 90f), Vector3.one)) : GraphTransform.identityTransform));
				base.movementPlane = movementPlane.ToSimpleMovementPlane();
			}
		}

		protected override void OnPathComplete(Path newPath)
		{
			if (!(newPath is ABPath aBPath))
			{
				throw new Exception("This function only handles ABPaths, do not use special path types");
			}
			waitingForPathCalculation = false;
			aBPath.Claim(this);
			if (aBPath.error)
			{
				aBPath.Release(this);
				SetPath(null);
				return;
			}
			if (path != null)
			{
				path.Release(this);
			}
			path = aBPath;
			if (!aBPath.endPointKnownBeforeCalculation)
			{
				base.destination = aBPath.originalEndPoint;
			}
			if (path.vectorPath.Count == 1)
			{
				path.vectorPath.Add(path.vectorPath[0]);
			}
			interpolatorPath.SetPath(path.vectorPath);
			interpolator = interpolatorPath.start;
			UpdateMovementPlane();
			reachedEndOfPath = false;
			interpolator.MoveToLocallyClosestPoint((GetFeetPosition() + aBPath.originalStartPoint) * 0.5f);
			interpolator.MoveToLocallyClosestPoint(GetFeetPosition());
			interpolator.MoveToCircleIntersection2D(base.position, pickNextWaypointDist, movementPlane);
			if (remainingDistance <= endReachedDistance)
			{
				reachedEndOfPath = true;
				OnTargetReached();
			}
		}

		protected override void ClearPath()
		{
			CancelCurrentPathRequest();
			if (path != null)
			{
				path.Release(this);
			}
			path = null;
			interpolatorPath.SetPath(null);
			reachedEndOfPath = false;
		}

		protected override void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			float num = maxAcceleration;
			if (num < 0f)
			{
				num *= 0f - maxSpeed;
			}
			if (updatePosition)
			{
				simulatedPosition = tr.position;
			}
			if (updateRotation)
			{
				simulatedRotation = tr.rotation;
			}
			Vector3 vector = simulatedPosition;
			Vector2 vector2 = movementPlane.ToPlane(simulatedRotation * ((orientation == OrientationMode.YAxisForward) ? Vector3.up : Vector3.forward));
			bool flag = base.isStopped || (reachedDestination && whenCloseToDestination == CloseToDestinationMode.Stop);
			if (rvoController != null)
			{
				rvoDensityBehavior.Update(rvoController.enabled, reachedDestination, ref flag, ref rvoController.priorityMultiplier, ref rvoController.flowFollowingStrength, vector);
			}
			float num2 = 0f;
			float num3;
			if (interpolator.valid)
			{
				interpolator.MoveToCircleIntersection2D(vector, pickNextWaypointDist, movementPlane);
				Vector2 deltaPosition = movementPlane.ToPlane(steeringTarget - vector);
				num3 = deltaPosition.magnitude + Mathf.Max(0f, interpolator.remainingDistance);
				bool num4 = reachedEndOfPath;
				reachedEndOfPath = num3 <= endReachedDistance;
				if (!num4 && reachedEndOfPath)
				{
					OnTargetReached();
				}
				if (!flag)
				{
					num2 = ((num3 < slowdownDistance) ? Mathf.Sqrt(num3 / slowdownDistance) : 1f);
					velocity2D += MovementUtilities.CalculateAccelerationToReachPoint(deltaPosition, deltaPosition.normalized * maxSpeed, velocity2D, num, rotationSpeed, maxSpeed, vector2) * deltaTime;
				}
			}
			else
			{
				reachedEndOfPath = false;
				num3 = float.PositiveInfinity;
			}
			if (!interpolator.valid || flag)
			{
				velocity2D -= Vector2.ClampMagnitude(velocity2D, num * deltaTime);
				num2 = 1f;
			}
			velocity2D = MovementUtilities.ClampVelocity(velocity2D, maxSpeed, num2, slowWhenNotFacingTarget && enableRotation, preventMovingBackwards, vector2);
			ApplyGravity(deltaTime);
			bool avoidingOtherAgents = false;
			if (rvoController != null && rvoController.enabled)
			{
				Vector3 pos = vector + movementPlane.ToWorld(Vector2.ClampMagnitude(velocity2D, num3));
				rvoController.SetTarget(pos, velocity2D.magnitude, maxSpeed, endOfPath);
				avoidingOtherAgents = rvoController.AvoidingAnyAgents;
			}
			Vector2 point = (lastDeltaPosition = CalculateDeltaToMoveThisFrame(vector, num3, deltaTime));
			nextPosition = vector + movementPlane.ToWorld(point, verticalVelocity * deltaTime);
			CalculateNextRotation(num2, avoidingOtherAgents, out nextRotation);
		}

		protected virtual void CalculateNextRotation(float slowdown, bool avoidingOtherAgents, out Quaternion nextRotation)
		{
			if (lastDeltaTime > 1E-05f && enableRotation)
			{
				float threshold = radius * tr.localScale.x * 0.2f;
				float num = MovementUtilities.FilterRotationDirection(ref rotationFilterState, ref rotationFilterState2, lastDeltaPosition, threshold, lastDeltaTime, avoidingOtherAgents);
				nextRotation = SimulateRotationTowards(rotationFilterState, rotationSpeed * lastDeltaTime * num, rotationSpeed * lastDeltaTime);
			}
			else
			{
				nextRotation = rotation;
			}
		}

		protected override Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			if (constrainInsideGraph)
			{
				cachedNNConstraint.tags = seeker.traversableTags;
				cachedNNConstraint.graphMask = seeker.graphMask;
				cachedNNConstraint.distanceMetric = DistanceMetric.ClosestAsSeenFromAboveSoft();
				NNInfo nearest = AstarPath.active.GetNearest(position, cachedNNConstraint);
				if (nearest.node == null)
				{
					positionChanged = false;
					return position;
				}
				Vector3 vector = nearest.position;
				if (rvoController != null && rvoController.enabled)
				{
					rvoController.SetObstacleQuery(nearest.node);
				}
				Vector2 vector2 = movementPlane.ToPlane(vector - position);
				float sqrMagnitude = vector2.sqrMagnitude;
				if (sqrMagnitude > 1.0000001E-06f)
				{
					velocity2D -= vector2 * Vector2.Dot(vector2, velocity2D) / sqrMagnitude;
					positionChanged = true;
					return position + movementPlane.ToWorld(vector2);
				}
			}
			positionChanged = false;
			return position;
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.IsLegacyFormat && migrations.LegacyVersion < 1)
			{
				rotationSpeed *= 90f;
			}
			base.OnUpgradeSerializedData(ref migrations, unityThread);
		}
	}
}
