using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Drawing;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/RichAI (3D, for navmesh)")]
	[UniqueComponent(tag = "ai")]
	public class RichAI : AIBase, IAstarAI
	{
		public float acceleration = 5f;

		public float rotationSpeed = 360f;

		public float slowdownTime = 0.5f;

		public float wallForce = 3f;

		public float wallDist = 1f;

		public bool funnelSimplification;

		public bool slowWhenNotFacingTarget = true;

		public bool preventMovingBackwards;

		public Func<RichSpecial, IEnumerator> onTraverseOffMeshLink;

		protected readonly RichPath richPath = new RichPath();

		protected bool delayUpdatePath;

		protected bool lastCorner;

		private Vector2 rotationFilterState;

		private Vector2 rotationFilterState2;

		protected float distanceToSteeringTarget = float.PositiveInfinity;

		protected readonly List<Vector3> nextCorners = new List<Vector3>();

		protected readonly List<Vector3> wallBuffer = new List<Vector3>();

		protected static readonly Color GizmoColorPath = new Color(0.03137255f, 26f / 85f, 0.7607843f);

		public bool traversingOffMeshLink { get; protected set; }

		public float remainingDistance => distanceToSteeringTarget + Vector3.Distance(steeringTarget, richPath.Endpoint);

		public bool reachedEndOfPath
		{
			get
			{
				if (approachingPathEndpoint)
				{
					return distanceToSteeringTarget < endReachedDistance;
				}
				return false;
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
				if (distanceToSteeringTarget + movementPlane.ToPlane(steeringTarget - richPath.Endpoint).magnitude + movementPlane.ToPlane(base.destination - richPath.Endpoint).magnitude > endReachedDistance)
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

		public bool hasPath => richPath.GetCurrentPart() != null;

		public bool pathPending
		{
			get
			{
				if (!waitingForPathCalculation)
				{
					return delayUpdatePath;
				}
				return true;
			}
		}

		public Vector3 steeringTarget { get; protected set; }

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

		public bool approachingPartEndpoint
		{
			get
			{
				if (lastCorner)
				{
					return nextCorners.Count == 1;
				}
				return false;
			}
		}

		public bool approachingPathEndpoint
		{
			get
			{
				if (approachingPartEndpoint)
				{
					return richPath.IsLastPart;
				}
				return false;
			}
		}

		public override Vector3 endOfPath
		{
			get
			{
				if (hasPath)
				{
					return richPath.Endpoint;
				}
				if (float.IsFinite(base.destination.x))
				{
					return base.destination;
				}
				return base.position;
			}
		}

		public override Quaternion rotation
		{
			get
			{
				return base.rotation;
			}
			set
			{
				base.rotation = value;
				rotationFilterState = Vector2.zero;
				rotationFilterState2 = Vector2.zero;
			}
		}

		protected override bool shouldRecalculatePath
		{
			get
			{
				if (base.shouldRecalculatePath)
				{
					return !traversingOffMeshLink;
				}
				return false;
			}
		}

		public override void Teleport(Vector3 newPosition, bool clearPath = true)
		{
			base.Teleport(ClampPositionToGraph(newPosition), clearPath);
		}

		protected virtual Vector3 ClampPositionToGraph(Vector3 newPosition)
		{
			NNInfo nNInfo = ((AstarPath.active != null) ? AstarPath.active.GetNearest(newPosition) : default(NNInfo));
			movementPlane.ToPlane(newPosition, out var elevation);
			return movementPlane.ToWorld(movementPlane.ToPlane((nNInfo.node != null) ? nNInfo.position : newPosition), elevation);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			traversingOffMeshLink = false;
			StopAllCoroutines();
			rotationFilterState = Vector2.zero;
			rotationFilterState2 = Vector2.zero;
		}

		public override void SearchPath()
		{
			if (traversingOffMeshLink)
			{
				delayUpdatePath = true;
			}
			else
			{
				base.SearchPath();
			}
		}

		protected override void OnPathComplete(Path p)
		{
			waitingForPathCalculation = false;
			p.Claim(this);
			if (p.error)
			{
				p.Release(this);
				return;
			}
			if (traversingOffMeshLink)
			{
				delayUpdatePath = true;
			}
			else
			{
				if (p is ABPath { endPointKnownBeforeCalculation: false } aBPath)
				{
					base.destination = aBPath.originalEndPoint;
				}
				richPath.Initialize(seeker, p, mergePartEndpoints: true, funnelSimplification);
				if (richPath.GetCurrentPart() is RichFunnel fn)
				{
					if (updatePosition)
					{
						simulatedPosition = tr.position;
					}
					Vector2 vector = movementPlane.ToPlane(UpdateTarget(fn));
					steeringTarget = nextCorners[0];
					Vector2 vector2 = movementPlane.ToPlane(steeringTarget);
					distanceToSteeringTarget = (vector2 - vector).magnitude;
					if (lastCorner && nextCorners.Count == 1 && distanceToSteeringTarget <= endReachedDistance)
					{
						NextPart();
					}
				}
			}
			p.Release(this);
		}

		protected override void ClearPath()
		{
			CancelCurrentPathRequest();
			richPath.Clear();
			lastCorner = false;
			delayUpdatePath = false;
			distanceToSteeringTarget = float.PositiveInfinity;
		}

		protected void NextPart()
		{
			if (!richPath.CompletedAllParts)
			{
				if (!richPath.IsLastPart)
				{
					lastCorner = false;
				}
				richPath.NextPart();
				if (richPath.CompletedAllParts)
				{
					OnTargetReached();
				}
			}
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			richPath.GetRemainingPath(buffer, null, simulatedPosition, out stale);
		}

		public void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale)
		{
			richPath.GetRemainingPath(buffer, partsBuffer, simulatedPosition, out stale);
		}

		protected virtual void OnTargetReached()
		{
		}

		protected virtual Vector3 UpdateTarget(RichFunnel fn)
		{
			nextCorners.Clear();
			bool requiresRepath;
			Vector3 result = fn.Update(simulatedPosition, nextCorners, 2, out lastCorner, out requiresRepath);
			if (requiresRepath && !waitingForPathCalculation && base.canSearch)
			{
				SearchPath();
			}
			return result;
		}

		protected override void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			if (updatePosition)
			{
				simulatedPosition = tr.position;
			}
			if (updateRotation)
			{
				simulatedRotation = tr.rotation;
			}
			RichPathPart currentPart = richPath.GetCurrentPart();
			if (currentPart is RichSpecial)
			{
				if (!traversingOffMeshLink && !richPath.CompletedAllParts)
				{
					StartCoroutine(TraverseSpecial(currentPart as RichSpecial));
				}
				Vector3 vector = (steeringTarget = simulatedPosition);
				nextPosition = vector;
				nextRotation = rotation;
				return;
			}
			RichFunnel richFunnel = currentPart as RichFunnel;
			bool flag = base.isStopped || (reachedDestination && whenCloseToDestination == CloseToDestinationMode.Stop);
			if (rvoController != null)
			{
				rvoDensityBehavior.Update(rvoController.enabled, reachedDestination, ref flag, ref rvoController.priorityMultiplier, ref rvoController.flowFollowingStrength, simulatedPosition);
			}
			if (richFunnel != null && !flag)
			{
				TraverseFunnel(richFunnel, deltaTime, out nextPosition, out nextRotation);
				return;
			}
			velocity2D -= Vector2.ClampMagnitude(velocity2D, acceleration * deltaTime);
			FinalMovement(simulatedPosition, deltaTime, float.PositiveInfinity, 1f, out nextPosition, out nextRotation);
			if (richFunnel == null || base.isStopped)
			{
				steeringTarget = simulatedPosition;
			}
		}

		private void TraverseFunnel(RichFunnel fn, float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			Vector3 vector = UpdateTarget(fn);
			float elevation;
			Vector2 vector2 = movementPlane.ToPlane(vector, out elevation);
			if (Time.frameCount % 5 == 0 && wallForce > 0f && wallDist > 0f)
			{
				wallBuffer.Clear();
				fn.FindWalls(wallBuffer, wallDist);
			}
			steeringTarget = nextCorners[0];
			Vector2 vector3 = movementPlane.ToPlane(steeringTarget);
			Vector2 vector4 = vector3 - vector2;
			Vector2 vector5 = VectorMath.Normalize(vector4, out distanceToSteeringTarget);
			Vector2 vector6 = CalculateWallForce(vector2, elevation, vector5);
			Vector2 targetVelocity;
			if (approachingPartEndpoint)
			{
				targetVelocity = ((slowdownTime > 0f) ? Vector2.zero : (vector5 * maxSpeed));
				vector6 *= Math.Min(distanceToSteeringTarget / 0.5f, 1f);
				if (distanceToSteeringTarget <= endReachedDistance)
				{
					NextPart();
				}
			}
			else
			{
				targetVelocity = (((nextCorners.Count > 1) ? movementPlane.ToPlane(nextCorners[1]) : (vector2 + 2f * vector4)) - vector3).normalized * maxSpeed;
			}
			Vector2 forwardsVector = movementPlane.ToPlane(simulatedRotation * ((orientation == OrientationMode.YAxisForward) ? Vector3.up : Vector3.forward));
			Vector2 vector7 = MovementUtilities.CalculateAccelerationToReachPoint(vector3 - vector2, targetVelocity, velocity2D, acceleration, rotationSpeed, maxSpeed, forwardsVector);
			velocity2D += (vector7 + vector6 * wallForce) * deltaTime;
			float num = distanceToSteeringTarget + Vector3.Distance(steeringTarget, fn.exactEnd);
			float speedLimitFactor = ((num < maxSpeed * slowdownTime) ? Mathf.Sqrt(num / (maxSpeed * slowdownTime)) : 1f);
			FinalMovement(vector, deltaTime, num, speedLimitFactor, out nextPosition, out nextRotation);
		}

		private void FinalMovement(Vector3 position3D, float deltaTime, float distanceToEndOfPath, float speedLimitFactor, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			Vector2 forward = movementPlane.ToPlane(simulatedRotation * ((orientation == OrientationMode.YAxisForward) ? Vector3.up : Vector3.forward));
			ApplyGravity(deltaTime);
			velocity2D = MovementUtilities.ClampVelocity(velocity2D, maxSpeed, speedLimitFactor, slowWhenNotFacingTarget && enableRotation, preventMovingBackwards, forward);
			bool avoidingOtherAgents = false;
			if (rvoController != null && rvoController.enabled)
			{
				Vector3 pos = position3D + movementPlane.ToWorld(Vector2.ClampMagnitude(velocity2D, distanceToEndOfPath));
				rvoController.SetTarget(pos, velocity2D.magnitude, maxSpeed, endOfPath);
				avoidingOtherAgents = rvoController.AvoidingAnyAgents;
			}
			Vector2 vector = (lastDeltaPosition = CalculateDeltaToMoveThisFrame(position3D, distanceToEndOfPath, deltaTime));
			if (enableRotation)
			{
				float threshold = radius * tr.localScale.x * 0.2f;
				float num = MovementUtilities.FilterRotationDirection(ref rotationFilterState, ref rotationFilterState2, vector, threshold, deltaTime, avoidingOtherAgents);
				nextRotation = SimulateRotationTowards(rotationFilterState, rotationSpeed * deltaTime * num, rotationSpeed * deltaTime);
			}
			else
			{
				nextRotation = simulatedRotation;
			}
			nextPosition = position3D + movementPlane.ToWorld(vector, verticalVelocity * deltaTime);
		}

		protected override Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			if (richPath != null && richPath.GetCurrentPart() is RichFunnel richFunnel)
			{
				Vector3 vector = richFunnel.ClampToNavmesh(position);
				if (rvoController != null && rvoController.enabled)
				{
					rvoController.SetObstacleQuery(richFunnel.CurrentNode);
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

		private Vector2 CalculateWallForce(Vector2 position, float elevation, Vector2 directionToTarget)
		{
			if (wallForce <= 0f || wallDist <= 0f)
			{
				return Vector2.zero;
			}
			float num = 0f;
			float num2 = 0f;
			Vector3 vector = movementPlane.ToWorld(position, elevation);
			for (int i = 0; i < wallBuffer.Count; i += 2)
			{
				float sqrMagnitude = (VectorMath.ClosestPointOnSegment(wallBuffer[i], wallBuffer[i + 1], vector) - vector).sqrMagnitude;
				if (!(sqrMagnitude > wallDist * wallDist))
				{
					Vector2 normalized = movementPlane.ToPlane(wallBuffer[i + 1] - wallBuffer[i]).normalized;
					float num3 = Vector2.Dot(directionToTarget, normalized);
					float num4 = 1f - Math.Max(0f, 2f * (sqrMagnitude / (wallDist * wallDist)) - 1f);
					if (num3 > 0f)
					{
						num2 = Math.Max(num2, num3 * num4);
					}
					else
					{
						num = Math.Max(num, (0f - num3) * num4);
					}
				}
			}
			return new Vector2(directionToTarget.y, 0f - directionToTarget.x) * (num2 - num);
		}

		protected virtual IEnumerator TraverseSpecial(RichSpecial link)
		{
			traversingOffMeshLink = true;
			velocity2D = Vector3.zero;
			IEnumerator routine = ((onTraverseOffMeshLink != null) ? onTraverseOffMeshLink(link) : TraverseOffMeshLinkFallback(link));
			yield return StartCoroutine(routine);
			traversingOffMeshLink = false;
			NextPart();
			if (delayUpdatePath)
			{
				delayUpdatePath = false;
				if (base.canSearch)
				{
					SearchPath();
				}
			}
		}

		protected IEnumerator TraverseOffMeshLinkFallback(RichSpecial link)
		{
			float duration = ((maxSpeed > 0f) ? (Vector3.Distance(link.second.position, link.first.position) / maxSpeed) : 1f);
			float startTime = Time.time;
			while (true)
			{
				Vector3 vector = Vector3.Lerp(link.first.position, link.second.position, Mathf.InverseLerp(startTime, startTime + duration, Time.time));
				if (updatePosition)
				{
					tr.position = vector;
				}
				else
				{
					simulatedPosition = vector;
				}
				if (!(Time.time >= startTime + duration))
				{
					yield return null;
					continue;
				}
				break;
			}
		}

		public override void DrawGizmos()
		{
			base.DrawGizmos();
			if (tr != null)
			{
				Vector3 a = base.position;
				for (int i = 0; i < nextCorners.Count; i++)
				{
					Draw.Line(a, nextCorners[i], GizmoColorPath);
					a = nextCorners[i];
				}
			}
		}
	}
}
