using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.Loading;

public class AsyncLoader
{
	[StructLayout((LayoutKind)3)]
	private struct _003CCleanup_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AsyncLoader _003C_003E4__this;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0124: Expected O, but got I4
			//IL_012f: Expected O, but got Ref
			//IL_00c8: Expected I4, but got I8
			//IL_00d3: Expected O, but got Ref
			AsyncLoader asyncLoader = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				_003C_003E1__state = -1;
				List<Action<Action>> loadCalls = asyncLoader._loadCalls;
				int version = loadCalls._version + 1;
				loadCalls._version = version;
				loadCalls._size = 0;
				if (loadCalls._size > 0)
				{
					Array.Clear(loadCalls._items, 0, loadCalls._size);
				}
				asyncLoader._onComplete = null;
				_003C_003E1__state = -2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				if (asyncVoidMethodBuilder.m_synchronizationContext != null)
				{
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->NotifySynchronizationContextOfCompletion();
				}
			}
			else
			{
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				YieldAwaitable.YieldAwaiter awaiter = default(YieldAwaitable.YieldAwaiter);
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private readonly List<Action<Action>> _loadCalls;

	private int _remainingLoadCalls;

	private Action _onComplete;

	public AsyncLoader(Action onComplete)
	{
		List<Action<Action>> loadCalls = new List<Action<Action>>();
		_loadCalls = loadCalls;
		_onComplete = onComplete;
	}

	private void OnLoad()
	{
		if (--_remainingLoadCalls <= 0)
		{
			Action onComplete = _onComplete;
			if (_onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v21.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003CCleanup_003Ed__5 stateMachine = default(_003CCleanup_003Ed__5);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
	}

	private void Cleanup()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CCleanup_003Ed__5 stateMachine = default(_003CCleanup_003Ed__5);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	public void Add(Action<Action> loadCall)
	{
		int remainingLoadCalls = _remainingLoadCalls + 1;
		_remainingLoadCalls = remainingLoadCalls;
		List<object> loadCalls = (List<object>)(object)_loadCalls;
		int version = loadCalls._version + 1;
		loadCalls._version = version;
		object[] items = loadCalls._items;
		if (loadCalls._size >= items.Length)
		{
			loadCalls.AddWithResize((object)loadCall);
			return;
		}
		int size = loadCalls._size + 1;
		loadCalls._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void Load()
	{
		//IL_0013: Expected O, but got I4
		if (_remainingLoadCalls == 0)
		{
			OnLoad();
			return;
		}
		List<Action<Action>>.Enumerator enumerator = default(List<Action<Action>>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
		}
	}
}
