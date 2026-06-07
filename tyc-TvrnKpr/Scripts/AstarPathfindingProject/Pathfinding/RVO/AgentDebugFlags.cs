using System;

namespace Pathfinding.RVO
{
	[Flags]
	public enum AgentDebugFlags : byte
	{
		Nothing = 0,
		ObstacleVelocityObstacles = 1,
		AgentVelocityObstacles = 2,
		ReachedState = 4,
		DesiredVelocity = 8,
		ChosenVelocity = 0x10,
		Obstacles = 0x20,
		ForwardClearance = 0x40,
		[Obsolete("Renamed to ObstacleVelocityObstacles")]
		ObstacleVOs = 1,
		[Obsolete("Renamed to AgentVelocityObstacles")]
		AgentVOs = 2
	}
}
