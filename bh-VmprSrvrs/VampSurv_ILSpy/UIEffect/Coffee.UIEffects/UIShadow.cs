using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIShadow : BaseMeshEffect, IParameterTexture
{
	private static readonly List<UIShadow> tmpShadows;

	private static readonly List<UIVertex> s_Verts;

	private int _graphicVertexCount;

	private UIEffect _uiEffect;

	private float m_BlurFactor;

	private ShadowStyle m_Style;

	private Color m_EffectColor;

	private Vector2 m_EffectDistance;

	private bool m_UseGraphicAlpha;

	private const float kMaxEffectDistance = 600f;

	private int _003CparameterIndex_003Ek__BackingField;

	private ParameterTexture _003CparamTex_003Ek__BackingField;

	public unsafe Color effectColor
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_EffectColor;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_EffectColor - value.r;
			object obj2 = default(object);
			object obj = obj2 - obj2;
			object obj3 = obj2 - obj2;
			object obj4 = obj2 - obj2;
			object obj5 = obj * obj;
			float num2 = num * num;
			object obj6 = obj3 * obj3;
			float num3 = (float)obj5 + num2;
			object obj7 = obj4 * obj4;
			float num4 = num3 + (float)obj6;
			float num5 = num4 + (float)obj7;
			if (!(9.9999994E-11f > num5))
			{
				m_EffectColor = (Color)value.r;
				base.SetVerticesDirty();
			}
		}
	}

	public Vector2 effectDistance
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			//IL_0009: Invalid comparison between O and F4
			//IL_0040: Invalid comparison between F4 and O
			//IL_0051: Expected F4, but got O
			//IL_0059: Expected F4, but got O
			//IL_00dc: Expected O, but got F4
			float num;
			float num2;
			float num3;
			if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref value) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)600f))
			{
				num = 600f;
				num2 = 600f;
			}
			else
			{
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-600f)) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref value);
				num2 = (float)value;
				num3 = (float)value;
				if (flag)
				{
					goto IL_00f4;
				}
				num = -600f;
				num2 = -600f;
			}
			num3 = num;
			goto IL_00f4;
			IL_00f4:
			float num4 = default(float);
			float num5;
			float num6 = default(float);
			if (num4 > 600f)
			{
				num5 = 600f;
				num3 = num6;
			}
			else
			{
				bool flag2 = !(-600f > num4);
				num5 = num4;
				if (!flag2)
				{
					num5 = -600f;
					num3 = num6;
				}
			}
			float num7 = (float)m_EffectDistance - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIEffects.UIShadow)+6C]");
			float num8 = 0f - num5;
			float num9 = num7 * num7;
			float num10 = num8 * num8;
			float num11 = num10 + num9;
			if (!(9.9999994E-11f > num11))
			{
				m_EffectDistance = (Vector2)num3;
				base.SetEffectParamsDirty();
			}
		}
	}

	public bool useGraphicAlpha
	{
		get
		{
			return m_UseGraphicAlpha;
		}
		set
		{
			if (m_UseGraphicAlpha != value)
			{
				m_UseGraphicAlpha = value;
				base.SetEffectParamsDirty();
			}
		}
	}

	public float blurFactor
	{
		get
		{
			return m_BlurFactor;
		}
		set
		{
			//IL_0009: Invalid comparison between I4 and F4
			//IL_005c: Expected F4, but got I4
			float num;
			if (!(0f > value))
			{
				bool flag = !(value > 2f);
				num = value;
				if (!flag)
				{
					num = 2f;
				}
			}
			else
			{
				num = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_BlurFactor = num;
				base.SetEffectParamsDirty();
			}
		}
	}

	public ShadowStyle style
	{
		get
		{
			return m_Style;
		}
		set
		{
			if (m_Style != value)
			{
				m_Style = value;
				base.SetEffectParamsDirty();
			}
		}
	}

	public int parameterIndex
	{
		get
		{
			return _003CparameterIndex_003Ek__BackingField;
		}
		set
		{
			_003CparameterIndex_003Ek__BackingField = value;
		}
	}

	public ParameterTexture paramTex
	{
		get
		{
			return _003CparamTex_003Ek__BackingField;
		}
		private set
		{
			_003CparamTex_003Ek__BackingField = value;
		}
	}

	protected override void OnEnable()
	{
		GraphicConnector graphicConnector = base.connector;
		Graphic graphic = base.graphic;
		graphicConnector.OnEnable(graphic);
		base.SetVerticesDirty();
		UIEffect component = GetComponent<UIEffect>();
		_uiEffect = component;
		UIEffect uiEffect = _uiEffect;
		if ((object)_uiEffect != null && ((UnityEngine.Object)uiEffect).m_CachedPtr != (IntPtr)0)
		{
			ParameterTexture parameterTexture = _uiEffect.paramTex;
			_003CparamTex_003Ek__BackingField = parameterTexture;
			_003CparamTex_003Ek__BackingField.Register(this);
		}
	}

	protected override void OnDisable()
	{
		GraphicConnector graphicConnector = base.connector;
		Graphic graphic = base.graphic;
		graphicConnector.OnDisable(graphic);
		base.SetVerticesDirty();
		_uiEffect = null;
		if (_003CparamTex_003Ek__BackingField != null)
		{
			_003CparamTex_003Ek__BackingField.Unregister(this);
			_003CparamTex_003Ek__BackingField = null;
		}
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_043e: Expected O, but got I4
		//IL_04eb: Expected O, but got I4
		//IL_06a4: Expected O, but got Ref
		//IL_02d3: Expected I4, but got O
		//IL_05fd: Expected I4, but got O
		//IL_0347: Invalid comparison between I and F4
		//IL_03a3: Invalid comparison between I4 and F4
		//IL_0058->IL0423: Incompatible stack heights: 1 vs 0
		//IL_04b0->IL0423: Incompatible stack heights: 1 vs 0
		//IL_067c->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0503->IL0593: Incompatible stack heights: 2 vs 1
		//IL_05d2->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0231->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0526->IL0145: Incompatible stack heights: 2 vs 1
		//IL_0400->IL0423: Incompatible stack heights: 1 vs 0
		//IL_029c->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0145->IL058e: Incompatible stack heights: 3 vs 1
		//IL_0140->IL0568: Incompatible stack heights: 4 vs 3
		//IL_02ed->IL0423: Incompatible stack heights: 1 vs 0
		//IL_030c->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0617->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0393->IL0423: Incompatible stack heights: 1 vs 0
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if (vh != null)
			{
				if (vh.m_Positions == null)
				{
					return;
				}
				List<Vector3> positions = vh.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rax_v32 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				if ((nint)0 <= (nint)0 || m_Style == ShadowStyle.None)
				{
					return;
				}
				vh.GetUIVertexStream(s_Verts);
				GetComponents(tmpShadows);
				if (tmpShadows != null)
				{
					List<UIShadow>.Enumerator enumerator = default(List<UIShadow>.Enumerator);
					List<UIShadow>.Enumerator enumerator2 = default(List<UIShadow>.Enumerator);
					while (enumerator.MoveNext())
					{
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rbx_v19 (System.IntPtr)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rbx_v19 (System.IntPtr)+10]");
						object obj2 = Behaviour.get_isActiveAndEnabled_Injected((IntPtr)0);
						if (obj2 == null)
						{
							continue;
						}
						if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
						{
							bool flag3 = tmpShadows == null;
							while (enumerator2.MoveNext())
							{
								nint num2 = 0;
								MissingMethodException ex = (MissingMethodException)(object)s_Verts;
								bool flag4 = s_Verts == null;
								_ = ((Exception)ex)._message;
							}
						}
						break;
					}
					List<UIShadow> list = tmpShadows;
					if (tmpShadows != null)
					{
						int version = list._version + 1;
						list._version = version;
						list._size = 0;
						if (list._size > 0)
						{
							Array.Clear(list._items, 0, list._size);
						}
						UIEffect uiEffect = ((!_uiEffect) ? GetComponent<UIEffect>() : _uiEffect);
						_uiEffect = uiEffect;
						if (s_Verts != null && s_Verts != null)
						{
							if (_003CparamTex_003Ek__BackingField == null || !_uiEffect)
							{
								goto IL_0681;
							}
							if ((object)_uiEffect != null)
							{
								if (!_uiEffect.IsActive())
								{
									goto IL_0681;
								}
								byte b = (byte)(int)_uiEffect;
								if ((object)_uiEffect != null && _003CparamTex_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v78 (System.Byte)+58]");
									if ((nint)0 <= (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v78 (System.Byte)+58]");
										if (!(0f > 1f))
										{
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
									_003CparamTex_003Ek__BackingField.SetData(this, 0, (byte)(int)_uiEffect);
									if (_003CparamTex_003Ek__BackingField != null)
									{
										_003CparamTex_003Ek__BackingField.SetData(this, 1, 255);
										if (_003CparamTex_003Ek__BackingField != null)
										{
											if (0f > m_BlurFactor || m_BlurFactor > 1f)
											{
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
											byte value = default(byte);
											_003CparamTex_003Ek__BackingField.SetData(this, 2, value);
											goto IL_0681;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0423;
		IL_0423:
		throw new NullReferenceException();
		IL_0681:
		Color color = default(Color);
		int start = default(int);
		ref int end = default(ref int);
		Vector2 distance = default(Vector2);
		ShadowStyle shadowStyle = default(ShadowStyle);
		bool alpha = default(bool);
		ApplyShadow(s_Verts, (Color)(&color), ref start, ref end, distance, shadowStyle, alpha);
		vh.Clear();
		vh.AddUIVertexTriangleStream(s_Verts);
		List<UIVertex> list2 = s_Verts;
		if (s_Verts != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v33 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			return;
		}
		goto IL_0423;
	}

	private void ApplyShadow(List<UIVertex> verts, Color color, ref int start, ref int end, Vector2 distance, ShadowStyle style, bool alpha)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0041: Invalid comparison between I4 and F4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_00a8: Expected O, but got I
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 55;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+6F]");
		if ((nint)0 == 0 || !(0f < color.a))
		{
			return;
		}
		Color color2 = (Color)(obj - 65);
		_ = color.r;
		ref int end2 = default(ref int);
		float x = default(float);
		float y = default(float);
		bool alpha2 = default(bool);
		ApplyShadowZeroAlloc(verts, color2, ref start, ref end2, x, y, alpha2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+6F]");
		object obj3 = -2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+6F]");
		bool flag = (nint)0 == 2;
		if (!flag)
		{
			object obj4 = obj3 - 1;
			if (!flag)
			{
				if ((nint)obj4 != 1)
				{
					return;
				}
			}
			else
			{
				Color color3 = (Color)(obj - 65);
				_ = color.r;
				ApplyShadowZeroAlloc(verts, color3, ref start, ref end2, x, y, alpha2);
				Color color4 = (Color)(obj - 65);
				_ = color.r;
				ApplyShadowZeroAlloc(verts, color4, ref start, ref end2, x, y, alpha2);
				Color color5 = (Color)(obj - 65);
				_ = color.r;
				ApplyShadowZeroAlloc(verts, color5, ref start, ref end2, x, y, alpha2);
				Color color6 = (Color)(obj - 65);
				_ = color.r;
				ApplyShadowZeroAlloc(verts, color6, ref start, ref end2, x, y, alpha2);
				Color color7 = (Color)(obj - 65);
				_ = color.r;
				ApplyShadowZeroAlloc(verts, color7, ref start, ref end2, x, y, alpha2);
			}
			Color color8 = (Color)(obj - 65);
			_ = color.r;
			ApplyShadowZeroAlloc(verts, color8, ref start, ref end2, x, y, alpha2);
		}
		else
		{
			Color color9 = (Color)(obj - 65);
			_ = color.r;
			ApplyShadowZeroAlloc(verts, color9, ref start, ref end2, x, y, alpha2);
			Color color10 = (Color)(obj - 65);
			_ = color.r;
			ApplyShadowZeroAlloc(verts, color10, ref start, ref end2, x, y, alpha2);
		}
		Color color11 = (Color)(obj - 65);
		_ = color.r;
		ApplyShadowZeroAlloc(verts, color11, ref start, ref end2, x, y, alpha2);
	}

	private unsafe void ApplyShadowZeroAlloc(List<UIVertex> verts, Color color, ref int start, ref int end, float x, float y, bool alpha)
	{
		//IL_0008: Expected O, but got Ref
		//IL_04de: Expected O, but got I
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_001d: Expected O, but got I
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0058: Expected I, but got O
		//IL_0560: Expected O, but got I4
		//IL_0244: Expected O, but got I
		//IL_04b5: Expected O, but got I
		//IL_04cd: Expected O, but got I
		//IL_06ed: Expected O, but got I
		//IL_0696: Expected O, but got I4
		//IL_06a3: Expected I4, but got O
		//IL_01d2: Expected O, but got I
		//IL_0282: Expected O, but got I
		//IL_01f2: Expected O, but got I
		//IL_01a4: Expected O, but got Ref
		//IL_01b1: Expected O, but got I4
		//IL_03be: Expected O, but got I
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected Ref, but got Unknown
		//IL_03d1: Expected O, but got I4
		//IL_0422: Expected O, but got I
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_05ec: Expected O, but got Ref
		//IL_05fa: Invalid comparison between F4 and I4
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_066e: Expected O, but got I
		//IL_0529: Expected I4, but got O
		//IL_0552: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+100]");
		object obj3 = 0;
		object obj4 = obj3 - start;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
		object obj6 = 0 + obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v4+18]");
		bool flag = 0 >= (nint)obj6;
		nint num = (nint)color;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v4+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v4+18]");
			int capacity = (int)(num2 + 0);
			verts.Capacity = capacity;
			num = 0;
		}
		float num4;
		if (_003CparamTex_003Ek__BackingField != null)
		{
			UIEffect uiEffect = _uiEffect;
			if ((object)_uiEffect != null && ((UnityEngine.Object)uiEffect).m_CachedPtr != (IntPtr)0 && _uiEffect.IsActive())
			{
				ParameterTexture parameterTexture = _003CparamTex_003Ek__BackingField;
				((List<UIVertex>)null).Capacity = (int)typeof(IParameterTexture);
				object obj7 = default(object);
				float num3 = (float)obj7 - 0.5f;
				num4 = num3 / (float)parameterTexture._instanceLimit;
				num = (nint)this;
				goto IL_0557;
			}
		}
		num4 = -1f;
		goto IL_0557;
		IL_04a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+100]");
		object obj8 = 0;
		ref int reference = ref *(int*)obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
		obj8 = 0;
		return;
		IL_05b2:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0557:
		obj = 0;
		object obj10 = default(object);
		if ((nint)obj4 > 0)
		{
			int num5 = 0;
			nint num6 = num;
			bool flag2;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v18+18]");
				if (num7 >= 0)
				{
					_ = 0;
					_ = 0;
					verts.AddWithResize((UIVertex)(&obj10));
					obj10 = 0;
					num = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
					object obj11 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
					object obj12 = (nint)0 * (nint)108;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					num = num6;
				}
				num5++;
				flag2 = num5 < (nint)obj4;
				num6 = num;
			}
			while (flag2);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
		object obj13 = -1;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
		{
			goto IL_0380;
		}
		object obj14 = obj13 - obj4;
		while (true)
		{
			object obj15 = obj14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
			if ((nint)obj15 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
			object obj16 = 0;
			ref int reference2 = ref *(int*)(obj14 * 108);
			object obj17 = obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
			if ((nint)obj17 >= 0)
			{
				break;
			}
			obj14--;
			object obj18 = obj13 * 108;
			obj13--;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+20+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+30+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+40+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+50+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+60+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+70+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+80+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v6 (System.Int32&)+88+v204 @ rdx_v16]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+1C]");
			_ = (nint)0 + (nint)1;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
			{
				continue;
			}
			goto IL_0380;
		}
		goto IL_05b2;
		IL_0380:
		if ((nint)obj4 <= 0)
		{
			goto IL_04a5;
		}
		int num8 = 0;
		object obj24 = default(object);
		Color color2 = default(Color);
		while (true)
		{
			object obj19 = start + num8;
			int num9 = (int)(obj19 + obj4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
			if ((nint)num9 >= (nint)0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
			object obj20 = 0;
			object obj21 = num9 * 108;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+80+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+88+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+20+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+40+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+20+v219 @ rcx_v15]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+108]");
			object obj22 = num10 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+110]");
			object obj23 = obj24 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+50+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+70+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+118]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,0Bh\"");
			}
			((List<UIVertex>)(&color2)).Capacity = num9;
			if (!(num4 < 0f))
			{
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+70+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+80+v219 @ rcx_v15]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v17+88+v219 @ rcx_v15]");
			_ = 0;
			verts.Capacity = num8;
			num8++;
			bool flag3 = num8 < (nint)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			obj10 = 0;
			num = (nint)(&obj10);
			if (flag3)
			{
				continue;
			}
			goto IL_04a5;
		}
		goto IL_05b2;
	}

	public UIShadow()
	{
		//IL_0012: Expected O, but got I
		//IL_0033: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11DC0]");
		m_EffectColor = (Color)0;
		m_BlurFactor = 1f;
		m_Style = ShadowStyle.Shadow;
		m_EffectDistance = (Vector2)1065353216;
		_ = 3212836864L;
		m_UseGraphicAlpha = true;
		base._002Ector();
	}

	static UIShadow()
	{
		//IL_0014: Expected I, but got O
		List<UIShadow> list = new List<UIShadow>();
		tmpShadows = list;
		List<UIVertex> list2 = null;
		nint num = unchecked((nint)null);
		s_Verts = list2;
	}
}
