using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class ArcadeSprite : PhaserGameObject
{
	private SpriteRenderer _spriteRenderer;

	private Transform _cachedTrans;

	public SpriteRenderer Rend => null;

	private Transform CachedTrans => null;

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

	public float2 cachedPosition
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return default(float2);
		}
	}

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

	public float2 displaySize => default(float2);

	public float2 displaySizeSafe => default(float2);

	public bool flipX => false;

	public bool flipY => false;

	public float2 origin => default(float2);

	public float2 size => default(float2);

	public PhaserScene scene => null;

	public int depth => 0;

	public override Rect? frame => null;

	private static bool AreValuesBroken(Vector3 pos, float validRange = 100000f)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int GetFinalDepthRelative(int sortOrderOffset = 0)
	{
		return 0;
	}

	protected void CheckRenderer()
	{
	}

	public void SetArcadeSpriteRenderer(SpriteRenderer spriteRenderer)
	{
	}

	public void ForceInit()
	{
	}

	public float2 getCenter()
	{
		return default(float2);
	}

	public ArcadeSprite setOrigin(float oX = 0.5f, float? oY = null)
	{
		return null;
	}

	public void setOriginFromFrame()
	{
	}

	public ArcadeSprite setScale(float xScale, float? yScale = null)
	{
		return null;
	}

	public ArcadeSprite setDepth(int depth)
	{
		return null;
	}

	public ArcadeSprite setDepth(float depth)
	{
		return null;
	}

	public ArcadeSprite setFlipX(bool flipX)
	{
		return null;
	}

	public ArcadeSprite setFlipY(bool flipY)
	{
		return null;
	}

	public ArcadeSprite setVisible(bool visible)
	{
		return null;
	}

	public ArcadeSprite setFrame(Sprite sprite)
	{
		return null;
	}

	public ArcadeSprite setFrameIncludingOriginalSize(Sprite sprite, float2 originalSize)
	{
		return null;
	}

	public ArcadeSprite setAlpha(float alpha)
	{
		return null;
	}

	public ArcadeSprite setTint(uint tint)
	{
		return null;
	}

	public ArcadeSprite setColor(Color color)
	{
		return null;
	}

	public ArcadeSprite setTintFill(bool isEnabled, int tintColor)
	{
		return null;
	}

	public ArcadeSprite setTintFill(bool isEnabled, uint tintColor)
	{
		return null;
	}

	public ArcadeSprite setTintFill(bool isEnabled, Color? tintColor = null)
	{
		return null;
	}

	public ArcadeSprite setBounce(float2 bounce)
	{
		return null;
	}

	public void setVelocity(float xVel, float? yVel = null)
	{
	}

	public void setVelocity(Vector2 velocity)
	{
	}

	public void setCollideWorldBounds(bool value, float? bounceX = null, float? bounceY = null)
	{
	}
}
