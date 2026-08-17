using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.CompilerServices;

[StructLayout((LayoutKind)3)]
public struct AsyncUniTaskMethodBuilder
{
	private IStateMachineRunnerPromise runnerPromise;

	private Exception ex;

	public unsafe UniTask Task
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			//IL_0052: Expected native int or pointer, but got O
			//IL_00c3: Expected native int or pointer, but got O
			UniTask uniTask = default(UniTask);
			UniTask uniTask2 = default(UniTask);
			if (runnerPromise == null)
			{
				if (ex == null)
				{
					System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, (IUniTaskSource)UniTask.CompletedTask);
					return uniTask;
				}
				uniTask2 = UniTask.FromException(ex);
			}
			else
			{
				if (runnerPromise == null)
				{
					return (UniTask)new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
			}
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTask2.source);
			return uniTask;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe static AsyncUniTaskMethodBuilder Create()
	{
		//IL_0005: Expected native int or pointer, but got O
		AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder = default(AsyncUniTaskMethodBuilder);
		System.Runtime.CompilerServices.Unsafe.Write(&((AsyncUniTaskMethodBuilder*)(nint)asyncUniTaskMethodBuilder)->runnerPromise, null);
		return asyncUniTaskMethodBuilder;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetException(Exception exception)
	{
		if (runnerPromise != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
		}
		else
		{
			ex = exception;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetResult()
	{
		if (runnerPromise != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
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
			if (runnerPromise != null)
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
		if (runnerPromise == null)
		{
			AsyncUniTask<UniTaskExtensions._003CTimeout_003Ed__12>.SetStateMachine(ref System.Runtime.CompilerServices.Unsafe.As<TStateMachine, UniTaskExtensions._003CTimeout_003Ed__12>(ref stateMachine), ref System.Runtime.CompilerServices.Unsafe.As<AsyncUniTaskMethodBuilder, IStateMachineRunnerPromise>(ref this));
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Action continuation = default(Action);
		System.Runtime.CompilerServices.Unsafe.As<TAwaiter, UniTask<(int, bool, bool)>.Awaiter>(ref awaiter).UnsafeOnCompleted(continuation);
	}

	[MethodImpl((MethodImplOptions)256)]
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
[StructLayout((LayoutKind)3)]
public struct AsyncUniTaskMethodBuilder<T>
{
	private IStateMachineRunnerPromise<T> runnerPromise;

	private Exception ex;

	private T result;

	public unsafe UniTask<T> Task
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			//IL_00e9: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_0042: Expected O, but got I
			//IL_0160: Expected O, but got Ref
			//IL_0151: Expected O, but got I4
			//IL_0057: Expected O, but got I
			//IL_0067: Expected O, but got I
			IntPtr intPtr = default(IntPtr);
			object obj4;
			if (intPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+20]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v22+C0]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v23+30]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v14+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1831F0DB0");
				}
				obj4 = 0;
			}
			else
			{
				if (intPtr == (IntPtr)0)
				{
					return (UniTask<T>)new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v6+C0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
				object obj7 = default(object);
				obj4 = obj7;
			}
			AsyncUniTaskMethodBuilder<T> asyncUniTaskMethodBuilder = (AsyncUniTaskMethodBuilder<T>)obj4;
			return (UniTask<T>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public static AsyncUniTaskMethodBuilder<T> Create()
	{
		//IL_0014: Expected O, but got I
		nint num = 0;
		_ = 0;
		return (AsyncUniTaskMethodBuilder<T>)num;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void SetException(Exception exception)
	{
		if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void SetResult(T result)
	{
		if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
		}
		else
		{
			runnerPromise = (IStateMachineRunnerPromise<T>)result;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
	{
		//IL_0008: Expected O, but got Ref
		//IL_003d: Expected O, but got I
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0080: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_00a2: Expected O, but got Ref
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0195: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_01b7: Expected O, but got Ref
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_0115: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_0137: Expected O, but got Ref
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v4 (Il2CppClass<TAwaiter>)+FC]");
		object obj3 = (nint)0 + (nint)16;
		object obj4 = obj3 + 15;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		}
		nint num2 = 0;
		IntPtr intPtr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder`1>>)+80]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v1+10]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v1+18]");
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
		object obj8 = obj7 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v14+28]");
		if ((nint)0 >= (nint)0)
		{
			obj8 = obj7;
		}
		if (obj8 == null)
		{
			nint num3 = 0;
			nint num4 = 0;
			IntPtr intPtr2 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v30 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder`1>>)+80]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v7+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v7+18]");
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			object obj12 = obj11 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v43+28]");
			if ((nint)0 >= (nint)0)
			{
				obj12 = obj11;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ rcx_v28 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		}
		nint num5 = 0;
		IntPtr intPtr3 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v10 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder`1>>)+80]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v3+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v3+18]");
		object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
		object obj16 = obj15 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v19+28]");
		if ((nint)0 >= (nint)0)
		{
			obj16 = obj15;
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
	{
		if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == null)
		{
			AsyncUniTask<UniTaskExtensions._003CTimeoutWithoutException_003Ed__14, bool>.SetStateMachine(ref System.Runtime.CompilerServices.Unsafe.As<TStateMachine, UniTaskExtensions._003CTimeoutWithoutException_003Ed__14>(ref stateMachine), ref System.Runtime.CompilerServices.Unsafe.As<AsyncUniTaskMethodBuilder<T>, IStateMachineRunnerPromise<bool>>(ref this));
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Action continuation = default(Action);
		System.Runtime.CompilerServices.Unsafe.As<TAwaiter, UniTask<(int, bool, bool)>.Awaiter>(ref awaiter).UnsafeOnCompleted(continuation);
	}

	[MethodImpl((MethodImplOptions)256)]
	public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
	{
		System.Runtime.CompilerServices.Unsafe.As<TStateMachine, UniTaskExtensions._003CTimeoutWithoutException_003Ed__14>(ref stateMachine).MoveNext();
	}

	public void SetStateMachine(IAsyncStateMachine stateMachine)
	{
	}
}
