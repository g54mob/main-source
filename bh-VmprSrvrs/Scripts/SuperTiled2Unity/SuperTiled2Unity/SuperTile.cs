using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SuperTiled2Unity
{
	public class SuperTile : TileBase
	{
		private static readonly Matrix4x4 HorizontalFlipMatrix;

		private static readonly Matrix4x4 VerticalFlipMatrix;

		private static readonly Matrix4x4 DiagonalFlipMatrix;

		private static readonly Matrix4x4 Rotate60Matrix;

		private static readonly Matrix4x4 Rotate120Matrix;

		[ReadOnly]
		public int m_TileId;

		[ReadOnly]
		public Sprite m_Sprite;

		[ReadOnly]
		public Sprite[] m_AnimationSprites;

		[ReadOnly]
		public string m_Type;

		[ReadOnly]
		public float m_Width;

		[ReadOnly]
		public float m_Height;

		[ReadOnly]
		public float m_TileOffsetX;

		[ReadOnly]
		public float m_TileOffsetY;

		[ReadOnly]
		public ObjectAlignment m_ObjectAlignment;

		[ReadOnly]
		public TileRenderSize m_TileRenderSize;

		[ReadOnly]
		public FillMode m_FillMode;

		[ReadOnly]
		public Tile.ColliderType m_ColliderType;

		public List<CustomProperty> m_CustomProperties;

		public List<CollisionObject> m_CollisionObjects;

		public static SuperTile CreateSuperTile()
		{
			return null;
		}

		public Matrix4x4 GetTransformMatrix(FlipFlags flipFlags, SuperMap superMap)
		{
			return default(Matrix4x4);
		}

		public void GetTRS(FlipFlags flags, MapOrientation orientation, SuperMap superMap, out Vector3 xfTranslate, out Vector3 xfRotate, out Vector3 xfScale)
		{
			xfTranslate = default(Vector3);
			xfRotate = default(Vector3);
			xfScale = default(Vector3);
		}

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}

		public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
		{
			return false;
		}

		private Matrix4x4 CalculateTileOffsetMatrix()
		{
			return default(Matrix4x4);
		}

		private Matrix4x4 CalculateRenderSizeMatrix(SuperMap superMap)
		{
			return default(Matrix4x4);
		}

		private Matrix4x4 CacluateFlipMatrix(FlipFlags flags, SuperMap superMap)
		{
			return default(Matrix4x4);
		}
	}
}
