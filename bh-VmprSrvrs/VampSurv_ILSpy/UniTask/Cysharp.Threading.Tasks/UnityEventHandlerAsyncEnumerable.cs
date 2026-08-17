using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace Cysharp.Threading.Tasks;

public class UnityEventHandlerAsyncEnumerable(UnityEvent unityEvent, CancellationToken cancellationToken) : IUniTaskAsyncEnumerable<AsyncUnit>
{
	private class UnityEventHandlerAsyncEnumerator(UnityEvent unityEvent, CancellationToken cancellationToken1, CancellationToken cancellationToken2) : MoveNextSource, IUniTaskAsyncEnumerator<AsyncUnit>, IUniTaskAsyncDisposable
	{
		private static readonly Action<object> cancel1;

		private static readonly Action<object> cancel2;

		private readonly UnityEvent unityEvent = unityEvent;

		private CancellationToken cancellationToken1 = cancellationToken1;

		private CancellationToken cancellationToken2 = cancellationToken2;

		private UnityAction unityAction;

		private CancellationTokenRegistration registration1;

		private CancellationTokenRegistration registration2;

		private bool isDisposed;

		public AsyncUnit Current
		{
			get
			{
				//IL_0006: Expected O, but got I4
				return (AsyncUnit)0;
			}
		}

		public unsafe UniTask<bool> MoveNextAsync()
		{
			//IL_0013: Expected O, but got I
			//IL_002a: Expected O, but got I
			//IL_0046: Expected O, but got I
			//IL_01e0: Expected O, but got I
			//IL_0086: Expected O, but got I
			//IL_00dc: Expected O, but got I
			//IL_00dc: Expected O, but got I
			//IL_0128: Expected O, but got I
			//IL_0128: Expected O, but got I
			//IL_0194: Expected O, but got I
			//IL_0194: Expected O, but got I
			nint num = default(nint);
			CancellationToken cancellationToken = (CancellationToken)(num + 64);
			((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
			CancellationToken cancellationToken2 = (CancellationToken)(num + 72);
			((CancellationToken*)cancellationToken2)->ThrowIfCancellationRequested();
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(num + 16);
			((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->Reset();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+50]");
			if ((nint)0 == 0)
			{
				UnityAction unityAction = ((UnityEventHandlerAsyncEnumerator)num).Invoke;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					return (UniTask<bool>)new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+50]");
				((UnityEvent)num2).AddListener((UnityAction)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
					_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)0, cancel1, num).m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v44 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
					_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)0, cancel2, num).m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v29 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
			}
			_ = 0;
			UnityEventHandlerAsyncEnumerator unityEventHandlerAsyncEnumerator = (UnityEventHandlerAsyncEnumerator)num;
			_ = 0;
			_ = 0;
			return (UniTask<bool>)this;
		}

