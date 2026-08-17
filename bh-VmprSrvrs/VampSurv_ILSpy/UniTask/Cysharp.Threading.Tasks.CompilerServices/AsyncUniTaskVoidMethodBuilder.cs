using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.CompilerServices;

[StructLayout((LayoutKind)3)]
public struct AsyncUniTaskVoidMethodBuilder
{
	private IStateMachineRunner runner;

	public UniTaskVoid Task
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			//IL_0006: Expected O, but got I4
			return (UniTaskVoid)0;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public static AsyncUniTaskVoidMethodBuilder Create()
	{
		//IL_0006: Expected O, but got I4
		return (AsyncUniTaskVoidMethodBuilder)0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetException(Exception exception)
	{
		if (runner != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Action continuation = default(Action);
			PlayerLoopHelper.AddContinuation(PlayerLoopTiming.LastPostLateUpdate, continuation);
			runner = null;
		}
		UniTaskScheduler.PublishUnobservedTaskException(exception);
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetResult()
	{
		if (runner != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Action continuation = default(Action);
			PlayerLoopHelper.AddContinuation(PlayerLoopTiming.LastPostLateUpdate, continuation);
			runner = null;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
	{
		//IL_0008: Expected O, but got Ref
		//IL_0065: Expected O, but got I
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r9_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v4 (Il2CppClass<TAwaiter>)+FC]");
		object obj3 = (nint)0 + (nint)16;
		object obj4 = obj3 + 15;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			if (runner != null)
			{
				goto IL_00a9;
			}
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ r9_v4 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		goto IL_00a9;
		IL_00a9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
	}

	[MethodImpl((MethodImplOptions)256)]
	public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		if (runner == null)
		{
			AsyncUniTaskVoid<UnityBindingExtensions._003CBindToCore_003Ed__2>.SetStateMachine(ref System.Runtime.CompilerServices.Unsafe.As<TStateMachine, UnityBindingExtensions._003CBindToCore_003Ed__2>(ref stateMachine), ref System.Runtime.CompilerServices.Unsafe.As<AsyncUniTaskVoidMethodBuilder, IStateMachineRunner>(ref this));
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Action continuation = default(Action);
		System.Runtime.CompilerServices.Unsafe.As<TAwaiter, UniTask<bool>.Awaiter>(ref awaiter).UnsafeOnCompleted(continuation);
	}

	public unsafe void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
	{
		//IL_0008: Expected O, but got Ref
		//IL_0042: Expected O, but got I
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppClass<TStateMachine>)+FC]");
		object obj3 = (nint)0 + (nint)16;
		object obj4 = obj3 + 15;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			nint num2 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
	}

	public void SetStateMachine(IAsyncStateMachine stateMachine)
	{
	}
}
