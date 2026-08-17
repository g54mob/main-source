using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ParticleSystemJobs;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncTriggerHandler<T> : IAsyncOneShotTrigger, IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, ITriggerHandler<T>, IDisposable, IAsyncFixedUpdateHandler, IAsyncLateUpdateHandler, IAsyncOnAnimatorIKHandler, IAsyncOnAnimatorMoveHandler, IAsyncOnApplicationFocusHandler, IAsyncOnApplicationPauseHandler, IAsyncOnApplicationQuitHandler, IAsyncOnAudioFilterReadHandler, IAsyncOnBecameInvisibleHandler, IAsyncOnBecameVisibleHandler, IAsyncOnBeforeTransformParentChangedHandler, IAsyncOnCanvasGroupChangedHandler, IAsyncOnCollisionEnterHandler, IAsyncOnCollisionEnter2DHandler, IAsyncOnCollisionExitHandler, IAsyncOnCollisionExit2DHandler, IAsyncOnCollisionStayHandler, IAsyncOnCollisionStay2DHandler, IAsyncOnControllerColliderHitHandler, IAsyncOnDisableHandler, IAsyncOnDrawGizmosHandler, IAsyncOnDrawGizmosSelectedHandler, IAsyncOnEnableHandler, IAsyncOnGUIHandler, IAsyncOnJointBreakHandler, IAsyncOnJointBreak2DHandler, IAsyncOnMouseDownHandler, IAsyncOnMouseDragHandler, IAsyncOnMouseEnterHandler, IAsyncOnMouseExitHandler, IAsyncOnMouseOverHandler, IAsyncOnMouseUpHandler, IAsyncOnMouseUpAsButtonHandler, IAsyncOnParticleCollisionHandler, IAsyncOnParticleSystemStoppedHandler, IAsyncOnParticleTriggerHandler, IAsyncOnParticleUpdateJobScheduledHandler, IAsyncOnPostRenderHandler, IAsyncOnPreCullHandler, IAsyncOnPreRenderHandler, IAsyncOnRectTransformDimensionsChangeHandler, IAsyncOnRectTransformRemovedHandler, IAsyncOnRenderImageHandler, IAsyncOnRenderObjectHandler, IAsyncOnServerInitializedHandler, IAsyncOnTransformChildrenChangedHandler, IAsyncOnTransformParentChangedHandler, IAsyncOnTriggerEnterHandler, IAsyncOnTriggerEnter2DHandler, IAsyncOnTriggerExitHandler, IAsyncOnTriggerExit2DHandler, IAsyncOnTriggerStayHandler, IAsyncOnTriggerStay2DHandler, IAsyncOnValidateHandler, IAsyncOnWillRenderObjectHandler, IAsyncResetHandler, IAsyncUpdateHandler, IAsyncOnBeginDragHandler, IAsyncOnCancelHandler, IAsyncOnDeselectHandler, IAsyncOnDragHandler, IAsyncOnDropHandler, IAsyncOnEndDragHandler, IAsyncOnInitializePotentialDragHandler, IAsyncOnMoveHandler, IAsyncOnPointerClickHandler, IAsyncOnPointerDownHandler, IAsyncOnPointerEnterHandler, IAsyncOnPointerExitHandler, IAsyncOnPointerUpHandler, IAsyncOnScrollHandler, IAsyncOnSelectHandler, IAsyncOnSubmitHandler, IAsyncOnUpdateSelectedHandler
{
	private static Action<object> cancellationCallback;

	private readonly AsyncTriggerBase<T> trigger;

	private CancellationToken cancellationToken;

	private CancellationTokenRegistration registration;

	private bool isDisposed;

	private bool callOnce;

	private UniTaskCompletionSourceCore<T> core;

	private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

	private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

	internal CancellationToken CancellationToken
	{
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+18]");
			return (CancellationToken)0;
		}
	}

	ITriggerHandler<T> ITriggerHandler<T>.Prev
	{
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+70]");
			return (ITriggerHandler<T>)0;
		}
		set
		{
		}
	}

	ITriggerHandler<T> ITriggerHandler<T>.Next
	{
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+78]");
			return (ITriggerHandler<T>)0;
		}
		set
		{
		}
	}

	unsafe UniTask IAsyncOneShotTrigger.OneShotAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_001e: Expected native int or pointer, but got O
		//IL_0028: Expected native int or pointer, but got O
		//IL_0042: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		((UniTask*)(nint)uniTask)->token = 0;
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, this);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
		((UniTask*)(nint)uniTask)->token = 0;
		return uniTask;
	}

	internal AsyncTriggerHandler(AsyncTriggerBase<T> trigger, bool callOnce)
	{
		//IL_003a: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v16+20]");
			if ((nint)0 >= (nint)2)
			{
				_ = 1;
				return;
			}
		}
		this.trigger = trigger;
		_ = 0;
		_ = 0;
		_ = 0;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0400");
	}

	internal AsyncTriggerHandler(AsyncTriggerBase<T> trigger, CancellationToken cancellationToken, bool callOnce)
	{
		//IL_0077: Expected O, but got I
		//IL_0087: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_00dd: Expected O, but got I
		//IL_00ed: Expected O, but got I
		//IL_0102: Expected O, but got I
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ r8 (System.Threading.CancellationToken)+20]");
			if ((nint)0 >= (nint)2)
			{
				_ = 1;
				return;
			}
		}
		this.trigger = trigger;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ stack_28+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v8+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0400");
		if ((object)cancellationToken != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ stack_28+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rax_v16+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rcx_v11+40]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v18+B8]");
			object callback = 0;
			_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, (Action<object>)callback, this).m_callbackInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v21 (System.Threading.CancellationTokenRegistration)+10]");
			_ = 0;
		}
	}

	private unsafe static void CancellationCallback(object state)
	{
		//IL_0079: Expected O, but got I
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_013a: Expected O, but got I
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f3: Expected O, but got I
		//IL_0103: Expected O, but got I
		nint num = 0;
		if (state == null)
		{
			goto IL_013f;
		}
		bool flag = (nint)state != num;
		object obj = null;
		if (!flag)
		{
			obj = state;
		}
		if (obj != null)
		{
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1>)+48]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v4 (System.Object)+38]");
			if ((nint)0 == 0)
			{
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(obj + 32);
				_ = 1;
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v4 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					goto IL_013f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v4+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v18+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0520");
			}
			UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(obj + 64);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v4 (System.Object)+18]");
			bool flag2 = ((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
			return;
		}
		goto IL_016b;
		IL_013f:
		NullReferenceException ex = new NullReferenceException();
		goto IL_016b;
		IL_016b:
		throw new InvalidCastException();
	}

	public unsafe void Dispose()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+38]");
		if ((nint)0 == 0)
		{
			_ = 1;
			CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 32);
			((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0520");
		}
	}

	T IUniTaskSource<T>.GetResult(short token)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0025: Expected O, but got I4
		//IL_0035: Expected O, but got I
		//IL_0045: Expected O, but got I
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_007d: Expected O, but got I4
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		object obj2 = default(object);
		object obj = obj2 + 16;
		object obj3 = token + 64;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r9+20]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rcx_v1+C0]");
		object obj5 = 0;
		object obj6 = obj2 - 48;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF7880");
		asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18446B620");
		object obj7 = 0;
		return (T)this;
	}

	void ITriggerHandler<T>.OnNext(T value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		object obj = this + 64;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180704600");
	}

	unsafe void ITriggerHandler<T>.OnCanceled(CancellationToken cancellationToken)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		bool flag = ((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
	}

	unsafe void ITriggerHandler<T>.OnCompleted()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_001e: Expected O, but got I4
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		bool flag = ((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
	}

	void ITriggerHandler<T>.OnError(Exception ex)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		object obj = this + 64;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF72B0");
	}

	void IUniTaskSource.GetResult(short token)
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050AAF0");
	}

	unsafe UniTaskStatus IUniTaskSource.GetStatus(short token)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		return ((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->GetStatus(token);
	}

	unsafe UniTaskStatus IUniTaskSource.UnsafeGetStatus()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		return ((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
	}

	unsafe void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
	}

	unsafe UniTask IAsyncFixedUpdateHandler.FixedUpdateAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncLateUpdateHandler.LateUpdateAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<int> IAsyncOnAnimatorIKHandler.OnAnimatorIKAsync()
	{
		//IL_0044: Expected O, but got I
		//IL_0057: Expected O, but got I4
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			_ = 0;
			_ = 0;
			return (UniTask<int>)this;
		}
		return (UniTask<int>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnAnimatorMoveHandler.OnAnimatorMoveAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<bool> IAsyncOnApplicationFocusHandler.OnApplicationFocusAsync()
	{
		//IL_0044: Expected O, but got I
		//IL_0057: Expected O, but got I4
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			_ = 0;
			_ = 0;
			return (UniTask<bool>)this;
		}
		return (UniTask<bool>)new InvalidCastException();
	}

	unsafe UniTask<bool> IAsyncOnApplicationPauseHandler.OnApplicationPauseAsync()
	{
		//IL_0044: Expected O, but got I
		//IL_0057: Expected O, but got I4
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			_ = 0;
			_ = 0;
			return (UniTask<bool>)this;
		}
		return (UniTask<bool>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnApplicationQuitHandler.OnApplicationQuitAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<(float[], int)> IAsyncOnAudioFilterReadHandler.OnAudioFilterReadAsync()
	{
		//IL_0044: Expected O, but got I
		//IL_0057: Expected O, but got I4
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			_ = 0;
			_ = 0;
			return (UniTask<(float[], int)>)this;
		}
		return (UniTask<(float[], int)>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnBecameInvisibleHandler.OnBecameInvisibleAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnBecameVisibleHandler.OnBecameVisibleAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnBeforeTransformParentChangedHandler.OnBeforeTransformParentChangedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnCanvasGroupChangedHandler.OnCanvasGroupChangedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<Collision> IAsyncOnCollisionEnterHandler.OnCollisionEnterAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collision>)this;
		}
		return (UniTask<Collision>)new InvalidCastException();
	}

	unsafe UniTask<Collision2D> IAsyncOnCollisionEnter2DHandler.OnCollisionEnter2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new InvalidCastException();
	}

	unsafe UniTask<Collision> IAsyncOnCollisionExitHandler.OnCollisionExitAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collision>)this;
		}
		return (UniTask<Collision>)new InvalidCastException();
	}

	unsafe UniTask<Collision2D> IAsyncOnCollisionExit2DHandler.OnCollisionExit2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new InvalidCastException();
	}

	unsafe UniTask<Collision> IAsyncOnCollisionStayHandler.OnCollisionStayAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collision>)this;
		}
		return (UniTask<Collision>)new InvalidCastException();
	}

	unsafe UniTask<Collision2D> IAsyncOnCollisionStay2DHandler.OnCollisionStay2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new InvalidCastException();
	}

	unsafe UniTask<ControllerColliderHit> IAsyncOnControllerColliderHitHandler.OnControllerColliderHitAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<ControllerColliderHit>)this;
		}
		return (UniTask<ControllerColliderHit>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnDisableHandler.OnDisableAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnDrawGizmosHandler.OnDrawGizmosAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnDrawGizmosSelectedHandler.OnDrawGizmosSelectedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnEnableHandler.OnEnableAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnGUIHandler.OnGUIAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<float> IAsyncOnJointBreakHandler.OnJointBreakAsync()
	{
		//IL_0044: Expected O, but got I
		//IL_0057: Expected O, but got I4
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			_ = 0;
			_ = 0;
			return (UniTask<float>)this;
		}
		return (UniTask<float>)new InvalidCastException();
	}

	unsafe UniTask<Joint2D> IAsyncOnJointBreak2DHandler.OnJointBreak2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Joint2D>)this;
		}
		return (UniTask<Joint2D>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseDownHandler.OnMouseDownAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseDragHandler.OnMouseDragAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseEnterHandler.OnMouseEnterAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseExitHandler.OnMouseExitAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseOverHandler.OnMouseOverAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseUpHandler.OnMouseUpAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnMouseUpAsButtonHandler.OnMouseUpAsButtonAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<GameObject> IAsyncOnParticleCollisionHandler.OnParticleCollisionAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<GameObject>)this;
		}
		return (UniTask<GameObject>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnParticleSystemStoppedHandler.OnParticleSystemStoppedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnParticleTriggerHandler.OnParticleTriggerAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<ParticleSystemJobData> IAsyncOnParticleUpdateJobScheduledHandler.OnParticleUpdateJobScheduledAsync()
	{
		//IL_0057: Expected O, but got I
		//IL_0033: Expected native int or pointer, but got O
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource<ParticleSystemJobData> uniTaskSource = default(IUniTaskSource<ParticleSystemJobData>);
		if (uniTaskSource != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)this, new UniTask<ParticleSystemJobData>(uniTaskSource, 0));
			return (UniTask<ParticleSystemJobData>)this;
		}
		return (UniTask<ParticleSystemJobData>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnPostRenderHandler.OnPostRenderAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnPreCullHandler.OnPreCullAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnPreRenderHandler.OnPreRenderAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnRectTransformDimensionsChangeHandler.OnRectTransformDimensionsChangeAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnRectTransformRemovedHandler.OnRectTransformRemovedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<(RenderTexture, RenderTexture)> IAsyncOnRenderImageHandler.OnRenderImageAsync()
	{
		//IL_0044: Expected O, but got I
		//IL_0057: Expected O, but got I4
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			_ = 0;
			_ = 0;
			return (UniTask<(RenderTexture, RenderTexture)>)this;
		}
		return (UniTask<(RenderTexture, RenderTexture)>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnRenderObjectHandler.OnRenderObjectAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnServerInitializedHandler.OnServerInitializedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnTransformChildrenChangedHandler.OnTransformChildrenChangedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnTransformParentChangedHandler.OnTransformParentChangedAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<Collider> IAsyncOnTriggerEnterHandler.OnTriggerEnterAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collider>)this;
		}
		return (UniTask<Collider>)new InvalidCastException();
	}

	unsafe UniTask<Collider2D> IAsyncOnTriggerEnter2DHandler.OnTriggerEnter2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collider2D>)this;
		}
		return (UniTask<Collider2D>)new InvalidCastException();
	}

	unsafe UniTask<Collider> IAsyncOnTriggerExitHandler.OnTriggerExitAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collider>)this;
		}
		return (UniTask<Collider>)new InvalidCastException();
	}

	unsafe UniTask<Collider2D> IAsyncOnTriggerExit2DHandler.OnTriggerExit2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collider2D>)this;
		}
		return (UniTask<Collider2D>)new InvalidCastException();
	}

	unsafe UniTask<Collider> IAsyncOnTriggerStayHandler.OnTriggerStayAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collider>)this;
		}
		return (UniTask<Collider>)new InvalidCastException();
	}

	unsafe UniTask<Collider2D> IAsyncOnTriggerStay2DHandler.OnTriggerStay2DAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<Collider2D>)this;
		}
		return (UniTask<Collider2D>)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnValidateHandler.OnValidateAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncOnWillRenderObjectHandler.OnWillRenderObjectAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncResetHandler.ResetAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask IAsyncUpdateHandler.UpdateAsync()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0059: Expected native int or pointer, but got O
		//IL_000d: Expected native int or pointer, but got O
		//IL_0027: Expected native int or pointer, but got O
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(this + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IUniTaskSource uniTaskSource = default(IUniTaskSource);
		if (uniTaskSource != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1<T>)+58]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
		return (UniTask)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnBeginDragHandler.OnBeginDragAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<BaseEventData> IAsyncOnCancelHandler.OnCancelAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new InvalidCastException();
	}

	unsafe UniTask<BaseEventData> IAsyncOnDeselectHandler.OnDeselectAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnDragHandler.OnDragAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnDropHandler.OnDropAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnEndDragHandler.OnEndDragAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnInitializePotentialDragHandler.OnInitializePotentialDragAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<AxisEventData> IAsyncOnMoveHandler.OnMoveAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<AxisEventData>)this;
		}
		return (UniTask<AxisEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnPointerClickHandler.OnPointerClickAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnPointerDownHandler.OnPointerDownAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnPointerEnterHandler.OnPointerEnterAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnPointerExitHandler.OnPointerExitAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnPointerUpHandler.OnPointerUpAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<PointerEventData> IAsyncOnScrollHandler.OnScrollAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new InvalidCastException();
	}

	unsafe UniTask<BaseEventData> IAsyncOnSelectHandler.OnSelectAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new InvalidCastException();
	}

	unsafe UniTask<BaseEventData> IAsyncOnSubmitHandler.OnSubmitAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new InvalidCastException();
	}

	unsafe UniTask<BaseEventData> IAsyncOnUpdateSelectedHandler.OnUpdateSelectedAsync()
	{
		//IL_0049: Expected O, but got I
		//IL_005c: Expected O, but got I4
		//IL_0024: Expected O, but got I
		nint num = default(nint);
		UniTaskCompletionSourceCore<(object, int)> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<(object, int)>)(num + 64);
		((UniTaskCompletionSourceCore<(object, int)>*)uniTaskCompletionSourceCore)->Reset();
		AsyncTriggerHandler<T> asyncTriggerHandler = (AsyncTriggerHandler<T>)0;
		trigger = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			asyncTriggerHandler = (AsyncTriggerHandler<T>)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+58]");
			trigger = (AsyncTriggerBase<T>)0;
			_ = 0;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new InvalidCastException();
	}

	static AsyncTriggerHandler()
	{
		//IL_003c: Expected O, but got I
		//IL_0051: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1>)+A8]");
		Action<object> action = new Action<object>(null, (IntPtr)0);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1>)+A8]");
		action._002Ector((object)null, (IntPtr)0);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerHandler`1>)+40]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
		object obj2 = 0;
		obj2 = action;
	}
}