		private unsafe void Invoke()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: true);
		}

		private unsafe static void OnCanceled1(object state)
		{
			//IL_011e: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00e3: Expected O, but got Ref
			//IL_0059: Expected O, but got I
			nint num = (nint)typeof(UnityEventHandlerAsyncEnumerator);
			object obj = default(object);
			if (obj != null)
			{
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable+UnityEventHandlerAsyncEnumerator>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v3 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable+UnityEventHandlerAsyncEnumerator>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v3 (Il2CppClass<System.Object>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v18+FFFFFFF8+v45 @ rax_v17 (System.Object)*8]");
					if (0 == (nint)typeof(UnityEventHandlerAsyncEnumerator))
					{
						goto IL_0086;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_0086;
			IL_0086:
			UnityEventHandlerAsyncEnumerator unityEventHandlerAsyncEnumerator = default(UnityEventHandlerAsyncEnumerator);
			if (unityEventHandlerAsyncEnumerator != null)
			{
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(unityEventHandlerAsyncEnumerator + 16);
				bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled(unityEventHandlerAsyncEnumerator.cancellationToken1);
				UniTask uniTask = unityEventHandlerAsyncEnumerator.DisposeAsync();
				IUniTaskSource uniTaskSource = default(IUniTaskSource);
				UniTaskExtensions.Forget((UniTask)(&uniTaskSource));
				return;
			}
			throw new NullReferenceException();
		}

		private unsafe static void OnCanceled2(object state)
		{
			//IL_0102: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00e3: Expected O, but got Ref
			//IL_0059: Expected O, but got I
			nint num = (nint)typeof(UnityEventHandlerAsyncEnumerator);
			object obj = default(object);
			if (obj != null)
			{
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable+UnityEventHandlerAsyncEnumerator>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable+UnityEventHandlerAsyncEnumerator>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (Il2CppClass<System.Object>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v14+FFFFFFF8+v45 @ rax_v13 (System.Object)*8]");
					if (0 == (nint)typeof(UnityEventHandlerAsyncEnumerator))
					{
						goto IL_0086;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_0086;
			IL_0086:
			UnityEventHandlerAsyncEnumerator unityEventHandlerAsyncEnumerator = default(UnityEventHandlerAsyncEnumerator);
			if (unityEventHandlerAsyncEnumerator != null)
			{
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(unityEventHandlerAsyncEnumerator + 16);
				bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled(unityEventHandlerAsyncEnumerator.cancellationToken2);
				UniTask uniTask = unityEventHandlerAsyncEnumerator.DisposeAsync();
				IUniTaskSource uniTaskSource = default(IUniTaskSource);
				UniTaskExtensions.Forget((UniTask)(&uniTaskSource));
				return;
			}
			throw new NullReferenceException();
		}

		public unsafe UniTask DisposeAsync()
		{
			//IL_011f: Expected native int or pointer, but got O
			//IL_0102: Expected native int or pointer, but got O
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00f4: Expected O, but got I4
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			if (!isDisposed)
			{
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 88);
				isDisposed = true;
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				CancellationTokenRegistration cancellationTokenRegistration2 = (CancellationTokenRegistration)(this + 112);
				((CancellationTokenRegistration*)cancellationTokenRegistration2)->Dispose();
				UnityEvent unityEvent = this.unityEvent;
				if (this.unityEvent != null)
				{
					UnityAction unityAction = this.unityAction;
					if (this.unityAction != null)
					{
						MethodInfo methodImpl = ((MulticastDelegate)this.unityAction).GetMethodImpl();
						if (((UnityEventBase)unityEvent).m_Calls != null)
						{
							((UnityEventBase)unityEvent).m_Calls.RemoveListener(((Delegate)unityAction).m_target, methodImpl);
							UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
							bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
							goto IL_00fd;
						}
					}
				}
				return (UniTask)new NullReferenceException();
			}
			goto IL_00fd;
			IL_00fd:
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			return uniTask;
		}

		static UnityEventHandlerAsyncEnumerator()
		{
			Action<object> action = OnCanceled1;
			cancel1 = action;
			Action<object> action2 = OnCanceled2;
			cancel2 = action2;
		}
	}

	private readonly UnityEvent unityEvent = unityEvent;

	private readonly CancellationToken cancellationToken1 = cancellationToken;

	public IUniTaskAsyncEnumerator<AsyncUnit> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_006f: Expected O, but got I4
		if ((object)cancellationToken1 != (object)cancellationToken)
		{
			return new UnityEventHandlerAsyncEnumerator(unityEvent, cancellationToken1, cancellationToken);
		}
		return new UnityEventHandlerAsyncEnumerator(unityEvent, cancellationToken1, (CancellationToken)0);
	}
}
public class UnityEventHandlerAsyncEnumerable<T>(UnityEvent<T> unityEvent, CancellationToken cancellationToken) : IUniTaskAsyncEnumerable<T>
{
	private class UnityEventHandlerAsyncEnumerator : MoveNextSource, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable
	{
		private static readonly Action<object> cancel1;

		private static readonly Action<object> cancel2;

		private readonly UnityEvent<T> unityEvent;

		private CancellationToken cancellationToken1;

		private CancellationToken cancellationToken2;

		private UnityAction<T> unityAction;

		private CancellationTokenRegistration registration1;

		private CancellationTokenRegistration registration2;

		private bool isDisposed;

		private T _003CCurrent_003Ek__BackingField;

		public T Current
		{
			get
			{
				//IL_000d: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>+UnityEventHandlerAsyncEnumerator<T>)+89]");
				return (T)0;
			}
			private set
			{
			}
		}

		public UnityEventHandlerAsyncEnumerator(UnityEvent<T> unityEvent, CancellationToken cancellationToken1, CancellationToken cancellationToken2)
		{
		}

