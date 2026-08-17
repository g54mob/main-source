using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public abstract class AsyncTriggerBase<T> : MonoBehaviour, IUniTaskAsyncEnumerable<T>
{
	private sealed class AsyncTriggerEnumerator : MoveNextSource, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable, ITriggerHandler<T>
	{
		private static Action<object> cancellationCallback;

		private readonly AsyncTriggerBase<T> parent;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration registration;

		private bool called;

		private bool isDisposed;

		private T _003CCurrent_003Ek__BackingField;

		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

		public T Current
		{
			get
			{
				//IL_0010: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+68]");
				AsyncTriggerEnumerator asyncTriggerEnumerator = (AsyncTriggerEnumerator)0;
				return (T)this;
			}
			private set
			{
			}
		}

		ITriggerHandler<T> ITriggerHandler<T>.Prev
		{
			get
			{
				//IL_000d: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>+AsyncTriggerEnumerator<T>)+78]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>+AsyncTriggerEnumerator<T>)+80]");
				return (ITriggerHandler<T>)0;
			}
			set
			{
			}
		}

		public AsyncTriggerEnumerator(AsyncTriggerBase<T> parent, CancellationToken cancellationToken)
		{
		}

		public unsafe void OnCanceled(CancellationToken cancellationToken = default(CancellationToken))
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
		}

		public unsafe void OnNext(T value)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: true);
		}

		public unsafe void OnCompleted()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: false);
		}

		public unsafe void OnError(Exception ex)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetException(ex);
		}

		private unsafe static void CancellationCallback(object state)
		{
			//IL_0081: Expected O, but got I
			//IL_0123: Expected O, but got Ref
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected O, but got Unknown
			//IL_0146: Expected O, but got I
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_00fb: Expected O, but got I
			//IL_010b: Expected O, but got I
			nint num = 0;
			if (state == null)
			{
				goto IL_0150;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1+AsyncTriggerEnumerator>)+8]");
			bool flag = state != null;
			object obj = null;
			if (!flag)
			{
				obj = state;
			}
			if (obj != null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v13 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1+AsyncTriggerEnumerator>)+20]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v4 (System.Object)+61]");
				if ((nint)0 == 0)
				{
					CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(obj + 72);
					_ = 1;
					((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v4 (System.Object)+38]");
					if ((nint)0 == 0)
					{
						goto IL_0150;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v4+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v18+C0]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0520");
				}
				object obj5 = default(object);
				UniTaskExtensions.Forget((UniTask)(&obj5));
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(obj + 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v4 (System.Object)+40]");
				bool flag2 = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
				return;
			}
			goto IL_0181;
			IL_0150:
			NullReferenceException ex = new NullReferenceException();
			goto IL_0181;
			IL_0181:
			throw new InvalidCastException();
		}

		public unsafe UniTask<bool> MoveNextAsync()
		{
			//IL_0013: Expected O, but got I
			//IL_002a: Expected O, but got I
			//IL_015d: Expected O, but got I
			//IL_007b: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_00dc: Expected O, but got I
			//IL_00ec: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_012f: Expected O, but got I
			//IL_012f: Expected O, but got I
			nint num = default(nint);
			CancellationToken cancellationToken = (CancellationToken)(num + 64);
			((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(num + 16);
			((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->Reset();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+60]");
			if ((nint)0 == 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v16+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0400");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v23+C0]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v15+38]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v25+B8]");
					object callback = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
					_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)0, (Action<object>)callback, num).m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v28 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
			}
			_ = 0;
			AsyncTriggerEnumerator asyncTriggerEnumerator = (AsyncTriggerEnumerator)num;
			_ = 0;
			_ = 0;
			return (UniTask<bool>)this;
		}

		public unsafe UniTask DisposeAsync()
		{
			//IL_0005: Expected native int or pointer, but got O
			//IL_008b: Expected native int or pointer, but got O
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>+AsyncTriggerEnumerator<T>)+61]");
			if ((nint)0 == 0)
			{
				_ = 1;
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 72);
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>+AsyncTriggerEnumerator<T>)+38]");
				if ((nint)0 == 0)
				{
					return (UniTask)new NullReferenceException();
				}
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807D0520");
			}
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			return uniTask;
		}

		static AsyncTriggerEnumerator()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1+AsyncTriggerEnumerator>)+48]");
			Action<object> action = new Action<object>(null, (IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1+AsyncTriggerEnumerator>)+48]");
			action._002Ector((object)null, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1+AsyncTriggerEnumerator>)+38]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
			object obj2 = 0;
			obj2 = action;
		}
	}

	private class AwakeMonitor(AsyncTriggerBase<T> trigger) : IPlayerLoopItem
	{
		private readonly AsyncTriggerBase<T> trigger = trigger;

		public bool MoveNext()
		{
			//IL_0127: Expected I4, but got O
			//IL_00a6: Expected O, but got I
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected O, but got Unknown
			//IL_00f4: Expected O, but got I
			//IL_0104: Expected O, but got I
			AsyncTriggerBase<T> asyncTriggerBase = trigger;
			if ((object)trigger != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>)+10]");
					if ((nint)0 != 0)
					{
						return true;
					}
					AsyncTriggerBase<T> asyncTriggerBase2 = trigger;
					if ((object)trigger == null)
					{
						goto IL_0119;
					}
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1+AwakeMonitor>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v3 (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>)+39]");
					if ((nint)0 == 0)
					{
						_ = 1;
						object obj2 = trigger + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v13+20]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rax_v14+C0]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E71120");
					}
				}
				return false;
			}
			goto IL_0119;
			IL_0119:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private TriggerEvent<T> triggerEvent;

	protected internal bool calledAwake;

	protected internal bool calledDestroy;

	private void Awake()
	{
		_ = 1;
	}

	private void OnDestroy()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>)+39]");
		if ((nint)0 == 0)
		{
			_ = 1;
			object obj = this + 32;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E71120");
		}
	}

	internal void AddHandler(ITriggerHandler<T> handler)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>)+38]");
		if ((nint)0 == 0)
		{
			nint num = 0;
			IPlayerLoopItem action = null;
			PlayerLoopHelper.AddAction(PlayerLoopTiming.Update, action);
		}
		object obj = this + 32;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E716B0");
	}

	internal void RemoveHandler(ITriggerHandler<T> handler)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Triggers.AsyncTriggerBase`1<T>)+38]");
		if ((nint)0 == 0)
		{
			nint num = 0;
			IPlayerLoopItem action = null;
			PlayerLoopHelper.AddAction(PlayerLoopTiming.Update, action);
		}
		object obj = this + 32;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E71AB0");
	}

	protected void RaiseEvent(T value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		object obj = this + 32;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E70B20");
	}

	public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
	{
		nint num = 0;
		return null;
	}

	protected AsyncTriggerBase()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
