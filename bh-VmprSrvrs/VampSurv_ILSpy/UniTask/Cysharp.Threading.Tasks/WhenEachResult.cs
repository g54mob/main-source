using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public struct WhenEachResult<T>
{
	private readonly T _003CResult_003Ek__BackingField;

	private readonly Exception _003CException_003Ek__BackingField;

	public unsafe T Result
	{
		get
		{
			//IL_0008: Expected O, but got Ref
			//IL_0018: Expected O, but got I
			//IL_003c: Expected O, but got I
			//IL_004c: Expected O, but got I
			//IL_0062: Expected O, but got I
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_014a: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_00c0: Expected O, but got I
			//IL_00d0: Expected O, but got I
			//IL_00e2: Expected O, but got Ref
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_0093: Expected O, but got I8
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2+FC]");
			if ((nint)obj7 <= 0)
			{
				obj6 = 1152921504606846960L;
			}
			object obj8 = obj6 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v7+C0]");
			object obj10 = 0;
			object obj11 = obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v7+80]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r9_v1+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r9_v1+18]");
			object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			object obj15 = obj14 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v9+28]");
			if ((nint)0 >= (nint)0)
			{
				obj15 = obj14;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			T result = default(T);
			return result;
		}
	}

	public unsafe Exception Exception
	{
		get
		{
			//IL_0023: Expected O, but got I
			//IL_0033: Expected O, but got I
			//IL_0045: Expected O, but got Ref
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rcx_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rdx_v1+30]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rdx_v1+38]");
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			object result = obj3 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
				result = obj3;
			}
			return (Exception)result;
		}
	}

	public bool IsCompletedSuccessfully
	{
		get
		{
			//IL_001b: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+10]");
			object obj = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ rcx_v2] (should have been resolved before IL gen)");
			object obj2 = default(object);
			return obj2 == null;
		}
	}

	public bool IsFaulted
	{
		get
		{
			//IL_001b: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+10]");
			object obj = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ rcx_v2] (should have been resolved before IL gen)");
			object obj2 = default(object);
			bool flag = obj2 == null;
			return !flag;
		}
	}

	public unsafe WhenEachResult(T result)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0032: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0092: Expected O, but got Ref
		//IL_00a2: Expected O, but got I
		//IL_00b8: Expected O, but got I
		//IL_0079: Expected O, but got I8
		//IL_011d: Expected O, but got I
		//IL_012d: Expected O, but got I
		//IL_013f: Expected O, but got Ref
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_01a3: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rcx_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rcx_v2+FC]");
		if ((nint)obj5 <= 0)
		{
			obj4 = 1152921504606846960L;
		}
		object obj6 = obj4 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		nint num2 = 0;
		T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v7+28]");
		object obj8 = (nint)0 >> 31;
		if (obj8 != null)
		{
			val = result;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num3 = 0;
		IntPtr intPtr = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		nint num4 = 0;
		IntPtr intPtr2 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v12 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>>)+80]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v5+30]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v5+38]");
		object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
		object obj12 = obj11 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v19+28]");
		if ((nint)0 < (nint)0)
		{
			obj12 = 0;
		}
	}

	public unsafe WhenEachResult(Exception exception)
	{
		//IL_001b: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_006b: Expected O, but got I
		//IL_007d: Expected O, but got Ref
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_00e1: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+8]");
		object obj = 0;
		if (exception != null)
		{
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v9 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>>)+80]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v3+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v3+18]");
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			object obj5 = obj4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v12+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num3 = 0;
			IntPtr intPtr2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v13 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>>)+80]");
			object obj6 = (nint)0 + (nint)32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("exception");
		throw ex;
	}

	public void TryThrow()
	{
		//IL_001b: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+20]");
		object obj = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ rcx_v2] (should have been resolved before IL gen)");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003490");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003490");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v81 @ rax_v10 (should have been resolved before IL gen)");
		Exception source = default(Exception);
		ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
		throw new NullReferenceException();
	}

	public unsafe T GetResult()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0037: Expected O, but got I
		//IL_0047: Expected O, but got I
		//IL_005d: Expected O, but got I
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_01fc: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_00b3: Expected O, but got I
		//IL_00c3: Expected O, but got I
		//IL_008e: Expected O, but got I8
		//IL_00d8: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0211: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0231: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0135: Expected O, but got Ref
		//IL_014a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3+8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2+FC]");
		object obj6 = (nint)0 + (nint)15;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v7+C0]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v8+20]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v10+C0]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ rcx_v7] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
		object obj14 = 0;
		object obj15 = default(object);
		if (obj15 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v19+C0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v23+28]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v25+C0]");
			object obj19 = 0;
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v26+28]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v125 @ rsi_v2+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			T result = default(T);
			return result;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003490");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003490");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v157 @ rax_v15 (should have been resolved before IL gen)");
		Exception source = default(Exception);
		ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
		throw new NullReferenceException();
	}

	public unsafe override string ToString()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0051: Expected O, but got I
		//IL_006c: Expected O, but got I
		//IL_0087: Expected O, but got I
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0351: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_0395: Expected O, but got I
		//IL_03d4: Expected O, but got I
		//IL_03dc: Expected O, but got Ref
		//IL_0425: Expected O, but got I
		//IL_04dc: Expected O, but got I
		//IL_046e: Expected O, but got I
		//IL_016a: Expected O, but got Ref
		//IL_018d: Expected O, but got I
		//IL_04bc: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_01e1: Expected O, but got I
		//IL_0507: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_0239: Expected O, but got I
		//IL_02d2: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189987104]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+8]");
		object obj3 = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v9+FC]");
		object obj5 = (nint)0 + (nint)16;
		object obj6 = obj5 + 15;
		object obj10 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			object obj7 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			if ((nint)obj7 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			object obj8 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			if ((nint)obj8 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			object obj9 = (nint)0 + (nint)15;
			obj10 = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			if ((nint)obj9 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			object obj11 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			if ((nint)obj11 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			object obj12 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			if ((nint)obj12 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v43 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+30]");
		object obj13 = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v11] (should have been resolved before IL gen)");
		object obj14 = default(object);
		string result;
		if (obj14 == null)
		{
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v85 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+10]");
			object obj15 = 0;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v310 @ rcx_v39] (should have been resolved before IL gen)");
			object obj16 = default(object);
			if (obj16 != null)
			{
				object obj17 = obj16;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v373 @ rdx_v15+188] (should have been resolved before IL gen)");
				string text = default(string);
				result = "Exception{" + text + "}";
				goto IL_04c1;
			}
			return (string)(object)new NullReferenceException();
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v50 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+28]");
		object obj18 = 0;
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rax_v53 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+28]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v327 @ rbx_v5+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rax_v59 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachResult`1>)+8]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v23+28]");
		object obj22 = (nint)0 >> 31;
		bool flag;
		object obj24;
		if (obj22 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v23+60]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v23+135]");
				object obj23 = (nint)0 & (nint)8;
				if (obj23 != null)
				{
					flag = obj10 == null;
					goto IL_04e1;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
			obj24 = 0;
			goto IL_0293;
		}
		flag = obj10 == null;
		goto IL_04e1;
		IL_030b:
		result = "";
		goto IL_04c1;
		IL_04e1:
		bool flag2 = !flag;
		bool flag3 = !flag2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v3+FC]");
		obj24 = 0;
		if (flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			goto IL_030b;
		}
		goto IL_0293;
		IL_04c1:
		return result;
		IL_0293:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num10 = 0;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+58]");
		result = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+58]");
		if ((nint)0 == 0)
		{
			goto IL_030b;
		}
		goto IL_04c1;
	}
}
