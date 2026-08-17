using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace Cysharp.Threading.Tasks;

public class AsyncUnityEventHandler : IUniTaskSource, IValueTaskSource, IDisposable, IAsyncClickEventHandler
{
	private static Action<object> cancellationCallback;

	private readonly UnityAction action;

	private readonly UnityEvent unityEvent;

	private CancellationToken cancellationToken;

	private CancellationTokenRegistration registration;

	private bool isDisposed;

	private bool callOnce;

	private UniTaskCompletionSourceCore<AsyncUnit> core;

	public AsyncUnityEventHandler(UnityEvent unityEvent, CancellationToken cancellationToken, bool callOnce)
	{
		this.cancellationToken = cancellationToken;
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r8 (System.Threading.CancellationToken)+20]");
			if ((nint)0 >= (nint)2)
			{
				isDisposed = true;
				return;
			}
		}
		UnityAction unityAction = Invoke;
		action = unityAction;
		this.unityEvent = unityEvent;
		this.callOnce = callOnce;
		unityEvent.AddListener(action);
		if ((object)cancellationToken != null)
		{
			registration = (CancellationTokenRegistration)CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, cancellationCallback, this).m_callbackInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rax_v19 (System.Threading.CancellationTokenRegistration)+10]");
			_ = 0;
		}
	}

	public unsafe UniTask OnInvokeAsync()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0031: Expected native int or pointer, but got O
		//IL_003b: Expected native int or pointer, but got O
		//IL_0055: Expected native int or pointer, but got O
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
		((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->Reset();
		if (isDisposed)
		{
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
			bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore2)->TrySetCanceled(cancellationToken);
		}
		UniTask uniTask = default(UniTask);
		((UniTask*)(nint)uniTask)->token = 0;
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, this);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.AsyncUnityEventHandler)+58]");
		((UniTask*)(nint)uniTask)->token = 0;
		return uniTask;
	}

	private unsafe void Invoke()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
		bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetResult(AsyncUnit.Default);
	}

	private static void CancellationCallback(object state)
	{
		//IL_00a3: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		nint num = (nint)typeof(AsyncUnityEventHandler);
		nint num2 = (nint)state;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (Il2CppClass<Cysharp.Threading.Tasks.AsyncUnityEventHandler>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v3 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v2 (Il2CppClass<Cysharp.Threading.Tasks.AsyncUnityEventHandler>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v3 (Il2CppClass<System.Object>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v7+FFFFFFF8+v42 @ rax_v6*8]");
			if (0 == (nint)typeof(AsyncUnityEventHandler))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 66 Invalid \"Jump target not found in method: 0x185D81300\"");
				throw new NullReferenceException();
			}
		}
		throw new InvalidCastException();
	}

	public unsafe void Dispose()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		if (!isDisposed)
		{
			CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 40);
			isDisposed = true;
			((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
			if (this.unityEvent != null)
			{
				UnityAction unityAction = action;
				UnityEvent unityEvent = this.unityEvent;
				MethodInfo methodImpl = ((MulticastDelegate)action).GetMethodImpl();
				((UnityEventBase)unityEvent).m_Calls.RemoveListener(((Delegate)unityAction).m_target, methodImpl);
			}
			UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
			bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
		}
	}

	unsafe UniTask IAsyncClickEventHandler.OnClickAsync()
	{
		//IL_0017: Expected native int or pointer, but got O
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, OnInvokeAsync().source);
		return uniTask;
	}

	unsafe void IUniTaskSource.GetResult(short token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		AsyncUnityEventHandler asyncUnityEventHandler = default(AsyncUnityEventHandler);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(asyncUnityEventHandler + 72);
		AsyncUnit result = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetResult(token);
		if (asyncUnityEventHandler.callOnce)
		{
			asyncUnityEventHandler.Dispose();
		}
	}

	unsafe UniTaskStatus IUniTaskSource.GetStatus(short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetStatus(token);
	}

	unsafe UniTaskStatus IUniTaskSource.UnsafeGetStatus()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
	}

	unsafe void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 72);
		((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
	}

	static AsyncUnityEventHandler()
	{
		Action<object> action = CancellationCallback;
		cancellationCallback = action;
	}
}
public class AsyncUnityEventHandler<T> : IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, IDisposable, IAsyncValueChangedEventHandler<T>, IAsyncEndEditEventHandler<T>, IAsyncEndTextSelectionEventHandler<T>, IAsyncTextSelectionEventHandler<T>, IAsyncDeselectEventHandler<T>, IAsyncSelectEventHandler<T>, IAsyncSubmitEventHandler<T>
{
	private static Action<object> cancellationCallback;

	private readonly UnityAction<T> action;

	private readonly UnityEvent<T> unityEvent;

	private CancellationToken cancellationToken;

	private CancellationTokenRegistration registration;

	private bool isDisposed;

	private bool callOnce;

	private UniTaskCompletionSourceCore<T> core;

