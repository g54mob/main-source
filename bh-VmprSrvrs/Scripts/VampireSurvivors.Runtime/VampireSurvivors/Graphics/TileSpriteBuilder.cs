using UnityEngine;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Graphics
{
	public class TileSpriteBuilder
	{
		private Vector2 _pos;

		private Vector3 _scale;

		private string _textureName;

		private string _spriteName;

		private Vector2? _spritePivot;

		private float _depth;

		private float _depthMul;

		private float _alpha;

		private Transform _parent;

		private string _name;

		private float _tileWidth;

		private float _tileHeight;

		private BlendMode _blendMode;

		public TileSpriteBuilder SetPosition(float x, float y)
		{
			return null;
		}

		public TileSpriteBuilder SetScale(float scale)
		{
			return null;
		}

		public TileSpriteBuilder SetScale(float xScale, float yScale)
		{
			return null;
		}

		public TileSpriteBuilder SetSpriteInfo(string textureName, string spriteName)
		{
			return null;
		}

		public TileSpriteBuilder SetSpritePivot(Vector2? pivot)
		{
			return null;
		}

		public TileSpriteBuilder SetDepth(float depth, float depthMul = 1f)
		{
			return null;
		}

		public TileSpriteBuilder SetAlpha(float alpha)
		{
			return null;
		}

		public TileSpriteBuilder SetParent(Transform parent)
		{
			return null;
		}

		public TileSpriteBuilder SetName(string name)
		{
			return null;
		}

		public TileSpriteBuilder SetTileSize(float width, float height)
		{
			return null;
		}

		public TileSpriteBuilder SetBlendMode(BlendMode blendMode)
		{
			return null;
		}

		public TileSprite Build()
		{
			return null;
		}

		private void GenerateSpriteRenderer(TileSprite tileSprite)
		{
		}

		private void GenerateSpriteScroller(TileSprite tileSprite)
		{
		}
	}
}
