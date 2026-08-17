using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace Coherence.Toolkit;

[Serializable]
public sealed class EnemyProvider : INetworkObjectProvider
{
	[StructLayout((LayoutKind)3)]
	private struct _003CLoadAsset_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public EnemyProvider _003C_003E4__this;

		public Action<ICoherenceSync> onLoaded;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0089: Expected O, but got I4
			//IL_0094: Expected O, but got Ref
			//IL_0118: Expected I4, but got I8
			//IL_0123: Expected O, but got Ref
			EnemyProvider enemyProvider = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				_003C_003E1__state = -1;
			}
			GameManager core = GM.Core;
			Stage stage = core._stage;
			if (!stage._003CPoolsInitialized_003Ek__BackingField)
			{
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				YieldAwaitable.YieldAwaiter awaiter = default(YieldAwaitable.YieldAwaiter);
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
				return;
			}
			Action<ICoherenceSync> action = onLoaded;
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			GameObject enemyPrefab = stage2._enemyFactory.GetEnemyPrefab(enemyProvider._enemyType);
			ICoherenceSync component = enemyPrefab.GetComponent<ICoherenceSync>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v156 @ rdi_v6 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+18] (should have been resolved before IL gen)");
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
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

	private EnemyType _enemyType;

	public void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CLoadAsset_003Ed__1 stateMachine = default(_003CLoadAsset_003Ed__1);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void LoadPrefab(Action<ICoherenceSync> onLoaded)
	{
		//IL_0056: Expected O, but got I
		//IL_0066: Expected O, but got I
		//IL_0076: Expected O, but got I
		while (true)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			GameObject enemyPrefab = stage._enemyFactory.GetEnemyPrefab(_enemyType);
			ICoherenceSync component = enemyPrefab.GetComponent<ICoherenceSync>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ rdx (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ rdx (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ rdx (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ rax_v9 (should have been resolved before IL gen)");
		}
	}

	public ICoherenceSync LoadAsset(string networkAssetId)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._enemyFactory != null)
			{
				GameObject enemyPrefab = stage._enemyFactory.GetEnemyPrefab(_enemyType);
				if ((object)enemyPrefab != null)
				{
					return enemyPrefab.GetComponent<ICoherenceSync>();
				}
			}
		}
		return (ICoherenceSync)new NullReferenceException();
	}

	public void Release(ICoherenceSync obj)
	{
	}

	public void OnApplicationQuit()
	{
	}

	public void Initialize(CoherenceSyncConfig entry)
	{
	}

	public bool Validate(CoherenceSyncConfig entry)
	{
		//IL_0010: Expected O, but got I4
		object obj = _enemyType - 246;
		bool flag = obj == null;
		return !flag;
	}
}
