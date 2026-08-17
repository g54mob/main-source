using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Cpp2ILInjected;

namespace UnityEngine.UI;

public class LetterSpacing : BaseMeshEffect
{
	private const string SupportedTagRegexPattersn = "<b>|</b>|<i>|</i>|<size=.*?>|</size>|<color=.*?>|</color>|<material=.*?>|</material>";

	private bool useRichText;

	private float m_spacing;

	public float spacing
	{
		get
		{
			return m_spacing;
		}
		set
		{
			bool flag = m_spacing == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018695A0E2h\"");
			if (!flag)
			{
				m_spacing = value;
				Graphic graphic = base.graphic;
				if ((object)graphic != null && ((Object)graphic).m_CachedPtr != (IntPtr)0)
				{
					Graphic graphic2 = base.graphic;
					graphic2.SetVerticesDirty();
				}
			}
		}
	}

	protected LetterSpacing()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	public override void ModifyMesh(VertexHelper vh)
	{
		if (base.IsActive())
		{
			List<UIVertex> list = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
			vh.GetUIVertexStream(list);
			ModifyVertices(list);
			vh.Clear();
			if (list != null)
			{
				vh.InitializeListIfRequired();
				List<Vector4> uv1S = default(List<Vector4>);
				List<Vector4> uv2S = default(List<Vector4>);
				List<Vector4> uv3S = default(List<Vector4>);
				List<Vector3> normals = default(List<Vector3>);
				CanvasRenderer.SplitUIVertexStreams(list, vh.m_Positions, vh.m_Colors, vh.m_Uv0S, uv1S, uv2S, uv3S, normals, vh.m_Uv1S, (List<int>)(object)vh.m_Uv2S);
			}
		}
	}

	public unsafe void ModifyVertices(List<UIVertex> verts)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected I4, but got Unknown
		//IL_0ded: Expected O, but got Ref
		//IL_0e00: Expected O, but got Ref
		//IL_0e10: Expected O, but got I
		//IL_00ce: Expected I, but got O
		//IL_0106: Expected O, but got I
		//IL_0daa: Expected O, but got I4
		//IL_02bc: Expected O, but got I4
		//IL_02d2: Expected O, but got I
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_11f3: Expected O, but got I4
		//IL_028b: Expected O, but got I8
		//IL_02a5: Expected O, but got I8
		//IL_0e91: Expected O, but got I4
		//IL_0368: Expected O, but got I
		//IL_0d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d31: Expected O, but got Unknown
		//IL_0d40: Expected O, but got I4
		//IL_0d50: Expected O, but got I
		//IL_0d59: Expected O, but got I4
		//IL_0687: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Expected O, but got Unknown
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected O, but got Unknown
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected O, but got Unknown
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Expected O, but got Unknown
		//IL_0704: Expected I4, but got O
		//IL_0712: Expected O, but got I4
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_0756: Expected O, but got Unknown
		//IL_0770: Expected I, but got O
		//IL_077e: Expected O, but got I
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Expected O, but got Unknown
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Expected I4, but got Unknown
		//IL_03b5: Expected I, but got O
		//IL_07cf: Expected O, but got I
		//IL_03ec: Expected I, but got O
		//IL_03fc: Expected O, but got I
		//IL_0438: Expected O, but got I
		//IL_0822: Expected O, but got I
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Expected O, but got Unknown
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Expected O, but got Unknown
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0e: Expected O, but got Unknown
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1c: Expected O, but got Unknown
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Expected O, but got Unknown
		//IL_08e1: Expected O, but got I4
		//IL_0569: Expected I, but got O
		//IL_05c7: Expected I, but got O
		//IL_05d7: Expected O, but got I
		//IL_0971: Expected O, but got I4
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Expected O, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Expected O, but got Unknown
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_0613: Expected O, but got I
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_0a1d: Expected O, but got I
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected O, but got Unknown
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected O, but got Unknown
		//IL_0aad: Expected O, but got I
		//IL_0b38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3d: Expected O, but got Unknown
		//IL_0f77: Expected I, but got O
		//IL_106e: Expected O, but got Ref
		//IL_10f0: Expected O, but got Ref
		//IL_116d: Expected O, but got Ref
		//IL_0ba8: Expected O, but got Ref
		//IL_0be7: Expected O, but got Ref
		//IL_0c69: Expected O, but got Ref
		//IL_0c83: Expected O, but got I
		//IL_0cf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Text component;
		IList<UILineInfo> lines;
		int num;
		string text2;
		string text3;
		if (base.IsActive())
		{
			component = GetComponent<Text>();
			string text = component.text;
			TextGenerator cachedTextGenerator = component.cachedTextGenerator;
			lines = cachedTextGenerator.lines;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj3 = default(object);
			num = obj3 - 1;
			bool flag = num <= 0;
			text2 = text;
			text3 = text;
			if (!flag)
			{
				goto IL_0095;
			}
			goto IL_01d7;
		}
		return;
		IL_0146:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
		goto IL_0155;
		IL_0095:
		string text4 = text3.Insert(lines.get_Item(num).startCharIdx, "\n");
		nint num2 = (nint)lines;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ r11_v13 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.UILineInfo>>)+12E]");
		if ((nint)0 >= (nint)0)
		{
			goto IL_0146;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ r11_v13 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.UILineInfo>>)+B0]");
		object obj4 = 0;
		bool flag2 = false;
		while (true)
		{
			object obj5 = (flag2 ? 1 : 0) + (flag2 ? 1 : 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ r10_v13+v1569 @ rcx_v29*8]");
			if (0 == (nint)typeof(IList<UILineInfo>))
			{
				break;
			}
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			bool num3 = flag2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ r11_v13 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.UILineInfo>>)+12E]");
			if ((nint)(num3 ? 1 : 0) < (nint)0)
			{
				continue;
			}
			goto IL_0146;
		}
		goto IL_02af;
		IL_01d7:
		_ = 10;
		_ = 1;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 1944));
		ReadOnlySpan<char> separators = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		string[] array = text2.SplitInternal(separators, 2147483647, StringSplitOptions.None);
		object obj32;
		if (((Object)component).m_CachedPtr != (IntPtr)0)
		{
			FontData fontData = component.m_FontData;
			bool flag3 = !useRichText;
			object obj8 = fontData.m_FontSize * m_spacing;
			float num4 = (float)obj8 / 100f;
			bool flag4 = false;
			if (!flag3)
			{
				flag4 = fontData.m_RichText;
			}
			TextAnchor alignment = fontData.m_Alignment;
			if (fontData.m_Alignment <= TextAnchor.LowerRight)
			{
				object obj9 = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rdx_v57+695B334+v704 @ rcx_v49 (UnityEngine.TextAnchor)*4]");
				object obj10 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v423 @ rcx_v86 (should have been resolved before IL gen)");
				goto IL_02af;
			}
			bool flag5 = flag4;
			object obj11 = 0;
			float num5 = num4;
			StringSplitOptions stringSplitOptions = StringSplitOptions.None;
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			string[] array2 = array;
			IEnumerator enumerator3 = null;
			IEnumerator enumerator4 = null;
			IEnumerator enumerator5 = null;
			IEnumerator enumerator6 = null;
			object obj12 = default(object);
			IEnumerator enumerator7 = default(IEnumerator);
			object obj17 = default(object);
			IEnumerator enumerator11 = default(IEnumerator);
			object obj58 = default(object);
			while ((nint)enumerator5 < array2.Length)
			{
				string text5 = array2[(object)enumerator4];
				bool flag6 = !flag4;
				int lineLengthWithoutTags = text5._stringLength;
				if (flag6)
				{
					goto IL_0e83;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+780]");
				IEnumerator regexMatchedTagCollection = ((LetterSpacing)0).GetRegexMatchedTagCollection(text5, out lineLengthWithoutTags);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				bool flag7 = obj12 == null;
				enumerator = null;
				if (flag7)
				{
					goto IL_0ed4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				nint num6 = (nint)typeof(Match);
				if (enumerator7 == null)
				{
					enumerator = null;
					enumerator3 = null;
					goto IL_0ede;
				}
				nint num7 = (nint)enumerator7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rdx_v56 (Il2CppClass<System.Text.RegularExpressions.Match>)+130]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ r8_v48 (Il2CppClass<System.Collections.IEnumerator>)+130]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rdx_v56 (Il2CppClass<System.Text.RegularExpressions.Match>)+130]");
				if (num8 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ r8_v48 (Il2CppClass<System.Collections.IEnumerator>)+C8]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v125+FFFFFFF8+v963 @ rax_v124*8]");
					if (0 == (nint)typeof(Match))
					{
						flag5 = flag4;
						enumerator = enumerator7;
						goto IL_0ed4;
					}
				}
				throw new InvalidCastException();
				IL_0e83:
				object obj15 = lineLengthWithoutTags - 1;
				float num9 = (float)obj15 * num5;
				float num10 = num9 * (float)obj11;
				float num11 = num10;
				IEnumerator enumerator8 = enumerator3;
				IEnumerator enumerator9 = enumerator3;
				string text6 = text5;
				while ((nint)enumerator8 < text6._stringLength)
				{
					if (flag4 && enumerator != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rsi_v16 (System.Collections.IEnumerator)+10]");
						if (0 == (nint)enumerator8)
						{
							IEnumerator enumerator10 = enumerator2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rsi_v16 (System.Collections.IEnumerator)+14]");
							enumerator2 = (IEnumerator)(enumerator10 + 0);
							object obj16 = enumerator8 - 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rsi_v16 (System.Collections.IEnumerator)+14]");
							enumerator8 = (IEnumerator)(obj16 + 0);
							enumerator9 = (IEnumerator)(enumerator9 - 1);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							bool flag8 = obj17 == null;
							enumerator = enumerator3;
							if (!flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								nint num12 = (nint)typeof(Match);
								if (enumerator11 == null)
								{
									enumerator8 = (IEnumerator)(enumerator8 + 1);
									enumerator9 = (IEnumerator)(enumerator9 + 1);
									enumerator = enumerator11;
									enumerator3 = null;
									text6 = text5;
									continue;
								}
								nint num13 = (nint)enumerator11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ rdx_v50 (Il2CppClass<System.Text.RegularExpressions.Match>)+130]");
								object obj18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ r8_v39 (Il2CppClass<System.Collections.IEnumerator>)+130]");
								nint num14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ rdx_v50 (Il2CppClass<System.Text.RegularExpressions.Match>)+130]");
								if (num14 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ r8_v39 (Il2CppClass<System.Collections.IEnumerator>)+C8]");
									object obj19 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v118+FFFFFFF8+v1067 @ rax_v117*8]");
									if (0 == (nint)typeof(Match))
									{
										enumerator8 = (IEnumerator)(enumerator8 + 1);
										enumerator9 = (IEnumerator)(enumerator9 + 1);
										flag5 = flag4;
										enumerator = enumerator11;
										enumerator3 = null;
										text6 = text5;
										continue;
									}
								}
								throw new InvalidCastException();
							}
							goto IL_0f00;
						}
					}
					object obj20 = enumerator2 * 2;
					object obj21 = (object)enumerator2 + obj20;
					object obj22 = obj21 + obj21;
					object obj23 = enumerator2 * 2;
					object obj24 = (object)enumerator2 + obj23;
					object obj25 = obj24 + obj24;
					object obj26 = obj25 + 1;
					object obj27 = enumerator2 * 2;
					object obj28 = (object)enumerator2 + obj27;
					stringSplitOptions = (StringSplitOptions)(obj28 + obj28);
					object obj29 = stringSplitOptions + 2;
					object obj30 = enumerator2 * 2;
					object obj31 = (object)enumerator2 + obj30;
					obj32 = obj31 + obj31;
					object obj33 = obj32 + 3;
					object obj34 = enumerator2 * 2;
					object obj35 = (object)enumerator2 + obj34;
					num2 = (nint)(obj35 + obj35);
					object obj36 = num2 + 4;
					object obj37 = enumerator2 * 2;
					object obj38 = (object)enumerator2 + obj37;
					object obj39 = obj38 + obj38;
					int num15 = obj39 + 5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
					object obj40 = -1;
					if (num15 > (nint)obj40)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
					if ((nint)obj22 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+10]");
						object obj41 = 0;
						object obj42 = obj22 * 108;
						object obj43 = obj25 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+20+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+30+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+40+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+50+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+60+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+70+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+80+v668 @ rdx_v41]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
						if ((nint)obj43 < 0)
						{
							object obj44 = obj25 * 108;
							object obj45 = stringSplitOptions + 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+8C+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+9C+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+AC+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+BC+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+CC+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+DC+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+EC+v668 @ rdx_v41]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
							if ((nint)obj45 < 0)
							{
								object obj46 = (int)stringSplitOptions * 108;
								object obj47 = obj32 + 3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+F8+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+108+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+118+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+128+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+138+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+148+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+158+v668 @ rdx_v41]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
								if ((nint)obj47 < 0)
								{
									object obj48 = obj32 * 108;
									object obj49 = num2 + 4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+164+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+174+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+184+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+194+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+1A4+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+1B4+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+1C4+v668 @ rdx_v41]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
									if ((nint)obj49 < 0)
									{
										object obj50 = num2 * 108;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+1D0+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+1E0+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+1F0+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+200+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+210+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+220+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+230+v668 @ rdx_v41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [verts @ rdx (System.Collections.Generic.List`1<UnityEngine.UIVertex>)+18]");
										if ((nint)num15 < (nint)0)
										{
											object obj51 = obj39 * 108;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+23C+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+29C+v668 @ rdx_v41]");
											_ = 0;
											nint num16 = (nint)typeof(Vector3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2148 @ rax_v101 (Il2CppClass<UnityEngine.Vector3>)+B8]");
											nint num17 = 0;
											float num18 = (float)enumerator9 * num5;
											float num19 = num18 - num11;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2151 @ rcx_v65 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
											float num20 = 0f * num19;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+408]");
											float num21 = 0f + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+478]");
											float num22 = 0f + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+4E8]");
											float num23 = 0f + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+558]");
											float num24 = 0f + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+5C8]");
											float num25 = 0f + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+638]");
											float num26 = 0f + num20;
											object obj52 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rcx_v57+88+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+138]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+148]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
											object obj53 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 464));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rcx_v58+F4+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
											object obj54 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rcx_v59+160+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+98]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E8]");
											_ = 0;
											object obj55 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 688));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v60+1CC+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
											object obj56 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 800));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v61+238+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+108]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+118]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+128]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
											object obj57 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 912));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
											obj7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+24C+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+25C+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+26C+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+27C+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+28C+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2139 @ rcx_v63+2A4+v668 @ rdx_v41]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180611140");
											enumerator2 = (IEnumerator)(enumerator2 + 1);
											num11 = num10;
											lineLengthWithoutTags = num15;
											obj11 = obj58;
											num5 = num4;
											flag4 = flag5;
											goto IL_0f00;
										}
									}
								}
							}
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new IndexOutOfRangeException();
					IL_0f00:
					enumerator8 = (IEnumerator)(enumerator8 + 1);
					enumerator9 = (IEnumerator)(enumerator9 + 1);
					enumerator3 = null;
					text6 = text5;
				}
				enumerator2 = (IEnumerator)(enumerator2 + 1);
				enumerator4 = (IEnumerator)(0 + 1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
				array2 = (string[])0;
				obj11 = 0;
				enumerator5 = enumerator4;
				continue;
				IL_0ed4:
				enumerator3 = null;
				goto IL_0ede;
				IL_0ede:
				stringSplitOptions = StringSplitOptions.None;
				enumerator6 = regexMatchedTagCollection;
				goto IL_0e83;
			}
			return;
		}
		Debug.LogWarning("LetterSpacing: Missing Text component");
		return;
		IL_0155:
		object obj59 = default(object);
		obj32 = obj59;
		int startIndex = lines.get_Item(num).startCharIdx - 1;
		string text7 = text4.Remove(startIndex, 1);
		num--;
		bool flag9 = num > 0;
		text2 = text7;
		text3 = text7;
		if (!flag9)
		{
			goto IL_01d7;
		}
		goto IL_0095;
		IL_02af:
		object obj60 = (flag2 ? 1 : 0) + (flag2 ? 1 : 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ r10_v13+8+v1639 @ rcx_v31*8]");
		object obj61 = (nint)0 << 4;
		object obj62 = obj61 + 312;
		obj59 = obj62 + num2;
		goto IL_0155;
	}

	private unsafe IEnumerator GetRegexMatchedTagCollection(string line, out int lineLengthWithoutTags)
	{
		//IL_00aa: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_02b5: Expected O, but got Ref
		//IL_02d1: Expected O, but got Ref
		//IL_01b7: Expected O, but got I4
		//IL_0403: Expected I, but got O
		//IL_015c: Expected O, but got I
		//IL_0165: Expected O, but got I4
		//IL_01e4: Expected O, but got I
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_021a: Expected I, but got O
		//IL_022a: Expected O, but got I
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0266: Expected O, but got I
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		MatchCollection matchCollection = Regex.Matches(line, "<b>|</b>|<i>|</i>|<size=.*?>|</size>|<color=.*?>|</color>|<material=.*?>|</material>");
		ref int reference = ref *(int*)null;
		if (matchCollection != null)
		{
			if (!matchCollection._done)
			{
				Match match = matchCollection.GetMatch(2147483647);
			}
			List<Match> matches = matchCollection._matches;
			if (matchCollection._matches != null)
			{
				bool flag = matches._size <= 0;
				object obj = 0;
				if (!flag)
				{
					IEnumerator enumerator = matchCollection.GetEnumerator();
					obj = 0;
					object obj2 = default(object);
					object obj3 = default(object);
					object obj14 = default(object);
					MatchCollection matchCollection3 = default(MatchCollection);
					while (true)
					{
						object obj13;
						object obj5;
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj3 == null)
							{
								break;
							}
							bool flag2 = obj2 == null;
							MatchCollection matchCollection2 = null;
							if (!flag2)
							{
								object obj4 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r10_v8+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_019c;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r10_v8+B0]");
								obj5 = 0;
								object obj6 = 0;
								while (true)
								{
									object obj7 = obj6 + obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ r8_v12+v523 @ rax_v41*8]");
									if (0 == (nint)typeof(IEnumerator))
									{
										break;
									}
									obj6++;
									object obj8 = obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r10_v8+12E]");
									if ((nint)obj8 < 0)
									{
										continue;
									}
									goto IL_019c;
								}
								object obj9 = obj6 + obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ r8_v12+8+v582 @ rcx_v28*8]");
								object obj10 = (nint)0 + (nint)1;
								object obj11 = obj10 << 4;
								object obj12 = obj11 + 312;
								obj13 = obj12 + obj4;
								goto IL_03eb;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
						IL_019c:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj13 = obj14;
						obj5 = 1;
						goto IL_03eb;
						IL_03eb:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v589 @ rdx_v17] (should have been resolved before IL gen)");
						nint num = (nint)typeof(Match);
						if (matchCollection3 != null)
						{
							nint num2 = (nint)matchCollection3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v19 (Il2CppClass<System.Text.RegularExpressions.Match>)+130]");
							MatchCollection matchCollection4 = (MatchCollection)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r9_v7 (Il2CppMethodInfo)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v19 (Il2CppClass<System.Text.RegularExpressions.Match>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r9_v7 (Il2CppMethodInfo)+C8]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v36+FFFFFFF8+v266 @ rax_v35 (System.Text.RegularExpressions.MatchCollection)*8]");
								if (0 == (nint)typeof(Match))
								{
									object obj16 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v34 (System.Text.RegularExpressions.MatchCollection)+14]");
									obj = obj16 + 0;
									continue;
								}
							}
							throw new InvalidCastException();
						}
						throw new NullReferenceException();
					}
					object obj17 = (object)(&obj2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj18 = (object)(&obj2);
					MatchCollection matchCollection5 = default(MatchCollection);
					obj18 = matchCollection5;
					if (matchCollection5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
				}
				if (line != null)
				{
					object obj19 = line._stringLength - obj;
					reference = ref *(int*)obj19;
					return matchCollection.GetEnumerator();
				}
			}
		}
		throw new NullReferenceException();
	}
}
