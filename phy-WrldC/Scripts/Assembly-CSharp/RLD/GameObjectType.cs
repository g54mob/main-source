using System;

namespace RLD
{
	[Flags]
	public enum GameObjectType
	{
		Mesh = 1,
		Terrain = 2,
		Sprite = 4,
		Camera = 8,
		Light = 0x10,
		ParticleSystem = 0x20,
		Empty = 0x40
	}
}
