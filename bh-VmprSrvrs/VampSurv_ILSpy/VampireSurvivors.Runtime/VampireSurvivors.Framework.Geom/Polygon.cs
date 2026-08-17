using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom;

[Serializable]
public class Polygon(List<float2> points) : BaseGeom
{
	public List<float2> _points = points;

	public void DrawDebug(Color c)
	{
		//IL_011b: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_004b: Expected O, but got I
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00dd: Expected F4, but got I
		//IL_00dd: Expected F4, but got I
		//IL_00dd: Expected F4, but got I
		//IL_00dd: Expected F4, but got I
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		List<float2> points = _points;
		object obj = 0;
		object obj2 = 0;
		Color colour = default(Color);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v3 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj3 < 0)
			{
				List<float2> points2 = _points;
				object obj4 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj5 = 0;
				object obj6 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				object obj7 = obj6 % 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v4+20+v65 @ rbx_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v4+24+v65 @ rbx_v2*8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v4+20+v111 @ rdx_v3*8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v4+24+v111 @ rdx_v3*8]");
				VSDebug.DrawDebugLine(num, num2, num3, 0f, colour);
				points = _points;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public bool IsPointInside(float2 point)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected F4, but got I4
		//IL_0028: Expected O, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01f5: Invalid comparison between O and F4
		//IL_0214: Invalid comparison between F4 and I4
		//IL_0073: Expected O, but got I
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_0168: Invalid comparison between F4 and I4
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_0186: Invalid comparison between I4 and F4
		//IL_0198: Expected F4, but got I4
		List<float2> points = _points;
		object obj = 0;
		float num = 0f;
		float2 float5 = point;
		object obj2 = 0;
		object obj8 = default(object);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj3 < 0)
			{
				List<float2> points2 = _points;
				object obj4 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v5 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v5 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj5 = 0;
				object obj6 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v5 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				object obj7 = obj6 % 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v5 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v8+20+v78 @ rbx_v5*8]");
				double x = 0.0 - (double)float5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v8+24+v78 @ rbx_v5*8]");
				double y = 0.0 - (double)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v8+20+v102 @ rdx_v6*8]");
				double x2 = 0.0 - (double)float5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v8+24+v102 @ rdx_v6*8]");
				double y2 = 0.0 - (double)obj8;
				double num2 = Math.Atan2(y, x);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
				double num3 = Math.Atan2(y2, x2);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
				float num4;
				if (!(-(float)Math.PI > 0f))
				{
					bool flag = !(0f > (float)Math.PI);
					num4 = 0f;
					if (!flag)
					{
						num4 = (float)Math.PI * -2f;
					}
				}
				else
				{
					num4 = (float)Math.PI * 2f;
				}
				points = _points;
				num += num4;
				obj++;
				float5 = point;
				obj2 = obj;
				continue;
			}
			float num5 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj9 = num5 & 0;
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(float)Math.PI);
			float num6 = (float)obj9 - (float)Math.PI;
			bool flag3 = num6 == 0f;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	public float2 ClosestPositionOnAnyEdge(float2 point)
	{
		//IL_003d: Expected O, but got I
		//IL_0092: Expected O, but got I
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00e0: Expected O, but got I
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0166: Expected O, but got I
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01d9: Expected O, but got I
		//IL_01f6: Expected O, but got I
		//IL_025c: Invalid comparison between I4 and F4
		//IL_02a7: Expected F4, but got I4
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		List<float2> points = _points;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v9+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_031d;
			}
			List<float2> points2 = _points;
			float num = 3.4028235E+38f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v9+20]");
			float2 result = (float2)0;
			object obj2 = 0;
			object obj3 = 0;
			object obj13 = default(object);
			float2 float5 = default(float2);
			while (true)
			{
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj4 < 0)
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)obj5 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj6 = 0;
					object obj7 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+18]");
					if ((nint)obj7 < 0)
					{
						object obj8 = obj3 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						object obj9 = obj8 % 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						if ((nint)obj9 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r9_v5+18]");
						if ((nint)obj9 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+20+v176 @ rcx_v7*8]");
							object obj11 = point - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+24+v176 @ rcx_v7*8]");
							object obj12 = obj13 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r9_v5+20+v158 @ rdx_v8*8]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+20+v176 @ rcx_v7*8]");
							object obj14 = num2 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r9_v5+24+v158 @ rdx_v8*8]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+24+v176 @ rcx_v7*8]");
							object obj15 = num3 - 0;
							object obj16 = obj11 * obj14;
							object obj17 = obj12 * obj15;
							object obj18 = obj15 * obj15;
							object obj19 = obj17 + obj16;
							object obj20 = obj14 * obj14;
							object obj21 = obj18 + obj20;
							float num4 = (float)obj19 / (float)obj21;
							if (!(0f > num4))
							{
								if (num4 > 1f)
								{
									num4 = 1f;
								}
							}
							else
							{
								num4 = 0f;
							}
							float num5 = (float)obj14 * num4;
							float num6 = (float)obj15 * num4;
							float num7 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+20+v176 @ rcx_v7*8]");
							float num8 = num7 + 0f;
							float num9 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6+24+v176 @ rcx_v7*8]");
							float num10 = num9 + 0f;
							float num11 = num8 - (float)point;
							float num12 = num10 - (float)obj13;
							float num13 = num11 * num11;
							float num14 = num12 * num12;
							float num15 = num14 + num13;
							if (num > num15)
							{
								obj3++;
								num = num15;
								result = float5;
								obj2 = obj3;
							}
							else
							{
								obj3++;
								obj2 = obj3;
							}
							continue;
						}
					}
					goto IL_031d;
				}
				return result;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_031d:
		return (float2)new IndexOutOfRangeException();
	}

	public unsafe bool LineToPolygonIntersection(float2 lineStart, float2 lineEnd, out float2 intersectionPoint)
	{
		//IL_001d: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_016d: Expected O, but got I4
		ref float2 reference;
		if (!IsPointInside(lineStart))
		{
			List<float2> points = _points;
			object obj = 0;
			float2 float5 = lineEnd;
			object obj2 = 0;
			float num = 3.4028235E+38f;
			object obj3 = 0;
			float2 float6 = default(float2);
			ref float2 intersection = default(ref float2);
			object obj9 = default(object);
			object obj11 = default(object);
			object obj12 = default(object);
			while (true)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj4 < 0)
				{
					object obj5 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)obj5 >= 0)
					{
						break;
					}
					object obj6 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					object obj7 = obj6 % 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)obj7 >= 0)
					{
						break;
					}
					if (MathUtils.LineToLineIntersection(lineStart, lineEnd, float6, float6, out intersection))
					{
						object obj8 = (object)lineStart - obj9;
						object obj10 = obj11 - obj12;
						object obj13 = obj8 * obj8;
						object obj14 = obj10 * obj10;
						float num2 = (float)obj14 + (float)obj13;
						if (num > num2)
						{
							obj++;
							float5 = float6;
							obj2 = 1;
							num = num2;
							obj3 = obj;
							continue;
						}
					}
					obj++;
					obj3 = obj;
					continue;
				}
				if (obj2 == null)
				{
					reference = ref *(float2*)lineEnd;
					return false;
				}
				reference = ref *(float2*)float5;
				return true;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
		reference = ref *(float2*)lineStart;
		return true;
	}

	private float2 ClosestPositionOnEdge(float2 pointA, float2 pointB, float2 point)
	{
		//IL_00b5: Invalid comparison between O and F4
		object obj = point - pointA;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj5 = pointB - pointA;
		object obj7 = default(object);
		object obj6 = obj7 - obj4;
		object obj8 = obj * obj5;
		object obj9 = obj2 * obj6;
		object obj10 = obj6 * obj6;
		object obj11 = obj9 + obj8;
		object obj12 = obj5 * obj5;
		object obj13 = obj10 + obj12;
		object obj14 = obj11 / obj13;
		if (0 > (nint)obj14 || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
		}
		float2 result = default(float2);
		return result;
	}
}
