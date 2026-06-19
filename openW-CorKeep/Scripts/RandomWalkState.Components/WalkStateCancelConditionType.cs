using System;

[Flags]
public enum WalkStateCancelConditionType : byte
{
	None = 0,
	ReachedGoal = 1,
	Time = 2,
	WalkedIntoWall = 4,
	All = 7
}
