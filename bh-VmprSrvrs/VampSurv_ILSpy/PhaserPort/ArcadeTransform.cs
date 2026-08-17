using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class ArcadeTransform
{
	private static ProfilerMarker updateDisplayOriginSampler;

	private static ProfilerMarker updateRendererMarker;

	private static ProfilerMarker setFromGameObjectMarker;

	private SpriteCachedData data;

	private Transform _unityTransform;

	private Transform _rendererTransform;

	private SpriteRenderer _unitySpriteRenderer;

	private BaseBody _body;

	public float2 position;

	public float2 scale;

	protected float3 _unityangles;

	protected float _unityz;

	protected float _scalez;

	public float2 displayOrigin;

	private float2 _origin;

	private float2 cachedLocalPosition;

	public unsafe ref SpriteCachedData Data
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected Ref, but got Unknown
			return ref *(SpriteCachedData*)(this + 16);
		}
	}

	public float z => _unityz;

	public float2 origin
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
	}

	public float rotation
	{
		get
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+60]");
			return 0f;
		}
	}

	public ArcadeTransform(Transform unityTransform, SpriteRenderer unitySpriteRenderer, BaseBody body)
	{
		//IL_000f: Expected O, but got I8
		cachedLocalPosition = (float2)3323739136L;
		_ = 1176255488;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x184FFB090\"");
	}

	public void Reset(Transform unityTransform, SpriteRenderer unitySpriteRenderer, BaseBody body)
	{
		_unityTransform = unityTransform;
		if ((object)_unitySpriteRenderer != unitySpriteRenderer)
		{
			if ((object)_unitySpriteRenderer != null)
			{
				_rendererTransform = null;
			}
			_unitySpriteRenderer = unitySpriteRenderer;
			Transform transform = _unitySpriteRenderer.transform;
			_rendererTransform = transform;
		}
		_body = body;
		SetFromGameObject();
		ForceSpriteFetch();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 290 Invalid \"Jump target not found in method: 0x184FFB2B0\"");
		throw new NullReferenceException();
	}

	public void setOrigin(float2 o)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_00ca: Expected O, but got I
		//IL_0096: Expected O, but got I
		_origin = o;
		float2 float5 = (object)data * (object)o;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+14]");
		object obj2 = default(object);
		object obj = 0 * obj2;
		displayOrigin = float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
		if ((nint)0 > (nint)0)
		{
			BaseBody body = _body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v3 (BaseBody)+5C]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
			object obj3 = num / 0;
			object obj4 = obj - obj3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj5 = num2 ^ 0;
		UpdateRendererPosition(force: true);
	}

	public unsafe void OnSpriteChanged()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_005a: Expected O, but got I
		//IL_00f9: Expected O, but got I
		//IL_00bd: Expected O, but got I
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		Sprite sprite = _unitySpriteRenderer.sprite;
		SpriteCachedData spriteCachedData = (SpriteCachedData)(this + 16);
		((SpriteCachedData*)spriteCachedData)->Set(sprite);
		float2 float5 = (object)data * (object)_origin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+14]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+78]");
		object obj = num * 0;
		displayOrigin = float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
		if ((nint)0 > (nint)0)
		{
			BaseBody body = _body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rax_v7 (BaseBody)+5C]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
			object obj2 = num2 / 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
			object obj3 = 0 - obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = num3 ^ 0;
		UpdateRendererPosition();
	}

	public void OnSpriteChanged(float2 originalSize)
	{
		//IL_0063: Expected O, but got F4
		//IL_00af: Expected O, but got I
		//IL_00cf: Expected O, but got F4
		//IL_015f: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		Sprite sprite = _unitySpriteRenderer.sprite;
		float num = (float)originalSize * 0.5f;
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		float num3 = (float)originalSize * 0.01f;
		float num4 = (float)obj * 0.01f;
		data = (SpriteCachedData)num3;
		float num5 = num * 0.01f;
		float num6 = num2 * 0.01f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+14]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+78]");
		object obj2 = num7 * 0;
		float num8 = num3 * (float)_origin;
		displayOrigin = (float2)num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
		if ((nint)0 > (nint)0)
		{
			BaseBody body = _body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v6 (BaseBody)+5C]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
			object obj3 = num9 / 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
			object obj4 = 0 - obj3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj5 = num10 ^ 0;
		UpdateRendererPosition();
	}

	public unsafe void SetFromGameObject()
	{
		//IL_0087: Expected I, but got O
		if ((object)setFromGameObjectMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)setFromGameObjectMarker);
		}
		ProfilerMarker.AutoScope unityTransform = (ProfilerMarker.AutoScope)_unityTransform;
		bool flag = (object)_unityTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdi_v3 (Unity.Profiling.ProfilerMarker+AutoScope)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdi_v3 (Unity.Profiling.ProfilerMarker+AutoScope)+10]");
		float2 ret;
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
		bool flag3 = (object)_unityTransform == null;
		Vector3 localEulerAngles = _unityTransform.localEulerAngles;
		ProfilerMarker.AutoScope unityTransform2 = (ProfilerMarker.AutoScope)_unityTransform;
		bool flag4 = (object)_unityTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rdi_v4 (Unity.Profiling.ProfilerMarker+AutoScope)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rdi_v4 (Unity.Profiling.ProfilerMarker+AutoScope)+10]");
		float2 ret2;
		Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret2));
		position = ret;
		_unityz = 0f;
		float3 unityangles = default(float3);
		_unityangles = unityangles;
		_ = localEulerAngles.z;
		scale = ret2;
		_scalez = 0f;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	[MethodImpl((MethodImplOptions)256)]
	public void AddPosition(float2 pos)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_007b: Invalid comparison between F4 and O
		//IL_00f3->IL00b7: Incompatible stack heights: 1 vs 0
		float2 float5 = pos + position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+4C]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		object obj3 = position - float5;
		object obj4 = obj3 & -2147483649L;
		object obj5 = obj3 >> 32;
		object obj6 = obj5 & -2147483649L;
		object obj7 = obj6 + obj4;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-07f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
		{
			object unityTransform = _unityTransform;
			position = float5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)0, ref value);
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void AddPositionForced(float2 pos)
	{
		float2 positionForced = default(float2);
		SetPositionForced(positionForced);
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetPosition(float2 pos)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0057: Invalid comparison between F4 and O
		//IL_00ca->IL008e: Incompatible stack heights: 1 vs 0
		object obj = position - pos;
		object obj2 = obj & -2147483649L;
		object obj3 = obj >> 32;
		object obj4 = obj3 & -2147483649L;
		object obj5 = obj4 + obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-07f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			object unityTransform = _unityTransform;
			position = pos;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rbx_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rbx_v2 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)0, ref value);
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetPositionForced(float2 pos)
	{
		Transform unityTransform = _unityTransform;
		position = pos;
		bool flag = ((UnityEngine.Object)unityTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)unityTransform).m_CachedPtr, ref value);
	}

	public void UpdateDisplayOrigin(bool forced = false)
	{
		//IL_002e: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		float2 float5 = (object)data * (object)_origin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+14]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+78]");
		object obj = num * 0;
		displayOrigin = float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
		if ((nint)0 > (nint)0)
		{
			BaseBody body = _body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rax_v2 (BaseBody)+5C]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
			object obj2 = num2 / 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
			object obj3 = 0 - obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = num3 ^ 0;
	}

	public void UpdateRendererPosition(bool force = false)
	{
		//IL_0141->IL00f6: Incompatible stack heights: 1 vs 0
		object obj = (object)data * (object)_origin;
		float num = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+78]");
		float num2 = num - 0f;
		object obj2 = default(object);
		float2 float5 = obj2 - obj;
		float num3 = (float)obj2 * num2;
		float num4 = (float)obj2 - num3;
		if (!force)
		{
			object obj3 = cachedLocalPosition - float5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+80]");
			float num5 = 0f - num4;
			object obj4 = obj3 * obj3;
			float num6 = num5 * num5;
			float num7 = num6 + (float)obj4;
			if (!(num7 > 1E-07f))
			{
				return;
			}
		}
		object rendererTransform = _rendererTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v4 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v4 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		cachedLocalPosition = float5;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float2 GetRendererPosition(float2 origin, Sprite sprite)
	{
		SpriteCachedData spriteCachedData = default(SpriteCachedData);
		spriteCachedData.SetUsingSpritePPU(sprite);
		float2 result = default(float2);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float2 GetRendererPosition(float2 origin, SpriteCachedData data)
	{
		float2 result = default(float2);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void AddRotation(float deltaZ)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_001b: Invalid comparison between F4 and O
		//IL_006b: Expected O, but got Ref
		object obj = deltaZ & -2147483649L;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-07f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+60]");
			float num = 0f + deltaZ;
			_unityangles = _unityangles;
			float3 float5 = default(float3);
			_unityTransform.localEulerAngles = (Vector3)(&float5);
		}
	}

	public unsafe void ForceSpriteFetch()
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		if ((object)_unitySpriteRenderer == null)
		{
			return;
		}
		Sprite sprite = _unitySpriteRenderer.sprite;
		Sprite t;
		if ((object)sprite != null)
		{
			bool flag = ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0;
			t = sprite;
			if (flag)
			{
				goto IL_00a0;
			}
		}
		t = null;
		goto IL_00a0;
		IL_00a0:
		SpriteCachedData spriteCachedData = (SpriteCachedData)(this + 16);
		((SpriteCachedData*)spriteCachedData)->Set(t);
	}

	public void ForceFullReupdate()
	{
		//IL_003f: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		ForceSpriteFetch();
		SetFromGameObject();
		float2 float5 = (object)data * (object)_origin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+14]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+78]");
		object obj = num * 0;
		displayOrigin = float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
		if ((nint)0 > (nint)0)
		{
			BaseBody body = _body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rax_v5 (BaseBody)+5C]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+54]");
			object obj2 = num2 / 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
			object obj3 = 0 - obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+70]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = num3 ^ 0;
		UpdateRendererPosition(force: true);
	}

	public unsafe bool SetRotation(float rotation)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_003a: Invalid comparison between O and F4
		//IL_009c: Expected I4, but got O
		//IL_0088: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeTransform)+60]");
		float num = 0f - rotation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-07f))
		{
			return false;
		}
		if ((object)_unityTransform != null)
		{
			float3 float5 = default(float3);
			_unityTransform.localEulerAngles = (Vector3)(&float5);
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void SetRotationForced(float rotation)
	{
		//IL_001a: Expected O, but got Ref
		float3 float5 = default(float3);
		_unityTransform.localEulerAngles = (Vector3)(&float5);
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void SetPositionAndRotationForced(float2 transformPosition, float f)
	{
		//IL_0013: Expected O, but got Ref
		position = transformPosition;
		Vector3 vector = default(Vector3);
		quaternion quaternion2 = quaternion.EulerZXY((float3)(&vector));
		object unityTransform = _unityTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (System.Object)+10]");
		float4 float5 = default(float4);
		Transform.SetPositionAndRotation_Injected((IntPtr)0, ref vector, ref *(Quaternion*)(&float5));
	}

	static ArcadeTransform()
	{
		//IL_0035: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_000e: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("ArcadeTransform.updateDisplayOrigin", 1, MarkerFlags.Default, 0);
		updateDisplayOriginSampler = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("ArcadeTransform.UpdateRendererPosition", 1, MarkerFlags.Default, 0);
		updateRendererMarker = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("ArcadeTransform.SetFromGameObject", 1, MarkerFlags.Default, 0);
		setFromGameObjectMarker = (ProfilerMarker)(nint)intPtr3;
	}
}
