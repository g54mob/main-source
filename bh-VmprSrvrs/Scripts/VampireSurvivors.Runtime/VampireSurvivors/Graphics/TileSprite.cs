using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Graphics
{
	public class TileSprite : GameMonoBehaviour
	{
		private SpriteRenderer _spriteRenderer;

		private SpriteScroller _spriteScroller;

		private float _xScrollSpeed;

		private float _yScrollSpeed;

		private float _xScrollOffset;

		private float _yScrollOffset;

		private float _tileWidth;

		private float _tileHeight;

		private float _tileScaleX;

		private float _tileScaleY;

		public SpriteRenderer SpriteRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SpriteScroller SpriteScroller
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float TileWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TileHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TileScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TileScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void SetLocalY(float yPos)
		{
		}

		public void SetFlipY(bool flip)
		{
		}

		public void SetFrame(string frameName, string textureName)
		{
		}

		public void SetScrollOffsetX(float pos, bool cumulative = true)
		{
		}

		public void SetScrollOffsetY(float pos, bool cumulative = true)
		{
		}

		public void SetScrollSpeedX(float speed)
		{
		}

		public void SetScrollSpeedY(float speed)
		{
		}

		public void SetVisible(bool visible)
		{
		}

		public void destroy()
		{
		}

		public TileSprite SetDepth(int depth)
		{
			return null;
		}

		public TileSprite SetTileScale(float xScale, float? yScale = null)
		{
			return null;
		}

		public TileSprite SetName(string newName)
		{
			return null;
		}

		public TileSprite SetMaterial(MaterialType materialType)
		{
			return null;
		}
	}
}
