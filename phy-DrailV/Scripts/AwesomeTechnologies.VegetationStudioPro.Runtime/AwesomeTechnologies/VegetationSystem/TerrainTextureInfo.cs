using System;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class TerrainTextureInfo
	{
		public Texture2D Texture;

		public Texture2D TextureNormals;

		public Texture2D TextureOcclusion;

		public Texture2D TextureHeightMap;

		public Vector2 TileSize = new Vector2(15f, 15f);

		public Vector2 Offset;

		public TerrainLayer TerrainLayer;
	}
}
