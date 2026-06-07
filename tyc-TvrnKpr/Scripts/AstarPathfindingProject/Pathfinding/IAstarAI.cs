using System;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public interface IAstarAI
	{
		float radius { get; set; }

		float height { get; set; }

		Vector3 position { get; }

		Quaternion rotation { get; set; }

		float maxSpeed { get; set; }

		Vector3 velocity { get; }

		Vector3 desiredVelocity { get; }

		Vector3 desiredVelocityWithoutLocalAvoidance { get; set; }

		float remainingDistance { get; }

		bool reachedDestination { get; }

		bool reachedEndOfPath { get; }

		Vector3 endOfPath { get; }

		Vector3 destination { get; set; }

		bool canSearch { get; set; }

		bool simulateMovement { get; set; }

		[Obsolete("Renamed to simulateMovement")]
		bool canMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool hasPath { get; }

		bool pathPending { get; }

		bool updatePosition { get; set; }

		bool updateRotation { get; set; }

		bool isStopped { get; set; }

		Vector3 steeringTarget { get; }

		Action onSearchPath { get; set; }

		NativeMovementPlane movementPlane { get; }

		void GetRemainingPath(List<Vector3> buffer, out bool stale);

		void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale);

		void SearchPath();

		void SetPath(Path path, bool updateDestinationFromPath = true);

		void Teleport(Vector3 newPosition, bool clearPath = true);

		void Move(Vector3 deltaPosition);

		void MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation);

		void FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation);
	}
}
