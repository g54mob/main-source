using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UIEffect : BaseMaterialEffect, IMaterialModifier
{
	private enum BlurEx
	{
		None,
		Ex
	}

	private const uint k_ShaderId = 16u;

	private static readonly ParameterTexture s_ParamTex;

	private float m_EffectFactor = 1f;

	private float m_ColorFactor = 1f;

	private float m_BlurFactor = 1f;

	private EffectMode m_EffectMode;

	private ColorMode m_ColorMode;

	private BlurMode m_BlurMode;

	private bool m_AdvancedBlur;

	public AdditionalCanvasShaderChannels uvMaskChannel
	{
		get
		{
			//IL_0067: Expected I4, but got O
			//IL_002f: Expected I, but got O
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			GraphicConnector graphicConnector = base.connector;
			if (graphicConnector != null)
			{
				nint num = (nint)graphicConnector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rdx_v2 (Il2CppClass<Coffee.UIEffects.GraphicConnector>)+188]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rdx_v2 (Il2CppClass<Coffee.UIEffects.GraphicConnector>)+190]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v15 @ r8_v1 (should have been resolved before IL gen)");
			}
			NullReferenceException ex = new NullReferenceException();
			return (AdditionalCanvasShaderChannels)ex;
		}
	}

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

	public float colorFactor
	{
		get
		{
			return m_ColorFactor;
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
				m_ColorFactor = num;
				SetEffectParamsDirty();
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
				m_BlurFactor = num;
				SetEffectParamsDirty();
			}
		}
	}

	public EffectMode effectMode
	{
		get
		{
			return m_EffectMode;
		}
		set
		{
			if (m_EffectMode != value)
			{
				m_EffectMode = value;
				SetMaterialDirty();
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

	public BlurMode blurMode
	{
		get
		{
			return m_BlurMode;
		}
		set
		{
			if (m_BlurMode != value)
			{
				m_BlurMode = value;
				SetMaterialDirty();
			}
		}
	}

	public override ParameterTexture paramTex => s_ParamTex;

	public bool advancedBlur
	{
		get
		{
			return m_AdvancedBlur;
		}
		set
		{
			if (m_AdvancedBlur != value)
			{
				m_AdvancedBlur = value;
				base.SetVerticesDirty();
				SetMaterialDirty();
			}
		}
	}

	public unsafe override Hash128 GetMaterialHash(Material material)
	{
		//IL_0141: Expected O, but got I4
		//IL_01c8: Expected I8, but got O
		//IL_01c3: Expected native int or pointer, but got O
		//IL_00b0: Expected O, but got I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0103: Expected I8, but got I4
		//IL_00fe: Expected native int or pointer, but got O
		//IL_010c: Expected O, but got I4
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected I4, but got Unknown
		//IL_01b5: Expected I8, but got I4
		//IL_01b0: Expected native int or pointer, but got O
		//IL_0123: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Hash128 hash = default(Hash128);
		if (obj != null && (object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
		{
			Shader shader = material.shader;
			if ((bool)shader)
			{
				int instanceID = material.GetInstanceID();
				object obj2 = (int)m_BlurMode * 4;
				object obj3 = m_ColorMode + obj2;
				object obj4 = obj3 * 8;
				object obj5 = m_EffectMode + obj4;
				object obj6 = obj5 << 6;
				bool flag2 = (byte)(~(m_AdvancedBlur ? 1u : 0u)) != 0;
				((Hash128*)(nint)hash)->u64_1 = 0uL;
				object obj7 = 16;
				if (!flag2)
				{
					obj7 = 8208;
				}
				object obj8 = obj7 + obj6;
				object obj9 = obj8 << 32;
				int num = obj9 | instanceID;
				((Hash128*)(nint)hash)->u64_0 = (ulong)num;
				return hash;
			}
		}
		((Hash128*)(nint)hash)->u64_0 = (ulong)(long)BaseMaterialEffect.k_InvalidHash;
		return hash;
	}

	public unsafe override void ModifyMaterial(Material newMaterial, Graphic graphic)
	{
		//IL_0057: Expected O, but got Ref
		//IL_00c5: Expected I, but got O
		//IL_012e: Expected I, but got O
		//IL_0197: Expected I, but got O
		//IL_01ff: Expected I, but got O
		GraphicConnector graphicConnector = GraphicConnector.FindConnector(graphic);
		Shader shader = newMaterial.shader;
		string arg = ((UnityEngine.Object)shader).GetName();
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "Hidden/{0} (UIEffect)", (System.ParamsArray)(&obj));
		Shader shader2 = Shader.Find(text);
		newMaterial.shader = shader2;
		object[] array = new object[4];
		EffectMode effectMode = default(EffectMode);
		object obj2 = effectMode;
		if (obj2 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj4 = (ColorMode)effectMode;
		if (obj4 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		ColorMode colorMode = default(ColorMode);
		object obj6 = (BlurMode)colorMode;
		if (obj6 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		BlurMode blurMode = default(BlurMode);
		object obj8 = (BlurEx)blurMode;
		if (obj8 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		SetShaderVariants(newMaterial, array);
		ParameterTexture parameterTexture = paramTex;
		parameterTexture.RegisterMaterial(newMaterial);
	}

	public unsafe override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0d13: Expected O, but got I4
		//IL_0f65: Expected O, but got I4
		//IL_111a: Invalid comparison between I4 and F4
		//IL_0fb8: Invalid comparison between I4 and F4
		//IL_0c31: Expected F4, but got I4
		//IL_102c: Expected O, but got Ref
		//IL_0c6d: Expected F4, but got I4
		//IL_0118: Expected F4, but got I4
		//IL_0121: Expected F4, but got I4
		//IL_0143: Expected F4, but got I
		//IL_0194: Expected F4, but got I
		//IL_0194: Expected F4, but got I
		//IL_021a: Expected O, but got I4
		//IL_0bc2: Expected O, but got I
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_0279: Expected O, but got I
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_02f7: Expected O, but got I
		//IL_0338: Expected O, but got I
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_1145: Unknown result type (might be due to invalid IL or missing references)
		//IL_114a: Expected O, but got Unknown
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Expected O, but got Unknown
		//IL_082a: Expected O, but got I
		//IL_05b0: Expected O, but got I
		//IL_0838: Unknown result type (might be due to invalid IL or missing references)
		//IL_083d: Expected O, but got Unknown
		//IL_084d: Expected F4, but got I
		//IL_08dc: Expected F4, but got I
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_044e: Expected O, but got I4
		//IL_0a50: Expected I, but got O
		//IL_0a6f: Expected O, but got F4
		//IL_0604: Expected O, but got I
		//IL_0a82: Expected O, but got Ref
		//IL_0ad3: Expected O, but got I
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Expected O, but got Unknown
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b12: Expected O, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_0634: Expected O, but got I
		//IL_069c: Expected O, but got I
		//IL_06d9: Expected O, but got I
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Expected O, but got Unknown
		//IL_0b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Expected O, but got Unknown
		//IL_0f00: Invalid comparison between O and F4
		//IL_0954: Expected F4, but got I
		//IL_09d8: Invalid comparison between F4 and O
		//IL_04cb: Invalid comparison between F4 and O
		//IL_04f4: Invalid comparison between O and F4
		//IL_0512: Invalid comparison between F4 and I4
		//IL_053b: Expected O, but got I4
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected I4, but got Unknown
		//IL_07f7->IL113c: Incompatible stack heights: 5 vs 3
		//IL_0b98->IL0f19: Incompatible stack heights: 4 vs 1
		//IL_0b37->IL0f14: Incompatible stack heights: 4 vs 3
		//IL_0bb2->IL0de4: Incompatible stack heights: 4 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj3 == null)
		{
			return;
		}
		ParameterTexture parameterTexture = paramTex;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		bool flag2 = m_BlurMode == BlurMode.None;
		object obj4 = default(object);
		float num = (float)obj4 - 0.5f;
		float num2 = num / (float)parameterTexture._instanceLimit;
		if (!flag2 && m_AdvancedBlur)
		{
			vh.GetUIVertexStream(BaseMaterialEffect.s_TempVerts);
			vh.Clear();
			List<UIVertex> list = BaseMaterialEffect.s_TempVerts;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
			_ = 0;
			GraphicConnector graphicConnector = base.connector;
			bool flag3 = graphicConnector.IsText(graphic);
			bool flag4 = !flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
			int num3 = 0;
			if (!flag4)
			{
				num3 = 6;
			}
			_ = 0;
			_ = 0;
			float num4 = (float)m_BlurMode * 6f;
			float num5 = num4 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
			bool flag5 = (nint)0 <= (nint)0;
			VertexHelper vertexHelper = vh;
			if (!flag5)
			{
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
				_ = 0;
				int num6 = 0;
				float num7 = 0f;
				float num8 = 0f;
				int num9 = 0;
				int num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-74]");
				float num11 = 0f;
				float num13 = default(float);
				float num12 = num13;
				int num14 = 0;
				Rect posBounds = default(Rect);
				ref Rect uvBounds = default(ref Rect);
				bool global = default(bool);
				object obj7 = default(object);
				object obj15 = default(object);
				object obj17 = default(object);
				float num22 = default(float);
				bool flag23;
				do
				{
					GetBounds(BaseMaterialEffect.s_TempVerts, num9, num3, ref posBounds, ref uvBounds, global);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
					nint num15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+14]");
					float num16 = Packer.ToFloat(num15, 0f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C]");
					float num17 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+14]");
					float y = num17 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
					float num18 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
					float x = num18 + 0f;
					float num19 = Packer.ToFloat(x, y);
					if (num3 > 0)
					{
						object obj5 = num6 + 4;
						object obj6 = obj7;
						int num20 = num14;
						int num21 = 0;
						bool flag22;
						do
						{
							List<UIVertex> list2 = BaseMaterialEffect.s_TempVerts;
							object obj8 = obj5 - 3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdx_v33 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
							bool flag6 = (nint)obj8 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdx_v33 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
							object obj9 = 0;
							object obj10 = obj5 * 108;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFEDC+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFEEC+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFEFC+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFF0C+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFF1C+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFF44+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFF2C+v316 @ rdx_v34]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1729 @ rax_v62+FFFFFF3C+v316 @ rdx_v34]");
							obj = 0;
							List<UIVertex> list3 = BaseMaterialEffect.s_TempVerts;
							object obj11 = obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v35 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
							bool flag7 = (nint)obj11 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v35 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
							object obj12 = 0;
							object obj13 = obj5 * 108;
							int num24;
							if (num3 != 6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
								if (0 >= (nint)posBounds)
								{
									object obj14 = obj6 + (object)posBounds;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
									if ((nint)obj14 > 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-5C]");
										if (0 >= (nint)obj15)
										{
											object obj16 = obj17 + obj15;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-5C]");
											bool flag8 = (nint)obj16 < 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-5C]");
											object obj18 = obj16 - 0;
											bool flag9 = obj18 == null;
											bool flag10 = !flag8;
											bool flag11 = !flag9;
											object obj19 = flag11 & flag10;
											if (obj19 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1737 @ rax_v66+20+v318 @ rdx_v36]");
												if (0 >= (nint)posBounds)
												{
													object obj20 = obj6 + (object)posBounds;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1737 @ rax_v66+20+v318 @ rdx_v36]");
													if ((nint)obj20 > 0 && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num22) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
													{
														object obj21 = obj17 + obj15;
														bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num22);
														float num23 = (float)obj21 - num22;
														bool flag13 = num23 == 0f;
														bool flag14 = !flag12;
														bool flag15 = !flag13;
														object obj22 = flag15 & flag14;
														num24 = obj22 ^ 1;
														goto IL_0e40;
													}
												}
												num24 = 1;
												goto IL_0e40;
											}
										}
									}
								}
							}
							num24 = 1;
							goto IL_0e40;
							IL_0e40:
							if (num24 != 0)
							{
								List<UIVertex> list4 = BaseMaterialEffect.s_TempVerts;
								object obj23 = obj5 - 3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v44 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
								bool flag16 = (nint)obj23 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v44 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
								object obj24 = 0;
								object obj25 = obj5 * 108;
								List<UIVertex> list5 = BaseMaterialEffect.s_TempVerts;
								object obj26 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdx_v46 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
								bool flag17 = (nint)obj26 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rdx_v46 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
								object obj27 = 0;
								object obj28 = obj5 * 108;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1737 @ rax_v66+20+v318 @ rdx_v36]");
								nint num25 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
								object obj29 = num25 + 0;
								float num26 = num22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-5C]");
								float num27 = num26 + 0f;
								float num28 = (float)obj29 * 0.5f;
								float num29 = num27 * 0.5f;
								float num30 = num22 + num22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1906 @ rax_v93+50+v288 @ r8_v27]");
								nint num31 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2020 @ rax_v90+FFFFFF0C+v319 @ rdx_v45]");
								object obj30 = num31 + 0;
								float num32 = num30 * 0.5f;
								float num33 = (float)obj30 * 0.5f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
								nint num34 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1737 @ rax_v66+20+v318 @ rdx_v36]");
								object obj31 = num34 - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-5C]");
								float num35 = 0f - num22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj32 = obj31 & 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj33 = num35 & 0;
								float num36 = num5 / (float)obj32;
								float num37 = num5 / (float)obj33;
								num8 = num36 + 1f;
								num7 = num37 + 1f;
								float num38 = num28 * num8;
								float num39 = num29 * num7;
								float num40 = num29 - num39;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E0]");
								float num41 = 0f - num38;
								float num42 = num32 * num8;
								float num43 = num33 * num7;
								float num44 = num32 - num42;
								float num45 = num33 - num43;
								num11 = num45;
								num12 = num40;
							}
							object obj34 = obj5 - 4;
							object obj41;
							do
							{
								List<UIVertex> list6 = BaseMaterialEffect.s_TempVerts;
								object obj35 = obj34;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v39 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
								bool flag18 = (nint)obj35 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v39 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
								object obj36 = 0;
								object obj37 = obj34 * 108;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+50+v321 @ rdx_v40]");
								float num46 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+20+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+30+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+40+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+50+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+60+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+70+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+80+v321 @ rdx_v40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+88+v321 @ rdx_v40]");
								_ = 0;
								bool flag19 = num24 == 0;
								float num47 = num22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+20+v321 @ rdx_v40]");
								float num48 = 0f;
								float num49 = num22;
								if (flag19)
								{
									goto IL_0e79;
								}
								Rect rect = posBounds;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+20+v321 @ rdx_v40]");
								if ((nint)rect <= 0)
								{
									object obj38 = obj7 + (object)posBounds;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+20+v321 @ rdx_v40]");
									bool flag20 = 0 <= (nint)obj38;
									num47 = num22;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+20+v321 @ rdx_v40]");
									num48 = 0f;
									if (flag20)
									{
										goto IL_0ef8;
									}
								}
								float num50 = num8 * num22;
								float num51 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2022 @ rcx_v46+20+v321 @ rdx_v40]");
								float num52 = num51 * 0f;
								float num53 = num50;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
								float num54 = num53 + 0f;
								float num55 = num52;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E0]");
								num48 = num55 + 0f;
								num47 = num54;
								goto IL_0ef8;
								IL_0ef8:
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num22))
								{
									object obj39 = obj17 + obj15;
									bool flag21 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num22) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj39);
									num49 = num22;
									if (flag21)
									{
										goto IL_0e79;
									}
								}
								float num56 = num7 * num22;
								float num57 = num7 * num46;
								float num58 = num56 + num12;
								float num59 = num57 + num11;
								num46 = num59;
								num49 = num58;
								goto IL_0e79;
								IL_0e79:
								float num60 = num46 + 0.5f;
								float num61 = num47 + 0.5f;
								float y2 = num60 * 0.5f;
								float x2 = num61 * 0.5f;
								float num62 = Packer.ToFloat(x2, y2);
								_ = 0;
								GraphicConnector graphicConnector2 = base.connector;
								nint num63 = (nint)graphicConnector2;
								graphicConnector2.SetExtraChannel(ref System.Runtime.CompilerServices.Unsafe.As<object, UIVertex>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32)), (Vector2)num22);
								object obj40 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
								obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
								obj34++;
								obj41 = num20 + obj34;
							}
							while ((nint)obj41 < 6);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
							num3 = 0;
							num21 += 6;
							num20 -= 6;
							obj5 += 6;
							int num64 = num21;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
							flag22 = (nint)num64 < (nint)0;
							obj6 = obj7;
						}
						while (flag22);
						num9 = num6;
						num14 = num10;
					}
					num9 += num3;
					num14 -= num3;
					int num65 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-7C]");
					flag23 = (nint)num65 < (nint)0;
					num6 = num9;
					num10 = num14;
				}
				while (flag23);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E8]");
				vertexHelper = (VertexHelper)0;
			}
			vertexHelper.AddUIVertexTriangleStream(BaseMaterialEffect.s_TempVerts);
			List<UIVertex> list7 = BaseMaterialEffect.s_TempVerts;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdx_v27 (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			return;
		}
		int num66;
		if (vh.m_Positions != null)
		{
			List<Vector3> positions = vh.m_Positions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1251 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			num66 = 0;
		}
		else
		{
			num66 = 0;
		}
		obj = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (num66 <= 0)
		{
			return;
		}
		int num67 = 0;
		object obj43 = default(object);
		object obj45 = default(object);
		do
		{
			vh.PopulateUIVertex(ref System.Runtime.CompilerServices.Unsafe.As<object, UIVertex>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96)), num67);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-34]");
			float num68 = 0f + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
			float num69 = 0f + 0.5f;
			float num70 = num68 * 0.5f;
			float num71 = num69 * 0.5f;
			if (0f > num70)
			{
				num70 = 0f;
			}
			else if (num70 > 1f)
			{
				num70 = 1f;
			}
			if (0f > num71)
			{
				num71 = 0f;
			}
			else if (num71 > 1f)
			{
				num71 = 1f;
			}
			float num72 = num71 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num73 = num70 * 4095f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			object obj42 = obj43 << 12;
			object obj44 = obj45 + obj42;
			UIVertex vertex = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
			_ = 0;
			vh.SetUIVertex(vertex, num67);
			num67++;
		}
		while (num67 < num66);
	}

	protected override void SetEffectParamsDirty()
	{
		//IL_001a: Invalid comparison between I4 and F4
		//IL_00fe: Expected I4, but got O
		//IL_0060: Invalid comparison between I4 and F4
		//IL_012a: Expected I4, but got O
		//IL_00a6: Invalid comparison between I4 and F4
		//IL_0156: Expected I4, but got O
		ParameterTexture parameterTexture = paramTex;
		if (0f > m_EffectFactor || m_EffectFactor > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture.SetData(this, 0, (byte)(int)parameterTexture);
		ParameterTexture parameterTexture2 = paramTex;
		if (0f > m_ColorFactor || m_ColorFactor > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture2.SetData(this, 1, (byte)(int)parameterTexture2);
		ParameterTexture parameterTexture3 = paramTex;
		if (0f > m_BlurFactor || m_BlurFactor > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		parameterTexture3.SetData(this, 2, (byte)(int)parameterTexture3);
	}

	private unsafe static void GetBounds(List<UIVertex> verts, int start, int count, ref Rect posBounds, ref Rect uvBounds, bool global)
	{
		//IL_02af: Expected O, but got I4
		//IL_0250: Expected Ref, but got F4
		//IL_0287: Expected O, but got F4
		//IL_0069: Expected O, but got I
		//IL_007c: Expected O, but got I4
		//IL_008c: Invalid comparison between F4 and I
		//IL_00e9: Invalid comparison between I and F4
		//IL_0389: Invalid comparison between F4 and I
		//IL_018f: Invalid comparison between I and F4
		//IL_0146: Invalid comparison between F4 and I
		//IL_00d4: Expected F4, but got I
		//IL_01b3: Invalid comparison between I and F4
		//IL_0131: Expected F4, but got I
		//IL_016a: Expected F4, but got I
		//IL_017a: Expected F4, but got I
		//IL_01d7: Expected F4, but got I
		//IL_01e7: Expected F4, but got I
		object obj = start + count;
		bool flag = start >= (nint)obj;
		float num = -3.4028235E+38f;
		float num2 = -3.4028235E+38f;
		float num3 = 3.4028235E+38f;
		float num4 = 3.4028235E+38f;
		float num5 = -3.4028235E+38f;
		float num6 = -3.4028235E+38f;
		float num7 = 3.4028235E+38f;
		float num8 = 3.4028235E+38f;
		int num9 = start;
		float num10 = -3.4028235E+38f;
		float num11 = -3.4028235E+38f;
		float num12 = 3.4028235E+38f;
		float num13 = 3.4028235E+38f;
		float num14 = -3.4028235E+38f;
		float num15 = -3.4028235E+38f;
		float num16 = 3.4028235E+38f;
		float num17 = 3.4028235E+38f;
		if (!flag)
		{
			float num20 = default(float);
			bool flag2;
			do
			{
				int num18 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rcx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
				if ((nint)num18 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rcx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
					object obj2 = 0;
					object obj3 = num9 * 108;
					float num19 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+20+v101 @ rcx_v7]");
					if (!(num19 < 0f) && !(num7 < num20))
					{
						num7 = num20;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+20+v101 @ rcx_v7]");
						num8 = 0f;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+20+v101 @ rcx_v7]");
						if (!(0f < num6) && !(num20 < num5))
						{
							num5 = num20;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+20+v101 @ rcx_v7]");
							num6 = 0f;
						}
					}
					float num21 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+4C+v101 @ rcx_v7]");
					if (!(num21 < 0f))
					{
						float num22 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+50+v101 @ rcx_v7]");
						if (!(num22 < 0f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+50+v101 @ rcx_v7]");
							num3 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+4C+v101 @ rcx_v7]");
							num4 = 0f;
							goto IL_039d;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+4C+v101 @ rcx_v7]");
					if (!(0f < num2))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+50+v101 @ rcx_v7]");
						if (!(0f < num))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+50+v101 @ rcx_v7]");
							num = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v12+4C+v101 @ rcx_v7]");
							num2 = 0f;
						}
					}
					goto IL_039d;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
				IL_039d:
				num9++;
				flag2 = num9 < (nint)obj;
				num10 = num;
				num11 = num2;
				num12 = num3;
				num13 = num4;
				num14 = num5;
				num15 = num6;
				num16 = num7;
				num17 = num8;
			}
			while (flag2);
		}
		float num23 = num11 - num13;
		float num24 = num10 - num12;
		float num25 = num15 - num17;
		float num26 = num17 + 0.001f;
		float num27 = num14 - num16;
		float num28 = num25 - 0.002f;
		ref Rect reference = ref *(Rect*)num26;
		float num29 = num16 + 0.001f;
		float num30 = num27 - 0.002f;
		object obj4 = num13;
	}

	static UIEffect()
	{
		ParameterTexture parameterTexture = new ParameterTexture(4, 1024, "_ParamTex");
		s_ParamTex = parameterTexture;
	}
}
