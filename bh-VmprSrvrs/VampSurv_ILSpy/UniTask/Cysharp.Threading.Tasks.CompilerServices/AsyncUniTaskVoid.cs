using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.CompilerServices;

internal sealed class AsyncUniTaskVoid<TStateMachine> : IStateMachineRunner, ITaskPoolNode<AsyncUniTaskVoid<TStateMachine>>, IUniTaskSource, IValueTaskSource where TStateMachine : IAsyncStateMachine
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			//IL_0030: Expected O, but got I
			//IL_0060: Expected O, but got I
			//IL_0075: Expected O, but got I
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1+<>c>)+8]");
			object obj2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1+<>c>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
			object obj4 = 0;
			obj4 = obj;
		}

		internal int _003C_002Ecctor_003Eb__10_0()
		{
			//IL_0020: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_004e: Expected O, but got I
			//IL_0063: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1+<>c>)+30]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1+<>c>)+28]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1+<>c>)+30]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v9+B8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ rdi_v1 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: rcx)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private static TaskPool<AsyncUniTaskVoid<TStateMachine>> pool;

	private readonly Action _003CReturnAction_003Ek__BackingField;

	private TStateMachine stateMachine;

	private readonly Action _003CMoveNext_003Ek__BackingField;

	private AsyncUniTaskVoid<TStateMachine> nextNode;

	public Action ReturnAction
	{
		get
		{
			//IL_001e: Expected O, but got I
			//IL_002e: Expected O, but got I
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+30]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+38]");
			object obj3 = 0 + this;
			object result = obj3 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
			if ((nint)0 >= (nint)0)
			{
				result = obj3;
			}
			return (Action)result;
		}
	}

	public Action MoveNext
	{
		get
		{
			//IL_001e: Expected O, but got I
			//IL_002e: Expected O, but got I
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+70]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+78]");
			object obj3 = 0 + this;
			object result = obj3 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
			if ((nint)0 >= (nint)0)
			{
				result = obj3;
			}
			return (Action)result;
		}
	}

	public unsafe ref AsyncUniTaskVoid<TStateMachine> NextNode
	{
		get
		{
			//IL_001e: Expected O, but got I
			//IL_002e: Expected O, but got I
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected Ref, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+90]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+98]");
			ref AsyncUniTaskVoid<TStateMachine> reference = ref *(AsyncUniTaskVoid<TStateMachine>*)(0 + this);
			ref AsyncUniTaskVoid<TStateMachine> result = ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref reference, 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
			if ((nint)0 >= (nint)0)
			{
				result = ref reference;
			}
			return ref result;
		}
	}

	public AsyncUniTaskVoid()
	{
		//IL_00d0: Expected O, but got I
		//IL_00e0: Expected O, but got I
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0025: Expected I, but got O
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+8]");
		Action action = new Action(this, (IntPtr)0);
		nint num = 0;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v6 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v3+70]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v3+78]");
		object obj3 = 0 + this;
		object obj4 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v7+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		obj4 = action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r8_v5 (Il2CppClass<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1<TStateMachine>>)+190]");
		Action action2 = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		nint num4 = 0;
		IntPtr intPtr2 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v12+30]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v12+38]");
		object obj7 = 0 + this;
		object obj8 = obj7 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v10+28]");
		if ((nint)0 < (nint)0)
		{
			obj8 = action2;
		}
	}

	public unsafe static void SetStateMachine(ref TStateMachine stateMachine, ref IStateMachineRunner runnerFieldRef)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I
		//IL_003e: Expected O, but got I
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_006f: Expected O, but got I8
		//IL_0099: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_00d2: Expected O, but got Ref
		//IL_0163: Expected O, but got I
		//IL_0191: Expected O, but got I
		//IL_012c: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+50]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
		if ((nint)obj5 <= 0)
		{
			obj4 = 1152921504606846960L;
		}
		object obj6 = obj4 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+28]");
		object obj7 = 0;
		nint num3 = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v20 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+20]");
		object obj8 = 0;
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v127 @ rcx_v10] (should have been resolved before IL gen)");
		object obj10 = default(object);
		object obj13;
		if (obj10 == null)
		{
			nint num5 = 0;
			object obj11 = null;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v48 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+40]");
			object obj12 = 0;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v344 @ rcx_v30] (should have been resolved before IL gen)");
			obj13 = obj11;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+40]");
			obj13 = 0;
		}
		ref IStateMachineRunner reference = ref *(IStateMachineRunner*)obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num8 = 0;
		IntPtr intPtr = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
		object obj14 = (nint)0 + (nint)64;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
	}

	static AsyncUniTaskVoid()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_008d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+58]");
		Type type;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type2 = default(Type);
			type = type2;
		}
		else
		{
			type = null;
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+68]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v16+B8]");
		object obj4 = 0;
		Func<int> getSize = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		TaskPool.RegisterSizeGetter(type, getSize);
	}

	public void Return()
	{
		//IL_001e: Expected O, but got I
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0046: Expected O, but got I
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0064: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_00cf: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_00f4: Expected O, but got I
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
		object obj = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r9_v1+58]");
		object obj2 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ r8_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+50]");
		object obj3 = 0;
		object obj4 = obj2 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r9_v1+50]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v5+28]");
		if ((nint)0 >= (nint)0)
		{
			obj4 = obj2;
		}
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+78]");
			object obj6 = 0;
			object obj7 = obj6;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+20]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+78]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v15+B8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v77 @ rdi_v1 (should have been resolved before IL gen)");
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	private unsafe void Run()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0032: Expected O, but got I
		//IL_004d: Expected O, but got I
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_00b2: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>)+50]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rax_v3+FC]");
		object obj4 = (nint)0 + (nint)16;
		object obj5 = obj4 + 15;
		object obj8 = default(object);
		object obj9;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v11 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoid`1>>)+80]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+50]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+58]");
			obj8 = 0 + this;
			obj9 = obj8 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v12+28]");
			if ((nint)0 < (nint)0)
			{
				goto IL_0107;
			}
		}
		obj9 = obj8;
		goto IL_0107;
		IL_0107:
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
	}

	UniTaskStatus IUniTaskSource.GetStatus(short token)
	{
		return UniTaskStatus.Pending;
	}

	UniTaskStatus IUniTaskSource.UnsafeGetStatus()
	{
		return UniTaskStatus.Pending;
	}

	void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
	{
	}

	void IUniTaskSource.GetResult(short token)
	{
	}
}
