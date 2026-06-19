using UnityEngine;

namespace TH20
{
	public class FogOfWarLevelTextureDefinition : ScriptableObjectWithID
	{
		public int TileHeight;

		public int TileWidth;

		public int MaxDistance;

		public Vector2Int Anchor;

		public Texture2D FogOfWarTexture;

		public bool UseCameraBoundingBoxExtents;
	}
}
