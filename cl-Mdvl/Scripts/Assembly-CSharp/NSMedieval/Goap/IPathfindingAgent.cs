using System;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IPathfindingAgent : IGoapAgentOwner, IGameDisposable, IDisposable
	{
		PathfinderAgentDriver PathDriver { get; }

		WalkableModel WalkableModel { get; }

		PathTraversalProvider PathTraversalProvider { get; }

		Vector3 GetPosition();

		Vec3Int GetGridPosition();

		float GetMovementSpeed();

		void UpdatePosition(Vector3 position);

		void UpdateRotation(Quaternion rotation);

		Quaternion GetRotation();

		void FaceObject(Vector3 objectPosition);

		MapNode GetNode();

		void SetWalkableModel(WalkableModel restoreWalkableModel);
	}
}
