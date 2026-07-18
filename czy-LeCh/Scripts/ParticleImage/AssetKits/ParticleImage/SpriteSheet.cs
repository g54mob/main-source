using UnityEngine;

namespace AssetKits.ParticleImage
{
	public struct SpriteSheet
	{
		public Vector2 size;

		public Vector2 pos;

		public SpriteSheet(Vector2 s, Vector2 p)
		{
			size = s;
			pos = p;
		}
	}
}
