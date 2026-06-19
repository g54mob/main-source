using System;
using UnityEngine;

namespace PugTilemap.Quads
{
	[Serializable]
	public struct Quad
	{
		public bool hidden;

		public readonly Vector3Int pos;

		public Rect spriteUV;

		public int adjacentTilesMask;

		public int state;

		public bool hasSprite => spriteUV.width > 0f;

		public Quad(Vector3Int pos)
		{
			hidden = false;
			this.pos = pos;
			spriteUV = Rect.zero;
			adjacentTilesMask = 0;
			state = 0;
		}

		public void Clear()
		{
			spriteUV = Rect.zero;
		}
	}
}
