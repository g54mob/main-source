using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using Unity.IL2CPP.Metadata;

namespace Cysharp.Threading.Tasks.CompilerServices;

internal sealed class AsyncUniTask<TStateMachine> : IStateMachineRunnerPromise, IUniTaskSource, IValueTaskSource, ITaskPoolNode<AsyncUniTask<TStateMachine>> where TStateMachine : IAsyncStateMachine
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1+<>c>)+8]");
			object obj2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1+<>c>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
			object obj4 = 0;
			obj4 = obj;
		}

		internal int _003C_002Ecctor_003Eb__12_0()
		{
			//IL_0020: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_004e: Expected O, but got I
			//IL_0063: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1+<>c>)+30]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1+<>c>)+28]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1+<>c>)+30]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v9+B8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ rdi_v1 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: rcx)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private static TaskPool<AsyncUniTask<TStateMachine>> pool;

	private readonly Action returnDelegate;

	private readonly Action _003CMoveNext_003Ek__BackingField;

	private TStateMachine stateMachine;

	private UniTaskCompletionSourceCore<AsyncUnit> core;

	private AsyncUniTask<TStateMachine> nextNode;

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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+50]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+58]");
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

	public unsafe ref AsyncUniTask<TStateMachine> NextNode
	{
		get
		{
			//IL_001e: Expected O, but got I
			//IL_002e: Expected O, but got I
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected Ref, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+B0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+B8]");
			ref AsyncUniTask<TStateMachine> reference = ref *(AsyncUniTask<TStateMachine>*)(0 + this);
			ref AsyncUniTask<TStateMachine> result = ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref reference, 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
			if ((nint)0 >= (nint)0)
			{
				result = ref reference;
			}
			return ref result;
		}
	}

	public unsafe UniTask Task
	{
		get
		{
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_00a8: Expected native int or pointer, but got O
			//IL_00b2: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1+90]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1+98]");
			object obj3 = 0 + this;
			object obj4 = obj3 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
				obj4 = obj3;
			}
			UniTask uniTask = default(UniTask);
			((UniTask*)(nint)uniTask)->token = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, this);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v3+10]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
	}

	private AsyncUniTask()
	{
		//IL_00d1: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0045: Expected O, but got I
		//IL_0055: Expected O, but got I
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+8]");
		Action action = new Action(this, (IntPtr)0);
		nint num = 0;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v6 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v3+50]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v3+58]");
		object obj3 = 0 + this;
		object obj4 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v7+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		obj4 = action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+10]");
		Action action2 = new Action(this, (IntPtr)0);
		nint num3 = 0;
		nint num4 = 0;
		IntPtr intPtr2 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v7+30]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v7+38]");
		object obj7 = 0 + this;
		object obj8 = obj7 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v14+28]");
		if ((nint)0 < (nint)0)
		{
			obj8 = action2;
		}
	}

	public unsafe static void SetStateMachine(ref TStateMachine stateMachine, ref IStateMachineRunnerPromise runnerPromiseFieldRef)
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+50]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+28]");
		object obj7 = 0;
		nint num3 = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v20 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+20]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v48 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+40]");
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
		ref IStateMachineRunnerPromise reference = ref *(IStateMachineRunnerPromise*)obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num8 = 0;
		IntPtr intPtr = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj14 = (nint)0 + (nint)96;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
	}

	static AsyncUniTask()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_008d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+58]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+68]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v16+B8]");
		object obj4 = 0;
		Func<int> getSize = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		TaskPool.RegisterSizeGetter(type, getSize);
	}

	private unsafe void Return()
	{
		//IL_009d: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0146: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_003a: Expected O, but got I
		//IL_0058: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_007d: Expected O, but got I
		while (true)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+50]");
			object obj = 0;
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3+98]");
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v6+28]");
			if ((nint)0 >= (nint)0)
			{
				uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
			}
			((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->Reset();
			nint num3 = 0;
			IntPtr intPtr2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v9 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v7+70]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v7+78]");
			object obj6 = 0 + this;
			object obj7 = obj6 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj7 = obj6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v13 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+78]");
			object obj8 = 0;
			object obj9 = obj8;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+20]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+78]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v20+B8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v122 @ rbx_v2 (should have been resolved before IL gen)");
		}
	}

	private unsafe bool TryReturn()
	{
		//IL_009d: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0146: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_003a: Expected O, but got I
		//IL_0058: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_007d: Expected O, but got I
		while (true)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+50]");
			object obj = 0;
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3+98]");
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v6+28]");
			if ((nint)0 >= (nint)0)
			{
				uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
			}
			((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->Reset();
			nint num3 = 0;
			IntPtr intPtr2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v9 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v7+70]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v7+78]");
			object obj6 = 0 + this;
			object obj7 = obj6 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj7 = obj6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v13 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+78]");
			object obj8 = 0;
			object obj9 = obj8;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+20]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+78]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v20+B8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v122 @ rbx_v2 (should have been resolved before IL gen)");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>)+50]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v11 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+70]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+78]");
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

	public unsafe void SetResult()
	{
		//IL_0048: Expected O, but got I
		//IL_0058: Expected O, but got I
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+90]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+98]");
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v5+28]");
		if ((nint)0 >= (nint)0)
		{
			uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
		}
		bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->TrySetResult(AsyncUnit.Default);
	}

	public unsafe void SetException(Exception exception)
	{
		//IL_0030: Expected O, but got I
		//IL_0040: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1+90]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1+98]");
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
		}
		bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->TrySetException(exception);
	}

	public unsafe void GetResult(short token)
	{
		//IL_00ff: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_014c: Expected O, but got I
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01af: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ stack_18_v2+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2+C0]");
		object obj2 = 0;
		object obj3 = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v3+80]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v1+98]");
		object obj5 = default(object);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + obj5);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v1+90]");
		object obj6 = 0;
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v6+28]");
		if ((nint)0 >= (nint)0)
		{
			uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
		}
		AsyncUnit result = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->GetResult(token);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore3 = default(UniTaskCompletionSourceCore<AsyncUnit>);
		AsyncUnit result2 = uniTaskCompletionSourceCore3.GetResult(token);
		object obj7 = 0;
	}

	public unsafe UniTaskStatus GetStatus(short token)
	{
		//IL_0030: Expected O, but got I
		//IL_0040: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v3 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v2+90]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v2+98]");
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
		}
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->GetStatus(token);
	}

	public unsafe UniTaskStatus UnsafeGetStatus()
	{
		//IL_0030: Expected O, but got I
		//IL_0040: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2+90]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2+98]");
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
		}
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->UnsafeGetStatus();
	}

	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_0022: Expected O, but got I
		//IL_0032: Expected O, but got I
		//IL_004a: Expected O, but got I
		//IL_005a: Expected O, but got I
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_28+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v1+C0]");
		object obj2 = 0;
		object obj3 = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v1+80]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v2+90]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v2+98]");
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(0 + this);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(uniTaskCompletionSourceCore - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			uniTaskCompletionSourceCore2 = uniTaskCompletionSourceCore;
		}
		((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->OnCompleted(continuation, state, token);
	}
}
internal sealed class AsyncUniTask<TStateMachine, T> : IStateMachineRunnerPromise<T>, IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, ITaskPoolNode<AsyncUniTask<TStateMachine, T>> where TStateMachine : IAsyncStateMachine
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2+<>c>)+8]");
			object obj2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2+<>c>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
			object obj4 = 0;
			obj4 = obj;
		}

		internal int _003C_002Ecctor_003Eb__12_0()
		{
			//IL_0020: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_004e: Expected O, but got I
			//IL_0063: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2+<>c>)+30]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2+<>c>)+28]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2+<>c>)+30]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v9+B8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ rdi_v1 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: rcx)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private static TaskPool<AsyncUniTask<TStateMachine, T>> pool;

	private readonly Action returnDelegate;

	private readonly Action _003CMoveNext_003Ek__BackingField;

	private TStateMachine stateMachine;

	private UniTaskCompletionSourceCore<T> core;

	private AsyncUniTask<TStateMachine, T> nextNode;

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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+50]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+58]");
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

	public unsafe ref AsyncUniTask<TStateMachine, T> NextNode
	{
		get
		{
			//IL_001e: Expected O, but got I
			//IL_002e: Expected O, but got I
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected Ref, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+B0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+B8]");
			ref AsyncUniTask<TStateMachine, T> reference = ref *(AsyncUniTask<TStateMachine, T>*)(0 + this);
			ref AsyncUniTask<TStateMachine, T> result = ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref reference, 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
			if ((nint)0 >= (nint)0)
			{
				result = ref reference;
			}
			return ref result;
		}
	}

	public unsafe UniTask<T> Task
	{
		get
		{
			//IL_0008: Expected O, but got Ref
			//IL_0018: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_004c: Expected O, but got I
			//IL_0062: Expected O, but got I
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			//IL_00d2: Expected O, but got I
			//IL_00e2: Expected O, but got I
			//IL_00f2: Expected O, but got I
			//IL_0102: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_012a: Expected O, but got I
			//IL_013a: Expected O, but got I
			//IL_014a: Expected O, but got I
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Expected O, but got Unknown
			//IL_016c: Expected O, but got I
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected O, but got Unknown
			//IL_01c3: Expected O, but got I
			//IL_01d3: Expected O, but got I
			//IL_0093: Expected O, but got I8
			UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> uniTask = default(UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>);
			object obj = (object)(&uniTask);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v1+C0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r9_v1+B0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
			object obj5 = (nint)0 + (nint)15;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
			if ((nint)obj6 <= 0)
			{
				obj5 = 1152921504606846960L;
			}
			object obj7 = obj5 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v5+C0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v1+A8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v7+C0]");
			object obj12 = 0;
			object obj13 = obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v8+80]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v9+C0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v1+98]");
			object obj17 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v1+90]");
			object obj18 = 0;
			object obj19 = obj17 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj19 = obj17;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ rax_v6] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7+C0]");
			object obj21 = 0;
			short token = default(short);
			uniTask = new UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>((IUniTaskSource<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)(object)this, token);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			UniTask<T> result = default(UniTask<T>);
			return result;
		}
	}

	private AsyncUniTask()
	{
		//IL_00d1: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0045: Expected O, but got I
		//IL_0055: Expected O, but got I
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+8]");
		Action action = new Action(this, (IntPtr)0);
		nint num = 0;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v6 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v3+50]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v3+58]");
		object obj3 = 0 + this;
		object obj4 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v7+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		obj4 = action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+10]");
		Action action2 = new Action(this, (IntPtr)0);
		nint num3 = 0;
		nint num4 = 0;
		IntPtr intPtr2 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v13 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v7+30]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v7+38]");
		object obj7 = 0 + this;
		object obj8 = obj7 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v14+28]");
		if ((nint)0 < (nint)0)
		{
			obj8 = action2;
		}
	}

	public unsafe static void SetStateMachine(ref TStateMachine stateMachine, ref IStateMachineRunnerPromise<T> runnerPromiseFieldRef)
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+58]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+28]");
		object obj7 = 0;
		nint num3 = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v20 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+20]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v48 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+40]");
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
		ref IStateMachineRunnerPromise<T> reference = ref *(IStateMachineRunnerPromise<T>*)obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num8 = 0;
		IntPtr intPtr = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj14 = (nint)0 + (nint)96;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
	}

	static AsyncUniTask()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_008d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+60]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+70]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v16+B8]");
		object obj4 = 0;
		Func<int> getSize = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		TaskPool.RegisterSizeGetter(type, getSize);
	}

	private void Return()
	{
		//IL_0016: Expected O, but got I
		//IL_0034: Expected O, but got I
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_005c: Expected O, but got I
		//IL_006c: Expected O, but got I
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0149: Expected O, but got I
		//IL_0159: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_0117: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+58]");
		object obj = 0;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9_v1+98]");
		object obj3 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9_v1+90]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+88]");
		object obj5 = 0;
		object obj6 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v6+28]");
		if ((nint)0 >= (nint)0)
		{
			obj6 = obj3;
		}
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ r10_v1] (should have been resolved before IL gen)");
			nint num4 = 0;
			IntPtr intPtr2 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v9 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4+70]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4+78]");
			object obj9 = 0 + this;
			object obj10 = obj9 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj10 = obj9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+98]");
			object obj11 = 0;
			object obj12 = obj11;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+20]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+98]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v20+B8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v105 @ rbx_v2 (should have been resolved before IL gen)");
		}
	}

	private bool TryReturn()
	{
		//IL_0016: Expected O, but got I
		//IL_0034: Expected O, but got I
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_005c: Expected O, but got I
		//IL_006c: Expected O, but got I
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0149: Expected O, but got I
		//IL_0159: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_0117: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+58]");
		object obj = 0;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9_v1+98]");
		object obj3 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9_v1+90]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+88]");
		object obj5 = 0;
		object obj6 = obj3 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v6+28]");
		if ((nint)0 >= (nint)0)
		{
			obj6 = obj3;
		}
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ r10_v1] (should have been resolved before IL gen)");
			nint num4 = 0;
			IntPtr intPtr2 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v9 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4+70]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4+78]");
			object obj9 = 0 + this;
			object obj10 = obj9 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj10 = obj9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+98]");
			object obj11 = 0;
			object obj12 = obj11;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+20]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+98]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v20+B8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v105 @ rbx_v2 (should have been resolved before IL gen)");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+58]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v11 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+70]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v4+78]");
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

	public unsafe void SetResult(T result)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I
		//IL_003e: Expected O, but got I
		//IL_009c: Expected O, but got Ref
		//IL_00a4: Expected O, but got Ref
		//IL_00ba: Expected O, but got I
		//IL_00d0: Expected O, but got I
		//IL_010d: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_013d: Expected O, but got Ref
		//IL_016e: Expected O, but got I
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0196: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01e7: Expected O, but got Ref
		//IL_01fd: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+C8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
		object obj5 = default(object);
		T val;
		if ((nint)obj4 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			obj5 = (object)(&obj2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v8+28]");
			object obj7 = (nint)0 >> 31;
			if (obj7 == null)
			{
				goto IL_00ed;
			}
		}
		val = result;
		goto IL_00ed;
		IL_00ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+C8]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v11+28]");
		object obj9 = (nint)0 >> 31;
		bool flag = obj9 != null;
		object obj10 = (object)(&obj2);
		if (!flag)
		{
			obj10 = obj5;
		}
		nint num4 = 0;
		IntPtr intPtr = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v13 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj11 = 0;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v3+98]");
		object obj12 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v3+90]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+D0]");
		object obj14 = 0;
		object obj15 = obj12 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v15+28]");
		if ((nint)0 >= (nint)0)
		{
			obj15 = obj12;
		}
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+D0]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v93 @ r10_v1+10] (should have been resolved before IL gen)");
	}

	public void SetException(Exception exception)
	{
		//IL_001e: Expected O, but got I
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0046: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r9_v2+98]");
		object obj2 = 0 + this;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r9_v2+90]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+D8]");
		object obj4 = 0;
		object obj5 = obj2 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			obj5 = obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ r11_v1] (should have been resolved before IL gen)");
	}

	public unsafe T GetResult(short token)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0061: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00a7: Expected O, but got I
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02ce: Expected O, but got I
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_0100: Expected O, but got Ref
		//IL_0113: Expected O, but got Ref
		//IL_013b: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_0173: Expected O, but got I
		//IL_0190: Expected O, but got I
		//IL_01a0: Expected O, but got I
		//IL_01b0: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_01d3: Expected O, but got Ref
		//IL_01ed: Expected O, but got I
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_001a: Expected O, but got I8
		//IL_022e: Expected O, but got Ref
		//IL_0250: Expected O, but got Ref
		//IL_002c: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r9_v1+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v2+C8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		object obj6 = (nint)0 + (nint)15;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		if ((nint)obj10 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj11 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A8]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v3+20]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v11+C0]");
		object obj16 = 0;
		object obj17 = obj16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v12+80]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v2+98]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+90]");
		object obj19 = num + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v3+20]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v13+C0]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v11+E0]");
		object obj22 = 0;
		object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v2+90]");
		object obj24 = 0;
		object obj25 = obj19 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v15+28]");
		if ((nint)0 >= (nint)0)
		{
			obj25 = obj19;
		}
		object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ r11_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844A1F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+30]");
		if ((nint)0 != 0)
		{
			throw null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		T result = default(T);
		return result;
	}

	unsafe void IUniTaskSource.GetResult(short token)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I
		//IL_003e: Expected O, but got I
		//IL_0080: Expected O, but got Ref
		//IL_009d: Expected O, but got I
		//IL_00b3: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+C8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
		if ((nint)obj4 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		nint num2 = 0;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		obj = obj5;
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+E8]");
		object obj6 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+E8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ r10_v1+10] (should have been resolved before IL gen)");
	}

	public UniTaskStatus GetStatus(short token)
	{
		//IL_0016: Expected O, but got I
		//IL_003c: Expected O, but got I
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0064: Expected O, but got I
		//IL_0074: Expected O, but got I
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+F0]");
		object obj = 0;
		object obj2 = obj;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9_v3+98]");
		object obj4 = 0 + this;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9_v3+90]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+F0]");
		object obj6 = 0;
		object obj7 = obj4 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ r11_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public UniTaskStatus UnsafeGetStatus()
	{
		//IL_0016: Expected O, but got I
		//IL_003c: Expected O, but got I
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0064: Expected O, but got I
		//IL_0074: Expected O, but got I
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+F8]");
		object obj = 0;
		object obj2 = obj;
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>>)+80]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8_v3+98]");
		object obj4 = 0 + this;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8_v3+90]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask`2>)+F8]");
		object obj6 = 0;
		object obj7 = obj4 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		//IL_0038: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_006a: Expected O, but got I
		//IL_007a: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+C0]");
		object obj2 = 0;
		object obj3 = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v2+80]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+20]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r10_v2+98]");
		object obj6 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v3+C0]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r10_v2+90]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rcx_v1+100]");
		object obj9 = 0;
		object obj10 = obj6 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		object obj11 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v40 @ rax_v6 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}
}