	public AsyncUnityEventHandler(UnityEvent<T> unityEvent, CancellationToken cancellationToken, bool callOnce)
	{
		//IL_0063: Expected O, but got I
		//IL_0073: Expected O, but got I
		//IL_008d: Expected O, but got I
		//IL_009d: Expected O, but got I
		//IL_00d5: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_012b: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_0160: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r8 (System.Threading.CancellationToken)+20]");
			if ((nint)0 >= (nint)2)
			{
				_ = 1;
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ stack_28+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v5+C0]");
		object obj2 = 0;
		UnityAction<T> unityAction = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ stack_28+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v7+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002FD0");
		action = unityAction;
		this.unityEvent = unityEvent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ stack_28+20]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v14+C0]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800030A0");
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ stack_28+20]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rax_v22+C0]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v17+30]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v24+B8]");
			object callback = 0;
			_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, (Action<object>)callback, this).m_callbackInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v27 (System.Threading.CancellationTokenRegistration)+10]");
			_ = 0;
		}
	}

	public unsafe UniTask<T> OnInvokeAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_006e: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_0057: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(num + 72);
		((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->Reset();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
		if ((nint)0 != 0)
		{
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<bool>)(num + 72);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore2)->TrySetCanceled((CancellationToken)0);
		}
		_ = 0;
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
		_ = 0;
		_ = 0;
		return (UniTask<T>)this;
	}

	private unsafe void Invoke(T result)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0018: Expected I4, but got O
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 72);
		bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult((byte)(int)result != 0);
	}

	private static void CancellationCallback(object state)
	{
		//IL_003d: Expected I, but got O
		//IL_004d: Expected O, but got I
		//IL_0089: Expected O, but got I
		//IL_00d5: Expected I, but got O
		//IL_00e5: Expected O, but got I
		//IL_0121: Expected O, but got I
		nint num = 0;
		IntPtr intPtr = num;
		if (state != null)
		{
			nint num2 = (nint)state;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v3 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v3 (Il2CppClass<System.Object>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8+FFFFFFF8+v54 @ rcx_v7*8]");
				if ((IntPtr)0 == intPtr)
				{
					nint num4 = 0;
					IntPtr intPtr2 = num4;
					nint num5 = (nint)state;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v16 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v12 (Il2CppClass<System.Object>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v16 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v12 (Il2CppClass<System.Object>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v7+FFFFFFF8+v125 @ rdx_v6*8]");
						if ((IntPtr)0 == intPtr2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1EA0");
							return;
						}
					}
					goto IL_0169;
				}
			}
			goto IL_0162;
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_0169;
		IL_0169:
		InvalidCastException ex2 = new InvalidCastException();
		goto IL_0162;
		IL_0162:
		throw new InvalidCastException();
	}

	public unsafe void Dispose()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00e5: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_00c7: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncUnityEventHandler`1<T>)+40]");
		if ((nint)0 != 0)
		{
			return;
		}
		CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 40);
		_ = 1;
		((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
		if (this.unityEvent != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			MethodInfo methodInfo = default(MethodInfo);
			if ((object)methodInfo != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			UnityEvent<T> unityEvent = this.unityEvent;
			UnityAction<T> unityAction = action;
			MethodInfo methodImpl = ((MulticastDelegate)action).GetMethodImpl();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdi_v4 (UnityEngine.Events.UnityEvent`1<T>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v9 (UnityEngine.Events.UnityAction`1<T>)+20]");
			((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
		}
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 72);
		bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
	}

	UniTask<T> IAsyncValueChangedEventHandler<T>.OnValueChangedAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	UniTask<T> IAsyncEndEditEventHandler<T>.OnEndEditAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	UniTask<T> IAsyncEndTextSelectionEventHandler<T>.OnEndTextSelectionAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	UniTask<T> IAsyncTextSelectionEventHandler<T>.OnTextSelectionAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	UniTask<T> IAsyncDeselectEventHandler<T>.OnDeselectAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	UniTask<T> IAsyncSelectEventHandler<T>.OnSelectAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	UniTask<T> IAsyncSubmitEventHandler<T>.OnSubmitAsync()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r8+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1F80");
		object obj3 = default(object);
		AsyncUnityEventHandler<T> asyncUnityEventHandler = (AsyncUnityEventHandler<T>)obj3;
		return (UniTask<T>)this;
	}

	T IUniTaskSource<T>.GetResult(short token)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 + 8;
		object obj3 = this + 72;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A008C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AsyncUnityEventHandler`1<T>)+41]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D1EA0");
		}
		T result = default(T);
		return result;
	}

	void IUniTaskSource.GetResult(short token)
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
	}

	unsafe UniTaskStatus IUniTaskSource.GetStatus(short token)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 72);
		return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetStatus(token);
	}

	unsafe UniTaskStatus IUniTaskSource.UnsafeGetStatus()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 72);
		return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
	}

	unsafe void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 72);
		((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
	}

	static AsyncUnityEventHandler()
	{
		//IL_003c: Expected O, but got I
		//IL_0051: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>)+C8]");
		Action<object> action = new Action<object>(null, (IntPtr)0);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>)+C8]");
		action._002Ector((object)null, (IntPtr)0);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncUnityEventHandler`1>)+30]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
		object obj2 = 0;
		obj2 = action;
	}
}
