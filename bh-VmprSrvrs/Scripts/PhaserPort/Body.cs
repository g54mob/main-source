using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Profiling;

public class Body : BaseBody, ArcadeObject
{
	public float2 _scale;

	public float2 _prev;

	public float2 _prevFrame;

	public bool _allowRotation;

	public float _rotation;

	public float2 _sourceSize;

	public float2 _acceleration;

	public bool _allowDrag;

	public float2 _drag;

	public float2? _worldBounce;

	public ArcadeBodyBounds _customBoundsRectangle;

	public float _maxSpeed;

	public float2 _friction;

	public bool _useDamping;

	public float _angularVelocity;

	public float _angularAcceleration;

	public float _angularDrag;

	public float _maxAngular;

	public float _angle;

	public float _speed;

	private static readonly ProfilerMarker s_postUpdateMarker;

	public Body body => null;

	public Body()
	{
	}

	public Body(World world, PhaserGameObject gameObject)
	{
	}

	public override void Reset(World world, PhaserGameObject gameObject, bool initial = false)
	{
	}

	private void updateBounds()
	{
	}

	public void updateFromGameObject()
	{
	}

	private void resetFlags(bool clear = false)
	{
	}

	public void preUpdate(bool willStep, float delta)
	{
	}

	public void update(float delta)
	{
	}

	public override void postUpdate()
	{
	}

	public override Body setBoundsRectangle(ArcadeBodyBounds bounds)
	{
		return null;
	}

	public bool checkWorldBounds()
	{
		return false;
	}

	public Body stop()
	{
		return null;
	}

	public ArcadeBodyBounds getBounds(ArcadeBodyBounds toFill)
	{
		return null;
	}

	public bool hitTest(float x, float y)
	{
		return false;
	}

	public bool onFloor()
	{
		return false;
	}

	public bool onCeiling()
	{
		return false;
	}

	public bool onWall()
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override float deltaAbsX()
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override float deltaAbsY()
	{
		return 0f;
	}

	public float deltaX()
	{
		return 0f;
	}

	public float deltaY()
	{
		return 0f;
	}

	public override void drawDebug()
	{
	}

	public override bool willDrawDebug()
	{
		return false;
	}

	public Body setCollideWorldBounds(bool? shouldCollide = null, float? bounceX = null, float? bounceY = null, bool? onWorldBounds = null)
	{
		return null;
	}

	public Body setVelocity(float x, float y)
	{
		return null;
	}

	public Body setVelocityX(float value)
	{
		return null;
	}

	public Body setVelocityY(float value)
	{
		return null;
	}

	public Body setMaxSpeed(float value)
	{
		return null;
	}

	public Body setBounce(float x, float y)
	{
		return null;
	}

	public Body setBounceX(float value)
	{
		return null;
	}

	public Body setBounceY(float value)
	{
		return null;
	}

	public Body setAcceleration(float x, float y)
	{
		return null;
	}

	public Body setAccelerationX(float value)
	{
		return null;
	}

	public Body setAccelerationY(float value)
	{
		return null;
	}

	public Body setAllowDrag(bool value = true)
	{
		return null;
	}

	public Body setAllowGravity(bool value = true)
	{
		return null;
	}

	public Body setAllowRotation(bool value = true)
	{
		return null;
	}

	public Body setDrag(float x, float y)
	{
		return null;
	}

	public Body setDamping(bool value)
	{
		return null;
	}

	public Body setDragX(float value)
	{
		return null;
	}

	public Body setDragY(float value)
	{
		return null;
	}

	public Body setGravity(float x, float y)
	{
		return null;
	}

	public Body setGravityX(float value)
	{
		return null;
	}

	public Body setGravityY(float value)
	{
		return null;
	}

	public Body setFriction(float x, float y)
	{
		return null;
	}

	public Body setFrictionX(float value)
	{
		return null;
	}

	public Body setFrictionY(float value)
	{
		return null;
	}

	public Body setAngularVelocity(float value)
	{
		return null;
	}

	public Body setAngularAcceleration(float value)
	{
		return null;
	}

	public Body setAngularDrag(float value)
	{
		return null;
	}

	public Body setMass(float value)
	{
		return null;
	}

	public Body setImmovable(bool value = true)
	{
		return null;
	}

	public Body setEnable(bool value = true)
	{
		return null;
	}

	public override BaseBody setCircle(float radius, float? offsetX = null, float? offsetY = null, bool worldSpace = false)
	{
		return null;
	}

	public override BaseBody setSize(float? width, float? height, bool center = true)
	{
		return null;
	}
}
