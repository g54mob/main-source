using System;

namespace Pathfinding
{
	[Flags]
	public enum GraphUpdateThreading
	{
		UnityThread = 0,
		UnityInit = 2,
		UnityPost = 4
	}
}
