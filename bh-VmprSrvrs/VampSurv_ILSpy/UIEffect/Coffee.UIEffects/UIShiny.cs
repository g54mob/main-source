using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIShiny : BaseMaterialEffect
{
	private const uint k_ShaderId = 8u;

	private static readonly ParameterTexture s_ParamTex;

	private float _lastRotation;

	private EffectArea _lastEffectArea;

	private float m_EffectFactor = 0.5f;

	private float m_Width = 0.25f;

	private float m_Rotation = 135f;

	private float m_Softness = 1f;

	private float m_Brightness = 1f;

	private float m_Gloss = 1f;

	protected EffectArea m_EffectArea;

	private EffectPlayer m_Player;

	public float effectFactor
	{
		get
		{
			return m_EffectFactor;
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
				m_EffectFactor = num;
				SetEffectParamsDirty();
			}
		}
	}

	public float width
	{
		get
		{
			return m_Width;
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
				m_Width = num;
				SetEffectParamsDirty();
			}
		}
	}

	public float softness
	{
		get
		{
			return m_Softness;
		}
		set
		{
			bool flag = 0.01f > value;
			float num = 0.01f;
			float num2;
			if (!flag)
			{
				bool flag2 = !(value > 1f);
				num = 1f;
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
				m_Softness = num2;
				SetEffectParamsDirty();
			}
		}
	}

	public float brightness
	{
		get
		{
			return m_Brightness;
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
				m_Brightness = num;
				SetEffectParamsDirty();
			}
		}
	}

	public float gloss
	{
		get
		{
			return m_Gloss;
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
				m_Gloss = num;
				SetEffectParamsDirty();
			}
		}
	}

	public float rotation
	{
		get
		{
			return m_Rotation;
		}
		set
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				m_Rotation = value;
				SetVerticesDirty();
			}
		}
	}

	public EffectArea effectArea
	{
		get
		{
			return m_EffectArea;
		}
		set
		{
			if (m_EffectArea != value)
			{
				m_EffectArea = value;
				SetVerticesDirty();
			}
		}
	}

	public override ParameterTexture paramTex => s_ParamTex;

	public EffectPlayer effectPlayer
	{
		get
		{
			EffectPlayer effectPlayer = m_Player;
			if (m_Player == null)
			{
				effectPlayer = (m_Player = new EffectPlayer());
				effectPlayer.duration = 1f;
			}
			return effectPlayer;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		EffectPlayer effectPlayer = this.effectPlayer;
		Action<float> action = null;
		float f = default(float);
		((UIShiny)(object)action)._003COnEnable_003Eb__37_0(f);
		effectPlayer.OnEnable(action);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		EffectPlayer effectPlayer = this.effectPlayer;
		effectPlayer.OnDisable();
	}

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
				int num = (int)(instanceID | 0x800000000L);
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
		string text = string.FormatHelper((IFormatProvider)null, "Hidden/{0} (UIShiny)", (System.ParamsArray)(&obj));
		Shader shader2 = Shader.Find(text);
		newMaterial.shader = shader2;
		ParameterTexture parameterTexture = paramTex;
		parameterTexture.RegisterMaterial(newMaterial);
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0354: Expected O, but got I4
		//IL_0059: Expected O, but got Ref
		//IL_0070: Expected O, but got Ref
		//IL_00b2: Expected O, but got Ref
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0178: Expected O, but got I4
		//IL_016a: Expected O, but got I
		//IL_01c9: Expected O, but got I4
		//IL_01c9: Expected O, but got Ref
		//IL_01d9: Expected F4, but got I
		//IL_0220: Invalid comparison between I and F4
		//IL_0434: Expected F4, but got I
		//IL_020a: Expected F4, but got I4
		//IL_0264: Invalid comparison between I and F4
		//IL_0499: Invalid comparison between I4 and F4
		//IL_024e: Expected F4, but got I4
		//IL_04b9: Invalid comparison between I4 and F4
		//IL_0292: Expected F4, but got I4
		//IL_02d6: Expected F4, but got I4
		//IL_052d: Expected O, but got Ref
		//IL_041f->IL0339: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj3 == null)
		{
			return;
		}
		ParameterTexture parameterTexture = paramTex;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj4 = default(object);
		float num = (float)obj4 - 0.5f;
		float num2 = num / (float)parameterTexture._instanceLimit;
		RectTransform rectTransform = base.rectTransform;
		bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect ret);
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		float aspectRatio = default(float);
		Rect rect = EffectAreaExtensions.GetEffectArea(m_EffectArea, vh, (Rect)(&ret), aspectRatio);
		float num3 = m_Rotation * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		object obj8 = default(object);
		object obj7 = obj8 / obj8;
		float num4 = (float)obj7 * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+144]");
		object obj9 = 0 / obj8;
		int num5 = 0;
		int num6 = 0;
		float num11 = default(float);
		object obj12 = default(object);
		object obj14 = default(object);
		while (true)
		{
			object obj10;
			if (vh.m_Positions != null)
			{
				List<Vector3> positions = vh.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rax_v48 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				obj10 = 0;
			}
			else
			{
				obj10 = 0;
			}
			if (num6 >= (nint)obj10)
			{
				break;
			}
			vh.PopulateUIVertex(ref System.Runtime.CompilerServices.Unsafe.As<object, UIVertex>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)), num5);
			GraphicConnector graphicConnector = base.connector;
			graphicConnector.GetNormalizedFactor(m_EffectArea, num5, (Matrix2x3)(&ret), (Vector2)0, out *(Vector2*)null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-54]");
			float num7 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-54]");
			if ((nint)0 > (nint)0)
			{
				num7 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-54]");
				if (0f > 1f)
				{
					num7 = 1f;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			float num8 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			if ((nint)0 > (nint)0)
			{
				num8 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
				if (0f > 1f)
				{
					num8 = 1f;
				}
			}
			float num9 = num8 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num10 = num7 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num12;
			if (0f > num11)
			{
				num12 = 0f;
			}
			else
			{
				bool flag3 = !(num11 > 1f);
				num12 = num11;
				if (!flag3)
				{
					num12 = 1f;
				}
			}
			float num13 = ((0f > num2) ? 0f : ((!(num2 > 1f)) ? num2 : 1f));
			float num14 = num13 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num15 = num12 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			object obj11 = obj12 << 12;
			object obj13 = obj14 + obj11;
			UIVertex vertex = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			_ = 0;
			vh.SetUIVertex(vertex, num5);
			num5++;
			ret = (Rect)obj8;
			num6 = num5;
		}
	}

	public void Play(bool reset = true)
	{
		EffectPlayer effectPlayer = this.effectPlayer;
		if (reset)
		{
			effectPlayer._time = 0f;
		}
		effectPlayer.play = true;
	}

	public void Stop(bool reset = true)
	{
		EffectPlayer effectPlayer = this.effectPlayer;
		if (reset)
		{
			bool flag = effectPlayer._callback == null;
			effectPlayer._time = 0f;
			if (!flag)
			{
				Action<float> callback = effectPlayer._callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v66 @ rdx_v3 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
		}
		effectPlayer.play = false;
	}

	protected override void SetEffectParamsDirty()
	{
		//IL_001a: Invalid comparison between I4 and F4
		//IL_018a: Expected I4, but got O
		//IL_0060: Invalid comparison between I4 and F4
		//IL_01b6: Expected I4, but got O
		//IL_00a6: Invalid comparison between I4 and F4
		//IL_01e2: Expected I4, but got O
		//IL_00ec: Invalid comparison between I4 and F4
		//IL_020e: Expected I4, but got O
		//IL_0132: Invalid comparison between I4 and F4
		//IL_023a: Expected I4, but got O
		ParameterTexture parameterTexture = paramTex;
		if (0f > m_EffectFactor || m_EffectFactor > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture.SetData(this, 0, (byte)(int)parameterTexture);
		ParameterTexture parameterTexture2 = paramTex;
		if (0f > m_Width || m_Width > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture2.SetData(this, 1, (byte)(int)parameterTexture2);
		ParameterTexture parameterTexture3 = paramTex;
		if (0f > m_Softness || m_Softness > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture3.SetData(this, 2, (byte)(int)parameterTexture3);
		ParameterTexture parameterTexture4 = paramTex;
		if (0f > m_Brightness || m_Brightness > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture4.SetData(this, 3, (byte)(int)parameterTexture4);
		ParameterTexture parameterTexture5 = paramTex;
		if (0f > m_Gloss || m_Gloss > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture5.SetData(this, 4, (byte)(int)parameterTexture5);
	}

	protected override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		_lastRotation = m_Rotation;
		_lastEffectArea = m_EffectArea;
	}

	protected override void OnDidApplyAnimationProperties()
	{
		base.OnDidApplyAnimationProperties();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj = default(object);
		if (obj == null || _lastEffectArea != m_EffectArea)
		{
			SetVerticesDirty();
		}
	}

	static UIShiny()
	{
		ParameterTexture parameterTexture = new ParameterTexture(8, 128, "_ParamTex");
		s_ParamTex = parameterTexture;
	}

	private void _003COnEnable_003Eb__37_0(float f)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_005c: Expected F4, but got I4
		float num;
		if (!(0f > f))
		{
			bool flag = !(f > 1f);
			num = f;
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
			m_EffectFactor = num;
			SetEffectParamsDirty();
		}
	}
}
