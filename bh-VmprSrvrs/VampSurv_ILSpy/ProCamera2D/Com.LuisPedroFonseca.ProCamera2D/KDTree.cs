using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class KDTree
{
	public KDTree[] lr;

	public Vector3 pivot;

	public int pivotIndex;

	public int axis;

	private const int numDims = 3;

	public KDTree()
	{
		KDTree[] array = new KDTree[2];
		lr = array;
	}

	public static KDTree MakeFromPoints(Vector3[] points)
	{
		//IL_000e: Expected O, but got I4
		//IL_0045: Expected I4, but got O
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		int[] array = new int[points.Length];
		if (points.Length > 0)
		{
			object obj = 0;
			do
			{
				if ((nint)obj < array.Length)
				{
					array[obj] = (int)obj;
					obj++;
					continue;
				}
				return (KDTree)(object)new IndexOutOfRangeException();
			}
			while ((nint)obj < points.Length);
		}
		int enIndex = points.Length - 1;
		int[] inds = default(int[]);
		return MakeFromPointsInner(0, 0, enIndex, points, inds);
	}

	private static KDTree MakeFromPointsInner(int depth, int stIndex, int enIndex, Vector3[] points, int[] inds)
	{
		//IL_001e: Expected O, but got I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		//IL_0100: Expected O, but got I4
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0139: Expected O, but got I
		//IL_0196: Expected O, but got I4
		//IL_0258: Expected O, but got I4
		//IL_01c4: Expected I, but got O
		//IL_0286: Expected I, but got O
		KDTree kDTree = new KDTree();
		KDTree[] array = new KDTree[2];
		kDTree.lr = array;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r13d\"");
		object obj = 2 >> 31;
		object obj2 = 2 + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		int num = depth - obj4;
		kDTree.axis = num;
		int[] array2 = default(int[]);
		int num3 = default(int);
		int num2 = FindPivotIndex(points, array2, stIndex, enIndex, num3);
		if (num2 < array2.Length)
		{
			kDTree.pivotIndex = array2[num2];
			if (array2[num2] < points.Length)
			{
				object obj5 = array2[num2] * 2;
				object obj6 = array2[num2] + obj5;
				int num4 = num2 - 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ r9 (UnityEngine.Vector3[])+20+v351 @ rcx_v15*4]");
				kDTree.pivot = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ r9 (UnityEngine.Vector3[])+28+v351 @ rcx_v15*4]");
				_ = 0;
				if (num4 >= stIndex)
				{
					KDTree[] array3 = kDTree.lr;
					int depth2 = depth + 1;
					KDTree kDTree2 = MakeFromPointsInner(depth2, stIndex, num4, points, (int[])num3);
					if (kDTree2 != null)
					{
						nint num5 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj7 = default(object);
						if (obj7 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int num6 = num2 + 1;
				if (num6 <= enIndex)
				{
					KDTree[] array4 = kDTree.lr;
					int depth3 = depth + 1;
					KDTree kDTree3 = MakeFromPointsInner(depth3, num6, enIndex, points, (int[])num3);
					if (kDTree3 != null)
					{
						nint num7 = (nint)array4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj8 = default(object);
						if (obj8 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				return kDTree;
			}
		}
		return (KDTree)(object)new IndexOutOfRangeException();
	}

	private static void SwapElements(int[] arr, int a, int b)
	{
		arr[a] = arr[b];
		arr[b] = arr[a];
	}

	private unsafe static int FindSplitPoint(Vector3[] points, int[] inds, int stIndex, int enIndex, int axis)
	{
		//IL_0310: Expected I4, but got O
		//IL_0062: Expected O, but got I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0114: Expected O, but got I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0171: Expected O, but got I4
		//IL_019a: Expected I4, but got O
		//IL_01fc: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		int num3;
		if (stIndex < inds.Length && inds[stIndex] < points.Length)
		{
			object obj = inds[stIndex] + 4;
			object obj2 = obj * 2;
			object obj3 = inds[stIndex] + obj2;
			object obj4 = obj3 * 4;
			Vector3 vector = (Vector3)((object)points + obj4);
			int index = default(int);
			float num = ((Vector3*)vector)->get_Item(index);
			if (enIndex < inds.Length && inds[enIndex] < points.Length)
			{
				object obj5 = inds[enIndex] + 4;
				object obj6 = obj5 * 2;
				object obj7 = inds[enIndex] + obj6;
				object obj8 = obj7 * 4;
				Vector3 vector2 = (Vector3)((object)points + obj8);
				float num2 = ((Vector3*)vector2)->get_Item(index);
				object obj9 = stIndex + enIndex;
				object obj10 = obj9 >> 31;
				object obj11 = obj9 - obj10;
				num3 = obj11 >> 1;
				if (num3 < inds.Length && inds[num3] < points.Length)
				{
					object obj12 = inds[num3] + 8;
					object obj13 = inds[num3] * 2;
					object obj14 = obj12 + obj13;
					object obj15 = obj14 * 4;
					Vector3 vector3 = (Vector3)((object)points + obj15);
					float num4 = ((Vector3*)vector3)->get_Item(index);
					int num5;
					if (!(num > num2))
					{
						if (num > num4)
						{
							goto IL_02f5;
						}
						bool flag = num4 > num2;
						num5 = enIndex;
						if (!flag)
						{
							goto IL_031d;
						}
					}
					else
					{
						if (num4 > num)
						{
							goto IL_02f5;
						}
						bool flag2 = num2 > num4;
						num5 = enIndex;
						if (!flag2)
						{
							num5 = num3;
						}
					}
					num3 = num5;
					goto IL_031d;
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
		IL_031d:
		return num3;
		IL_02f5:
		num3 = stIndex;
		goto IL_031d;
	}

	public unsafe static int FindPivotIndex(Vector3[] points, int[] inds, int stIndex, int enIndex, int axis)
	{
		//IL_06ff: Expected I4, but got O
		//IL_0062: Expected O, but got I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0114: Expected O, but got I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0171: Expected O, but got I4
		//IL_019a: Expected I4, but got O
		//IL_01fc: Expected O, but got I4
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0350: Expected O, but got I4
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		//IL_047d: Expected O, but got I4
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		//IL_04a3: Expected O, but got I
		//IL_0546: Expected O, but got I
		//IL_04ce: Expected O, but got I4
		//IL_0559: Expected O, but got I4
		//IL_050c: Expected O, but got I
		//IL_051c: Expected O, but got I
		int num2 = default(int);
		int num6;
		if (stIndex < inds.Length && inds[stIndex] < points.Length)
		{
			object obj = inds[stIndex] + 4;
			object obj2 = obj * 2;
			object obj3 = inds[stIndex] + obj2;
			object obj4 = obj3 * 4;
			Vector3 vector = (Vector3)(obj4 + (object)points);
			float num = ((Vector3*)vector)->get_Item(num2);
			if (enIndex < inds.Length && inds[enIndex] < points.Length)
			{
				object obj5 = inds[enIndex] + 4;
				object obj6 = obj5 * 2;
				object obj7 = inds[enIndex] + obj6;
				object obj8 = obj7 * 4;
				Vector3 vector2 = (Vector3)(obj8 + (object)points);
				float num3 = ((Vector3*)vector2)->get_Item(num2);
				object obj9 = stIndex + enIndex;
				object obj10 = obj9 >> 31;
				object obj11 = obj9 - obj10;
				int num4 = obj11 >> 1;
				if (num4 < inds.Length && inds[num4] < points.Length)
				{
					object obj12 = inds[num4] * 2;
					object obj13 = inds[num4] + obj12;
					object obj14 = points + 32;
					object obj15 = obj13 * 4;
					Vector3 vector3 = (Vector3)(obj14 + obj15);
					float num5 = ((Vector3*)vector3)->get_Item(num2);
					if (!(num > num3))
					{
						if (num > num5)
						{
							goto IL_0302;
						}
						bool flag = num5 > num3;
						num6 = enIndex;
						if (!flag)
						{
							num6 = num4;
						}
					}
					else
					{
						if (num5 > num)
						{
							goto IL_0302;
						}
						bool flag2 = num3 > num5;
						num6 = enIndex;
						if (!flag2)
						{
							num6 = num4;
						}
					}
					goto IL_0770;
				}
			}
		}
		goto IL_06f1;
		IL_06c0:
		int num7;
		return num7 - 1;
		IL_0302:
		num6 = stIndex;
		goto IL_0770;
		IL_0770:
		if (num6 < inds.Length && inds[num6] < points.Length)
		{
			object obj16 = inds[num6] * 2;
			object obj17 = inds[num6] + obj16;
			if (stIndex < inds.Length && num6 < inds.Length)
			{
				inds[stIndex] = inds[num6];
				if (num6 < inds.Length)
				{
					num7 = stIndex + 1;
					inds[num6] = inds[stIndex];
					if (num7 > enIndex)
					{
						goto IL_06c0;
					}
					int num8 = num7;
					int num9 = enIndex;
					Vector3 vector6 = default(Vector3);
					int num12 = default(int);
					while (num8 < inds.Length && inds[num8] < points.Length)
					{
						object obj18 = inds[num8] * 2;
						object obj19 = inds[num8] + obj18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (UnityEngine.Vector3[])+20+v641 @ rcx_v26*4]");
						Vector3 vector4 = (Vector3)0;
						bool flag3 = num2 == 0;
						Vector3 vector5;
						if (!flag3)
						{
							object obj20 = num2 - 1;
							if (!flag3)
							{
								if ((nint)obj20 != 1)
								{
									IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid Vector3 index!");
									ex._002Ector("Invalid Vector3 index!");
									throw ex;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (UnityEngine.Vector3[])+28+v594 @ rax_v18*4]");
								vector5 = (Vector3)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (UnityEngine.Vector3[])+28+v641 @ rcx_v26*4]");
								vector4 = (Vector3)0;
							}
							else
							{
								vector5 = vector6;
								vector4 = vector6;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rcx (UnityEngine.Vector3[])+20+v594 @ rax_v18*4]");
							vector5 = (Vector3)0;
						}
						int num10;
						if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector4) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector5))
						{
							object obj21 = num8 - 1;
							if ((nint)obj21 >= inds.Length)
							{
								break;
							}
							num10 = inds[obj21];
							if (num8 >= inds.Length)
							{
								break;
							}
							_ = inds[num8];
							if (num8 >= inds.Length)
							{
								break;
							}
							num7 = num8 + 1;
						}
						else
						{
							if (num8 >= inds.Length)
							{
								break;
							}
							num10 = inds[num8];
							if (num9 >= inds.Length || num8 >= inds.Length)
							{
								break;
							}
							inds[num8] = inds[num9];
							if (num9 >= inds.Length)
							{
								break;
							}
							int num11 = num9 - 1;
							num7 = num8;
							num9 = num11;
						}
						inds[num12] = num10;
						bool flag4 = num7 <= num9;
						num8 = num7;
						if (flag4)
						{
							continue;
						}
						goto IL_06c0;
					}
				}
			}
		}
		goto IL_06f1;
		IL_06f1:
		IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
		return (int)ex2;
	}

	public static int[] Iota(int num)
	{
		//IL_000e: Expected O, but got I4
		//IL_0045: Expected I4, but got O
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		int[] array = new int[num];
		if (num > 0)
		{
			object obj = 0;
			do
			{
				if ((nint)obj < array.Length)
				{
					array[obj] = (int)obj;
					obj++;
					continue;
				}
				return (int[])(object)new IndexOutOfRangeException();
			}
			while ((nint)obj < num);
		}
		return array;
	}

	public unsafe int FindNearest(Vector3 pt)
	{
		//IL_0012: Expected O, but got Ref
		//IL_001c: Expected I4, but got I8
		object obj = default(object);
		float bestSqSoFar = default(float);
		int bestIndex = default(int);
		Search((Vector3)(&obj), ref bestSqSoFar, ref bestIndex);
		return -1;
	}

	private unsafe void Search(Vector3 pt, ref float bestSqSoFar, ref int bestIndex)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_023a: Invalid comparison between I4 and F4
		//IL_00da: Expected Ref, but got F4
		//IL_0157: Expected O, but got I4
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_012d: Expected O, but got Ref
		//IL_01e1: Expected O, but got Ref
		_ = pivot;
		_ = pt.x;
		float num = (float)pivot - pt.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.KDTree)+20]");
		object obj = 0 - pt.z;
		object obj3 = default(object);
		object obj2 = obj3 - obj3;
		float num2 = num * num;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		float num3 = num2 + (float)obj4;
		float num4 = num3 + (float)obj5;
		if (bestSqSoFar > num4)
		{
			ref float reference = ref *(float*)num4;
			ref int reference2 = ref *(int*)pivotIndex;
		}
		float num5 = ((Vector3*)pt)->get_Item(axis);
		Vector3 vector = (Vector3)(this + 24);
		float num6 = ((Vector3*)vector)->get_Item(axis);
		float num7 = num5 - num6;
		KDTree[] array = lr;
		bool flag = 0f < num7;
		float x = default(float);
		if (array[flag ? 1u : 0u] != null)
		{
			array[flag ? 1u : 0u].Search((Vector3)(&x), ref bestSqSoFar, ref bestIndex);
			x = pt.x;
		}
		KDTree[] array2 = lr;
		object obj6 = (flag ? 1 : 0) - 1;
		object obj7 = obj6 & 1;
		if (array2[obj7] != null)
		{
			float num8 = num7 * num7;
			if (bestSqSoFar > num8)
			{
				array2[obj7].Search((Vector3)(&x), ref bestSqSoFar, ref bestIndex);
			}
		}
	}

	private unsafe float DistFromSplitPlane(Vector3 pt, Vector3 planePt, int axis)
	{
		float num = ((Vector3*)pt)->get_Item(axis);
		float num2 = ((Vector3*)planePt)->get_Item(axis);
		return num - num2;
	}

	public unsafe string Dump(int level)
	{
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C285]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = this + 36;
		string text = ((int*)num)->ToString();
		string text2 = text.PadLeft(level, ' ');
		string text3 = text2 + "\n";
		KDTree[] array = lr;
		if (array.Length > 0)
		{
			bool flag = array[0] == null;
			string text4 = text3;
			if (!flag)
			{
				int level2 = level + 2;
				string text5 = array[0].Dump(level2);
				string text6 = text3 + text5;
				text4 = text6;
			}
			KDTree[] array2 = lr;
			if (array2.Length > 1)
			{
				if (array2[1] != null)
				{
					int level3 = level + 2;
					string text7 = array2[1].Dump(level3);
					string text8 = text4 + text7;
					text4 = text8;
				}
				return text4;
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}
}
