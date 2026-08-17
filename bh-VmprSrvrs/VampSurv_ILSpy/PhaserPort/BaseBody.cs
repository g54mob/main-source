using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
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

	public Transform CachedUnityTransform => _cachedUnityTransform;

	public Transform CachedSpriteUnityTransform
	{
		get
		{
			Transform cachedSpriteUnityTransform = _cachedSpriteUnityTransform;
			if ((object)_cachedSpriteUnityTransform == null || ((UnityEngine.Object)cachedSpriteUnityTransform).m_CachedPtr == (IntPtr)0)
			{
				if ((object)_spriteRenderer != null)
				{
					Transform transform = _spriteRenderer.transform;
					_cachedSpriteUnityTransform = transform;
					if ((object)_cachedSpriteUnityTransform != null)
					{
						_cachedSpriteUnityTransform.hasChanged = true;
						goto IL_00aa;
					}
				}
				return (Transform)(object)new NullReferenceException();
			}
			goto IL_00aa;
			IL_00aa:
			return _cachedSpriteUnityTransform;
		}
	}

	public float x
	{
		get
		{
			//IL_0007: Expected F4, but got O
			return (float)_position;
		}
		set
		{
			//IL_000a: Expected O, but got F4
			_position = (float2)value;
		}
	}

	public float y
	{
		get
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
			return 0f;
		}
		set
		{
		}
	}

	public float left
	{
		get
		{
			//IL_0007: Expected F4, but got O
			return (float)_position;
		}
	}

	public float right => (float)_size + (float)_position;

	public float top
	{
		get
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
			return 0f;
		}
	}

	public float bottom
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+5C]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
			return num + 0f;
		}
	}

	public float PhaserRadius => _radius / 0.01f;

	public float WorldRadius
	{
		get
		{
			if ((object)_gameObject != null)
			{
				Transform transform = _gameObject.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					return (float)ret * _radius;
				}
			}
			throw new NullReferenceException();
		}
	}

	public virtual void Reset(World world, PhaserGameObject gameObject, bool initial = false)
	{
		//IL_0095: Expected O, but got I8
		//IL_01e1: Expected F4, but got O
		//IL_01ec: Expected O, but got I4
		//IL_0246: Expected O, but got I
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02c0: Expected O, but got F4
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02e2: Expected O, but got I4
		//IL_02f8: Expected O, but got I4
		//IL_0303: Expected O, but got I4
		//IL_030d: Expected F4, but got O
		//IL_0344: Expected O, but got I4
		Transform transform = gameObject.transform;
		_cachedUnityTransform = transform;
		SpriteRenderer attachedRenderer = gameObject.GetAttachedRenderer();
		_spriteRenderer = attachedRenderer;
		_world = world;
		_gameObject = gameObject;
		Transform transform2;
		if (_transform != null)
		{
			_transform.Reset(_cachedUnityTransform, _spriteRenderer, this);
			transform2 = null;
		}
		else
		{
			ArcadeTransform arcadeTransform = null;
			arcadeTransform.cachedLocalPosition = (float2)3323739136L;
			_ = 1176255488;
			arcadeTransform.Reset(_cachedUnityTransform, _spriteRenderer, this);
			_transform = arcadeTransform;
			transform2 = null;
		}
		ArcadeTransform transform3 = _transform;
		SpriteRenderer spriteRenderer = _spriteRenderer;
		_size = (float2)transform3.data;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v13 (ArcadeTransform)+14]");
		_ = 0;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			Sprite sprite = _spriteRenderer.sprite;
			if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
			{
				Transform transform4 = _spriteRenderer.transform;
				_cachedSpriteUnityTransform = transform4;
				_cachedSpriteUnityTransform.hasChanged = true;
				goto IL_01bc;
			}
		}
		_cachedSpriteUnityTransform = transform2;
		goto IL_01bc;
		IL_01bc:
		_cachedUnityTransform.hasChanged = true;
		_enable = true;
		_radius = (float)transform2;
		_offset = (float2)0;
		ArcadeTransform transform5 = _transform;
		float num = (float)_size * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v21 (ArcadeTransform)+4C]");
		_ = 0;
		_center = transform5.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v13 (ArcadeTransform)+1C]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v21 (ArcadeTransform)+54]");
		object obj = num2 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v13 (ArcadeTransform)+18]");
		object obj2 = 0 * transform5.scale;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v21 (ArcadeTransform)+4C]");
		object obj3 = 0 - obj;
		float2 position = (object)transform5.position - obj2;
		float2 halfSize = (float2)(num & -2147483649L);
		_halfSize = halfSize;
		_position = position;
		object obj4 = num >> 32;
		object obj5 = obj4 & -2147483649L;
		_velocity = (float2)0;
		_allowGravity = true;
		_gravity = (float2)0;
		_bounce = (float2)0;
		_dy = (float)transform2;
		_onWorldBounds = false;
		_onOverlap = false;
		_mass = 1f;
		_immovable = false;
		_checkCollision = (ArcadeBodyCollision)15;
		_physicsType = PhysicsType.STATIC_BODY;
	}

	public virtual void drawDebug()
	{
	}

	public virtual bool willDrawDebug()
	{
		return true;
	}

	public virtual void postUpdate()
	{
	}

	public bool RectangleContains(float x, float y)
	{
		//IL_000a: Invalid comparison between F4 and O
		//IL_0037: Invalid comparison between O and F4
		//IL_005b: Invalid comparison between F4 and I
		//IL_008c: Expected O, but got I
		//IL_0094: Invalid comparison between O and F4
		float2 position = _position;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
		{
			object obj = _size + _position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
				if (!(y < 0f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+5C]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
					object obj2 = num + 0;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y);
					return !flag;
				}
			}
		}
		return false;
	}

	public bool CircleContains(float x, float y)
	{
		float num = x - (float)_position;
		float num2 = y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		float num3 = num2 - 0f;
		float num4 = _radius * _radius;
		float num5 = num * num;
		float num6 = num3 * num3;
		float num7 = num5 + num6;
		bool flag = num4 < num7;
		return !flag;
	}

	[MethodImpl((MethodImplOptions)256)]
	public virtual float deltaAbsX()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	[MethodImpl((MethodImplOptions)256)]
	public virtual float deltaAbsY()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void updateCenter()
	{
		//IL_000c: Expected F4, but got O
		//IL_001e: Expected F4, but got I
		//IL_009c: Expected O, but got I
		MinX = (float)_position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		MinY = 0f;
		float maxX = (float)_size + (float)_position;
		MaxX = maxX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+5C]");
		float num = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		float maxY = num + 0f;
		MaxY = maxY;
		float2 center = _halfSize + _position;
		_center = center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+64]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		object obj = num2 + 0;
	}

	public void destroy()
	{
		bool flag = _world == null;
		_enable = false;
		if (!flag)
		{
			World world = _world;
			bool flag2 = ((HashSet<object>)(object)world._pendingAdd).Remove((object)this);
			bool flag3 = ((HashSet<object>)(object)world._pendingDestroy).AddIfNotPresent((object)this);
		}
	}

	public void processX(float x, float? vx, bool left = false, bool right = false)
	{
		//IL_002f: Expected O, but got F4
		//IL_004b: Expected F4, but got I
		//IL_00aa: Expected O, but got F4
		//IL_00c7: Expected O, but got I
		float num = x + (float)_position;
		_position = (float2)num;
		MinX = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		MinY = 0f;
		float maxX = num + (float)_size;
		MaxX = maxX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+5C]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		float maxY = num2 + 0f;
		MaxY = maxY;
		float num3 = num + (float)_halfSize;
		_center = (float2)num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+64]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		object obj = num4 + 0;
		if ((object)vx != null)
		{
			float2 velocity = default(float2);
			_velocity = velocity;
		}
	}

	public void processY(float y, float? vy, bool up = false, bool down = false)
	{
		//IL_0041: Expected F4, but got O
		float num = y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
		float num2 = (MinY = num + 0f);
		MinX = (float)_position;
		float maxX = (float)_size + (float)_position;
		MaxX = maxX;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+5C]");
		float maxY = num3 + 0f;
		MaxY = maxY;
		float2 center = _halfSize + _position;
		_center = center;
		float num4 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+64]");
		float num5 = num4 + 0f;
		if ((object)vy == null)
		{
		}
	}

	public virtual BaseBody setCircle(float radius, float? offsetX = null, float? offsetY = null, bool worldSpace = false)
	{
		//IL_01a0: Expected O, but got I4
		//IL_01c6: Expected O, but got I4
		//IL_052c: Invalid comparison between F4 and I4
		//IL_010e: Expected F4, but got O
		//IL_0117: Expected O, but got I4
		//IL_012c: Expected F4, but got I
		//IL_0135: Expected O, but got I4
		//IL_023e: Expected O, but got F4
		//IL_0267: Expected O, but got F4
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02cc: Expected O, but got F4
		//IL_02d8: Expected F4, but got O
		//IL_02ea: Expected F4, but got I
		//IL_035e: Expected O, but got I
		//IL_04da: Expected O, but got I4
		//IL_051e: Expected O, but got I4
		//IL_05ec->IL05b2: Incompatible stack heights: 1 vs 0
		//IL_0074->IL0412: Incompatible stack heights: 1 vs 0
		//IL_00c9->IL0412: Incompatible stack heights: 1 vs 0
		//IL_037d->IL0412: Incompatible stack heights: 2 vs 0
		//IL_00a0->IL0412: Incompatible stack heights: 1 vs 0
		//IL_00f5->IL0412: Incompatible stack heights: 1 vs 0
		//IL_03ac->IL0412: Incompatible stack heights: 2 vs 0
		//IL_03db->IL0412: Incompatible stack heights: 2 vs 0
		//IL_04df->IL058d: Incompatible stack heights: 2 vs 1
		//IL_0410->IL0410: Incompatible stack heights: 2 vs 0
		//IL_0523->IL05df: Incompatible stack heights: 2 vs 1
		object obj = default(object);
		float num;
		Transform transform2;
		Vector3 ret2;
		if (obj != null)
		{
			if ((object)_gameObject != null)
			{
				Transform transform = _gameObject.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					num = radius / (float)ret;
					bool flag2 = (object)offsetX == null;
					transform2 = (Transform)offsetX;
					if (flag2)
					{
						goto IL_058d;
					}
					if ((object)_gameObject != null)
					{
						Transform transform3 = _gameObject.transform;
						if ((object)transform3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v47 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v47 (UnityEngine.Transform)+10]");
							Transform.get_localScale_Injected((IntPtr)0, out ret2);
							transform2 = (Transform)1;
							goto IL_058d;
						}
					}
				}
			}
			goto IL_0412;
		}
		num = radius * 0.01f;
		bool flag4 = (object)offsetX == null;
		float num3 = default(float);
		float num2 = num3;
		float? num4 = offsetX;
		if (!flag4)
		{
			num2 = num3 * 0.01f;
			num4 = (float?)(object)1;
		}
		bool flag5 = (object)offsetY == null;
		transform2 = (Transform)num4;
		float? num5 = offsetY;
		float num6;
		float num7 = default(float);
		if (!flag5)
		{
			num6 = num7 * 0.01f;
			transform2 = (Transform)num4;
			num5 = (float?)(object)1;
			goto IL_056d;
		}
		goto IL_05b2;
		IL_058d:
		bool flag6 = (object)offsetY == null;
		num5 = offsetY;
		if (!flag6)
		{
			if ((object)_gameObject != null)
			{
				Transform transform4 = _gameObject.transform;
				if ((object)transform4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v38 (UnityEngine.Transform)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v38 (UnityEngine.Transform)+10]");
					Transform.get_localScale_Injected((IntPtr)0, out ret2);
					num5 = (float?)(object)1;
					goto IL_05df;
				}
			}
			goto IL_0412;
		}
		goto IL_05df;
		IL_0410:
		return this;
		IL_056d:
		if ((object)transform2 == null)
		{
			num2 = (float)_offset;
			transform2 = (Transform)1;
		}
		if ((object)num5 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+4C]");
			num6 = 0f;
			num5 = (float?)(object)1;
		}
		if (!(num > 0f))
		{
			_isCircle = false;
			goto IL_0410;
		}
		World world = _world;
		if (_world != null && world._staticTree != null)
		{
			RBush rBush = world._staticTree.remove(this);
			_radius = num;
			_halfSize = (float2)num;
			float num8 = num + num;
			_isCircle = true;
			_size = (float2)num8;
			bool flag8 = (object)transform2 == null;
			bool flag9 = (object)num5 == null;
			float num9 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = num9 ^ 0;
			World world2 = _world;
			_offset = (float2)num2;
			MinX = (float)_position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
			MinY = 0f;
			float maxX = num8 + (float)_position;
			MaxX = maxX;
			float num10 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
			float maxY = num10 + 0f;
			MaxY = maxY;
			float2 center = _halfSize + _position;
			_center = center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+64]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseBody)+54]");
			object obj3 = num11 + 0;
			if (_world != null)
			{
				RBush staticTree = world2._staticTree;
				if (world2._staticTree != null)
				{
					RBush.Node data = staticTree.data;
					if (staticTree.data != null)
					{
						int level = data.height - 1;
						world2._staticTree._insert((RBush.IRectangular)this, level, false);
						goto IL_0410;
					}
				}
			}
		}
		goto IL_0412;
		IL_0412:
		throw new NullReferenceException();
		IL_05df:
		num2 = num3;
		goto IL_05b2;
		IL_05b2:
		num6 = num7;
		goto IL_056d;
	}

	public virtual BaseBody setOffset(float x, float? y = null)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0073: Expected O, but got F4
		bool flag = (object)y == null;
		float num = x * 0.01f;
		object obj = default(object);
		float num2 = (flag ? num : ((float)obj * 0.01f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = num2 ^ 0;
		_offset = (float2)num;
		return this;
	}

	public virtual BaseBody setSize(float? width, float? height, bool center = true)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	public virtual Body setBoundsRectangle(ArcadeBodyBounds bounds)
	{
		//IL_0015: Expected I, but got O
		//IL_001a: Expected I, but got O
		//IL_002a: Expected O, but got I
		//IL_0066: Expected O, but got I
		if (this == null)
		{
			return null;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v1 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppClass<Body>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v1 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v7+FFFFFFF8+v45 @ rax_v2*8]");
			if (0 == (nint)typeof(Body))
			{
				Body body = null;
				return (Body)this;
			}
		}
		return null;
	}

	protected BaseBody()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(RBush.IRectangular);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<RBush+IRectangular>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
