using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public abstract class BaseBody : RBush.IRectangular
{
	public SpriteRenderer _spriteRenderer;

	public ArcadeTransform _transform;

	public World _world;

	public PhaserGameObject _gameObject;

	public bool _enable;

	public bool _isCircle;

	public float _radius;

	public float2 _offset;

	public float2 _position;

	public float2 _size;

	public float2 _halfSize;

	public float2 _center;

	public float2 _velocity;

	public bool _allowGravity;

	public float2 _gravity;

	public float2 _bounce;

	public bool _onWorldBounds;

	public bool _onCollide;

	public bool _onOverlap;

	public float _mass;

	public bool _immovable;

	public bool _pushable;

	public bool _embedded;

	protected bool _collideWorldBounds;

	public ArcadeBodyCollision _checkCollision;

	public ArcadeBodyCollision _blocked;

	public PhysicsType _physicsType;

	public float _dx;

	public float _dy;

	protected Transform _cachedUnityTransform;

	protected Transform _cachedSpriteUnityTransform;

	public Transform CachedUnityTransform => null;

	public Transform CachedSpriteUnityTransform => null;

	public float x
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float y
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float left => 0f;

	public float right => 0f;

	public float top => 0f;

	public float bottom => 0f;

	public float PhaserRadius => 0f;

	public float WorldRadius => 0f;

	public virtual void Reset(World world, PhaserGameObject gameObject, bool initial = false)
	{
	}

	public virtual void drawDebug()
	{
	}

	public virtual bool willDrawDebug()
	{
		return false;
	}

	public virtual void postUpdate()
	{
	}

	public bool RectangleContains(float x, float y)
	{
		return false;
	}

	public bool CircleContains(float x, float y)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public virtual float deltaAbsX()
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public virtual float deltaAbsY()
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void updateCenter()
	{
	}

	public void destroy()
	{
	}

	public void processX(float x, float? vx, bool left = false, bool right = false)
	{
	}

	public void processY(float y, float? vy, bool up = false, bool down = false)
	{
	}

	public virtual BaseBody setCircle(float radius, float? offsetX = null, float? offsetY = null, bool worldSpace = false)
	{
		return null;
	}

	public virtual BaseBody setOffset(float x, float? y = null)
	{
		return null;
	}

	public virtual BaseBody setSize(float? width, float? height, bool center = true)
	{
		return null;
	}

	public virtual Body setBoundsRectangle(ArcadeBodyBounds bounds)
	{
		return null;
	}
}
