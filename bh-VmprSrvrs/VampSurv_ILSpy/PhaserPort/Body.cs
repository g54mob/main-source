using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

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

	public Body body => this;

	public Body()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(RBush.IRectangular);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<RBush+IRectangular>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	public Body(World world, PhaserGameObject gameObject)
	{
		Reset(world, gameObject, initial: true);
	}

	public unsafe override void Reset(World world, PhaserGameObject gameObject, bool initial = false)
	{
		//IL_0198: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_01d7->IL0121: Incompatible stack heights: 1 vs 0
		//IL_0112->IL0121: Incompatible stack heights: 1 vs 0
		PhaserGameObject gameObject2 = default(PhaserGameObject);
		bool initial2 = default(bool);
		base.Reset(world, gameObject2, initial2);
		Transform cachedUnityTransform = _cachedUnityTransform;
		_prev = _position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		_ = 0;
		_prevFrame = _position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		_ = 0;
		_allowRotation = true;
		if ((object)_cachedUnityTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedUnityTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localRotation_Injected(((UnityEngine.Object)cachedUnityTransform).m_CachedPtr, out Quaternion _);
			Quaternion quaternion2 = default(Quaternion);
			Vector3 eulerAngles = quaternion2.eulerAngles;
			_sourceSize = _size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
			_ = 0;
			_rotation = eulerAngles.z;
			_acceleration = (float2)0;
			_allowDrag = true;
			_drag = (float2)0;
			_worldBounce = (float2?)(object)0;
			_ = 0;
			if (world != null)
			{
				_customBoundsRectangle = world._bounds;
				Transform cachedUnityTransform2 = _cachedUnityTransform;
				_maxSpeed = -1f;
				_friction = (float2)1065353216;
				_useDamping = false;
				_angularVelocity = 0f;
				_angularDrag = 0f;
				_maxAngular = 1000f;
				_speed = 0f;
				_physicsType = PhysicsType.DYNAMIC_BODY;
				if ((object)_cachedUnityTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedUnityTransform2).m_CachedPtr == (IntPtr)0;
					float2 ret2;
					Transform.get_localScale_Injected(((UnityEngine.Object)cachedUnityTransform2).m_CachedPtr, out *(Vector3*)(&ret2));
					_scale = ret2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void updateBounds()
	{
		//IL_01fc: Expected O, but got I4
		//IL_012d: Expected O, but got I
		//IL_021e: Expected O, but got I
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00f6: Expected O, but got F4
		//IL_01ad: Expected O, but got I
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		Transform cachedUnityTransform = _cachedUnityTransform;
		ArcadeTransform transform = _transform;
		bool flag = ((UnityEngine.Object)cachedUnityTransform).m_CachedPtr == (IntPtr)0;
		object obj = Transform.get_hasChanged_Injected(((UnityEngine.Object)cachedUnityTransform).m_CachedPtr);
		if (obj != null)
		{
			transform.SetFromGameObject();
			float2 float5 = (float2)(transform.scale & -2147483649L);
			object obj2 = (object)transform.scale >> 32;
			object obj3 = obj2 & -2147483649L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+E4]");
			object obj4 = obj3 * 0;
			_scale = float5;
			float2 float6 = float5 * _sourceSize;
			float num = (float)obj4 * 0.5f;
			_size = float6;
			float num2 = (float)float6 * 0.5f;
			_halfSize = (float2)num2;
			_cachedUnityTransform.hasChanged = false;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbx_v1 (ArcadeTransform)+78]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbx_v1 (ArcadeTransform)+14]");
		object obj5 = num3 * 0;
		float2 displayOrigin = (object)transform.data * (object)transform._origin;
		transform.displayOrigin = displayOrigin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbx_v1 (ArcadeTransform)+54]");
		if ((nint)0 > (nint)0)
		{
			BaseBody baseBody = transform._body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v14 (BaseBody)+5C]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbx_v1 (ArcadeTransform)+54]");
			object obj6 = num4 / 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbx_v1 (ArcadeTransform)+70]");
			object obj7 = 0 - obj6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rbx_v1 (ArcadeTransform)+70]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj8 = num5 ^ 0;
	}

	public void updateFromGameObject()
	{
		//IL_0046: Expected O, but got I
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00af: Expected F4, but got O
		//IL_00c1: Expected F4, but got I
		//IL_013b: Expected O, but got I
		updateBounds();
		ArcadeTransform transform = _transform;
		object obj = _offset - transform.displayOrigin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+4C]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (ArcadeTransform)+70]");
		object obj2 = num - 0;
		object obj3 = (object)transform.scale * obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (ArcadeTransform)+54]");
		object obj4 = obj2 * 0;
		float2 float5 = (float2)(obj3 + (object)transform.position);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (ArcadeTransform)+4C]");
		object obj5 = obj4 + 0;
		_position = float5;
		MinX = (float)_position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		MinY = 0f;
		float maxX = (float)_size + (float)float5;
		MaxX = maxX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		float maxY = num2 + 0f;
		MaxY = maxY;
		float2 center = _halfSize + float5;
		_center = center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+64]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		object obj6 = num3 + 0;
	}

	private void resetFlags(bool clear = false)
	{
		//IL_000b: Expected O, but got I4
		_blocked = (ArcadeBodyCollision)0;
		_embedded = false;
	}

	public void preUpdate(bool willStep, float delta)
	{
		//IL_0078: Expected F4, but got I
		//IL_0024: Expected O, but got I4
		if (willStep)
		{
			_blocked = (ArcadeBodyCollision)0;
			_embedded = false;
		}
		updateFromGameObject();
		ArcadeTransform transform = _transform;
		_prev = _position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		_ = 0;
		_prevFrame = _position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2 (ArcadeTransform)+60]");
		_rotation = 0f;
		if (willStep)
		{
			update(delta);
		}
	}

	public void update(float delta)
	{
		//IL_036a: Expected O, but got F4
		//IL_037b: Expected F4, but got O
		//IL_038d: Expected F4, but got I
		//IL_03e4: Expected O, but got F4
		//IL_0401: Expected O, but got I
		//IL_0452: Expected F4, but got I
		//IL_0043: Invalid comparison between F4 and I4
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected F4, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_0084: Invalid comparison between F4 and I4
		//IL_0114: Expected F4, but got I4
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		_prev = _position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		_ = 0;
		if (_allowRotation)
		{
			float num = _angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FFDE06h\"");
			if (_angularAcceleration == 0f)
			{
				if (_allowDrag)
				{
					bool flag = _angularDrag == 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FFDDCCh\"");
					if (!flag)
					{
						float num2 = _angularDrag * delta;
						float num3 = num - num2;
						if (!(num3 > -0.1f))
						{
							float num4 = num2 + num;
							num = ((0.1f > num4) ? (num + num2) : 0f);
						}
						else
						{
							num -= num2;
						}
					}
				}
			}
			else
			{
				float num5 = _angularAcceleration * delta;
				num += num5;
			}
			float maxAngular = _maxAngular;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float num6 = maxAngular ^ 0;
			object obj = num & -2147483649L;
			if ((nint)obj > 2139095040 || num > _maxAngular)
			{
				num = _maxAngular;
			}
			object obj2 = num & -2147483649L;
			if ((nint)obj2 > 2139095040 || num6 > num)
			{
				num = num6;
			}
			float num7 = num - _angularVelocity;
			float num8 = (_angularVelocity = num7 + _angularVelocity) * delta;
			float rotation = num8 + _rotation;
			_rotation = rotation;
		}
		_world.computeVelocity(this, delta);
		float num9 = (float)_velocity * delta;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		float num10 = 0f * delta;
		float num11 = (float)_position + num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		float num12 = 0f + num10;
		_position = (float2)num11;
		MinX = (float)_position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		MinY = 0f;
		float maxX = (float)_size + num11;
		MaxX = maxX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
		float maxY = 0f + num12;
		MaxY = maxY;
		float num13 = (float)_halfSize + num11;
		_center = (float2)num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+64]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		object obj3 = num14 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		float num15 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		float num16 = num15 * 0f;
		object obj4 = _velocity * _velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		_angle = 0f;
		float speed = num16 + (float)obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		bool flag2 = !_collideWorldBounds;
		_speed = speed;
		if (!flag2 && checkWorldBounds() && _onWorldBounds)
		{
			World world = _world;
			Delegate[] callbacks = ((EventEmitter)world).callbacks;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 != null)
			{
				object obj6 = _blocked & 2;
				bool flag3 = obj6 == null;
				bool flag4 = !flag3;
				object obj7 = _blocked & 1;
				bool flag5 = obj7 == null;
				bool flag6 = !flag5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v477 @ rax_v19+18] (should have been resolved before IL gen)");
			}
		}
		float dx = (float)_position - (float)_prev;
		_dx = dx;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		float num17 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+CC]");
		float dy = num17 - 0f;
		_dy = dy;
	}

	public unsafe override void postUpdate()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0059: Invalid comparison between O and F4
		//IL_006b: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e1: Invalid comparison between O and F4
		//IL_0122: Expected O, but got Ref
		//IL_012b: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		object obj = _position - _prevFrame;
		object obj2 = obj >> 32;
		object obj3 = obj2 & -2147483649L;
		object obj4 = obj & -2147483649L;
		object obj5 = obj3 + obj4;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-07f);
		object obj6 = 0;
		if (!flag)
		{
			float2 positionForced = default(float2);
			_transform.SetPositionForced(positionForced);
			obj6 = 1;
		}
		if (_allowRotation)
		{
			ArcadeTransform transform = _transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdi_v3 (ArcadeTransform)+60]");
			float num = 0f - _rotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj7 = num & 0;
			object obj8;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-07f))
			{
				obj8 = 0;
			}
			else
			{
				_ = _rotation;
				float3 float5 = default(float3);
				transform._unityTransform.localEulerAngles = (Vector3)(&float5);
				obj8 = 1;
			}
			obj6 |= obj8;
		}
		if (obj6 != null)
		{
			_cachedUnityTransform.hasChanged = false;
		}
	}

	public override Body setBoundsRectangle(ArcadeBodyBounds bounds)
	{
		ArcadeBodyBounds arcadeBodyBounds = default(ArcadeBodyBounds);
		World world = default(World);
		if (arcadeBodyBounds == null)
		{
			world = _world;
			if (_world == null)
			{
				goto IL_005f;
			}
		}
		if (this != null)
		{
			_customBoundsRectangle = world._bounds;
			return this;
		}
		goto IL_005f;
		IL_005f:
		return (Body)(object)new NullReferenceException();
	}

	public bool checkWorldBounds()
	{
		//IL_04a1: Expected I4, but got O
		//IL_0070: Expected O, but got I
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected O, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_0041: Expected O, but got I
		//IL_0051: Expected O, but got I
		//IL_0084: Invalid comparison between F4 and O
		//IL_0168: Invalid comparison between O and F4
		//IL_0532: Invalid comparison between F4 and I
		//IL_02f3: Expected O, but got I
		//IL_0314: Invalid comparison between O and F4
		//IL_03f9: Expected F4, but got O
		//IL_040b: Expected F4, but got I
		//IL_0489: Expected O, but got I
		//IL_00fe: Expected O, but got F4
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0207: Expected O, but got F4
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		World world = _world;
		ArcadeBodyBounds customBoundsRectangle = _customBoundsRectangle;
		CheckCollisionObject checkCollision;
		object obj3;
		if (_world != null)
		{
			bool flag = _worldBounce == null;
			checkCollision = world._checkCollision;
			float2 float5;
			object obj;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+100]");
				float5 = (float2)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+104]");
				obj = 0;
			}
			else
			{
				float5 = _bounce;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+88]");
				obj = 0;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			obj3 = obj2 ^ 0;
			float2 obj4 = float5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj5 = obj4 ^ 0;
			if (_customBoundsRectangle != null)
			{
				float num = customBoundsRectangle.x;
				float2 position = _position;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
				{
					if (world._checkCollision == null)
					{
						goto IL_0493;
					}
					if (checkCollision._left)
					{
						float num2 = customBoundsRectangle.x + 1E-06f;
						_position = (float2)num2;
						float2 velocity = obj5 * (object)_velocity;
						_velocity = velocity;
						ArcadeBodyCollision blocked = (ArcadeBodyCollision)(_blocked | 4);
						_blocked = blocked;
						goto IL_051d;
					}
				}
				object obj6 = _size + _position;
				float num3 = customBoundsRectangle.width + customBoundsRectangle.x;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
				{
					if (world._checkCollision == null)
					{
						goto IL_0493;
					}
					if (checkCollision._right)
					{
						float num4 = customBoundsRectangle.width + customBoundsRectangle.x;
						float num5 = num4 - (float)_size;
						float num6 = num5 - 1E-06f;
						_position = (float2)num6;
						float2 velocity2 = obj5 * (object)_velocity;
						_velocity = velocity2;
						ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(_blocked | 8);
						_blocked = blocked2;
					}
				}
				goto IL_051d;
			}
		}
		goto IL_0493;
		IL_051d:
		float num7 = customBoundsRectangle.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		if (num7 > 0f)
		{
			if (world._checkCollision == null)
			{
				goto IL_0493;
			}
			if (checkCollision._up)
			{
				float num8 = customBoundsRectangle.y + 1E-06f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
				object obj7 = obj3 * 0;
				ArcadeBodyCollision blocked3 = (ArcadeBodyCollision)(_blocked | 1);
				_blocked = blocked3;
				goto IL_0549;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		object obj8 = num9 + 0;
		float num10 = customBoundsRectangle.height + customBoundsRectangle.y;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10))
		{
			if (world._checkCollision == null)
			{
				goto IL_0493;
			}
			if (checkCollision._down)
			{
				float num11 = customBoundsRectangle.height + customBoundsRectangle.y;
				float num12 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
				float num13 = num12 - 0f;
				float num14 = num13 - 1E-06f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
				object obj9 = obj3 * 0;
				ArcadeBodyCollision blocked4 = (ArcadeBodyCollision)(_blocked | 2);
				_blocked = blocked4;
			}
		}
		goto IL_0549;
		IL_0493:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0549:
		bool flag2 = (object)_blocked == null;
		if (!flag2)
		{
			MinX = (float)_position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
			MinY = 0f;
			float maxX = (float)_size + (float)_position;
			MaxX = maxX;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
			float num15 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
			float maxY = num15 + 0f;
			MaxY = maxY;
			float2 center = _halfSize + _position;
			_center = center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+64]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
			object obj10 = num16 + 0;
		}
		return !flag2;
	}

	public Body stop()
	{
		//IL_0013: Expected I, but got O
		//IL_0049: Expected I, but got O
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		_velocity = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v3 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num4 = 0;
		_speed = 0f;
		_angularVelocity = 0f;
		_acceleration = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		return this;
	}

	public ArcadeBodyBounds getBounds(ArcadeBodyBounds toFill)
	{
		//IL_002c: Expected F4, but got O
		//IL_0041: Expected F4, but got I
		//IL_0050: Expected F4, but got O
		//IL_0065: Expected F4, but got I
		if (toFill != null)
		{
			toFill.x = (float)_position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
			toFill.y = 0f;
			toFill.width = (float)_size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
			toFill.height = 0f;
			return toFill;
		}
		return (ArcadeBodyBounds)(object)new NullReferenceException();
	}

	public bool hitTest(float x, float y)
	{
		//IL_00af: Invalid comparison between F4 and O
		//IL_00dc: Invalid comparison between O and F4
		//IL_0100: Invalid comparison between F4 and I
		//IL_0131: Expected O, but got I
		//IL_0139: Invalid comparison between O and F4
		if (_isCircle)
		{
			float num = x - (float)_position;
			float num2 = y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
			float num3 = num2 - 0f;
			float num4 = _radius * _radius;
			float num5 = num * num;
			float num6 = num3 * num3;
			float num7 = num5 + num6;
			bool flag = num4 < num7;
			return !flag;
		}
		float2 position = _position;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
		{
			object obj = _size + _position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				if (!(y < 0f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
					object obj2 = num8 + 0;
					bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y);
					return !flag2;
				}
			}
		}
		return false;
	}

	public bool onFloor()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		object obj = _blocked & 2;
		bool flag = obj == null;
		return !flag;
	}

	public bool onCeiling()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		object obj = _blocked & 1;
		bool flag = obj == null;
		return !flag;
	}

	public bool onWall()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0048: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		object obj = _blocked & 4;
		bool flag = obj == null;
		bool flag2 = (nint)obj < 0;
		bool flag3 = !flag2;
		object obj2 = !flag3;
		object obj3 = obj2 | flag;
		if (obj3 == null)
		{
			return true;
		}
		object obj4 = _blocked & 8;
		bool flag4 = obj4 == null;
		return !flag4;
	}

	[MethodImpl((MethodImplOptions)256)]
	public override float deltaAbsX()
	{
		//IL_0015: Invalid comparison between F4 and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected F4, but got Unknown
		float num = _dx;
		if (!(_dx > 0f))
		{
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			num = num2 ^ 0;
		}
		return num;
	}

	[MethodImpl((MethodImplOptions)256)]
	public override float deltaAbsY()
	{
		//IL_0015: Invalid comparison between F4 and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected F4, but got Unknown
		float num = _dy;
		if (!(_dy > 0f))
		{
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			num = num2 ^ 0;
		}
		return num;
	}

	public float deltaX()
	{
		return _dx;
	}

	public float deltaY()
	{
		return _dy;
	}

	public unsafe override void drawDebug()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0075: Expected O, but got I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_011c: Expected O, but got I4
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0382: Expected O, but got Ref
		//IL_0382: Expected F8, but got O
		//IL_0382: Expected F8, but got I
		//IL_0382: Expected F8, but got O
		//IL_03d7: Expected F4, but got I
		//IL_03d7: Expected F4, but got O
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01eb: Expected O, but got I4
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_03f4: Expected I, but got O
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_02c0: Expected O, but got I4
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_00cf: Expected F8, but got I
		//IL_00cf: Expected F8, but got I
		//IL_00cf: Expected F8, but got O
		//IL_0428: Expected I, but got O
		//IL_0438: Expected O, but got I
		//IL_019e: Expected F8, but got I
		//IL_0273: Expected F8, but got O
		//IL_0474: Expected O, but got I
		//IL_0320: Expected F8, but got O
		//IL_0320: Expected F8, but got I
		//IL_0320: Expected F8, but got O
		//IL_0567: Expected F4, but got O
		//IL_0567: Expected F4, but got I
		//IL_0567: Expected F4, but got O
		double num = (double)_position + (double)_halfSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
		double num2 = 0.0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+64]");
		double num3 = num2 + 0.0;
		if (!_isCircle)
		{
			object obj = _checkCollision & 1;
			bool flag = obj == null;
			bool flag2 = (nint)obj < 0;
			bool flag3 = !flag2;
			object obj2 = !flag3;
			object obj3 = obj2 | flag;
			if (obj3 == null)
			{
				double x = (double)_position + (double)_size;
				float2 position = _position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				VSDebug.DrawDebugLine((double)position, num4, x, 0.0);
			}
			object obj4 = _checkCollision & 8;
			bool flag4 = obj4 == null;
			bool flag5 = (nint)obj4 < 0;
			bool flag6 = !flag5;
			object obj5 = !flag6;
			object obj6 = obj5 | flag4;
			if (obj6 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				double num5 = 0.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
				double y = num5 + 0.0;
				double x2 = (double)_position + (double)_size;
				double x3 = (double)_position + (double)_size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				VSDebug.DrawDebugLine(x3, 0.0, x2, y);
			}
			object obj7 = _checkCollision & 2;
			bool flag7 = obj7 == null;
			bool flag8 = (nint)obj7 < 0;
			bool flag9 = !flag8;
			object obj8 = !flag9;
			object obj9 = obj8 | flag7;
			if (obj9 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				double num6 = 0.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
				double y2 = num6 + 0.0;
				double x4 = (double)_position + (double)_size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				double num7 = 0.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
				double y3 = num7 + 0.0;
				VSDebug.DrawDebugLine((double)_position, y3, x4, y2);
			}
			object obj10 = _checkCollision & 4;
			bool flag10 = obj10 == null;
			bool flag11 = (nint)obj10 < 0;
			bool flag12 = !flag11;
			object obj11 = !flag12;
			object obj12 = obj11 | flag10;
			if (obj12 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				double num8 = 0.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
				double y4 = num8 + 0.0;
				float2 position2 = _position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				VSDebug.DrawDebugLine((double)position2, 0.0, (double)_position, y4);
			}
		}
		else
		{
			float num9 = (float)_size * 0.5f;
			VSDebug.DrawDebugCircle(num, num3, num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm2,qword ptr [188A105F0h]\"");
		float2 center = _center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+6C]");
		object obj13 = default(object);
		VSDebug.DrawDebugCircle((double)center, 0.0, (double)_halfSize, (Color)(&obj13));
		float x5 = (float)_center - (float)_offset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+6C]");
		float num10 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+4C]");
		float y5 = num10 - 0f;
		float2 center2 = _center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+6C]");
		Color colour = default(Color);
		VSDebug.DrawDebugLine((float)center2, 0f, x5, y5, colour);
		PhaserGameObject gameObject = _gameObject;
		nint num11 = (nint)typeof(ArcadeSprite);
		ArcadeSprite arcadeSprite;
		if ((object)_gameObject == null)
		{
			arcadeSprite = null;
			goto IL_060f;
		}
		nint num12 = (nint)gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rdx_v1 (Il2CppClass<ArcadeSprite>)+130]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r8_v2 (Il2CppClass<PhaserGameObject>)+130]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rdx_v1 (Il2CppClass<ArcadeSprite>)+130]");
		if (num13 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r8_v2 (Il2CppClass<PhaserGameObject>)+C8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v32+FFFFFFF8+v372 @ rax_v29*8]");
			bool flag13 = 0 != (nint)typeof(ArcadeSprite);
			arcadeSprite = (ArcadeSprite)_gameObject;
			if (!flag13)
			{
				goto IL_060f;
			}
		}
		throw new InvalidCastException();
		IL_060f:
		if ((object)arcadeSprite != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0 && arcadeSprite.body != null)
		{
			BaseBody baseBody = arcadeSprite.body;
			if (baseBody._transform != null)
			{
				float2 position3 = arcadeSprite.position;
				float2 center3 = _center;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+6C]");
				float y6 = default(float);
				VSDebug.DrawDebugLine((float)center3, 0f, (float)position3, y6, colour);
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		double y7 = 0.0 + num3;
		double x6 = (double)_velocity + num;
		VSDebug.DrawDebugLine(num, num3, x6, y7);
	}

	public override bool willDrawDebug()
	{
		return true;
	}

	public Body setCollideWorldBounds(bool? shouldCollide = null, float? bounceX = null, float? bounceY = null, bool? onWorldBounds = null)
	{
		//IL_0040: Expected O, but got I4
		bool flag = (object)shouldCollide == null;
		bool flag2 = (object)shouldCollide != null;
		bool flag3 = default(bool);
		bool collideWorldBounds = flag3;
		if (!flag2)
		{
			collideWorldBounds = true;
		}
		_collideWorldBounds = collideWorldBounds;
		if (!flag)
		{
			if (_worldBounce == null)
			{
				_worldBounce = (float2?)(object)1;
			}
			float2? worldBounce = default(float2?);
			if ((object)bounceX != null)
			{
				if (_worldBounce == null)
				{
					goto IL_00c7;
				}
				_worldBounce = worldBounce;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+104]");
				_ = 0;
			}
			if ((object)bounceY != null)
			{
				if (_worldBounce == null)
				{
					goto IL_00c7;
				}
				_worldBounce = worldBounce;
			}
		}
		object obj = default(object);
		if (obj != null)
		{
			bool onWorldBounds2 = default(bool);
			_onWorldBounds = onWorldBounds2;
		}
		return this;
		IL_00c7:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		Body result = default(Body);
		return result;
	}

	public Body setVelocity(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_velocity = (float2)x;
		float num = x * x;
		float num2 = y * y;
		float speed = num + num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		_speed = speed;
		return this;
	}

	public Body setVelocityX(float value)
	{
		//IL_000a: Expected O, but got F4
		//IL_0027: Expected O, but got I
		_velocity = (float2)value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+74]");
		object obj = num * 0;
		float num2 = value * value;
		float speed = (float)obj + num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		_speed = speed;
		return this;
	}

	public Body setVelocityY(float value)
	{
		object obj = _velocity * _velocity;
		float num = value * value;
		float speed = (float)obj + num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		_speed = speed;
		return this;
	}

	public Body setMaxSpeed(float value)
	{
		_maxSpeed = value;
		return this;
	}

	public Body setBounce(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_bounce = (float2)x;
		return this;
	}

	public Body setBounceX(float value)
	{
		//IL_000a: Expected O, but got F4
		_bounce = (float2)value;
		return this;
	}

	public Body setBounceY(float value)
	{
		return this;
	}

	public Body setAcceleration(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_acceleration = (float2)x;
		return this;
	}

	public Body setAccelerationX(float value)
	{
		//IL_000a: Expected O, but got F4
		_acceleration = (float2)value;
		return this;
	}

	public Body setAccelerationY(float value)
	{
		return this;
	}

	public Body setAllowDrag(bool value = true)
	{
		_allowDrag = value;
		return this;
	}

	public Body setAllowGravity(bool value = true)
	{
		_allowGravity = value;
		return this;
	}

	public Body setAllowRotation(bool value = true)
	{
		_allowRotation = value;
		return this;
	}

	public Body setDrag(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_drag = (float2)x;
		return this;
	}

	public Body setDamping(bool value)
	{
		_useDamping = value;
		return this;
	}

	public Body setDragX(float value)
	{
		//IL_000a: Expected O, but got F4
		_drag = (float2)value;
		return this;
	}

	public Body setDragY(float value)
	{
		return this;
	}

	public Body setGravity(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_gravity = (float2)x;
		return this;
	}

	public Body setGravityX(float value)
	{
		//IL_000a: Expected O, but got F4
		_gravity = (float2)value;
		return this;
	}

	public Body setGravityY(float value)
	{
		return this;
	}

	public Body setFriction(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_friction = (float2)x;
		return this;
	}

	public Body setFrictionX(float value)
	{
		//IL_000a: Expected O, but got F4
		_friction = (float2)value;
		return this;
	}

	public Body setFrictionY(float value)
	{
		return this;
	}

	public Body setAngularVelocity(float value)
	{
		_angularVelocity = value;
		return this;
	}

	public Body setAngularAcceleration(float value)
	{
		_angularAcceleration = value;
		return this;
	}

	public Body setAngularDrag(float value)
	{
		_angularDrag = value;
		return this;
	}

	public Body setMass(float value)
	{
		_mass = value;
		return this;
	}

	public Body setImmovable(bool value = true)
	{
		_immovable = value;
		return this;
	}

	public Body setEnable(bool value = true)
	{
		_enable = value;
		return this;
	}

	public override BaseBody setCircle(float radius, float? offsetX = null, float? offsetY = null, bool worldSpace = false)
	{
		//IL_0188: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0493: Invalid comparison between F4 and I4
		//IL_00f6: Expected F4, but got O
		//IL_00ff: Expected O, but got I4
		//IL_01d9: Expected O, but got F4
		//IL_0210: Expected O, but got F4
		//IL_023f: Expected O, but got F4
		//IL_0114: Expected F4, but got I
		//IL_011d: Expected O, but got I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02a2: Expected O, but got F4
		//IL_02ae: Expected F4, but got O
		//IL_02c0: Expected F4, but got I
		//IL_0441: Expected O, but got I4
		//IL_0485: Expected O, but got I4
		//IL_0566->IL052c: Incompatible stack heights: 3 vs 0
		//IL_0446->IL0507: Incompatible stack heights: 6 vs 3
		//IL_048a->IL0559: Incompatible stack heights: 6 vs 3
		object obj = default(object);
		float num5 = default(float);
		float num7 = default(float);
		while (true)
		{
			float num;
			float? num2;
			float? num3;
			float num4;
			float num6;
			if (obj != null)
			{
				bool flag = (object)_gameObject == null;
				Transform transform = _gameObject.transform;
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				num = radius / (float)ret;
				bool flag4 = (object)offsetX == null;
				num2 = offsetX;
				Vector3 ret2;
				if (!flag4)
				{
					bool flag5 = (object)_gameObject == null;
					Transform transform2 = _gameObject.transform;
					bool flag6 = (object)transform2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v50 (UnityEngine.Transform)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v50 (UnityEngine.Transform)+10]");
					Transform.get_localScale_Injected((IntPtr)0, out ret2);
					num2 = (float?)(object)1;
				}
				bool flag8 = (object)offsetY == null;
				num3 = offsetY;
				if (!flag8)
				{
					bool flag9 = (object)_gameObject == null;
					Transform transform3 = _gameObject.transform;
					bool flag10 = (object)transform3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v41 (UnityEngine.Transform)+10]");
					bool flag11 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v41 (UnityEngine.Transform)+10]");
					Transform.get_localScale_Injected((IntPtr)0, out ret2);
					num3 = (float?)(object)1;
				}
				num4 = num5;
			}
			else
			{
				num = radius * 0.01f;
				bool flag12 = (object)offsetX == null;
				num4 = num5;
				num2 = offsetX;
				if (!flag12)
				{
					num4 = num5 * 0.01f;
					num2 = (float?)(object)1;
				}
				bool flag13 = (object)offsetY == null;
				num3 = offsetY;
				if (!flag13)
				{
					num6 = num7 * 0.01f;
					num3 = (float?)(object)1;
					goto IL_04e7;
				}
			}
			num6 = num7;
			goto IL_04e7;
			IL_04e7:
			if ((object)num2 == null)
			{
				num4 = (float)_offset;
				num2 = (float?)(object)1;
			}
			if ((object)num3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+4C]");
				num6 = 0f;
				num3 = (float?)(object)1;
			}
			if (!(num > 0f))
			{
				_isCircle = false;
				break;
			}
			_radius = num;
			float num8 = num + num;
			_isCircle = true;
			_sourceSize = (float2)num8;
			float num9 = num8 * (float)_scale;
			float num10 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+C4]");
			float num11 = num10 * 0f;
			_size = (float2)num9;
			float num12 = num9 * 0.5f;
			float num13 = num11 * 0.5f;
			_halfSize = (float2)num12;
			if ((object)num2 != null && (object)num3 != null)
			{
				float num14 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj2 = num14 ^ 0;
				_offset = (float2)num4;
				MinX = (float)_position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				MinY = 0f;
				float maxX = (float)_size + (float)_position;
				MaxX = maxX;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+5C]");
				float num15 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				float maxY = num15 + 0f;
				MaxY = maxY;
				float2 center = _halfSize + _position;
				_center = center;
				float num16 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Body)+54]");
				float num17 = num16 + 0f;
				break;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
		bool flag14 = _transform == null;
		_transform.ForceSpriteFetch();
		bool flag15 = _transform == null;
		_transform.UpdateRendererPosition(force: true);
		return this;
	}

	public unsafe override BaseBody setSize(float? width, float? height, bool center = true)
	{
		//IL_003c: Expected O, but got I
		//IL_0067: Expected O, but got Ref
		//IL_0216: Expected O, but got I4
		//IL_0130: Expected O, but got I
		//IL_015b: Expected O, but got Ref
		//IL_008d: Expected O, but got I
		//IL_023c: Expected O, but got I4
		//IL_0181: Expected O, but got I
		//IL_019b: Expected O, but got I
		//IL_00c5: Expected O, but got I4
		//IL_00df: Expected O, but got Ref
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_029e: Expected O, but got F4
		//IL_02bd: Expected O, but got F4
		//IL_01c1: Expected O, but got I4
		//IL_01d1: Expected O, but got I
		//IL_02fa: Expected O, but got F4
		//IL_0306: Expected F4, but got O
		//IL_0318: Expected F4, but got I
		//IL_0379: Expected O, but got F4
		//IL_0396: Expected O, but got I
		//IL_03c8: Expected I, but got O
		//IL_03e0: Expected O, but got I
		//IL_0460: Expected O, but got I4
		//IL_0625: Expected O, but got I4
		//IL_041c: Expected O, but got I
		//IL_0452: Expected O, but got I4
		//IL_04cd: Invalid comparison between F4 and I4
		//IL_051a: Expected O, but got F4
		float? gameObject = (float?)_gameObject;
		bool flag = (object)width != null;
		float? num = width;
		float? num2 = height;
		Body body = this;
		object obj3 = default(object);
		float num3 = default(float);
		float num4 = default(float);
		float? num5;
		float num6;
		if (!flag)
		{
			if ((object)_gameObject == null)
			{
				goto IL_05a5;
			}
			object obj = gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r8_v13+240]");
			num2 = (float?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v121 @ r8_v13+238] (should have been resolved before IL gen)");
			object obj2 = default(object);
			bool flag2 = obj2 == null;
			num = (float?)_gameObject;
			body = (Body)(&obj3);
			if (!flag2)
			{
				object obj4 = gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v15+240]");
				num2 = (float?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v378 @ r8_v15+238] (should have been resolved before IL gen)");
				object obj5 = default(object);
				if (obj5 == null)
				{
					goto IL_055b;
				}
				num3 = num4;
				num5 = (float?)(object)1;
				num6 = num4;
				num = (float?)_gameObject;
				body = (Body)(&obj3);
				goto IL_05b3;
			}
		}
		num5 = width;
		num6 = num3;
		goto IL_05b3;
		IL_05a5:
		return (BaseBody)(object)new NullReferenceException();
		IL_05d3:
		object obj6 = default(object);
		if ((object)num5 != null)
		{
			float num7 = (float)obj6 * 0.01f;
			num3 = num7;
			num5 = (float?)(object)1;
			num6 = num7;
		}
		float? num8;
		Body body2;
		if ((object)num8 != null)
		{
			float num9 = (float)obj6 * 0.01f;
			num8 = (float?)(object)1;
			body2 = body;
			num3 = num9;
		}
		if ((object)num5 == null || (object)num8 == null)
		{
			goto IL_055b;
		}
		float num10 = num6 * (float)_scale;
		Body obj7 = body2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Body)+C4]");
		object obj8 = obj7 * 0;
		_size = (float2)num10;
		float num11 = num10 * 0.5f;
		_sourceSize = (float2)num6;
		float num12 = (float)obj8 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		_halfSize = (float2)num11;
		MinX = (float)_position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Body)+54]");
		MinY = 0f;
		float maxX = (float)_size + (float)_position;
		MaxX = maxX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Body)+5C]");
		float num13 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Body)+54]");
		float maxY = num13 + 0f;
		MaxY = maxY;
		float num14 = num11 + (float)_position;
		_center = (float2)num14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Body)+64]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Body)+54]");
		object obj9 = num15 + 0;
		if ((object)_gameObject == null)
		{
			goto IL_05a5;
		}
		nint num16 = (nint)typeof(ArcadeSprite);
		object obj10 = gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v3 (Il2CppClass<ArcadeSprite>)+130]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r8_v3+130]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v3 (Il2CppClass<ArcadeSprite>)+130]");
		object obj13;
		if (num17 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r8_v3+C8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v21+FFFFFFF8+v609 @ rax_v11*8]");
			if (0 == (nint)typeof(ArcadeSprite))
			{
				obj13 = 1;
				goto IL_060d;
			}
		}
		obj13 = 0;
		goto IL_060d;
		IL_055b:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_05a5;
		IL_0633:
		_isCircle = false;
		_radius = 0f;
		if (_transform != null)
		{
			_transform.ForceSpriteFetch();
			if (_transform != null)
			{
				_transform.UpdateRendererPosition(force: true);
				return this;
			}
		}
		goto IL_05a5;
		IL_060d:
		bool flag3 = obj13 == null;
		float? num18 = (float?)(object)0;
		if (!flag3)
		{
			num18 = (float?)_gameObject;
		}
		if ((object)num18 == null)
		{
			goto IL_05a5;
		}
		float2 center2 = ((ArcadeSprite)num18).getCenter();
		if (center)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FFF835h\"");
			if ((object)center2 == null)
			{
				bool flag4 = num3 == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FFF835h\"");
				if (flag4)
				{
					goto IL_0633;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v4 (System.Nullable`1<System.Single>)+28]");
			if ((nint)0 == 0)
			{
				goto IL_05a5;
			}
			_offset = (float2)num4;
		}
		goto IL_0633;
		IL_05b3:
		if ((object)height == null)
		{
			if ((object)_gameObject == null)
			{
				goto IL_05a5;
			}
			object obj14 = gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ r8_v6+240]");
			num2 = (float?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v514 @ r8_v6+238] (should have been resolved before IL gen)");
			object obj15 = default(object);
			bool flag5 = obj15 == null;
			num = (float?)_gameObject;
			body = (Body)(&obj3);
			if (!flag5)
			{
				object obj16 = gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r8_v8+240]");
				num2 = (float?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v551 @ r8_v8+238] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v31+10]");
				body = (Body)0;
				object obj17 = default(object);
				if (obj17 == null)
				{
					goto IL_055b;
				}
				num8 = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v31+10]");
				body2 = (Body)0;
				num = (float?)_gameObject;
				goto IL_05d3;
			}
		}
		num8 = height;
		Body body3 = default(Body);
		body2 = body3;
		goto IL_05d3;
	}

	static Body()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("Body.postUpdate", 5, MarkerFlags.Default, 0);
		s_postUpdateMarker = (ProfilerMarker)(nint)intPtr;
	}
}
