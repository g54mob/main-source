using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIDissolve : BaseMaterialEffect, IMaterialModifier
{
	private const uint k_ShaderId = 0u;

	private static readonly ParameterTexture s_ParamTex;

	private static readonly int k_TransitionTexId;

	private bool _lastKeepAspectRatio;

	private EffectArea _lastEffectArea;

	private static Texture _defaultTransitionTexture;

	private float m_EffectFactor;

	private float m_Width;

	private float m_Softness;

	private Color m_Color;

	private ColorMode m_ColorMode;

	private Texture m_TransitionTexture;

	protected EffectArea m_EffectArea;

	private bool m_KeepAspectRatio;

	private EffectPlayer m_Player;

	private bool m_Reverse;

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
				m_Softness = num;
				SetEffectParamsDirty();
			}
		}
	}

	public unsafe Color color
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_Color;
			return color;
		}
		set
		{
			//IL_00cc: Expected O, but got F4
			float num = (float)m_Color - value.r;
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
				m_Color = (Color)value.r;
				SetEffectParamsDirty();
			}
		}
	}

	public Texture transitionTexture
	{
		get
		{
			Texture texture = m_TransitionTexture;
			if ((object)m_TransitionTexture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
			{
				return m_TransitionTexture;
			}
			return defaultTransitionTexture;
		}
		set
		{
			//IL_0106: Expected O, but got I4
			//IL_0120: Expected O, but got I4
			Texture texture = m_TransitionTexture;
			bool flag = (object)m_TransitionTexture == null;
			bool flag2 = (object)value == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 != null)
			{
				return;
			}
			bool flag4;
			if ((object)value != null)
			{
				if ((object)m_TransitionTexture != null)
				{
					object obj3 = (object)m_TransitionTexture - (object)value;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)value).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)texture).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				m_TransitionTexture = value;
				SetMaterialDirty();
			}
		}
	}

	private static Texture defaultTransitionTexture
	{
		get
		{
			Texture texture = _defaultTransitionTexture;
			if ((object)_defaultTransitionTexture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
			{
				return _defaultTransitionTexture;
			}
			return _defaultTransitionTexture = Resources.Load<Texture>("Default-Transition");
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

	public bool keepAspectRatio
	{
		get
		{
			return m_KeepAspectRatio;
		}
		set
		{
			if (m_KeepAspectRatio != value)
			{
				m_KeepAspectRatio = value;
				SetVerticesDirty();
			}
		}
	}

	public ColorMode colorMode
	{
		get
		{
			return m_ColorMode;
		}
		set
		{
			if (m_ColorMode != value)
			{
				m_ColorMode = value;
				SetMaterialDirty();
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

	public unsafe override Hash128 GetMaterialHash(Material material)
	{
		//IL_0124: Expected O, but got I4
		//IL_0171: Expected I8, but got O
		//IL_016c: Expected native int or pointer, but got O
		//IL_00d1: Expected O, but got I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected I4, but got Unknown
		//IL_00f9: Expected I8, but got I4
		//IL_00f4: Expected native int or pointer, but got O
		//IL_0106: Expected I8, but got I4
		//IL_0101: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Hash128 hash = default(Hash128);
		if (obj != null && (object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
		{
			Shader shader = material.shader;
			if ((bool)shader)
			{
				Texture texture = transitionTexture;
				int instanceID = texture.GetInstanceID();
				int instanceID2 = material.GetInstanceID();
				object obj2 = (int)m_ColorMode << 6;
				object obj3 = obj2 << 32;
				int num = obj3 | instanceID2;
				((Hash128*)(nint)hash)->u64_1 = (ulong)instanceID;
				((Hash128*)(nint)hash)->u64_0 = (ulong)num;
				goto IL_0176;
			}
		}
		((Hash128*)(nint)hash)->u64_0 = (ulong)(long)BaseMaterialEffect.k_InvalidHash;
		goto IL_0176;
		IL_0176:
		return hash;
	}

	public unsafe override void ModifyMaterial(Material newMaterial, Graphic graphic)
	{
		//IL_0057: Expected O, but got Ref
		//IL_0096: Expected I4, but got O
		//IL_00c4: Expected I, but got O
		GraphicConnector graphicConnector = GraphicConnector.FindConnector(graphic);
		Shader shader = newMaterial.shader;
		string arg = ((UnityEngine.Object)shader).GetName();
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "Hidden/{0} (UIDissolve)", (System.ParamsArray)(&obj));
		Shader shader2 = Shader.Find(text);
		newMaterial.shader = shader2;
		object[] array = new object[1];
		object obj3 = default(object);
		object obj2 = (ColorMode)obj3;
		if (obj2 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		SetShaderVariants(newMaterial, array);
		Texture value = transitionTexture;
		newMaterial.SetTextureImpl(k_TransitionTexId, value);
		ParameterTexture parameterTexture = paramTex;
		parameterTexture.RegisterMaterial(newMaterial);
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0433: Expected O, but got I4
		//IL_00e9: Expected O, but got Ref
		//IL_0190: Expected O, but got I4
		//IL_0190: Expected O, but got Ref
		//IL_01a0: Expected F4, but got I
		//IL_01e7: Invalid comparison between I and F4
		//IL_0538: Expected F4, but got I
		//IL_01d1: Expected F4, but got I4
		//IL_022b: Invalid comparison between I and F4
		//IL_05a4: Expected F4, but got I
		//IL_0215: Expected F4, but got I4
		//IL_026f: Invalid comparison between I and F4
		//IL_05d5: Invalid comparison between I4 and F4
		//IL_0259: Expected F4, but got I4
		//IL_05f5: Invalid comparison between I4 and F4
		//IL_029d: Expected F4, but got I4
		//IL_02e1: Expected F4, but got I4
		//IL_0365: Expected O, but got Ref
		//IL_004f->IL0412: Incompatible stack heights: 1 vs 0
		//IL_04cc->IL0412: Incompatible stack heights: 1 vs 0
		//IL_009c->IL0412: Incompatible stack heights: 1 vs 0
		//IL_0129->IL0412: Incompatible stack heights: 2 vs 0
		//IL_0523->IL0411: Incompatible stack heights: 2 vs 1
		//IL_0163->IL0411: Incompatible stack heights: 2 vs 1
		//IL_0692->IL0412: Incompatible stack heights: 2 vs 0
		//IL_0411->IL0411: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj3 == null)
			{
				return;
			}
			ParameterTexture parameterTexture = paramTex;
			if (parameterTexture != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj4 = default(object);
				float num = (float)obj4 - 0.5f;
				float num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v20 (Coffee.UIEffects.ParameterTexture)+2C]");
				float num3 = num2 / 0f;
				Texture texture = transitionTexture;
				if (m_KeepAspectRatio && (bool)texture)
				{
					if ((object)texture == null)
					{
						goto IL_0412;
					}
					int num4 = texture.width;
					int height = texture.height;
				}
				RectTransform rectTransform = base.rectTransform;
				if ((object)rectTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					float ret;
					RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)(&ret));
					float aspectRatio = default(float);
					Rect rect = EffectAreaExtensions.GetEffectArea(m_EffectArea, vh, (Rect)(&ret), aspectRatio);
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					if (vh != null)
					{
						if (vh.m_Positions == null)
						{
							return;
						}
						List<Vector3> positions = vh.m_Positions;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rax_v34 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						if ((nint)0 <= (nint)0)
						{
							return;
						}
						int num5 = 0;
						UIVertex vertex = default(UIVertex);
						float num11 = default(float);
						object obj6 = default(object);
						RectTransform rectTransform2 = default(RectTransform);
						object obj10 = default(object);
						while (true)
						{
							vh.PopulateUIVertex(ref vertex, num5);
							GraphicConnector graphicConnector = base.connector;
							if (graphicConnector == null)
							{
								break;
							}
							graphicConnector.GetPositionFactor(m_EffectArea, num5, (Rect)(&ret), (Vector2)0, out *(float*)null, out *(float*)null);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-74]");
							float num6 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-74]");
							if ((nint)0 > (nint)0)
							{
								num6 = 0f;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-74]");
								if (0f > 1f)
								{
									num6 = 1f;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
							float num7 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
							if ((nint)0 > (nint)0)
							{
								num7 = 0f;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
								if (0f > 1f)
								{
									num7 = 1f;
								}
							}
							float num8 = num7 * 4095f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
							float num9 = num6 * 4095f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
							float num10 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
							if ((nint)0 > (nint)0)
							{
								num10 = 0f;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
								if (0f > 1f)
								{
									num10 = 1f;
								}
							}
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
							float num13 = ((0f > num3) ? 0f : ((!(num3 > 1f)) ? num3 : 1f));
							float num14 = num13 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
							float num15 = num12 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
							float num16 = num10 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
							object obj5 = obj6 << 8;
							object obj7 = obj5 + (object)rectTransform2;
							object obj8 = obj7 << 8;
							object obj9 = obj10 + obj8;
							UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
							_ = 0;
							_ = 0;
							obj = obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
							_ = 0;
							vh.SetUIVertex(vertex2, num5);
							num5++;
							int num17 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rax_v34 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							bool flag4 = (nint)num17 < (nint)0;
							ret = rect.m_XMin;
							if (!flag4)
							{
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0412;
		IL_0412:
		throw new NullReferenceException();
	}

	protected override void SetEffectParamsDirty()
	{
		//IL_001a: Invalid comparison between I4 and F4
		//IL_01e8: Expected I4, but got O
		//IL_0060: Invalid comparison between I4 and F4
		//IL_0214: Expected I4, but got O
		//IL_00a6: Invalid comparison between I4 and F4
		//IL_0240: Expected I4, but got O
		//IL_026c: Expected I4, but got O
		//IL_010b: Invalid comparison between O and F4
		//IL_0298: Expected I4, but got O
		//IL_015d: Invalid comparison between I and F4
		//IL_02c4: Expected I4, but got O
		//IL_01af: Invalid comparison between I and F4
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
		if (0 > (nint)m_Color || System.Runtime.CompilerServices.Unsafe.As<Color, UIntPtr>(ref m_Color) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture4.SetData(this, 4, (byte)(int)parameterTexture4);
		ParameterTexture parameterTexture5 = paramTex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIEffects.UIDissolve)+70]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIEffects.UIDissolve)+70]");
			if (!(0f > 1f))
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture5.SetData(this, 5, (byte)(int)parameterTexture5);
		ParameterTexture parameterTexture6 = paramTex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIEffects.UIDissolve)+74]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIEffects.UIDissolve)+74]");
			if (!(0f > 1f))
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture6.SetData(this, 6, (byte)(int)parameterTexture6);
	}

	protected override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		_lastKeepAspectRatio = m_KeepAspectRatio;
		_lastEffectArea = m_EffectArea;
	}

	protected override void OnDidApplyAnimationProperties()
	{
		base.OnDidApplyAnimationProperties();
		if (_lastKeepAspectRatio != m_KeepAspectRatio || _lastEffectArea != m_EffectArea)
		{
			SetVerticesDirty();
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

	protected override void OnEnable()
	{
		base.OnEnable();
		EffectPlayer effectPlayer = this.effectPlayer;
		Action<float> action = null;
		float f = default(float);
		((UIDissolve)(object)action)._003COnEnable_003Eb__54_0(f);
		effectPlayer.OnEnable(action);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		EffectPlayer effectPlayer = this.effectPlayer;
		effectPlayer.OnDisable();
	}

	public UIDissolve()
	{
		//IL_001e: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12430]");
		m_Color = (Color)0;
		m_EffectFactor = 0.5f;
		m_Width = 0.5f;
		m_Softness = 0.5f;
		m_ColorMode = ColorMode.Add;
		((BaseMeshEffect)this)._002Ector();
	}

	static UIDissolve()
	{
		ParameterTexture parameterTexture = new ParameterTexture(8, 128, "_ParamTex");
		s_ParamTex = parameterTexture;
		int num = Shader.PropertyToID("_TransitionTex");
		k_TransitionTexId = num;
	}

	private void _003COnEnable_003Eb__54_0(float f)
	{
		//IL_009b: Invalid comparison between I4 and F4
		//IL_0078: Expected F4, but got I4
		float num = ((!m_Reverse) ? f : (1f - f));
		if (!(0f > num))
		{
			if (num > 1f)
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
