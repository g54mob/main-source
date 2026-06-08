using System;

namespace XRL.World
{
	[Serializable]
	public enum MissileMapType
	{
		Empty = 0,
		Wall = 1,
		VeryLightCover = 2,
		LightCover = 3,
		MediumCover = 4,
		HeavyCover = 5,
		VeryHeavyCover = 6,
		Hostile = 7,
		Friendly = 8
	}
}