		public unsafe UniTask<bool> MoveNextAsync()
		{
			//IL_0013: Expected O, but got I
			//IL_002a: Expected O, but got I
			//IL_0046: Expected O, but got I
			//IL_0293: Expected O, but got I
			//IL_0087: Expected O, but got I
			//IL_0097: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_00ef: Expected O, but got I
			//IL_00ff: Expected O, but got I
			//IL_0150: Expected O, but got I
			//IL_0160: Expected O, but got I
			//IL_0170: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_020a: Expected O, but got I
			//IL_021a: Expected O, but got I
			//IL_022a: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_023f: Expected O, but got I
			//IL_0265: Expected O, but got I
			//IL_0265: Expected O, but got I
			//IL_0265: Expected O, but got I
			nint num = default(nint);
			CancellationToken cancellationToken = (CancellationToken)(num + 64);
			((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
			CancellationToken cancellationToken2 = (CancellationToken)(num + 72);
			((CancellationToken*)cancellationToken2)->ThrowIfCancellationRequested();
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(num + 16);
			((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->Reset();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+50]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v16+C0]");
				object obj2 = 0;
				object obj3 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v14+C0]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002FD0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v23+C0]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800030A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v53+C0]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rcx_v37+38]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rax_v55+B8]");
					object callback = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+40]");
					_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)0, (Action<object>)callback, num).m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v58 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r8+20]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v32+C0]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rcx_v24+38]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v34+B8]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+48]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v35+8]");
					_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)num2, (Action<object>)0, num).m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v37 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
			}
			_ = 0;
			UnityEventHandlerAsyncEnumerator unityEventHandlerAsyncEnumerator = (UnityEventHandlerAsyncEnumerator)num;
			_ = 0;
			_ = 0;
			return (UniTask<bool>)this;
		}

		private unsafe void Invoke(T value)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: true);
		}

		private unsafe static void OnCanceled1(object state)
		{
			//IL_001b: Expected O, but got I
			//IL_0028: Expected I, but got O
			//IL_0038: Expected O, but got I
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00db: Expected O, but got I
			//IL_0074: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+8]");
			object obj = 0;
			object obj2 = default(object);
			if (obj2 != null)
			{
				nint num2 = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v3+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r8_v1 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v3+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r8_v1 (Il2CppClass<System.Object>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v25+FFFFFFF8+v75 @ rax_v24 (System.Object)*8]");
					if (0 == (nint)obj)
					{
						goto IL_009b;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_009b;
			IL_009b:
			object obj5 = default(object);
			if (obj5 != null)
			{
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(obj5 + 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_8_v3+40]");
				bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183F330A0");
				return;
			}
			throw new NullReferenceException();
		}

		private unsafe static void OnCanceled2(object state)
		{
			//IL_001b: Expected O, but got I
			//IL_0028: Expected I, but got O
			//IL_0038: Expected O, but got I
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00db: Expected O, but got I
			//IL_0074: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+8]");
			object obj = 0;
			object obj2 = default(object);
			if (obj2 != null)
			{
				nint num2 = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v3+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v2 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v3+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v2 (Il2CppClass<System.Object>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v18+FFFFFFF8+v75 @ rax_v17 (System.Object)*8]");
					if (0 == (nint)obj)
					{
						goto IL_009b;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_009b;
			IL_009b:
			object obj5 = default(object);
			if (obj5 != null)
			{
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(obj5 + 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_8_v3+48]");
				bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183F330A0");
				return;
			}
			throw new NullReferenceException();
		}

		public unsafe UniTask DisposeAsync()
		{
			//IL_0174: Expected native int or pointer, but got O
			//IL_0157: Expected native int or pointer, but got O
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_007e: Expected O, but got I
			//IL_00b3: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_0149: Expected O, but got I4
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>+UnityEventHandlerAsyncEnumerator<T>)+88]");
			if ((nint)0 == 0)
			{
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(this + 88);
				_ = 1;
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				CancellationTokenRegistration cancellationTokenRegistration2 = (CancellationTokenRegistration)(this + 112);
				((CancellationTokenRegistration*)cancellationTokenRegistration2)->Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>+UnityEventHandlerAsyncEnumerator<T>)+38]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>+UnityEventHandlerAsyncEnumerator<T>)+38]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>+UnityEventHandlerAsyncEnumerator<T>)+50]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>+UnityEventHandlerAsyncEnumerator<T>)+50]");
					if ((nint)0 != 0)
					{
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v176 @ rdx_v7+1B8] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rsi_v3+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rsi_v3+10]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v8+20]");
							MethodInfo method = default(MethodInfo);
							((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, method);
							UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
							bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)0);
							goto IL_0152;
						}
					}
				}
				return (UniTask)new NullReferenceException();
			}
			goto IL_0152;
			IL_0152:
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			return uniTask;
		}

		static UnityEventHandlerAsyncEnumerator()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_00ba: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+58]");
			Action<object> action = new Action<object>(null, (IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+58]");
			action._002Ector((object)null, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+38]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v10+B8]");
			object obj2 = 0;
			obj2 = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r8_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+60]");
			Action<object> action2 = new Action<object>(null, (IntPtr)0);
			nint num3 = 0;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v24 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1+UnityEventHandlerAsyncEnumerator>)+38]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v26+B8]");
			object obj4 = 0;
		}
	}

	private readonly UnityEvent<T> unityEvent = unityEvent;

	private readonly CancellationToken cancellationToken1;

	public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0069: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityEventHandlerAsyncEnumerable`1<T>)+18]");
		IUniTaskAsyncEnumerator<T> result;
		if (0 != (nint)cancellationToken)
		{
			nint num = 0;
			result = null;
			CancellationToken cancellationToken2 = cancellationToken;
		}
		else
		{
			nint num2 = 0;
			result = null;
			CancellationToken cancellationToken2 = (CancellationToken)0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18071FCB0");
		return result;
	}
}
