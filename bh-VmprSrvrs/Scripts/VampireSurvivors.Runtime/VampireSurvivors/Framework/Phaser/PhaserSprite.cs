using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Phaser
{
	public class PhaserSprite : GameMonoBehaviour
	{
		private SpriteRenderer _spriteRenderer;

		private SpriteAnimation _spriteAnimation;

		[HideInInspector]
		public float _originX;

		[HideInInspector]
		public float _originY;

		public SpriteAnimation Anim => null;

		public SpriteAnimation anims => null;

		public SpriteRenderer Rend => null;

		public Bounds Bounds => default(Bounds);

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float2 position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(float2);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		public float Width => 0f;

		public float Height => 0f;

		public bool flipX => false;

		public bool flipY => false;

		public float scale => 0f;

		public float angle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Alpha => 0f;

		protected virtual void Awake()
		{
		}

		public void InternalForceInit()
		{
		}

		public PhaserSprite setName(string newName)
		{
			return null;
		}

		public PhaserSprite setOrigin(float2 origin)
		{
			return null;
		}

		public PhaserSprite setOrigin(float originX = 0.5f, float? originY = null)
		{
			return null;
		}

		public PhaserSprite setScale(float xScale, float? yScale = null)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetFinalDepthRelative(int sortOrderOffset = 0)
		{
			return 0;
		}

		public PhaserSprite setDepth(float depth)
		{
			return null;
		}

		public PhaserSprite setDepth(int depth)
		{
			return null;
		}

		public PhaserSprite setFlipX(bool flipX)
		{
			return null;
		}

		public PhaserSprite setFlipY(bool flipY)
		{
			return null;
		}

		public PhaserSprite setVisible(bool visible)
		{
			return null;
		}

		public PhaserSprite setFrame(string spriteName, string textureName)
		{
			return null;
		}

		public string getFrameName()
		{
			return null;
		}

		public PhaserSprite setFrame(Sprite sprite)
		{
			return null;
		}

		public PhaserSprite setAlpha(float alpha)
		{
			return null;
		}

		public PhaserSprite setTint(int tintColor)
		{
			return null;
		}

		public PhaserSprite setTint(uint topLeft, uint topRight, uint bottomLeft, uint bottomRight, BlendMode blendMode = BlendMode.Normal)
		{
			return null;
		}

		public PhaserSprite setTint(uint tintColor)
		{
			return null;
		}

		public PhaserSprite setTintFill(bool isEnabled, uint tintColor)
		{
			return null;
		}

		public PhaserSprite setTintFill(bool isEnabled, Color? tintColor = null)
		{
			return null;
		}

		public PhaserSprite setBlendMode(BlendMode blendMode)
		{
			return null;
		}

		public PhaserSprite setPosition(float2 value)
		{
			return null;
		}

		public PhaserSprite setPosition(float x, float y)
		{
			return null;
		}

		public PhaserSprite setLocalPosition(float2 value)
		{
			return null;
		}

		public PhaserSprite setLocalPosition(float x, float y)
		{
			return null;
		}

		public PhaserSprite setParent(Transform parent, bool keepWorldPos = true)
		{
			return null;
		}

		public PhaserSprite setDrawModeSliced(float width, float height)
		{
			return null;
		}

		public PhaserSprite setDrawModeSimple()
		{
			return null;
		}

		public void destroy()
		{
		}

		public PhaserSprite SetAsTiledSprite()
		{
			return null;
		}

		public PhaserSprite SetTileSize(float width, float height)
		{
			return null;
		}

		public PhaserSprite SetTileWidth(float width)
		{
			return null;
		}

		public PhaserSprite SetTileHeight(float height)
		{
			return null;
		}

		public PhaserSprite SetMaterial(MaterialType material)
		{
			return null;
		}

		private void EnsureSpriteRenderer()
		{
		}
	}
}
