using System;

[Flags]
public enum SteeringBehaviorTypes
{
	None = 0,
	Seek = 1,
	Arrive = 2,
	LazyAvoidance = 4,
	WallAvoidance = 8,
	ObstacleAvoidance = 0x20
}
