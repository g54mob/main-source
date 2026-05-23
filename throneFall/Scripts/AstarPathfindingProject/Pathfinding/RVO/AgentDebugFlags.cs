using System;

namespace Pathfinding.RVO
{
	[Flags]
	public enum AgentDebugFlags : byte
	{
		Nothing = 0,
		ObstacleVOs = 1,
		AgentVOs = 2,
		ReachedState = 4,
		DesiredVelocity = 8,
		ChosenVelocity = 0x10,
		Obstacles = 0x20,
		ForwardClearance = 0x40
	}
}
