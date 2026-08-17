using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

public class EventEmitter
{
	private Delegate[] callbacks;

	public DelegateType getDelegate<DelegateType>(WorldEvents evt) where DelegateType : Delegate
	{
		Delegate[] array = callbacks;
		if ((int)evt < array.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			DelegateType result = default(DelegateType);
			return result;
		}
		return (DelegateType)(object)new IndexOutOfRangeException();
	}

	public void on<DelegateType>(DelegateType a, WorldEvents evt) where DelegateType : Delegate
	{
		//IL_00e2: Expected I, but got O
		//IL_0081: Expected I, but got O
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] != null)
		{
			Delegate obj = Delegate.Combine(array[(int)evt], a);
			bool flag = (object)obj == null;
			DelegateType val = (DelegateType)obj;
			if (!flag)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				val = (DelegateType)obj;
			}
		}
		else
		{
			bool flag2 = (object)a == null;
			DelegateType val = a;
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				val = a;
				if (flag3)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void emit(WorldEvents evt)
	{
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] != null)
		{
			object[] args = Array.Empty<object>();
			object obj = array[(int)evt].DynamicInvokeImpl(args);
		}
	}

	public void emit<T1>(WorldEvents evt, T1 arg1)
	{
		//IL_0079: Expected I, but got O
		//IL_00a7: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] == null)
		{
			return;
		}
		object[] array2 = new object[1];
		object obj2 = default(object);
		object obj = (IntPtr)obj2;
		if (obj != null)
		{
			nint num = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj4 = array[(int)evt].DynamicInvokeImpl(array2);
	}

	public unsafe void emit<T1, T2>(WorldEvents evt, T1 arg1, T2 arg2)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001d: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Expected O, but got I
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02e6: Expected O, but got I
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_00eb: Expected O, but got I8
		//IL_00fd: Expected O, but got I8
		//IL_0146: Expected O, but got I
		//IL_0154: Expected O, but got Ref
		//IL_0172: Expected O, but got I
		//IL_0356: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_0210: Expected O, but got Ref
		//IL_0220: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_0393: Expected O, but got I
		//IL_01c1: Expected I, but got O
		//IL_0268: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+60]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj4 = 0;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v2+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		object obj7 = (nint)0 + (nint)15;
		object obj8 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		if ((nint)obj8 <= 0)
		{
			obj7 = 1152921504606846960L;
		}
		object obj9 = obj7 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		object obj10 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj11 = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		if ((nint)obj11 <= 0)
		{
			obj10 = 1152921504606846960L;
		}
		object obj12 = obj10 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Delegate[] array = callbacks;
		_ = ref obj2;
		if ((object)array[(int)evt] == null)
		{
			return;
		}
		object[] array2 = new object[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj13 = 0;
		T1 val = (T1)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		object obj14 = obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r9_v6+28]");
		object obj15 = (nint)0 >> 31;
		if (obj15 != null)
		{
			val = arg1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj17 = default(object);
		if (obj17 != null)
		{
			nint num = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj18 = default(object);
			if (obj18 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj19 = 0;
		T2 val2 = (T2)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v25+8]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v27+28]");
		object obj21 = (nint)0 >> 31;
		if (obj21 != null)
		{
			val2 = arg2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj23 = default(object);
		if (obj23 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj24 = default(object);
			if (obj24 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj25 = array[(int)evt].DynamicInvokeImpl(array2);
	}

	public void emit<T1, T2, T3>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3)
	{
		//IL_0063: Expected I, but got O
		//IL_00b9: Expected I, but got O
		//IL_010f: Expected I, but got O
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] == null)
		{
			return;
		}
		object[] array2 = new object[3];
		if (arg1 != null)
		{
			nint num = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (arg2 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj5 = array[(int)evt].DynamicInvokeImpl(array2);
	}

	public void emit<T1, T2, T3, T4>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		//IL_0063: Expected I, but got O
		//IL_00b9: Expected I, but got O
		//IL_010f: Expected I, but got O
		//IL_0165: Expected I, but got O
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] == null)
		{
			return;
		}
		object[] array2 = new object[4];
		if (arg1 != null)
		{
			nint num = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (arg2 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj5 = default(object);
		if (obj5 != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj7 = array[(int)evt].DynamicInvokeImpl(array2);
	}

	public unsafe void emit<T1, T2, T3, T4, T5>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0087: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_00f9: Expected O, but got I
		//IL_011c: Expected O, but got I
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Expected O, but got Unknown
		//IL_0598: Expected O, but got I
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		//IL_05ef: Expected O, but got I
		//IL_015a: Expected O, but got I8
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_0646: Expected O, but got I
		//IL_016c: Expected O, but got I8
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_069d: Expected O, but got I
		//IL_017e: Expected O, but got I8
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Expected O, but got Unknown
		//IL_0190: Expected O, but got I8
		//IL_01a2: Expected O, but got I8
		//IL_01eb: Expected O, but got I
		//IL_01f9: Expected O, but got Ref
		//IL_0217: Expected O, but got I
		//IL_0703: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_02b5: Expected O, but got Ref
		//IL_02c5: Expected O, but got I
		//IL_02db: Expected O, but got I
		//IL_0740: Expected O, but got I
		//IL_0266: Expected I, but got O
		//IL_034e: Expected O, but got I
		//IL_035c: Expected O, but got Ref
		//IL_036c: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_0795: Expected O, but got I
		//IL_030d: Expected I, but got O
		//IL_03fd: Expected O, but got I
		//IL_040b: Expected O, but got Ref
		//IL_041b: Expected O, but got I
		//IL_0431: Expected O, but got I
		//IL_03af: Expected O, but got I
		//IL_07ea: Expected O, but got I
		//IL_03bc: Expected I, but got O
		//IL_04ac: Expected O, but got I
		//IL_04ba: Expected O, but got Ref
		//IL_04ca: Expected O, but got I
		//IL_04e0: Expected O, but got I
		//IL_045e: Expected O, but got I
		//IL_083f: Expected O, but got I
		//IL_046b: Expected I, but got O
		//IL_050d: Expected O, but got I
		//IL_051a: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+A8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj4 = 0;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+18]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v4+FC]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+20]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v5+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		object obj10 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v6+FC]");
		_ = 0;
		object obj11 = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		if ((nint)obj11 <= 0)
		{
			obj10 = 1152921504606846960L;
		}
		object obj12 = obj10 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		object obj13 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj14 = obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		if ((nint)obj14 <= 0)
		{
			obj13 = 1152921504606846960L;
		}
		object obj15 = obj13 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v4+FC]");
		object obj16 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj17 = obj16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v4+FC]");
		if ((nint)obj17 <= 0)
		{
			obj16 = 1152921504606846960L;
		}
		object obj18 = obj16 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v5+FC]");
		object obj19 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj20 = obj19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v5+FC]");
		if ((nint)obj20 <= 0)
		{
			obj19 = 1152921504606846960L;
		}
		object obj21 = obj19 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+78]");
		object obj22 = (nint)0 + (nint)15;
		object obj23 = obj22;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+78]");
		if ((nint)obj23 <= 0)
		{
			obj22 = 1152921504606846960L;
		}
		object obj24 = obj22 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] == null)
		{
			return;
		}
		object[] array2 = new object[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj25 = 0;
		T1 val = (T1)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		object obj26 = obj25;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r9_v11+28]");
		object obj27 = (nint)0 >> 31;
		if (obj27 != null)
		{
			val = arg1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj29 = default(object);
		if (obj29 != null)
		{
			nint num = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj30 = default(object);
			if (obj30 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj31 = 0;
		T2 val2 = (T2)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v44+8]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rcx_v45+28]");
		object obj33 = (nint)0 >> 31;
		if (obj33 != null)
		{
			val2 = arg2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj35 = default(object);
		if (obj35 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj36 = default(object);
			if (obj36 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj37 = 0;
		object obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v52+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rcx_v50+28]");
		object obj40 = (nint)0 >> 31;
		if (obj40 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+90]");
			obj38 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj42 = default(object);
		if (obj42 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj43 = default(object);
			if (obj43 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj44 = 0;
		object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rax_v60+18]");
		object obj46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rcx_v55+28]");
		object obj47 = (nint)0 >> 31;
		if (obj47 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+98]");
			obj45 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj49 = default(object);
		if (obj49 != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj50 = default(object);
			if (obj50 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj51 = 0;
		object obj52 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rax_v68+20]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ rcx_v60+28]");
		object obj54 = (nint)0 >> 31;
		if (obj54 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+A0]");
			obj52 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj56 = default(object);
		if (obj56 != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj57 = default(object);
			if (obj57 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj58 = array[(int)evt].DynamicInvokeImpl(array2);
	}

	public unsafe void emit<T1, T2, T3, T4, T5, T6>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0087: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_00f9: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Expected O, but got Unknown
		//IL_0676: Expected O, but got I
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_06cd: Expected O, but got I
		//IL_0177: Expected O, but got I8
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Expected O, but got Unknown
		//IL_0724: Expected O, but got I
		//IL_0189: Expected O, but got I8
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Expected O, but got Unknown
		//IL_077b: Expected O, but got I
		//IL_019b: Expected O, but got I8
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Expected O, but got Unknown
		//IL_07d2: Expected O, but got I
		//IL_01ad: Expected O, but got I8
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected O, but got Unknown
		//IL_01bf: Expected O, but got I8
		//IL_01d1: Expected O, but got I8
		//IL_021a: Expected O, but got I
		//IL_0228: Expected O, but got Ref
		//IL_0246: Expected O, but got I
		//IL_0838: Expected O, but got I
		//IL_02d6: Expected O, but got I
		//IL_02e4: Expected O, but got Ref
		//IL_02f4: Expected O, but got I
		//IL_030a: Expected O, but got I
		//IL_0875: Expected O, but got I
		//IL_0295: Expected I, but got O
		//IL_037d: Expected O, but got I
		//IL_038b: Expected O, but got Ref
		//IL_039b: Expected O, but got I
		//IL_03b1: Expected O, but got I
		//IL_08ca: Expected O, but got I
		//IL_033c: Expected I, but got O
		//IL_042c: Expected O, but got I
		//IL_043a: Expected O, but got Ref
		//IL_044a: Expected O, but got I
		//IL_0460: Expected O, but got I
		//IL_03de: Expected O, but got I
		//IL_091f: Expected O, but got I
		//IL_03eb: Expected I, but got O
		//IL_04db: Expected O, but got I
		//IL_04e9: Expected O, but got Ref
		//IL_04f9: Expected O, but got I
		//IL_050f: Expected O, but got I
		//IL_048d: Expected O, but got I
		//IL_0974: Expected O, but got I
		//IL_049a: Expected I, but got O
		//IL_058a: Expected O, but got I
		//IL_0598: Expected O, but got Ref
		//IL_05a8: Expected O, but got I
		//IL_05be: Expected O, but got I
		//IL_053c: Expected O, but got I
		//IL_09c9: Expected O, but got I
		//IL_0549: Expected I, but got O
		//IL_05eb: Expected O, but got I
		//IL_05f8: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+C0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj4 = 0;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+18]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v4+FC]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+20]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v5+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v2+28]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v6+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		object obj11 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v7+FC]");
		_ = 0;
		object obj12 = obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v2+FC]");
		if ((nint)obj12 <= 0)
		{
			obj11 = 1152921504606846960L;
		}
		object obj13 = obj11 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		object obj14 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj15 = obj14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+FC]");
		if ((nint)obj15 <= 0)
		{
			obj14 = 1152921504606846960L;
		}
		object obj16 = obj14 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v4+FC]");
		object obj17 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj18 = obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v4+FC]");
		if ((nint)obj18 <= 0)
		{
			obj17 = 1152921504606846960L;
		}
		object obj19 = obj17 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v5+FC]");
		object obj20 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj21 = obj20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v5+FC]");
		if ((nint)obj21 <= 0)
		{
			obj20 = 1152921504606846960L;
		}
		object obj22 = obj20 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v6+FC]");
		object obj23 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj24 = obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v6+FC]");
		if ((nint)obj24 <= 0)
		{
			obj23 = 1152921504606846960L;
		}
		object obj25 = obj23 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+88]");
		object obj26 = (nint)0 + (nint)15;
		object obj27 = obj26;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+88]");
		if ((nint)obj27 <= 0)
		{
			obj26 = 1152921504606846960L;
		}
		object obj28 = obj26 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Delegate[] array = callbacks;
		if ((object)array[(int)evt] == null)
		{
			return;
		}
		object[] array2 = new object[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj29 = 0;
		T1 val = (T1)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		object obj30 = obj29;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ r9_v12+28]");
		object obj31 = (nint)0 >> 31;
		if (obj31 != null)
		{
			val = arg1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj33 = default(object);
		if (obj33 != null)
		{
			nint num = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj34 = default(object);
			if (obj34 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj35 = 0;
		T2 val2 = (T2)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v50+8]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rcx_v51+28]");
		object obj37 = (nint)0 >> 31;
		if (obj37 != null)
		{
			val2 = arg2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj39 = default(object);
		if (obj39 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj40 = default(object);
			if (obj40 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj41 = 0;
		object obj42 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ rax_v58+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v56+28]");
		object obj44 = (nint)0 >> 31;
		if (obj44 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+A0]");
			obj42 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj46 = default(object);
		if (obj46 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj47 = default(object);
			if (obj47 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj48 = 0;
		object obj49 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v763 @ rax_v66+18]");
		object obj50 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rcx_v61+28]");
		object obj51 = (nint)0 >> 31;
		if (obj51 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+A8]");
			obj49 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj52 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj53 = default(object);
		if (obj53 != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj54 = default(object);
			if (obj54 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj55 = 0;
		object obj56 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ rax_v74+20]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rcx_v66+28]");
		object obj58 = (nint)0 >> 31;
		if (obj58 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B0]");
			obj56 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj60 = default(object);
		if (obj60 != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj61 = default(object);
			if (obj61 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj62 = 0;
		object obj63 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rax_v82+28]");
		object obj64 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ rcx_v71+28]");
		object obj65 = (nint)0 >> 31;
		if (obj65 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
			obj63 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbx_v1+38]");
		object obj66 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj67 = default(object);
		if (obj67 != null)
		{
			nint num6 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj68 = default(object);
			if (obj68 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj69 = array[(int)evt].DynamicInvokeImpl(array2);
	}

	public void removeAllListeners()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		Delegate[] array = callbacks;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			Delegate[] array2 = callbacks;
			array2[obj2] = null;
			array = callbacks;
			obj2++;
			obj = obj2;
		}
	}

	public EventEmitter()
	{
		Delegate[] array = new Delegate[9];
		callbacks = array;
	}
}
