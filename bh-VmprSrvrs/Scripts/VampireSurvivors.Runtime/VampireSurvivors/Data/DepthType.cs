using System;

namespace VampireSurvivors.Data
{
	[Serializable]
	public enum DepthType
	{
		Floor = -2000,
		FloorOverlay = -1999,
		FakeWalls = -1998,
		Walls = -1997,
		PlayerWall = -1996,
		Obstacle = -1995,
		Decals = -1994,
		Overlay1 = 1,
		Shadows = 1994,
		ShadowDecals = 1995,
		Spawning = 10000
	}
}
