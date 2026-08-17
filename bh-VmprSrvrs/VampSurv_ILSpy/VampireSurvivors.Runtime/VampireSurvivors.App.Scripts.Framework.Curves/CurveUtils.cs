using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Curves;

public static class CurveUtils
{
	public unsafe static List<Vector3> GetEvenlySpacedPoints(List<Vector3> points, int numPoints = 9)
	{
		//IL_0008: Expected O, but got Ref
		//IL_007e: Expected O, but got I
		//IL_00a7: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_0129: Expected O, but got I
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_00e5: Expected O, but got Ref
		//IL_00ee: Expected O, but got Ref
		//IL_0944: Expected F8, but got I4
		//IL_0748: Expected O, but got I
		//IL_0316: Expected O, but got I4
		//IL_035d: Expected O, but got I
		//IL_0372: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01b4: Expected I, but got O
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_03b0: Expected F4, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Expected O, but got Unknown
		//IL_06de: Expected I, but got O
		//IL_06fb: Expected O, but got I
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Expected O, but got Unknown
		//IL_072d: Expected O, but got I
		//IL_077d: Expected O, but got I
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected O, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_040b: Expected O, but got I
		//IL_041e: Expected O, but got Ref
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_0453: Expected O, but got I
		//IL_0463: Expected O, but got I
		//IL_0471: Expected O, but got Ref
		//IL_05e0: Invalid comparison between I4 and F4
		//IL_062b: Expected F4, but got I4
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_050e: Expected O, but got I
		//IL_051e: Expected O, but got I
		//IL_052e: Expected O, but got I
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected O, but got Unknown
		//IL_0858: Expected O, but got Ref
		//IL_0554: Expected O, but got I
		//IL_0564: Expected O, but got I
		//IL_057c: Expected O, but got I
		//IL_0594: Expected O, but got I
		//IL_05a4: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (points != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			if ((nint)0 >= (nint)2)
			{
				List<Vector3> list = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rcx_v15+18]");
					Vector3 vector;
					if (num >= 0)
					{
						List<Vector3> list2 = default(List<Vector3>);
						list.AddWithResize((Vector3)(&list2));
						vector = (Vector3)(&list2);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj5 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj6 = (nint)0 * (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						vector = (Vector3)(0 + obj6);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14+28]");
						_ = 0;
					}
					double num2 = 0.0;
					List<Vector3> list3 = null;
					List<Vector3> list4 = null;
					object obj14 = default(object);
					double num8 = default(double);
					List<Vector3> list13 = default(List<Vector3>);
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj7 = -1;
						if (System.Runtime.CompilerServices.Unsafe.As<List<Vector3>, UIntPtr>(ref list4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
						{
							List<Vector3> list5 = list3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							if ((nint)list5 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							vector = (Vector3)0;
							object obj8 = list3 * 2;
							nint num3 = (nint)((object)list3 + obj8);
							object obj9 = list3 + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							if ((nint)obj9 >= 0)
							{
								break;
							}
							object obj10 = list3 * 2;
							object obj11 = (object)list3 + obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v15 (UnityEngine.Vector3)+2C+v824 @ rcx_v27*4]");
							_ = 0;
							nint num4 = (nint)typeof(Math);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v15 (UnityEngine.Vector3)+20+v226 @ r9_v6 (Il2CppMethodInfo)*4]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
							object obj12 = num5 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-75]");
							object obj13 = obj14 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v15 (UnityEngine.Vector3)+28+v226 @ r9_v6 (Il2CppMethodInfo)*4]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v15 (UnityEngine.Vector3)+34+v824 @ rcx_v27*4]");
							object obj15 = num6 - 0;
							object obj16 = obj13 * obj13;
							object obj17 = obj12 * obj12;
							object obj18 = obj15 * obj15;
							object obj19 = obj16 + obj17;
							double num7 = (double)obj19 + (double)obj18;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rcx_v29 (Il2CppClass<System.Math>)+E4]");
							if ((nint)0 <= (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
								list3 = (List<Vector3>)(list3 + 1);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
								num8 = num7;
								list4 = list3;
							}
							else
							{
								double num9 = Math.Sqrt(num7);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
								list3 = (List<Vector3>)(list3 + 1);
								num2 += num9;
								num8 = num7;
								list4 = list3;
							}
							continue;
						}
						List<Vector3> list6 = (List<Vector3>)(numPoints - 1);
						double num10 = num2 / (double)list6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						if ((nint)0 <= (nint)0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ r14_v5+20]");
						List<Vector3> list7 = (List<Vector3>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ r14_v5+28]");
						List<Vector3> list8 = (List<Vector3>)0;
						if (numPoints > 1)
						{
							List<Vector3> list9 = null;
							float num11 = 0f;
							object obj21 = 1;
							List<Vector3> list10 = list6;
							while (true)
							{
								double num12 = (double)obj21 * num10;
								bool flag = !(num12 > (double)num11);
								List<Vector3> list11 = list9;
								List<Vector3> list12 = list13;
								List<Vector3> list14 = list3;
								double num13 = num8;
								List<Vector3> list15 = list7;
								float num14 = num11;
								List<Vector3> list16 = list8;
								List<Vector3> list17 = list10;
								Vector3 vector2 = vector;
								List<Vector3> list18 = list4;
								if (!flag)
								{
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
										list6 = (List<Vector3>)(-1);
										bool flag2 = System.Runtime.CompilerServices.Unsafe.As<List<Vector3>, UIntPtr>(ref list11) >= System.Runtime.CompilerServices.Unsafe.As<List<Vector3>, UIntPtr>(ref list6);
										list9 = list11;
										list13 = list12;
										list3 = list14;
										num8 = num13;
										list7 = list15;
										num11 = num14;
										list8 = list16;
										list10 = list17;
										vector = vector2;
										list4 = list18;
										if (flag2)
										{
											break;
										}
										object obj22 = list11 + 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
										if ((nint)obj22 >= 0)
										{
											goto end_IL_08bd;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
										object obj23 = 0;
										vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
										object obj24 = list11 * 2;
										object obj25 = (object)list11 + obj24;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
										list12 = (List<Vector3>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+34+v974 @ rax_v31*4]");
										list14 = (List<Vector3>)0;
										list18 = (List<Vector3>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+34+v974 @ rax_v31*4]");
										_ = 0;
										list18.Add(vector2);
										num13 = (double)list17 + (double)num14;
										if (num13 < num12)
										{
											num14 += (float)list17;
											list11 = (List<Vector3>)(list11 + 1);
											bool flag3 = num12 > (double)num14;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
											list15 = (List<Vector3>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+34+v974 @ rax_v31*4]");
											list16 = (List<Vector3>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
											list17 = (List<Vector3>)0;
											if (!flag3)
											{
												list9 = list11;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
												list13 = (List<Vector3>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+34+v974 @ rax_v31*4]");
												list3 = (List<Vector3>)0;
												num8 = num13;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
												list7 = (List<Vector3>)0;
												num11 = num14;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+34+v974 @ rax_v31*4]");
												list8 = (List<Vector3>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v23+2C+v974 @ rax_v31*4]");
												list10 = (List<Vector3>)0;
												vector = vector2;
												list4 = list18;
												break;
											}
											continue;
										}
										double num15 = num12 - (double)num14;
										float num16 = (float)num15 / (float)list17;
										if (!(0f > num16))
										{
											if (num16 > 1f)
											{
												num16 = 1f;
											}
										}
										else
										{
											num16 = 0f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-55]");
										object obj26 = 0 - obj14;
										object obj27 = (object)list14 - (object)list16;
										float num17 = (float)obj26 * num16;
										float num18 = (float)obj27 * num16;
										float num19 = num17 + (float)obj14;
										float num20 = num18 + (float)list16;
										vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										list.Add(vector);
										list9 = list11;
										list13 = list12;
										list3 = list14;
										num8 = num20;
										list7 = list15;
										num11 = num14;
										list8 = list16;
										list10 = list16;
										list4 = list;
										break;
									}
								}
								obj21++;
								if ((nint)obj21 < numPoints)
								{
									continue;
								}
								goto IL_065a;
								continue;
								end_IL_08bd:
								break;
							}
							break;
						}
						goto IL_065a;
						IL_065a:
						return list;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				List<Vector3> result = default(List<Vector3>);
				return result;
			}
		}
		object obj28 = new ArgumentException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
		throw obj28;
	}

	private static float CalculateCurveLength(List<Vector3> points)
	{
		//IL_0269: Expected F4, but got I4
		//IL_0272: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_031f: Expected O, but got I
		//IL_0044: Expected O, but got I
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_02bd: Expected I, but got O
		//IL_02da: Expected O, but got I
		//IL_0304: Expected O, but got I
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01f2: Expected F8, but got I4
		bool flag = points == null;
		float num = 0f;
		object obj = 0;
		double num3 = default(double);
		double num2 = num3;
		object obj2 = 0;
		if (!flag)
		{
			object obj15 = default(object);
			object obj16 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj3 = -1;
				float result;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag2 = (nint)obj4 >= 0;
					result = (float)num2;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						bool flag3 = (nint)0 == 0;
						num3 = num2;
						if (flag3)
						{
							break;
						}
						object obj6 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+18]");
						bool flag4 = (nint)obj6 >= 0;
						num3 = num2;
						if (!flag4)
						{
							object obj7 = obj * 2;
							object obj8 = obj + obj7;
							object obj9 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							bool flag5 = (nint)obj9 >= 0;
							result = (float)num2;
							if (flag5)
							{
								goto IL_0291;
							}
							object obj10 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+18]");
							bool flag6 = (nint)obj10 >= 0;
							num3 = num2;
							if (!flag6)
							{
								object obj11 = obj * 2;
								object obj12 = obj + obj11;
								nint num4 = (nint)typeof(Math);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+20+v131 @ r9_v2*4]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+2C+v325 @ rcx_v4*4]");
								object obj13 = num5 - 0;
								object obj14 = obj15 - obj16;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+28+v131 @ r9_v2*4]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+34+v325 @ rcx_v4*4]");
								object obj17 = num6 - 0;
								object obj18 = obj14 * obj14;
								object obj19 = obj13 * obj13;
								object obj20 = obj17 * obj17;
								object obj21 = obj18 + obj19;
								double d = (double)obj21 + (double)obj20;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v6 (Il2CppClass<System.Math>)+E4]");
								if ((nint)0 <= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
									obj++;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									num2 = 0.0;
									obj2 = obj;
								}
								else
								{
									num2 = Math.Sqrt(d);
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									obj++;
									num += (float)num2;
									obj2 = obj;
								}
								continue;
							}
						}
						throw new IndexOutOfRangeException();
					}
					goto IL_0291;
				}
				return num;
				IL_0291:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		throw new NullReferenceException();
	}
}
