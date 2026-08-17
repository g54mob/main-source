using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

public class QuickSelect
{
	private unsafe static void swap<T>(List<T> arr, int i, int j)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002e: Expected O, but got I
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01ac: Expected O, but got I
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_0203: Expected O, but got I
		//IL_020b: Expected O, but got Ref
		//IL_005f: Expected O, but got I8
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_025d: Expected O, but got I
		//IL_0265: Expected O, but got Ref
		//IL_0071: Expected O, but got I8
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_0083: Expected O, but got I8
		//IL_00c8: Expected O, but got Ref
		//IL_0108: Expected O, but got Ref
		//IL_013c: Expected O, but got I
		//IL_0156: Expected O, but got Ref
		//IL_0095: Expected O, but got I8
		//IL_02d6: Expected O, but got Ref
		//IL_0314: Expected O, but got I
		//IL_032e: Expected O, but got Ref
		//IL_035a: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		object obj4 = obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		if ((nint)obj4 <= 0)
		{
			obj3 = 1152921504606846960L;
		}
		object obj5 = obj3 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		object obj6 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = (object)(&obj2);
		object obj11 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		if ((nint)obj11 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj12 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		object obj13 = (nint)0 + (nint)15;
		object obj14 = (object)(&obj2);
		object obj15 = obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r10_v1 (Il2CppClass<T>)+FC]");
		if ((nint)obj15 <= 0)
		{
			obj13 = 1152921504606846960L;
		}
		object obj16 = obj13 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+68]");
		_ = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+58]");
		_ = 0;
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		obj = obj17;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v156 @ r10_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		_ = ref obj2;
		nint num4 = 0;
		object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		obj = obj18;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v174 @ r10_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v17 (Il2CppClass<T>)+28]");
		object obj19 = (nint)0 >> 31;
		bool flag = obj19 != null;
		object obj20 = (object)(&obj2);
		if (!flag)
		{
			obj20 = obj10;
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+58]");
		_ = 0;
		object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		obj = obj21;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v202 @ r10_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v21 (Il2CppClass<T>)+28]");
		object obj22 = (nint)0 >> 31;
		bool flag2 = obj22 != null;
		object obj23 = (object)(&obj2);
		if (!flag2)
		{
			obj23 = obj14;
		}
		nint num10 = 0;
		object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		obj = obj24;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v231 @ r10_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
	}

	[MethodImpl((MethodImplOptions)256)]
	private static void swap<T>(T[] arr, int i, int j)
	{
		arr[i] = arr[j];
		arr[j] = arr[i];
	}

	private unsafe static int defaultCompare<T>(T a, T b)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0056: Expected O, but got I
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_010f: Expected O, but got I
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0087: Expected O, but got I8
		//IL_015e: Expected O, but got Ref
		//IL_017a: Expected O, but got I
		//IL_0099: Expected O, but got I8
		//IL_01df: Expected I, but got O
		//IL_01f1: Expected O, but got Ref
		//IL_020d: Expected O, but got I
		//IL_01aa: Expected I, but got O
		//IL_00e1: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v2 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		object obj4 = obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v2 (Il2CppClass<T>)+FC]");
		if ((nint)obj4 <= 0)
		{
			obj3 = 1152921504606846960L;
		}
		object obj5 = obj3 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v2 (Il2CppClass<T>)+FC]");
		object obj6 = (nint)0 + (nint)15;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v2 (Il2CppClass<T>)+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v10 (Il2CppClass<T>)+28]");
		object obj9 = (nint)0 >> 31;
		if (obj9 != null)
		{
			val = a;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		object a2 = (IntPtr)obj2;
		T val2 = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r9_v1 (Il2CppClass<T>)+28]");
		object obj10 = (nint)0 >> 31;
		if (obj10 != null)
		{
			val2 = b;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		object b2 = (IntPtr)obj2;
		if (Comparer.Default != null)
		{
			return Comparer.Default.Compare(a2, b2);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe static void DoQuickSelect<T>(ref ListAccessor<T> list, int k, int left = 0, int right = -1, Comparison<T> compare = null)
	{
		//IL_0591: Expected O, but got I
		//IL_0561: Expected O, but got I4
		//IL_0201: Expected O, but got I
		//IL_00a1: Expected I, but got O
		//IL_00ae: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0153: Expected F8, but got I4
		//IL_02be: Expected O, but got I
		//IL_01a9: Invalid comparison between I4 and F8
		//IL_04a6: Invalid comparison between I4 and F8
		//IL_04b7: Expected F8, but got I4
		//IL_01d0: Expected I4, but got F8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
		bool flag = (nint)0 != 0;
		ref ListAccessor<T> reference = ref list;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			reference = ref list;
		}
		int num = default(int);
		bool flag2 = num != -1;
		int num2 = num;
		if (!flag2)
		{
			object obj = reference;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r12_v10+18]");
			num2 = (int)(-1);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rdx_v5 (ListAccessor`1<T>&)+8]");
		object obj2 = 0;
		if (num2 <= left)
		{
			return;
		}
		int num3 = left;
		object obj9 = default(object);
		object obj10 = default(object);
		object obj11 = default(object);
		object obj12 = default(object);
		bool flag7;
		do
		{
			object obj3 = num2 - num3;
			if ((nint)obj3 > 600)
			{
				nint num4 = (nint)typeof(Math);
				object obj4 = num2 - num3;
				object obj5 = k - num3;
				object obj6 = obj4 + 1;
				object obj7 = obj5 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,edi\"");
				double d = Math.Log(0.0);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,xmm9\"");
				double num5 = Math.Exp(d);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,xmm8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,edi\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm7\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm7\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm1,edi\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm2,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rbx_v16 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 <= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm0\"");
				}
				else
				{
					double num6 = Math.Sqrt(0.0);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm2,xmm7\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm2,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm2\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm6\"");
				double num7 = Math.Floor(k);
				double d2 = (double)obj6 - (double)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm7\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm2\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm6\"");
				double num8 = Math.Floor(d2);
				bool flag3 = !((double)num2 > num8);
				num = num2;
				if (!flag3)
				{
					num = (int)num8;
				}
				bool flag4 = !((double)num3 < num7);
				double num9 = num3;
				if (!flag4)
				{
					num9 = num7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18310D3D0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FC000");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_28+28]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ stack_28+18] (should have been resolved before IL gen)");
			if ((nint)obj9 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FC000");
			}
			bool flag5 = num3 >= num2;
			int num10 = num2;
			int num11 = num3;
			int num12 = num2;
			if (!flag5)
			{
				bool flag6;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FC000");
					num11++;
					num10 = num12 - 1;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ stack_28+18] (should have been resolved before IL gen)");
						if ((nint)obj10 >= 0)
						{
							break;
						}
						num11++;
					}
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_28+28]");
						obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ stack_28+18] (should have been resolved before IL gen)");
						if ((nint)obj11 <= 0)
						{
							break;
						}
						num10--;
					}
					flag6 = num11 < num10;
					num12 = num10;
				}
				while (flag6);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_28+28]");
			num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ stack_28+18] (should have been resolved before IL gen)");
			if (obj12 != null)
			{
				num10++;
				int num13 = num2;
				reference = ref *(ListAccessor<T>*)num10;
			}
			else
			{
				int num13 = num10;
				reference = ref *(ListAccessor<T>*)num3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FC000");
			int num14 = num10 + 1;
			int num15 = num10 - 1;
			if (num10 > k)
			{
				num14 = num3;
			}
			if (num10 < k)
			{
				num15 = num2;
			}
			flag7 = num15 > num14;
			num3 = num14;
			num2 = num15;
		}
		while (flag7);
	}
}
