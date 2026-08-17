using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIHsvModifier : BaseMaterialEffect
{
	private const uint k_ShaderId = 48u;

	private static readonly ParameterTexture s_ParamTex;

	private Color m_TargetColor;

	private float m_Range;

	private float m_Hue;

	private float m_Saturation;

	private float m_Value;

	public unsafe Color targetColor
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_TargetColor;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_TargetColor - value.r;
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
				m_TargetColor = (Color)value.r;
				SetEffectParamsDirty();
			}
		}
	}

	public float range
	{
		get
		{
			return m_Range;
		}
		set
		{
			//IL_0009: Invalid comparison between I4 and F4
			//IL_005c: Expected F4, but got I4
			float num;
			if (!(0f > value))
			{
				bool flag = !(value > 1f);
				num = value;
				if (!flag)
				{
					num = 1f;
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
				m_Range = num;
				SetEffectParamsDirty();
			}
		}
	}

	public float saturation
	{
		get
		{
			return m_Saturation;
		}
		set
		{
			bool flag = -0.5f > value;
			float num = -0.5f;
			float num2;
			if (!flag)
			{
				bool flag2 = !(value > 0.5f);
				num = 0.5f;
				num2 = value;
				if (flag2)
				{
					goto IL_0079;
				}
			}
			num2 = num;
			goto IL_0079;
			IL_0079:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_Saturation = num2;
				SetEffectParamsDirty();
			}
		}
	}

	public float value
	{
		get
		{
			return m_Value;
		}
		set
		{
			bool flag = -0.5f > value;
			float num = -0.5f;
			float num2;
			if (!flag)
			{
				bool flag2 = !(value > 0.5f);
				num = 0.5f;
				num2 = value;
				if (flag2)
				{
					goto IL_0079;
				}
			}
			num2 = num;
			goto IL_0079;
			IL_0079:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_Value = num2;
				SetEffectParamsDirty();
			}
		}
	}

	public float hue
	{
		get
		{
			return m_Hue;
		}
		set
		{
			bool flag = -0.5f > value;
			float num = -0.5f;
			float num2;
			if (!flag)
			{
				bool flag2 = !(value > 0.5f);
				num = 0.5f;
				num2 = value;
				if (flag2)
				{
					goto IL_0079;
				}
			}
			num2 = num;
			goto IL_0079;
			IL_0079:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_Hue = num2;
				SetEffectParamsDirty();
			}
		}
	}

	public override ParameterTexture paramTex => s_ParamTex;

	public unsafe override Hash128 GetMaterialHash(Material material)
	{
		//IL_00eb: Expected O, but got I4
		//IL_0138: Expected I8, but got O
		//IL_0133: Expected native int or pointer, but got O
		//IL_00b2: Expected I4, but got I8
		//IL_00c0: Expected I8, but got I4
		//IL_00bb: Expected native int or pointer, but got O
		//IL_00cd: Expected I8, but got I4
		//IL_00c8: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Hash128 hash = default(Hash128);
		if (obj != null && (object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
		{
			Shader shader = material.shader;
			if ((bool)shader)
			{
				int instanceID = material.GetInstanceID();
				int num = (int)(instanceID | 0x3000000000L);
				((Hash128*)(nint)hash)->u64_1 = 0uL;
				((Hash128*)(nint)hash)->u64_0 = (ulong)num;
				goto IL_013d;
			}
		}
		((Hash128*)(nint)hash)->u64_0 = (ulong)(long)BaseMaterialEffect.k_InvalidHash;
		goto IL_013d;
		IL_013d:
		return hash;
	}

	public unsafe override void ModifyMaterial(Material newMaterial, Graphic graphic)
	{
		//IL_0057: Expected O, but got Ref
		GraphicConnector graphicConnector = GraphicConnector.FindConnector(graphic);
		Shader shader = newMaterial.shader;
		string arg = ((UnityEngine.Object)shader).GetName();
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "Hidden/{0} (UIHsvModifier)", (System.ParamsArray)(&obj));
		Shader shader2 = Shader.Find(text);
		newMaterial.shader = shader2;
		ParameterTexture parameterTexture = paramTex;
		parameterTexture.RegisterMaterial(newMaterial);
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0175: Expected O, but got I4
		//IL_0084: Expected F4, but got I4
		//IL_008d: Expected F4, but got I4
		//IL_02db: Invalid comparison between I4 and F4
		//IL_01fc: Invalid comparison between I4 and F4
		//IL_00a4: Expected F4, but got I4
		//IL_0270: Expected O, but got Ref
		//IL_00e8: Expected F4, but got I4
		//IL_0158: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj3 == null)
		{
			return;
		}
		ParameterTexture parameterTexture = paramTex;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		_ = 0;
		_ = 0;
		object obj4 = default(object);
		float num = (float)obj4 - 0.5f;
		float num2 = num / (float)parameterTexture._instanceLimit;
		if (vh.m_Positions == null)
		{
			return;
		}
		List<Vector3> positions = vh.m_Positions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		float num3 = 0f;
		float num4 = 0f;
		int num5 = 0;
		UIVertex vertex = default(UIVertex);
		float num6 = default(float);
		object obj6 = default(object);
		object obj8 = default(object);
		bool flag4;
		do
		{
			vh.PopulateUIVertex(ref vertex, num5);
			float num7;
			if (0f > num6)
			{
				num7 = 0f;
			}
			else
			{
				bool flag2 = !(num6 > 1f);
				num7 = num6;
				if (!flag2)
				{
					num7 = 1f;
				}
			}
			float num8;
			if (0f > num3)
			{
				num8 = 0f;
			}
			else
			{
				bool flag3 = !(num3 > 1f);
				num8 = num3;
				if (!flag3)
				{
					num8 = 1f;
				}
			}
			float num9 = num8 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num10 = num7 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			object obj5 = obj6 << 12;
			object obj7 = obj8 + obj5;
			UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
			_ = 0;
			vh.SetUIVertex(vertex2, num5);
			num5++;
			int num11 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			flag4 = (nint)num11 < (nint)0;
			num3 = num2;
			num4 = 0f;
		}
		while (flag4);
	}

	protected override void SetEffectParamsDirty()
	{
		//IL_00dd: Invalid comparison between F4 and O
		//IL_012b: Expected F4, but got O
		//IL_0045: Invalid comparison between F4 and O
		//IL_0065: Invalid comparison between F4 and I4
		//IL_008e: Expected O, but got I4
		//IL_010b: Expected F4, but got O
		//IL_0114: Expected F4, but got I4
		//IL_014a: Invalid comparison between I4 and F4
		//IL_00b5: Expected F4, but got O
		//IL_0396: Expected I4, but got O
		//IL_018c: Invalid comparison between I4 and F4
		//IL_03c2: Expected I4, but got O
		//IL_01ce: Invalid comparison between I4 and F4
		//IL_03ee: Expected I4, but got O
		//IL_0212: Invalid comparison between I4 and F4
		//IL_041a: Expected I4, but got O
		//IL_0268: Invalid comparison between I4 and F4
		//IL_0446: Expected I4, but got O
		//IL_02bc: Invalid comparison between I4 and F4
		//IL_0472: Expected I4, but got O
		//IL_0310: Invalid comparison between I4 and F4
		//IL_049e: Expected I4, but got O
		_ = 0;
		_ = 0;
		_ = 0;
		float num = default(float);
		float colorone;
		float colortwo;
		float dominantcolor;
		float offset;
		if (num > num)
		{
			Color color = m_TargetColor;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<Color, UIntPtr>(ref color);
			float num2 = num - (float)m_TargetColor;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj = flag4 & flag3;
			if (obj != null)
			{
				colorone = (float)m_TargetColor;
				colortwo = num;
				dominantcolor = num;
				offset = 4f;
				goto IL_0349;
			}
		}
		Color color2 = m_TargetColor;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) <= System.Runtime.CompilerServices.Unsafe.As<Color, UIntPtr>(ref color2))
		{
			colorone = num;
			colortwo = num;
			dominantcolor = (float)m_TargetColor;
			offset = 0f;
		}
		else
		{
			colorone = num;
			colortwo = (float)m_TargetColor;
			dominantcolor = num;
			offset = 2f;
		}
		goto IL_0349;
		IL_0349:
		ref float h = default(ref float);
		ref float s = default(ref float);
		ref float v = default(ref float);
		Color.RGBToHSVHelper(offset, dominantcolor, colorone, colortwo, out h, out s, out v);
		ParameterTexture parameterTexture = paramTex;
		float num3 = default(float);
		if (0f > num3 || num3 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture.SetData(this, 0, (byte)(int)parameterTexture);
		ParameterTexture parameterTexture2 = paramTex;
		float num4 = default(float);
		if (0f > num4 || num4 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture2.SetData(this, 1, (byte)(int)parameterTexture2);
		ParameterTexture parameterTexture3 = paramTex;
		float num5 = default(float);
		if (0f > num5 || num5 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture3.SetData(this, 2, (byte)(int)parameterTexture3);
		ParameterTexture parameterTexture4 = paramTex;
		if (0f > m_Range || m_Range > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture4.SetData(this, 3, (byte)(int)parameterTexture4);
		ParameterTexture parameterTexture5 = paramTex;
		float num6 = m_Hue + 0.5f;
		if (0f > num6 || num6 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture5.SetData(this, 4, (byte)(int)parameterTexture5);
		ParameterTexture parameterTexture6 = paramTex;
		float num7 = m_Saturation + 0.5f;
		if (0f > num7 || num7 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture6.SetData(this, 5, (byte)(int)parameterTexture6);
		ParameterTexture parameterTexture7 = paramTex;
		float num8 = m_Value + 0.5f;
		if (0f > num8 || num8 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture7.SetData(this, 6, (byte)(int)parameterTexture7);
	}

	public UIHsvModifier()
	{
		//IL_001e: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		m_TargetColor = (Color)0;
		m_Range = 0.1f;
		((BaseMeshEffect)this)._002Ector();
	}

	static UIHsvModifier()
	{
		ParameterTexture parameterTexture = new ParameterTexture(7, 128, "_ParamTex");
		s_ParamTex = parameterTexture;
	}
}
