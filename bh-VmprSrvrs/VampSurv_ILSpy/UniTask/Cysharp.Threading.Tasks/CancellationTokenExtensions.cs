using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks;

public static class CancellationTokenExtensions
{
	[StructLayout((LayoutKind)3)]
	private struct _003CToCancellationTokenCore_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public UniTask task;

		public CancellationTokenSource cts;

		private UniTask.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0030: Expected O, but got I4
			//IL_003f: Expected I4, but got I8
			//IL_00b9: Expected O, but got Ref
			//IL_01fa: Expected I, but got O
			//IL_012a: Expected I4, but got I8
			//IL_0135: Expected O, but got Ref
			UniTask.Awaiter awaiter;
			if (_003C_003E1__state == 0)
			{
				awaiter = _003C_003Eu__1;
				_003C_003Eu__1 = (UniTask.Awaiter)0;
				_003C_003E1__state = -1;
			}
			else
			{
				bool flag = (object)task == null;
				awaiter = (UniTask.Awaiter)task;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
					object obj = default(object);
					bool flag2 = obj != null;
					awaiter = (UniTask.Awaiter)task;
					if (!flag2)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = (UniTask.Awaiter)task;
						AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						UniTask.Awaiter awaiter2 = default(UniTask.Awaiter);
						((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
			}
			if ((object)awaiter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
			}
			CancellationTokenSource cancellationTokenSource = cts;
			if (!cancellationTokenSource._disposed)
			{
				cancellationTokenSource.NotifyCancellation(false);
				object obj2 = cts;
				nint num = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v454 @ r8_v7 (Il2CppClass<System.Object>)+188] (should have been resolved before IL gen)");
				GC.SuppressFinalize(obj2);
				_003C_003E1__state = -2;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
			CancellationTokenSource.ThrowObjectDisposedException();
			throw new NullReferenceException();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private static readonly Action<object> cancellationTokenCallback;

	private static readonly Action<object> disposeCallback;

	public unsafe static CancellationToken ToCancellationToken(UniTask task)
	{
		//IL_0048: Expected I4, but got I8
		//IL_0012: Expected O, but got Ref
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource._threadIDExecutingCallbacks = -1;
		cancellationTokenSource._state = 1;
		object obj = default(object);
		UniTaskVoid uniTaskVoid = ToCancellationTokenCore((UniTask)(&obj), cancellationTokenSource);
		return cancellationTokenSource.Token;
	}

	public unsafe static CancellationToken ToCancellationToken(UniTask task, CancellationToken linkToken)
	{
		//IL_01ae: Expected O, but got Ref
		//IL_00b8: Expected O, but got I4
		//IL_014a: Expected O, but got Ref
		//IL_0129: Expected O, but got Ref
		//IL_0129: Expected O, but got Ref
		//IL_016d: Expected O, but got Ref
		if ((object)linkToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [linkToken @ rdx (System.Threading.CancellationToken)+20]");
			if ((nint)0 >= (nint)2)
			{
				return linkToken;
			}
		}
		CancellationTokenSource.LinkedNCancellationTokenSource linkedNCancellationTokenSource2;
		if ((object)linkToken != null)
		{
			CancellationToken[] array = new CancellationToken[1];
			if (array != null)
			{
				bool flag = array.Length == 0;
				if (!flag)
				{
					object obj = array.Length - 1;
					CancellationTokenSource cancellationTokenSource;
					if (!flag)
					{
						if ((nint)obj != 1)
						{
							CancellationTokenSource.LinkedNCancellationTokenSource linkedNCancellationTokenSource = new CancellationTokenSource.LinkedNCancellationTokenSource(array);
							linkedNCancellationTokenSource2 = linkedNCancellationTokenSource;
							goto IL_0160;
						}
						cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource((CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[0]), (CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[1]));
					}
					else
					{
						cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource((CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[0]));
					}
					linkedNCancellationTokenSource2 = (CancellationTokenSource.LinkedNCancellationTokenSource)cancellationTokenSource;
					goto IL_0160;
				}
				object obj2 = new ArgumentException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
				throw obj2;
			}
			goto IL_01e9;
		}
		object obj3 = default(object);
		return ToCancellationToken((UniTask)(&obj3));
		IL_0160:
		UniTaskVoid uniTaskVoid = ToCancellationTokenCore((UniTask)(&obj3), linkedNCancellationTokenSource2);
		if (linkedNCancellationTokenSource2 != null)
		{
			return linkedNCancellationTokenSource2.Token;
		}
		goto IL_01e9;
		IL_01e9:
		return (CancellationToken)new NullReferenceException();
	}

	public unsafe static CancellationToken ToCancellationToken<T>(UniTask<T> task)
	{
		//IL_004c: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v61 @ rcx_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		object obj = default(object);
		return ToCancellationToken((UniTask)(&obj));
	}

	public unsafe static CancellationToken ToCancellationToken<T>(UniTask<T> task, CancellationToken linkToken)
	{
		//IL_0050: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ rcx_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		object obj = default(object);
		return ToCancellationToken((UniTask)(&obj), linkToken);
	}

	private static UniTaskVoid ToCancellationTokenCore(UniTask task, CancellationTokenSource cts)
	{
		//IL_001a: Expected O, but got I4
		_003CToCancellationTokenCore_003Ed__6 obj = default(_003CToCancellationTokenCore_003Ed__6);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}

	public unsafe static (UniTask, CancellationTokenRegistration) ToUniTask(CancellationToken cancellationToken)
	{
		//IL_00ff: Expected O, but got I
		//IL_011d: Expected native int or pointer, but got O
		//IL_004b: Expected O, but got I
		//IL_006e: Expected native int or pointer, but got O
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)0 && (nint)0 >= (nint)2)
		{
			UniTask uniTask = UniTask.FromCanceled((CancellationToken)(nint)intPtr);
			_ = 0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((CancellationToken*)(nint)cancellationToken)->_source, uniTask.source);
			_ = 0;
			_ = 0;
		}
		else
		{
			UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
			if (uniTaskCompletionSource == null)
			{
				return ((UniTask, CancellationTokenRegistration))new NullReferenceException();
			}
			CancellationTokenRegistration cancellationTokenRegistration = RegisterWithoutCaptureExecutionContext((CancellationToken)(nint)intPtr, cancellationTokenCallback, uniTaskCompletionSource);
			_ = 0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((CancellationToken*)(nint)cancellationToken)->_source, uniTaskCompletionSource);
			_ = cancellationTokenRegistration.m_callbackInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v12 (System.Threading.CancellationTokenRegistration)+10]");
			_ = 0;
		}
		return ((UniTask, CancellationTokenRegistration))cancellationToken;
	}

	private static void Callback(object state)
	{
		//IL_00a7: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		nint num = (nint)typeof(UniTaskCompletionSource);
		nint num2 = (nint)state;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskCompletionSource>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskCompletionSource>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<System.Object>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v6+FFFFFFF8+v42 @ rax_v5*8]");
			if (0 == (nint)typeof(UniTaskCompletionSource))
			{
				bool flag = ((UniTaskCompletionSource)state).TrySignalCompletion(UniTaskStatus.Succeeded);
				return;
			}
		}
		throw new InvalidCastException();
	}

	public unsafe static CancellationTokenAwaitable WaitUntilCanceled(CancellationToken cancellationToken)
	{
		//IL_0033: Expected O, but got I
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_00c6: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		if ((nint)0 != 0)
		{
			CancellationTokenAwaitable result = default(CancellationTokenAwaitable);
			object obj = (nint)(&result) >> 12;
			object obj2 = obj & 0x1FFFFF;
			object obj3 = obj2 >> 6;
			object obj4 = obj2 & 0x3F;
			object obj5 = obj3 * 8;
			object obj6 = 6603864928L + obj5;
			do
			{
				object obj7 = 1 << (int)obj4;
				object obj8 = obj6 | obj7;
				if (obj6 == obj6)
				{
					obj6 = obj8;
				}
			}
			while (obj6 != obj6);
			return result;
		}
		return (CancellationTokenAwaitable)cancellationToken;
	}

	public unsafe static CancellationTokenRegistration RegisterWithoutCaptureExecutionContext(CancellationToken cancellationToken, Action callback)
	{
		//IL_00ca: Expected native int or pointer, but got O
		//IL_005f: Expected native int or pointer, but got O
		CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
		System.Runtime.CompilerServices.Unsafe.Write(&((CancellationTokenRegistration*)(nint)cancellationTokenRegistration)->m_callbackInfo, null);
		_ = 0;
		if (!ExecutionContext.IsFlowSuppressed())
		{
			AsyncFlowControl asyncFlowControl = ExecutionContext.SuppressFlow();
		}
		if (callback != null)
		{
			CancellationToken cancellationToken2 = default(CancellationToken);
			bool useSynchronizationContext = default(bool);
			bool useExecutionContext = default(bool);
			System.Runtime.CompilerServices.Unsafe.Write(&((CancellationTokenRegistration*)(nint)cancellationTokenRegistration)->m_callbackInfo, cancellationToken2.Register(CancellationToken.s_actionToActionObjShunt, callback, useSynchronizationContext, useExecutionContext).m_callbackInfo);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v19 (System.Threading.CancellationTokenRegistration)+10]");
			_ = 0;
			object obj = default(object);
			if (obj != null)
			{
				ExecutionContext.RestoreFlow();
			}
			return cancellationTokenRegistration;
		}
		ArgumentNullException ex = new ArgumentNullException("callback");
		throw ex;
	}

	public unsafe static CancellationTokenRegistration RegisterWithoutCaptureExecutionContext(CancellationToken cancellationToken, Action<object> callback, object state)
	{
		//IL_00a6: Expected native int or pointer, but got O
		//IL_005e: Expected native int or pointer, but got O
		CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
		System.Runtime.CompilerServices.Unsafe.Write(&((CancellationTokenRegistration*)(nint)cancellationTokenRegistration)->m_callbackInfo, null);
		_ = 0;
		if (!ExecutionContext.IsFlowSuppressed())
		{
			AsyncFlowControl asyncFlowControl = ExecutionContext.SuppressFlow();
		}
		CancellationToken cancellationToken2 = default(CancellationToken);
		bool useSynchronizationContext = default(bool);
		bool useExecutionContext = default(bool);
		System.Runtime.CompilerServices.Unsafe.Write(&((CancellationTokenRegistration*)(nint)cancellationTokenRegistration)->m_callbackInfo, cancellationToken2.Register(callback, state, useSynchronizationContext, useExecutionContext).m_callbackInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v10 (System.Threading.CancellationTokenRegistration)+10]");
		_ = 0;
		object obj = default(object);
		if (obj != null)
		{
			ExecutionContext.RestoreFlow();
		}
		return cancellationTokenRegistration;
	}

	public unsafe static CancellationTokenRegistration AddTo(IDisposable disposable, CancellationToken cancellationToken)
	{
		//IL_002d: Expected native int or pointer, but got O
		CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
		System.Runtime.CompilerServices.Unsafe.Write(&((CancellationTokenRegistration*)(nint)cancellationTokenRegistration)->m_callbackInfo, RegisterWithoutCaptureExecutionContext(cancellationToken, disposeCallback, disposable).m_callbackInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v5 (System.Threading.CancellationTokenRegistration)+10]");
		_ = 0;
		return cancellationTokenRegistration;
	}

	private static void DisposeCallback(object state)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	static CancellationTokenExtensions()
	{
		Action<object> action = Callback;
		cancellationTokenCallback = action;
		Action<object> action2 = DisposeCallback;
		disposeCallback = action2;
	}
}
