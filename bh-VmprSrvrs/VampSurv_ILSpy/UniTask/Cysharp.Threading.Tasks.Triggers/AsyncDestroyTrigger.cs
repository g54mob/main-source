using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncDestroyTrigger : MonoBehaviour
{
	private class AwakeMonitor(AsyncDestroyTrigger trigger) : IPlayerLoopItem
	{
		private readonly AsyncDestroyTrigger trigger = trigger;

		public bool MoveNext()
		{
			AsyncDestroyTrigger asyncDestroyTrigger = trigger;
			if (!asyncDestroyTrigger.called && !asyncDestroyTrigger.awakeCalled)
			{
				if (((UnityEngine.Object)asyncDestroyTrigger).m_CachedPtr != (IntPtr)0)
				{
					return true;
				}
				AsyncDestroyTrigger asyncDestroyTrigger2 = trigger;
				CancellationTokenSource cancellationTokenSource = asyncDestroyTrigger2.cancellationTokenSource;
				asyncDestroyTrigger2.called = true;
				if (asyncDestroyTrigger2.cancellationTokenSource != null)
				{
					if (cancellationTokenSource._disposed)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
						CancellationTokenSource.ThrowObjectDisposedException();
						bool result = default(bool);
						return result;
					}
					asyncDestroyTrigger2.cancellationTokenSource.NotifyCancellation(false);
				}
				if (asyncDestroyTrigger2.cancellationTokenSource != null)
				{
					asyncDestroyTrigger2.cancellationTokenSource.Dispose();
				}
			}
			return false;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<object> _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnDestroyAsync_003Eb__7_0(object state)
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
	}

	private bool awakeCalled;

	private bool called;

	private CancellationTokenSource cancellationTokenSource;

	public CancellationToken CancellationToken
	{
		get
		{
			//IL_0020: Expected I4, but got I8
			if (this.cancellationTokenSource == null)
			{
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				cancellationTokenSource._threadIDExecutingCallbacks = -1;
				cancellationTokenSource._state = 1;
				this.cancellationTokenSource = cancellationTokenSource;
				if (!awakeCalled)
				{
					AwakeMonitor awakeMonitor = null;
					awakeMonitor.trigger = this;
					PlayerLoopHelper.AddAction(PlayerLoopTiming.Update, awakeMonitor);
				}
			}
			if (this.cancellationTokenSource != null)
			{
				return this.cancellationTokenSource.Token;
			}
			return (CancellationToken)new NullReferenceException();
		}
	}

	private void Awake()
	{
		awakeCalled = true;
	}

	private void OnDestroy()
	{
		CancellationTokenSource cancellationTokenSource = this.cancellationTokenSource;
		called = true;
		if (this.cancellationTokenSource != null)
		{
			if (cancellationTokenSource._disposed)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
				CancellationTokenSource.ThrowObjectDisposedException();
				return;
			}
			this.cancellationTokenSource.NotifyCancellation(false);
		}
		if (this.cancellationTokenSource != null)
		{
			this.cancellationTokenSource.Dispose();
		}
	}

	public unsafe UniTask OnDestroyAsync()
	{
		//IL_0108: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		UniTask uniTask = default(UniTask);
		if (!called)
		{
			UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
			CancellationToken cancellationToken = CancellationToken;
			Action<object> callback = _003C_003Ec._003C_003E9__7_0;
			if (_003C_003Ec._003C_003E9__7_0 == null)
			{
				callback = (_003C_003Ec._003C_003E9__7_0 = delegate(object state)
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
				});
			}
			CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, callback, uniTaskCompletionSource);
			if (uniTaskCompletionSource != null)
			{
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, uniTaskCompletionSource);
				return uniTask;
			}
			return (UniTask)new NullReferenceException();
		}
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, (IUniTaskSource)UniTask.CompletedTask);
		return uniTask;
	}

	public AsyncDestroyTrigger()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
