using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Phaser;

public class PhaserSprite : GameMonoBehaviour
{
	private SpriteRenderer _spriteRenderer;

	private SpriteAnimation _spriteAnimation;

	public float _originX;

	public float _originY;

	public SpriteAnimation Anim => _spriteAnimation;

	public SpriteAnimation anims => _spriteAnimation;

	public SpriteRenderer Rend => _spriteRenderer;

	public unsafe Bounds Bounds
	{
		get
		{
			//IL_0051: Expected native int or pointer, but got O
			SpriteRenderer spriteRenderer = _spriteRenderer;
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Vector3 ret;
			Renderer.get_bounds_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Bounds*)(&ret));
			Bounds bounds = default(Bounds);
			((Bounds*)(nint)bounds)->m_Center = ret;
			_ = 0;
			return bounds;
		}
	}

	public unsafe float X
	{
		get
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			return ret;
		}
		set
		{
			//IL_00ad->IL0054: Incompatible stack heights: 1 vs 0
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				Transform transform3 = base.transform;
				if ((object)transform3 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
					bool flag3 = (object)transform == null;
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	public float Y
	{
		get
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			float result = default(float);
			return result;
		}
		set
		{
			//IL_00ad->IL0054: Incompatible stack heights: 1 vs 0
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				Transform transform3 = base.transform;
				if ((object)transform3 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
					bool flag3 = (object)transform == null;
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	public float2 position
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			float2 result = default(float2);
			return result;
		}
		[MethodImpl((MethodImplOptions)256)]
		set
		{
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		}
	}

	public unsafe float Width
	{
		get
		{
			//IL_00a6->IL003d: Incompatible stack heights: 1 vs 0
			SpriteRenderer spriteRenderer = _spriteRenderer;
			if ((object)_spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				float ret;
				Renderer.get_bounds_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Bounds*)(&ret));
				object obj = default(object);
				float num = (float)obj * 2f;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					return ret * num;
				}
			}
			throw new NullReferenceException();
		}
	}

	public unsafe float Height
	{
		get
		{
			//IL_00a7->IL003d: Incompatible stack heights: 1 vs 0
			SpriteRenderer spriteRenderer = _spriteRenderer;
			if ((object)_spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				float ret;
				Renderer.get_bounds_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Bounds*)(&ret));
				float num = 0f * 2f;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					object obj = default(object);
					return (float)obj * num;
				}
			}
			throw new NullReferenceException();
		}
	}

	public bool flipX
	{
		get
		{
			SpriteRenderer spriteRenderer = _spriteRenderer;
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public bool flipY
	{
		get
		{
			SpriteRenderer spriteRenderer = _spriteRenderer;
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
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
			Transform transform = base.transform;
			return transform.localEulerAngles.z;
		}
		set
		{
			//IL_0038: Expected O, but got Ref
			Transform transform = base.transform;
			Vector3 localEulerAngles = transform.localEulerAngles;
			Transform transform2 = base.transform;
			object obj = default(object);
			transform2.localEulerAngles = (Vector3)(&obj);
		}
	}

	public unsafe float Alpha
	{
		get
		{
			SpriteRenderer spriteRenderer = _spriteRenderer;
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			float ret;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)(&ret));
			float result = default(float);
			return result;
		}
	}

	protected virtual void Awake()
	{
		EnsureSpriteRenderer();
	}

	public void InternalForceInit()
	{
		EnsureSpriteRenderer();
	}

	public PhaserSprite setName(string newName)
	{
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			((UnityEngine.Object)gameObject).SetName(newName);
			return this;
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public PhaserSprite setOrigin(float2 origin)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 32 Invalid \"Jump target not found in method: 0x186B49D00\"");
		PhaserSprite result = default(PhaserSprite);
		return result;
	}

	public unsafe PhaserSprite setOrigin(float originX = 0.5f, float? originY = null)
	{
		//IL_0067: Expected O, but got I4
		//IL_00cd->IL0156: Incompatible stack heights: 1 vs 0
		//IL_01c6->IL0156: Incompatible stack heights: 3 vs 0
		float num2 = default(float);
		SpriteCachedData value = default(SpriteCachedData);
		while (true)
		{
			EnsureSpriteRenderer();
			SpriteRenderer spriteRenderer = _spriteRenderer;
			if ((object)_spriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
			{
				break;
			}
			float originY2;
			float? num;
			if ((object)originY == null)
			{
				originY2 = originX;
				num = (float?)(object)1;
			}
			else
			{
				originY2 = num2;
				num = originY;
			}
			_originX = originX;
			if ((object)num != null)
			{
				_originY = originY2;
				bool flag = (object)_spriteRenderer == null;
				Sprite sprite = _spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					value.SetUsingSpritePPU(sprite);
					bool flag2 = (object)_spriteRenderer == null;
					Transform transform = _spriteRenderer.transform;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				}
				break;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
		return this;
	}

	public PhaserSprite setScale(float xScale, float? yScale = null)
	{
		if ((object)yScale != null)
		{
		}
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		return this;
	}

	[MethodImpl((MethodImplOptions)256)]
	public int GetFinalDepthRelative(int sortOrderOffset = 0)
	{
		//IL_0072: Expected I, but got O
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected I4, but got Unknown
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					object obj = default(object);
					float num3 = (float)obj * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
					object obj2 = default(object);
					return obj2 + sortOrderOffset;
				}
			}
		}
		throw new NullReferenceException();
	}

	public PhaserSprite setDepth(float depth)
	{
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			if ((object)_spriteRenderer == null)
			{
				return (PhaserSprite)(object)new NullReferenceException();
			}
			int sortingOrder = default(int);
			_spriteRenderer.sortingOrder = sortingOrder;
		}
		return this;
	}

	public PhaserSprite setDepth(int depth)
	{
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (PhaserSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.sortingOrder = depth;
		}
		return this;
	}

	public PhaserSprite setFlipX(bool flipX)
	{
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (PhaserSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.flipX = flipX;
		}
		return this;
	}

	public PhaserSprite setFlipY(bool flipY)
	{
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (PhaserSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.flipY = flipY;
		}
		return this;
	}

	public PhaserSprite setVisible(bool visible)
	{
		EnsureSpriteRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_spriteRenderer == null)
			{
				return (PhaserSprite)(object)new NullReferenceException();
			}
			_spriteRenderer.enabled = visible;
		}
		return this;
	}

	public PhaserSprite setFrame(string spriteName, string textureName)
	{
		Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
		PhaserSprite phaserSprite = setFrame(sprite);
		return this;
	}

	public string getFrameName()
	{
		if ((object)_spriteRenderer != null)
		{
			Sprite sprite = _spriteRenderer.sprite;
			if ((object)sprite != null)
			{
				return ((UnityEngine.Object)sprite).GetName();
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public PhaserSprite setFrame(Sprite sprite)
	{
		EnsureSpriteRenderer();
		if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer = _spriteRenderer;
			if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_spriteRenderer == null)
				{
					return (PhaserSprite)(object)new NullReferenceException();
				}
				_spriteRenderer.sprite = sprite;
			}
		}
		return this;
	}

	public PhaserSprite setAlpha(float alpha)
	{
		//IL_011e->IL0092: Incompatible stack heights: 3 vs 0
		EnsureSpriteRenderer();
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

	public PhaserSprite setTint(int tintColor)
	{
		return setTint((uint)tintColor);
	}

	public unsafe PhaserSprite setTint(uint topLeft, uint topRight, uint bottomLeft, uint bottomRight, BlendMode blendMode = BlendMode.Normal)
	{
		//IL_0024: Expected O, but got Ref
		//IL_0024: Expected O, but got Ref
		//IL_0024: Expected O, but got Ref
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		Color bottomRight2 = default(Color);
		BlendMode blendMode2 = default(BlendMode);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_spriteRenderer, (Color)(&obj), (Color)(&obj2), (Color)(&obj3), bottomRight2, blendMode2);
		return this;
	}

	public unsafe PhaserSprite setTint(uint tintColor)
	{
		EnsureSpriteRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			object spriteRenderer2 = _spriteRenderer;
			bool flag = (object)_spriteRenderer == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rsi_v1 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rsi_v1 (System.Object)+10]");
			SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rsi_v1 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rsi_v1 (System.Object)+10]");
			float value = default(float);
			SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
			return this;
		}
		return this;
	}

	public unsafe PhaserSprite setTintFill(bool isEnabled, uint tintColor)
	{
		//IL_0031: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		object obj = default(object);
		return setTintFill(isEnabled, (Color?)(object)(&obj));
	}

	public unsafe PhaserSprite setTintFill(bool isEnabled, Color? tintColor = null)
	{
		//IL_010e: Expected O, but got Ref
		//IL_0201->IL0141: Incompatible stack heights: 1 vs 0
		//IL_00b0->IL0141: Incompatible stack heights: 1 vs 0
		//IL_00cf->IL0143: Incompatible stack heights: 1 vs 0
		//IL_0128->IL0143: Incompatible stack heights: 2 vs 0
		//IL_0141->IL0141: Incompatible stack heights: 2 vs 0
		EnsureSpriteRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			IntPtr ptr = MaterialPropertyBlock.CreateImpl();
			materialPropertyBlock.m_Ptr = ptr;
			if ((object)_spriteRenderer != null)
			{
				((Renderer)_spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
				RenderingExtensions.SetTintFillEnabled(materialPropertyBlock, isEnabled);
				SpriteRenderer spriteRenderer2 = _spriteRenderer;
				if ((object)_spriteRenderer != null)
				{
					bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
					Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, materialPropertyBlock.m_Ptr);
					if (!isEnabled || (object)tintColor == null)
					{
						goto IL_0141;
					}
					if ((object)_spriteRenderer != null)
					{
						((Renderer)_spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
						bool flag2 = (object)tintColor == null;
						object obj = default(object);
						RenderingExtensions.SetTintFillColor(materialPropertyBlock, (Color)(&obj));
						if ((object)_spriteRenderer != null)
						{
							((Renderer)_spriteRenderer).Internal_SetPropertyBlock(materialPropertyBlock);
							goto IL_0141;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0141;
		IL_0141:
		return this;
	}

	public PhaserSprite setBlendMode(BlendMode blendMode)
	{
		EnsureSpriteRenderer();
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetBlendMode(_spriteRenderer, blendMode);
		}
		return this;
	}

	public PhaserSprite setPosition(float2 value)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		return this;
	}

	public PhaserSprite setPosition(float x, float y)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		return this;
	}

	public PhaserSprite setLocalPosition(float2 value)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		return this;
	}

	public PhaserSprite setLocalPosition(float x, float y)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		return this;
	}

	public PhaserSprite setParent(Transform parent, bool keepWorldPos = true)
	{
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			transform.SetParent(parent, keepWorldPos);
			return this;
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public PhaserSprite setDrawModeSliced(float width, float height)
	{
		//IL_002f: Expected O, but got I4
		object spriteRenderer = _spriteRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v1 (System.Object)+10]");
		SpriteRenderer.set_drawMode_Injected((IntPtr)0, SpriteDrawMode.Sliced);
		Vector2 size = default(Vector2);
		_spriteRenderer.size = size;
		PhaserSprite phaserSprite = setOrigin(_originX, (float?)(object)1);
		return this;
	}

	public PhaserSprite setDrawModeSimple()
	{
		//IL_0066: Expected O, but got I4
		object spriteRenderer = _spriteRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
		SpriteRenderer.set_drawMode_Injected((IntPtr)0, SpriteDrawMode.Simple);
		PhaserSprite phaserSprite = setOrigin(_originX, (float?)(object)1);
		return this;
	}

	public void destroy()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public PhaserSprite SetAsTiledSprite()
	{
		//IL_0037->IL004d: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null)
		{
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.set_drawMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, SpriteDrawMode.Tiled);
			Material material = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
			if ((object)_spriteRenderer != null)
			{
				((Renderer)_spriteRenderer).SetMaterial(material);
				return this;
			}
		}
		throw new NullReferenceException();
	}

	public PhaserSprite SetTileSize(float width, float height)
	{
		//IL_005f: Expected O, but got I4
		SpriteRenderer spriteRenderer = _spriteRenderer;
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		object obj = SpriteRenderer.get_drawMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
		if ((nint)obj == 2)
		{
			Vector2 size = default(Vector2);
			_spriteRenderer.size = size;
		}
		return this;
	}

	public PhaserSprite SetTileWidth(float width)
	{
		//IL_0073: Expected O, but got I4
		SpriteRenderer spriteRenderer = _spriteRenderer;
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		object obj = SpriteRenderer.get_drawMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
		if ((nint)obj == 2)
		{
			Vector2 size = _spriteRenderer.size;
			Vector2 size2 = default(Vector2);
			_spriteRenderer.size = size2;
		}
		return this;
	}

	public PhaserSprite SetTileHeight(float height)
	{
		//IL_0073: Expected O, but got I4
		SpriteRenderer spriteRenderer = _spriteRenderer;
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		object obj = SpriteRenderer.get_drawMode_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
		if ((nint)obj == 2)
		{
			Vector2 size = _spriteRenderer.size;
			Vector2 size2 = default(Vector2);
			_spriteRenderer.size = size2;
		}
		return this;
	}

	public PhaserSprite SetMaterial(MaterialType material)
	{
		EnsureSpriteRenderer();
		Material material2 = MaterialManager.GetMaterial(material);
		if ((object)_spriteRenderer != null)
		{
			((Renderer)_spriteRenderer).SetMaterial(material2);
			return this;
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	private void EnsureSpriteRenderer()
	{
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_03b4: Expected O, but got I4
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_0174->IL0325: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = _spriteRenderer;
		if ((object)_spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			int childCount = transform.childCount;
			if (childCount <= 0)
			{
				GameObject gameObject = new GameObject("PhaserSpriteRenderer");
				if ((object)gameObject != null)
				{
					Transform transform2 = gameObject.transform;
					Transform parent = base.transform;
					if ((object)transform2 != null)
					{
						transform2.SetParent(parent, worldPositionStays: true);
						Transform transform3 = gameObject.transform;
						bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
						SpriteRenderer spriteRenderer2 = gameObject.AddComponent<SpriteRenderer>();
						_spriteRenderer = spriteRenderer2;
						SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
						_spriteAnimation = spriteAnimation;
						Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
						((Renderer)_spriteRenderer).SetMaterial(material);
						return;
					}
				}
			}
			else
			{
				Transform transform4 = base.transform;
				if ((object)transform4 != null)
				{
					Transform child = transform4.GetChild(0);
					if ((object)child != null)
					{
						SpriteRenderer component = child.GetComponent<SpriteRenderer>();
						_spriteRenderer = component;
						Transform transform5 = base.transform;
						if ((object)transform5 != null)
						{
							Transform child2 = transform5.GetChild(0);
							if ((object)child2 != null)
							{
								SpriteAnimation component2 = child2.GetComponent<SpriteAnimation>();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
								bool flag2 = (nint)0 == 0;
								_spriteAnimation = component2;
								if (flag2)
								{
									return;
								}
								object obj = this + 48;
								object obj2 = obj >> 12;
								object obj3 = obj2 & 0x1FFFFF;
								object obj4 = obj3 >> 6;
								object obj5 = obj3 & 0x3F;
								object obj6 = obj4 * 8;
								object obj7 = 6603577472L + obj6;
								nint num2;
								do
								{
									object obj8 = 1 << (int)obj5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v18+462E0]");
									object obj9 = 0 | obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v18+462E0]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v18+462E0]");
									if (num == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v18+462E0]");
									num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v18+462E0]");
								}
								while (num2 != 0);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public PhaserSprite()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
