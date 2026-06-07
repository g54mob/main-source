using System;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.RVO
{
	public interface IAgent
	{
		int AgentIndex { get; }

		Vector3 Position { get; set; }

		Vector3 CalculatedTargetPoint { get; }

		bool AvoidingAnyAgents { get; }

		float CalculatedSpeed { get; }

		SimpleMovementPlane MovementPlane { get; set; }

		bool Locked { get; set; }

		float Radius { get; set; }

		float Height { get; set; }

		float AgentTimeHorizon { get; set; }

		float ObstacleTimeHorizon { get; set; }

		int MaxNeighbours { get; set; }

		int NeighbourCount { get; }

		RVOLayer Layer { get; set; }

		RVOLayer CollidesWith { get; set; }

		float FlowFollowingStrength { get; set; }

		AgentDebugFlags DebugFlags { get; set; }

		float Priority { get; set; }

		int HierarchicalNodeIndex { get; set; }

		Action PreCalculationCallback { set; }

		Action DestroyedCallback { set; }

		ReachedEndOfPath CalculatedEffectivelyReachedDestination { get; }

		void SetTarget(Vector3 targetPoint, float desiredSpeed, float maxSpeed, Vector3 endOfPath);

		void SetCollisionNormal(Vector3 normal);

		void ForceSetVelocity(Vector3 velocity);

		void SetObstacleQuery(GraphNode sourceNode);
	}
}
