using System;
using System.Collections;
using Cpp2ILInjected;
using UnityEngine;

public class TextSize
{
	private Hashtable dict;

	private TextMesh textMesh;

	private Renderer renderer;

	public float width
	{
		get
		{
			string text = textMesh.text;
			return GetTextWidth(text);
		}
	}

	public TextSize(TextMesh tm)
	{
		textMesh = tm;
		Renderer component = tm.GetComponent<Renderer>();
		renderer = component;
		Hashtable hashtable = new Hashtable(0, 1f);
		dict = hashtable;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 189 Invalid \"Jump target not found in method: 0x186951DF0\"");
		throw new NullReferenceException();
	}

	private void getSpace()
	{
		//IL_0171: Expected I, but got O
		//IL_01c1: Expected I, but got O
		//IL_0266->IL01f6: Incompatible stack heights: 1 vs 0
		//IL_0319->IL01f6: Incompatible stack heights: 6 vs 0
		//IL_0128->IL01f6: Incompatible stack heights: 6 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1D1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)textMesh != null)
		{
			string text = textMesh.text;
			if ((object)renderer != null)
			{
				Transform transform = renderer.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Quaternion _);
					if ((object)renderer != null)
					{
						Transform transform2 = renderer.transform;
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Quaternion value = default(Quaternion);
						Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						bool flag4 = (object)textMesh == null;
						textMesh.text = "a";
						Transform transform3 = (Transform)(object)renderer;
						bool flag5 = (object)renderer == null;
						bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Renderer.get_bounds_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Bounds ret2);
						if ((object)textMesh != null)
						{
							textMesh.text = "a a";
							Transform transform4 = (Transform)(object)renderer;
							if ((object)renderer != null)
							{
								bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								Renderer.get_bounds_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret2);
								bool flag8 = (object)renderer == null;
								Transform transform5 = renderer.transform;
								bool flag9 = (object)transform5 == null;
								bool flag10 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
								Transform.set_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value);
								Transform transform6 = (Transform)(object)dict;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								bool flag11 = dict == null;
								nint num = (nint)transform6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v860 @ r10_v7 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
								Transform transform7 = (Transform)(object)dict;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								bool flag12 = dict == null;
								nint num2 = (nint)transform7;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v386 @ r10_v8 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
								bool flag13 = (object)textMesh == null;
								textMesh.text = text;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe float GetTextWidth(string s)
	{
		//IL_0094: Expected O, but got I4
		//IL_009d: Expected F4, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_0103: Expected I, but got O
		//IL_033c: Expected I, but got O
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_04eb: Expected I4, but got F4
		//IL_00f6->IL041c: Incompatible stack heights: 1 vs 0
		//IL_032f->IL041c: Incompatible stack heights: 1 vs 0
		//IL_0147->IL041c: Incompatible stack heights: 1 vs 0
		//IL_036e->IL041c: Incompatible stack heights: 1 vs 0
		//IL_0173->IL041c: Incompatible stack heights: 1 vs 0
		//IL_03e9->IL04f8: Incompatible stack heights: 2 vs 0
		//IL_019f->IL041c: Incompatible stack heights: 1 vs 0
		//IL_0219->IL041c: Incompatible stack heights: 4 vs 0
		//IL_0247->IL041c: Incompatible stack heights: 4 vs 0
		//IL_04f8->IL04f8: Incompatible stack heights: 8 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1D2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (s != null)
		{
			char[] array = s.ToCharArray();
			if ((object)textMesh != null)
			{
				string text = textMesh.text;
				if (array != null)
				{
					object obj = 0;
					float num = 0f;
					object obj2 = 0;
					object obj3 = default(object);
					float value = default(float);
					object obj4 = default(object);
					IFormatProvider provider = default(IFormatProvider);
					float value2 = default(float);
					IntPtr intPtr = default(IntPtr);
					object obj5 = default(object);
					while (true)
					{
						if ((nint)obj2 < array.Length)
						{
							bool flag = (nint)obj >= array.Length;
							string text2 = (string)(object)dict;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							if (dict == null)
							{
								break;
							}
							nint num2 = (nint)text2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v630 @ r8_v12 (Il2CppClass<System.String>)+2E8] (should have been resolved before IL gen)");
							if (obj3 == null)
							{
								if ((object)renderer == null)
								{
									break;
								}
								Transform transform = renderer.transform;
								if ((object)transform == null)
								{
									break;
								}
								Quaternion rotation = transform.rotation;
								if ((object)renderer == null)
								{
									break;
								}
								Transform transform2 = renderer.transform;
								bool flag2 = (object)transform2 == null;
								bool flag3 = ((string)(object)transform2)._stringLength == 0;
								Transform.set_rotation_Injected((IntPtr)((string)(object)transform2)._stringLength, ref *(Quaternion*)(&value));
								string text3 = string.FastAllocateString(1);
								bool flag4 = text3 == null;
								text3._firstChar = array[obj];
								if ((object)textMesh == null)
								{
									break;
								}
								textMesh.text = text3;
								if ((object)renderer == null)
								{
									break;
								}
								Bounds bounds = renderer.bounds;
								float num3 = (float)obj4 * 2f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								bool flag5 = dict == null;
								DateTime dateTime = ((IConvertible)dict).ToDateTime(provider);
								bool flag6 = (object)renderer == null;
								Transform transform3 = renderer.transform;
								bool flag7 = (object)transform3 == null;
								bool flag8 = ((string)(object)transform3)._stringLength == 0;
								Transform.set_rotation_Injected((IntPtr)((string)(object)transform3)._stringLength, ref *(Quaternion*)(&value2));
								obj++;
								num += num3;
								nint num4 = intPtr;
								char c = (char)(int)num3;
								obj2 = obj;
							}
							else
							{
								string text4 = (string)(object)dict;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								if (dict == null)
								{
									break;
								}
								nint num5 = (nint)text4;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v760 @ r8_v14 (Il2CppClass<System.String>)+308] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
								nint num4 = 0;
								if (obj5 == null)
								{
									break;
								}
								object obj6 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v23+40]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r8_v10 (Il2CppMethodInfo)+40]");
								bool flag9 = num6 != 0;
								obj++;
								float num7 = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v30+10]");
								num = num7 + 0f;
								char c = array[obj];
								obj2 = obj;
							}
							continue;
						}
						if ((object)textMesh == null)
						{
							break;
						}
						textMesh.text = text;
						return num;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void FitToWidth(float wantedWidth, int maxLines = -1)
	{
		//IL_01a1: Expected O, but got Ref
		//IL_006a: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1D3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = textMesh.text;
		textMesh.text = "";
		object obj = default(object);
		string[] array = text.SplitInternal((ReadOnlySpan<char>)(&obj), 2147483647, StringSplitOptions.None);
		object obj2 = 0;
		int num = maxLines;
		object obj3 = 0;
		object obj4 = 0;
		while ((nint)obj4 < array.Length)
		{
			string text2 = textMesh.text;
			string text3 = wrapLine(array[obj3], wantedWidth, num);
			string text4 = text2 + text3;
			textMesh.text = text4;
			num--;
			obj2++;
			if (maxLines == -1 || (nint)obj2 < maxLines)
			{
				string text5 = textMesh.text;
				string text6 = text5 + "\n";
				textMesh.text = text6;
				obj3++;
				obj4 = obj3;
				continue;
			}
			break;
		}
	}

	private unsafe string wrapLine(string s, float w, int maxLines = -1)
	{
		//IL_06cb: Invalid comparison between F4 and I4
		//IL_00de: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_00f0: Expected F4, but got I4
		//IL_00f9: Expected F4, but got I4
		//IL_0114: Expected O, but got I4
		//IL_0182: Expected I, but got O
		//IL_019c: Expected O, but got I
		//IL_03eb: Expected I, but got O
		//IL_0405: Expected O, but got I
		//IL_0465: Expected F4, but got I
		//IL_048b: Expected O, but got I4
		//IL_0814: Expected F4, but got I4
		//IL_04ba: Expected O, but got I
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_030c: Expected F4, but got I
		//IL_039b: Expected I4, but got F4
		//IL_0175->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_03de->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_041d->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_020f->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_0244->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_0272->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_029e->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_05a9->IL06bb: Incompatible stack heights: 2 vs 0
		//IL_02ca->IL06bb: Incompatible stack heights: 1 vs 0
		//IL_0637->IL06bb: Incompatible stack heights: 2 vs 0
		//IL_050d->IL06bb: Incompatible stack heights: 2 vs 0
		//IL_06a2->IL06f1: Incompatible stack heights: 2 vs 0
		//IL_0695->IL083f: Incompatible stack heights: 2 vs 0
		//IL_03b0->IL07d4: Incompatible stack heights: 8 vs 2
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1D4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = w == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186952B44h\"");
		string result = s;
		string text;
		if (!flag)
		{
			if (s != null)
			{
				bool flag2 = s._stringLength <= 0;
				result = s;
				if (flag2)
				{
					goto IL_06b6;
				}
				char[] array = s.ToCharArray();
				if ((object)textMesh != null)
				{
					text = textMesh.text;
					if (array != null)
					{
						object obj = 0;
						object obj2 = 0;
						float num = 0f;
						float num2 = 0f;
						string text2 = "";
						string text3 = "";
						object obj3 = 0;
						result = "";
						int num3 = maxLines;
						object obj5 = default(object);
						Quaternion value = default(Quaternion);
						object obj6 = default(object);
						float value2 = default(float);
						IFormatProvider formatProvider = default(IFormatProvider);
						object obj8 = default(object);
						while (true)
						{
							float num6;
							if ((nint)obj3 < array.Length)
							{
								bool flag3 = (nint)obj >= array.Length;
								string text4 = (string)(object)dict;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								if (dict == null)
								{
									break;
								}
								nint num4 = (nint)text4;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v893 @ r8_v14 (Il2CppClass<System.String>)+2E8] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
								object obj4 = 0;
								float num5;
								string text6;
								if (obj5 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v27+E4]");
									if ((nint)0 == 0)
									{
									}
									string text5 = string.FastAllocateString(1);
									if (text5 == null)
									{
										break;
									}
									text5._firstChar = array[obj];
									if ((object)textMesh == null)
									{
										break;
									}
									textMesh.text = text5;
									if ((object)renderer == null)
									{
										break;
									}
									Transform transform = renderer.transform;
									if ((object)transform == null)
									{
										break;
									}
									Quaternion rotation = transform.rotation;
									if ((object)renderer == null)
									{
										break;
									}
									Transform transform2 = renderer.transform;
									bool flag4 = (object)transform2 == null;
									bool flag5 = ((string)(object)transform2)._stringLength == 0;
									Transform.set_rotation_Injected((IntPtr)((string)(object)transform2)._stringLength, ref value);
									bool flag6 = (object)renderer == null;
									Bounds bounds = renderer.bounds;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v64 (UnityEngine.Bounds)+10]");
									num5 = 0f;
									num6 = (float)obj6 * 2f;
									bool flag7 = (object)renderer == null;
									Transform transform3 = renderer.transform;
									bool flag8 = (object)transform3 == null;
									bool flag9 = ((string)(object)transform3)._stringLength == 0;
									Transform.set_rotation_Injected((IntPtr)((string)(object)transform3)._stringLength, ref *(Quaternion*)(&value2));
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									bool flag10 = dict == null;
									DateTime dateTime = ((IConvertible)dict).ToDateTime(formatProvider);
									value2 = rotation.x;
									value = Quaternion.identityQuaternion;
									char c = (char)(int)num6;
									text6 = (string)(object)formatProvider;
									num3 = maxLines;
								}
								else
								{
									string text7 = (string)(object)dict;
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									if (dict == null)
									{
										break;
									}
									nint num7 = (nint)text7;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1082 @ r8_v24 (Il2CppClass<System.String>)+308] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
									object obj7 = 0;
									if (obj8 == null)
									{
										break;
									}
									text6 = (string)obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rdx_v28 (System.String)+40]");
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v26+40]");
									bool flag11 = num8 != 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v51+10]");
									num6 = 0f;
									char c = array[obj];
								}
								if (array[obj] != ' ')
								{
									object obj9 = array.Length - 1;
									if (obj != obj9)
									{
										result = text2;
										goto IL_0611;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
									object obj10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1245 @ rcx_v40+E4]");
									if ((nint)0 == 0)
									{
									}
									string text8 = string.FastAllocateString(1);
									if (text8 == null)
									{
										break;
									}
									text8._firstChar = array[obj];
									string text9 = text3 + text8;
									num2 += num6;
									text3 = text9;
								}
								num5 = num + num2;
								string text11;
								if (!(w > num5))
								{
									if (num3 != -1 && (nint)obj2 >= num3)
									{
										result = text2;
										goto IL_06f1;
									}
									if (text3 == null)
									{
										break;
									}
									obj2++;
									string text10 = text3.Replace(" ", "\n");
									num = num2;
									text11 = text10;
								}
								else
								{
									num += num2;
									text11 = text3;
								}
								string text12 = text2 + text11;
								num2 = 0f;
								text2 = text12;
								text3 = "";
								text6 = text11;
								result = text12;
								goto IL_0611;
							}
							goto IL_06f1;
							IL_0611:
							string text13 = string.FastAllocateString(1);
							if (text13 == null)
							{
								break;
							}
							text13._firstChar = array[obj];
							string text14 = text3 + text13;
							obj++;
							num2 += num6;
							text3 = text14;
							obj3 = obj;
							continue;
							IL_06f1:
							if ((object)textMesh == null)
							{
								break;
							}
							goto IL_06a2;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_06b6;
		IL_06b6:
		return result;
		IL_06a2:
		textMesh.text = text;
		goto IL_06b6;
	}
}
