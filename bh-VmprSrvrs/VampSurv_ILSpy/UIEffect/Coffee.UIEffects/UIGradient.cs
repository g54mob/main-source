using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIGradient : BaseMeshEffect
{
	public enum Direction
	{
		Horizontal,
		Vertical,
		Angle,
		Diagonal
	}

	public enum GradientStyle
	{
		Rect,
		Fit,
		Split
	}

	private static readonly Vector2[] s_SplitedCharacterPosition;

	private Direction m_Direction;

	private Color m_Color1;

	private Color m_Color2;

	private Color m_Color3;

	private Color m_Color4;

	private float m_Rotation;

	private float m_Offset1;

	private float m_Offset2;

	private GradientStyle m_GradientStyle;

	private ColorSpace m_ColorSpace;

	private bool m_IgnoreAspectRatio;

	public Direction direction
	{
		get
		{
			return m_Direction;
		}
		set
		{
			if (m_Direction != value)
			{
				m_Direction = value;
				base.SetVerticesDirty();
			}
		}
	}

	public unsafe Color color1
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_Color1;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_Color1 - value.r;
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
				m_Color1 = (Color)value.r;
				base.SetVerticesDirty();
			}
		}
	}

	public unsafe Color color2
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_Color2;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_Color2 - value.r;
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
				m_Color2 = (Color)value.r;
				base.SetVerticesDirty();
			}
		}
	}

	public unsafe Color color3
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_Color3;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_Color3 - value.r;
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
				m_Color3 = (Color)value.r;
				base.SetVerticesDirty();
			}
		}
	}

	public unsafe Color color4
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_Color4;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_Color4 - value.r;
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
				m_Color4 = (Color)value.r;
				base.SetVerticesDirty();
			}
		}
	}

	public float rotation
	{
		get
		{
			//IL_0050: Expected F4, but got I4
			if (m_Direction == Direction.Horizontal)
			{
				return -90f;
			}
			if (m_Direction == Direction.Vertical)
			{
				return 0f;
			}
			return m_Rotation;
		}
		set
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_Rotation = value;
				base.SetVerticesDirty();
			}
		}
	}

	public float offset
	{
		get
		{
			return m_Offset1;
		}
		set
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_Offset1 = value;
				base.SetVerticesDirty();
			}
		}
	}

	public Vector2 offset2
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			//IL_005b: Expected F4, but got O
			//IL_0065: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj2 = default(object);
				if (obj2 != null)
				{
					return;
				}
			}
			Vector2 vector = default(Vector2);
			m_Offset1 = (float)vector;
			m_Offset2 = (float)value;
			base.SetVerticesDirty();
		}
	}

	public GradientStyle gradientStyle
	{
		get
		{
			return m_GradientStyle;
		}
		set
		{
			if (m_GradientStyle != value)
			{
				m_GradientStyle = value;
				base.SetVerticesDirty();
			}
		}
	}

	public ColorSpace colorSpace
	{
		get
		{
			return m_ColorSpace;
		}
		set
		{
			if (m_ColorSpace != value)
			{
				m_ColorSpace = value;
				base.SetVerticesDirty();
			}
		}
	}

	public bool ignoreAspectRatio
	{
		get
		{
			return m_IgnoreAspectRatio;
		}
		set
		{
			if (m_IgnoreAspectRatio != value)
			{
				m_IgnoreAspectRatio = value;
				base.SetVerticesDirty();
			}
		}
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_0008: Expected O, but got Ref
		//IL_060d: Expected O, but got I4
		//IL_0157: Expected I4, but got O
		//IL_017a: Expected F4, but got I4
		//IL_0108: Expected F4, but got I4
		//IL_0119: Expected F4, but got I4
		//IL_00d1: Expected F4, but got I4
		//IL_00e2: Expected F4, but got I4
		//IL_07a5: Expected O, but got Ref
		//IL_07ce: Expected F4, but got I4
		//IL_02d2: Expected F4, but got I4
		//IL_01e3: Invalid comparison between O and F4
		//IL_0849: Expected O, but got F4
		//IL_0876: Expected O, but got F4
		//IL_08b2: Expected O, but got F4
		//IL_0202: Expected O, but got F4
		//IL_0323: Expected O, but got Ref
		//IL_0365: Expected F4, but got I
		//IL_0375: Expected F4, but got I
		//IL_06ff: Invalid comparison between F4 and O
		//IL_070d: Expected O, but got F4
		//IL_03bd: Expected O, but got I4
		//IL_0748: Expected O, but got Ref
		//IL_0750: Expected F4, but got O
		//IL_03af: Expected O, but got I
		//IL_045e: Expected I4, but got I8
		//IL_0588: Expected F4, but got I
		//IL_048d: Expected O, but got I4
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected I4, but got Unknown
		//IL_05c3: Expected O, but got Ref
		//IL_0a39: Expected O, but got Ref
		//IL_0a73: Expected O, but got I
		//IL_05a2: Expected O, but got Ref
		//IL_05e6: Expected O, but got Ref
		//IL_0260->IL05ec: Incompatible stack heights: 1 vs 0
		//IL_028a->IL05ec: Incompatible stack heights: 1 vs 0
		//IL_0195->IL05ec: Incompatible stack heights: 1 vs 0
		//IL_07e0->IL062a: Incompatible stack heights: 2 vs 1
		//IL_092f->IL05ec: Incompatible stack heights: 1 vs 0
		//IL_09b8->IL05ec: Incompatible stack heights: 1 vs 0
		//IL_0513->IL0975: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		float num3;
		float num4;
		float num5;
		UIVertex vertex = default(UIVertex);
		float num15 = default(float);
		float num21 = default(float);
		float num2;
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj3 == null)
			{
				return;
			}
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			bool flag2 = m_GradientStyle == GradientStyle.Rect;
			Graphic graphic2 = default(Graphic);
			if (!flag2)
			{
				nint num = (nint)(m_GradientStyle - 1);
				if (!flag2)
				{
					float num6 = default(float);
					if (num == 1)
					{
						VertexHelper vertexHelper = vh;
						num2 = 1f;
						num3 = 1f;
						num4 = 0f;
						num5 = num6;
						float num7 = 0f;
					}
					else
					{
						VertexHelper vertexHelper = vh;
						float num8 = default(float);
						num2 = num8;
						float num9 = default(float);
						num3 = num9;
						num4 = 0f;
						num5 = num6;
						float num7 = 0f;
					}
				}
				else
				{
					num2 = -3.4028235E+38f - 3.4028235E+38f;
					num3 = -3.4028235E+38f - 3.4028235E+38f;
					bool flag3 = vh == null;
					int num10 = (int)graphic2;
					VertexHelper vertexHelper = vh;
					num4 = 3.4028235E+38f;
					num5 = 3.4028235E+38f;
					float num7 = 0f;
					int num11 = 0;
					int num12 = 0;
					if (flag3)
					{
						goto IL_05ec;
					}
					while (true)
					{
						if (vh.m_Positions != null)
						{
							List<Vector3> positions = vh.m_Positions;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v933 @ rax_v72 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							num = 0;
						}
						else
						{
							num = 0;
						}
						if (num12 >= num)
						{
							break;
						}
						vh.PopulateUIVertex(ref vertex, num11);
						UIVertex uIVertex = ((System.Runtime.CompilerServices.Unsafe.As<UIVertex, UIntPtr>(ref vertex) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4)) ? vertex : ((UIVertex)num4));
						float num13 = num3 + num4;
						float num14 = num13 - (float)uIVertex;
						num7 = ((!(num15 > num5)) ? num15 : num5);
						float num16 = num2 + num5;
						float num17 = num16 - num7;
						float num18 = num14 + (float)uIVertex;
						bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num18) > System.Runtime.CompilerServices.Unsafe.As<UIVertex, UIntPtr>(ref vertex);
						UIVertex uIVertex2 = (UIVertex)num18;
						if (!flag4)
						{
							uIVertex2 = vertex;
						}
						num3 = (float)uIVertex2 - (float)uIVertex;
						float num19 = num17 + num7;
						if (!(num19 > num15))
						{
							num19 = num15;
						}
						int num20 = num11 + 1;
						num2 = num19 - num7;
						num10 = num11;
						vertexHelper = (VertexHelper)(&vertex);
						num4 = (float)uIVertex;
						num5 = num7;
						num11 = num20;
						num12 = num20;
					}
				}
				goto IL_062a;
			}
			if ((object)graphic2 != null)
			{
				RectTransform rectTransform = graphic2.rectTransform;
				if ((object)rectTransform != null)
				{
					bool flag5 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					float ret;
					RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)(&ret));
					VertexHelper vertexHelper = (VertexHelper)(&ret);
					num2 = num21;
					num3 = num21;
					num4 = ret;
					num5 = num21;
					float num7 = 0f;
					nint num = ((UnityEngine.Object)rectTransform).m_CachedPtr;
					goto IL_062a;
				}
			}
		}
		goto IL_05ec;
		IL_062a:
		float num22 = ((m_Direction == Direction.Horizontal) ? (-90f) : ((m_Direction != Direction.Vertical) ? m_Rotation : 0f));
		float num23 = num22 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		bool flag6 = m_IgnoreAspectRatio;
		float num24 = num23;
		float num25 = num23;
		if (!flag6)
		{
			bool flag7 = m_Direction < Direction.Angle;
			num24 = num23;
			num25 = num23;
			if (!flag7)
			{
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
				float num26 = num2 / num3;
				float num27 = num26 * num23;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
				num24 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+124]");
				num25 = 0f;
			}
		}
		object obj5 = num4 ^ -0f;
		float num28 = (float)obj5 / num3;
		float num29 = num28 - 0.5f;
		object obj6 = num5 ^ -0f;
		float num30 = (float)obj6 / num2;
		float num31 = num30 - 0.5f;
		float num32 = num24 / num3;
		object obj7 = num25 ^ -0f;
		float num33 = num24 * num29;
		float num34 = num25 * num31;
		float num35 = (float)obj7 / num2;
		float num36 = num33 - num34;
		float num37 = num36 + 0.5f;
		float num38 = num24 / num2;
		if (vh != null)
		{
			int num39 = 0;
			int num40 = 0;
			Color color = default(Color);
			while (true)
			{
				object obj8;
				if (vh.m_Positions != null)
				{
					List<Vector3> positions2 = vh.m_Positions;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1262 @ rax_v58 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					obj8 = 0;
				}
				else
				{
					obj8 = 0;
				}
				if (num40 >= (nint)obj8)
				{
					return;
				}
				vh.PopulateUIVertex(ref vertex, num39);
				float num45;
				if (m_GradientStyle != GradientStyle.Split)
				{
					float num41 = num35 * num15;
					float num42 = (float)vertex * num32;
					float num43 = num42 + num41;
					float num44 = num43 + num37;
					num45 = m_Offset2 + num44;
				}
				else
				{
					Vector2[] array = s_SplitedCharacterPosition;
					if (s_SplitedCharacterPosition == null)
					{
						break;
					}
					int num46 = (int)(num39 & 0x80000003L);
					if ((nint)s_SplitedCharacterPosition < 0)
					{
						object obj9 = num46 - 1;
						object obj10 = obj9 | -4;
						num46 = obj10 + 1;
					}
					bool flag8 = num46 >= array.Length;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v35 (UnityEngine.Vector2[])+20+v990 @ rax_v51 (System.Int32)*8]");
					float num47 = 0f * num32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v35 (UnityEngine.Vector2[])+24+v990 @ rax_v51 (System.Int32)*8]");
					float num48 = 0f * num35;
					float num49 = num47 + num48;
					float num50 = num49 + num37;
					num45 = m_Offset2 + num50;
				}
				if (m_Direction == Direction.Diagonal)
				{
					float num51 = num21 - num21;
					float num52 = num51 * num45;
					num2 = num52 + num21;
					float num53 = num21 - num21;
					float num54 = num53 * num45;
					num31 = num54 + num21;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
					num38 = 0f;
				}
				if (m_ColorSpace == ColorSpace.Gamma)
				{
					Color gamma = color.gamma;
					Color color2 = (Color)(&color);
				}
				else
				{
					bool flag9 = m_ColorSpace != ColorSpace.Linear;
					Color color2 = (Color)(&vertex);
					if (!flag9)
					{
						Color linear = color.linear;
						color2 = (Color)(&color);
					}
				}
				float num55 = num21 * num21;
				float num56 = num21 * num21;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
				UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
				_ = 0;
				vh.SetUIVertex(vertex2, num39);
				num39++;
				num40 = num39;
			}
		}
		goto IL_05ec;
		IL_05ec:
		throw new NullReferenceException();
	}

	public UIGradient()
	{
		//IL_0012: Expected O, but got I
		//IL_0024: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_0045: Expected I4, but got I8
		//IL_0057: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_Color1 = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_Color2 = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_Color3 = (Color)0;
		m_ColorSpace = ColorSpace.Uninitialized;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_Color4 = (Color)0;
		m_IgnoreAspectRatio = true;
		base._002Ector();
	}

	static UIGradient()
	{
		//IL_0090: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_00d6: Expected I, but got O
		//IL_00f9: Expected I, but got O
		Vector2[] array = new Vector2[4];
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_ = Vector2.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_ = Vector2.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
		_ = 0;
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v10 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		_ = Vector2.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		_ = 0;
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v12 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		_ = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v10 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		s_SplitedCharacterPosition = array;
	}
}
