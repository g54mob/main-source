using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

public class ArcadeSprite : PhaserGameObject
{
	private SpriteRenderer _spriteRenderer;

	private Transform _cachedTrans;

	public SpriteRenderer Rend
	{
		get
		{
			CheckRenderer();
			return _spriteRenderer;
		}
	}

	private Transform CachedTrans
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			Transform cachedTrans = _cachedTrans;
			Transform cachedTrans2;
			if ((object)_cachedTrans == null || ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0)
			{
				cachedTrans2 = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_cachedTrans = cachedTrans2;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 80;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			cachedTrans2 = _cachedTrans;
			goto IL_0129;
			IL_0129:
			return cachedTrans2;
		}
	}

	public unsafe float2 position
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			Transform cachedTrans = CachedTrans;
			bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (body != null)
			{
				BaseBody baseBody = body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				arcadeTransform.position = ret;
			}
			float2 result = default(float2);
			return result;
		}
		[MethodImpl((MethodImplOptions)256)]
		set
		{
			if (body == null)
			{
				Transform transform = base.transform;
				Transform cachedTrans = CachedTrans;
				if ((object)cachedTrans != null)
				{
					bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					return;
				}
			}
			else
			{
				BaseBody baseBody = body;
				if (body != null && baseBody._transform != null)
				{
					baseBody._transform.SetPositionForced(value);
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	public float2 cachedPosition
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			//IL_0106->IL00ad: Incompatible stack heights: 1 vs 0
			//IL_0140->IL0140: Incompatible stack heights: 2 vs 0
			if (body == null)
			{
				Transform cachedTrans = CachedTrans;
				if ((object)cachedTrans != null)
				{
					bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out Vector3 _);
					Transform cachedTrans2 = CachedTrans;
					if ((object)cachedTrans2 != null)
					{
						bool flag2 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out Vector3 _);
						goto IL_0140;
					}
				}
			}
			else
			{
				BaseBody baseBody = body;
				if (body != null && baseBody._transform != null)
				{
					goto IL_0140;
				}
			}
			throw new NullReferenceException();
			IL_0140:
			float2 result = default(float2);
			return result;
		}
	}

	public unsafe float scale
	{
		get
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			return ret;
		}
	}

	public unsafe float angle
	{
		get
		{
			Transform cachedTrans = CachedTrans;
			return cachedTrans.localEulerAngles.z;
		}
		set
		{
			//IL_0038: Expected O, but got Ref
			Transform cachedTrans = CachedTrans;
			Vector3 localEulerAngles = cachedTrans.localEulerAngles;
			Transform cachedTrans2 = CachedTrans;
			object obj = default(object);
			cachedTrans2.localEulerAngles = (Vector3)(&obj);
		}
	}

	public float2 displaySize
	{
		get
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			float2 result = default(float2);
			return result;
		}
	}

	public float2 displaySizeSafe
	{
		get
		{
			//IL_00a8->IL0154: Incompatible stack heights: 1 vs 0
			//IL_010c->IL0154: Incompatible stack heights: 1 vs 0
			//IL_0138->IL0154: Incompatible stack heights: 1 vs 0
			//IL_0254->IL0254: Incompatible stack heights: 2 vs 1
			Transform transform = base.transform;
			float2 result = default(float2);
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (body != null)
				{
					BaseBody baseBody = body;
					if (baseBody._transform != null)
					{
						return result;
					}
				}
				CheckRenderer();
				Transform spriteRenderer = (Transform)(object)_spriteRenderer;
				if ((object)_spriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0147;
				}
				if ((object)_spriteRenderer != null)
				{
					Sprite sprite = _spriteRenderer.sprite;
					if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
					{
						goto IL_0147;
					}
					if ((object)_spriteRenderer != null)
					{
						Sprite sprite2 = _spriteRenderer.sprite;
						if ((object)sprite2 != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect _);
							return result;
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_0147:
			return result;
		}
	}

	public bool flipX
	{
		get
		{
			CheckRenderer();
			object spriteRenderer = _spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbx_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 46 ConditionalJump @-1, v52 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public bool flipY
	{
		get
		{
			CheckRenderer();
			object spriteRenderer = _spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbx_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 46 ConditionalJump @-1, v52 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public float2 origin
	{
		get
		{
			BaseBody baseBody = body;
			float2 result = default(float2);
			if (body != null && baseBody._transform != null)
			{
				return result;
			}
			return (float2)new NullReferenceException();
		}
	}

	public float2 size
	{
		get
		{
			float2 result = default(float2);
			if (body != null)
			{
				return result;
			}
			return (float2)new NullReferenceException();
		}
	}

	public PhaserScene scene => ArcadePhysics.s_scene;

	public int depth
	{
		get
		{
			CheckRenderer();
			object spriteRenderer = _spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbx_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 46 ConditionalJump @-1, v52 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public override Rect? frame
	{
		get
		{
			//IL_0051: Expected O, but got I
			//IL_0016: Expected O, but got I
			//IL_00c0: Expected O, but got I4
			IntPtr intPtr = default(IntPtr);
			((ArcadeSprite)(nint)intPtr).CheckRenderer();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
				Sprite sprite = ((SpriteRenderer)0).sprite;
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
					_ = 0;
					_ = 0;
					ArcadeSprite arcadeSprite = (ArcadeSprite)1;
					return (Rect?)this;
				}
			}
			throw new NullReferenceException();
		}
	}

	private static bool AreValuesBroken(Vector3 pos, float validRange = 100000f)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Invalid comparison between F4 and O
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005b: Invalid comparison between F4 and O
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0094: Invalid comparison between F4 and O
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		float x = pos.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = x & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)validRange) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			float y = pos.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = y & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)validRange) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				float z = pos.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj3 = z & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)validRange) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = pos.x & -2147483649L;
					if ((nint)obj4 <= 2139095040)
					{
						object obj5 = pos.y & -2147483649L;
						if ((nint)obj5 <= 2139095040)
						{
							object obj6 = pos.z & -2147483649L;
							if ((nint)obj6 <= 2139095040)
							{
								object obj7 = pos.x & -2147483649L;
								if ((nint)obj7 != 2139095040)
								{
									object obj8 = pos.y & -2147483649L;
									if ((nint)obj8 != 2139095040)
									{
										object obj9 = pos.z & -2147483649L;
										object obj10 = obj9 - 2139095040;
										return obj10 == null;
									}
								}
							}
						}
					}
				}
			}
		}
		return true;
	}

	[MethodImpl((MethodImplOptions)256)]
	public int GetFinalDepthRelative(int sortOrderOffset = 0)
	{
		//IL_0088: Expected I, but got O
		//IL_007a: Expected I4, but got O
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected I4, but got Unknown
		nint num = (nint)typeof(ArcadePhysics);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<ArcadePhysics>)+B8]");
		nint num2 = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
		{
			float2 float5 = cachedPosition;
			object obj = default(object);
			float num3 = (float)obj * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			object obj2 = default(object);
			return obj2 + sortOrderOffset;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected void CheckRenderer()
	{
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
		{
			SpriteRenderer component = GetComponent<SpriteRenderer>();
			_spriteRenderer = component;
			SpriteRenderer spriteRenderer2 = _spriteRenderer;
			if ((object)_spriteRenderer == null || ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0)
			{
				SpriteRenderer componentInChildren = GetComponentInChildren<SpriteRenderer>();
				_spriteRenderer = componentInChildren;
			}
		}
	}

	public void SetArcadeSpriteRenderer(SpriteRenderer spriteRenderer)
	{
		_spriteRenderer = spriteRenderer;
	}

	public void ForceInit()
	{
		CheckRenderer();
	}

	public float2 getCenter()
	{
		float2 float5 = position;
		float2 float6 = displaySize;
		BaseBody baseBody = body;
		float2 result = default(float2);
		if (body != null && baseBody._transform != null)
		{
			return result;
		}
		return (float2)new NullReferenceException();
	}

	public ArcadeSprite setOrigin(float oX = 0.5f, float? oY = null)
	{
		//IL_000e: Expected O, but got I4
		float? num = (float?)(((object)oY != null) ? oY : ((object)1));
		BaseBody baseBody = body;
		if ((object)num != null)
		{
			float2 float5 = default(float2);
			baseBody._transform.setOrigin(float5);
			return this;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		ArcadeSprite result = default(ArcadeSprite);
		return result;
	}

	public unsafe void setOriginFromFrame()
	{
		//IL_0062: Expected O, but got Ref
		//IL_0053: Expected O, but got I4
		Rect ret = default(Rect);
		Rect? rect = ((ArcadeSprite)(&ret)).frame;
		if ((object)rect != null)
		{
			Sprite sprite = _spriteRenderer.sprite;
			Vector2 pivot = sprite.pivot;
			bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
			BaseBody baseBody = body;
			float2 float5 = default(float2);
			baseBody._transform.setOrigin(float5);
		}
		else
		{
			ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		}
	}

	public ArcadeSprite setScale(float xScale, float? yScale = null)
	{
		if ((object)yScale != null)
		{
		}
		Transform cachedTrans = CachedTrans;
		bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, ref value);
		return this;
	}

	public ArcadeSprite setDepth(int depth)
	{
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer != null)
			{
				_spriteRenderer.sortingOrder = depth;
				return this;
			}
			return (ArcadeSprite)(object)new NullReferenceException();
		}
		GameObject context = base.gameObject;
		Debug.Log("[ArcadeSprite] SetDepth: Cannot find renderer", context);
		return this;
	}

	public ArcadeSprite setDepth(float depth)
	{
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			if ((object)_spriteRenderer != null)
			{
				int sortingOrder = default(int);
				_spriteRenderer.sortingOrder = sortingOrder;
				return this;
			}
			return (ArcadeSprite)(object)new NullReferenceException();
		}
		GameObject context = base.gameObject;
		Debug.Log("[ArcadeSprite] SetDepth: Cannot find renderer", context);
		return this;
	}

	public ArcadeSprite setFlipX(bool flipX)
	{
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (ArcadeSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.flipX = flipX;
		}
		return this;
	}

	public ArcadeSprite setFlipY(bool flipY)
	{
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (ArcadeSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.flipY = flipY;
		}
		return this;
	}

	public ArcadeSprite setVisible(bool visible)
	{
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (ArcadeSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.enabled = visible;
		}
		return this;
	}

	public ArcadeSprite setFrame(Sprite sprite)
	{
		CheckRenderer();
		if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer = _spriteRenderer;
			if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_spriteRenderer == null)
				{
					goto IL_0104;
				}
				_spriteRenderer.sprite = sprite;
				BaseBody baseBody = body;
				if (body != null)
				{
					if (baseBody._transform == null)
					{
						goto IL_0104;
					}
					baseBody._transform.OnSpriteChanged();
				}
			}
		}
		return this;
		IL_0104:
		return (ArcadeSprite)(object)new NullReferenceException();
	}

	public ArcadeSprite setFrameIncludingOriginalSize(Sprite sprite, float2 originalSize)
	{
		CheckRenderer();
		if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer = _spriteRenderer;
			if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_spriteRenderer == null)
				{
					goto IL_0108;
				}
				_spriteRenderer.sprite = sprite;
				BaseBody baseBody = body;
				if (body != null)
				{
					if (baseBody._transform == null)
					{
						goto IL_0108;
					}
					baseBody._transform.OnSpriteChanged(originalSize);
				}
			}
		}
		return this;
		IL_0108:
		return (ArcadeSprite)(object)new NullReferenceException();
	}

	public ArcadeSprite setAlpha(float alpha)
	{
		//IL_011e->IL0092: Incompatible stack heights: 3 vs 0
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer2 = _spriteRenderer;
			bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out Color _);
			SpriteRenderer spriteRenderer3 = _spriteRenderer;
			bool flag2 = (object)_spriteRenderer == null;
			bool flag3 = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer3).m_CachedPtr, ref value);
		}
		return this;
	}

	public unsafe ArcadeSprite setTint(uint tint)
	{
		//IL_013f->IL0092: Incompatible stack heights: 3 vs 0
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer2 = _spriteRenderer;
			bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out Color _);
			SpriteRenderer spriteRenderer3 = _spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			bool flag2 = (object)_spriteRenderer == null;
			bool flag3 = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer3).m_CachedPtr, ref *(Color*)(&value));
		}
		return this;
	}

	public unsafe ArcadeSprite setColor(Color color)
	{
		//IL_00c5->IL0088: Incompatible stack heights: 1 vs 0
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			object spriteRenderer2 = _spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v4 (System.Object)+10]");
			float value = default(float);
			SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
		}
		return this;
	}

	public ArcadeSprite setTintFill(bool isEnabled, int tintColor)
	{
		return setTintFill(isEnabled, (uint)tintColor);
	}

	public unsafe ArcadeSprite setTintFill(bool isEnabled, uint tintColor)
	{
		//IL_0031: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		object obj = default(object);
		return setTintFill(isEnabled, (Color?)(object)(&obj));
	}

	public ArcadeSprite setTintFill(bool isEnabled, Color? tintColor = null)
	{
		//IL_0206->IL0146: Incompatible stack heights: 1 vs 0
		//IL_00b5->IL0146: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL0148: Incompatible stack heights: 1 vs 0
		//IL_023b->IL0148: Incompatible stack heights: 3 vs 0
		//IL_0146->IL0146: Incompatible stack heights: 3 vs 0
		CheckRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			IntPtr ptr = MaterialPropertyBlock.CreateImpl();
			materialPropertyBlock.m_Ptr = ptr;
			if ((object)_spriteRenderer != null)
			{
				((Renderer)_spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetInt("_ApplyTintFill", isEnabled ? 1 : 0);
				SpriteRenderer spriteRenderer2 = _spriteRenderer;
				if ((object)_spriteRenderer != null)
				{
					bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
					Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, materialPropertyBlock.m_Ptr);
					if (!isEnabled || (object)tintColor == null)
					{
						goto IL_0146;
					}
					if ((object)_spriteRenderer != null)
					{
						((Renderer)_spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
						bool flag2 = (object)tintColor == null;
						int num = Shader.PropertyToID("_TintFillColor");
						bool flag3 = materialPropertyBlock.m_Ptr == (IntPtr)0;
						Color value = default(Color);
						MaterialPropertyBlock.SetColorImpl_Injected(materialPropertyBlock.m_Ptr, num, ref value);
						if ((object)_spriteRenderer != null)
						{
							((Renderer)_spriteRenderer).Internal_SetPropertyBlock(materialPropertyBlock);
							goto IL_0146;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0146;
		IL_0146:
		return this;
	}

	public ArcadeSprite setBounce(float2 bounce)
	{
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._bounce = bounce;
			return this;
		}
		return (ArcadeSprite)(object)new NullReferenceException();
	}

	public void setVelocity(float xVel, float? yVel = null)
	{
		//IL_002c: Expected O, but got F4
		if ((object)yVel == null)
		{
			float num = xVel;
		}
		else
		{
			float num2 = default(float);
			float num = num2;
		}
		BaseBody baseBody = body;
		baseBody._velocity = (float2)xVel;
	}

	public void setVelocity(Vector2 velocity)
	{
		BaseBody baseBody = body;
		baseBody._velocity = velocity;
	}

	public void setCollideWorldBounds(bool value, float? bounceX = null, float? bounceY = null)
	{
		//IL_0162: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		BaseBody baseBody = body;
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v3 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppClass<Body>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v3 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v9+FFFFFFF8+v59 @ rax_v8*8]");
			if (0 == (nint)typeof(Body))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998B245]");
				bool flag = (nint)0 == 0;
				baseBody._collideWorldBounds = false;
				if (flag)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rsi_v2 (BaseBody)+FC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if ((object)bounceX != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rsi_v2 (BaseBody)+FC]");
					if ((nint)0 == 0)
					{
						goto IL_01a7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rsi_v2 (BaseBody)+104]");
					_ = 0;
				}
				if ((object)bounceY != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rsi_v2 (BaseBody)+FC]");
					if ((nint)0 != 0)
					{
						return;
					}
					goto IL_01a7;
				}
				return;
			}
		}
		goto IL_0167;
		IL_0167:
		throw new InvalidCastException();
		IL_01a7:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_0167;
	}

	public ArcadeSprite()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
