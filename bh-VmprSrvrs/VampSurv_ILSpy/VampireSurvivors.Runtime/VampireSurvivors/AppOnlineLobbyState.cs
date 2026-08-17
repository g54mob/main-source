using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Connection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class AppOnlineLobbyState : AppStateMachineState
{
	[StructLayout((LayoutKind)3)]
	private struct _003CDisconnect_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool leaveLobby;

		public AppOnlineLobbyState _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0174: Expected I4, but got I8
			//IL_0184: Expected O, but got Ref
			//IL_00dd: Expected O, but got I4
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_01b8: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (!leaveLobby)
				{
					goto IL_0148;
				}
				AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
				_003CLeaveLobby_003Ed__11 stateMachine = default(_003CLeaveLobby_003Ed__11);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<System.Threading.Tasks.VoidTaskResult> task2 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
				TaskAwaiter awaiter = ((Task)task2).GetAwaiter();
				int num = ((Task)awaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)awaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = awaiter;
					AsyncTaskMethodBuilder asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter2 = default(TaskAwaiter);
					((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_0148;
			IL_0148:
			CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class _003CDisconnectIfHostNotInGameRoutine_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AppOnlineLobbyState _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c2: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.DisconnectWithoutLeavingLobby();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CDisconnectWithoutLeavingLobby_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AppOnlineLobbyState _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_017a: Expected I4, but got I8
			//IL_0185: Expected O, but got Ref
			//IL_009c: Expected O, but got I4
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_0131: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task task2 = _003C_003E4__this.Disconnect(leaveLobby: false);
				int num = task2.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task2;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter)task2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
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

	[StructLayout((LayoutKind)3)]
	private struct _003CLeaveLobby_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AppOnlineLobbyState _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_009a: Expected O, but got I4
			//IL_00a9: Expected I4, but got I8
			//IL_025b: Expected I4, but got I8
			//IL_012e: Expected O, but got I4
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_0214: Expected O, but got Ref
			//IL_01f6: Expected O, but got Ref
			AppOnlineLobbyState appOnlineLobbyState = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				goto IL_006d;
			}
			LobbiesManager lobbiesManager = appOnlineLobbyState.LobbiesManager;
			if (lobbiesManager._activeLobby != null)
			{
				LobbySession activeLobby = lobbiesManager._activeLobby;
				if (!activeLobby._003CIsDisposed_003Ek__BackingField)
				{
					goto IL_006d;
				}
			}
			goto IL_024c;
			IL_006d:
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<bool> task2 = appOnlineLobbyState.LobbiesManager.LeaveLobby();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				int num = task3.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task3;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<bool>)task3;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rbx_v11 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_024c;
			IL_024c:
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder2)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003COnBack_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AppOnlineLobbyState _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_01ec: Expected I4, but got I8
			//IL_01f7: Expected O, but got Ref
			//IL_00ee: Expected O, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected O, but got Unknown
			//IL_0183: Expected O, but got Ref
			AppOnlineLobbyState appOnlineLobbyState = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				LobbiesManager lobbiesManager = appOnlineLobbyState.LobbiesManager;
				LobbySession activeLobby = lobbiesManager._activeLobby;
				bool flag = lobbiesManager._activeLobby == null;
				bool leaveLobby = false;
				if (!flag)
				{
					bool flag2 = activeLobby.lobbyOwnerSession == null;
					leaveLobby = flag2;
				}
				Task task2 = appOnlineLobbyState.Disconnect(leaveLobby);
				int num = task2.m_stateFlags & 0x1600000;
				bool flag3 = num == 0;
				bool flag4 = num < 0;
				bool flag5 = !flag4;
				object obj = !flag5;
				object obj2 = obj | flag3;
				task = task2;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter)task2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
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

	private Coroutine _coroutine;

	public override void Init(StateMachine stateMachine)
	{
		base.Init(stateMachine);
		UsesBackButton = true;
	}

	public override void OnEnter()
	{
		//IL_009b: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0375: Expected O, but got I
		//IL_015d: Expected O, but got I4
		//IL_015d: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_03ac: Expected O, but got I
		//IL_028e: Expected O, but got I
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = SelectStage;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.SelectOnlineStageSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.SelectOnlineStageSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v14 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action3 = StartGame;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.StartOnlineGame>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.StartOnlineGame>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = appStateMachine2.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v30 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action5 = OnShowErrorScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA84B0");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action6 = ShowAchievements;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7410");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action7 = ShowCollections;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7590");
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action action8 = ShowPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7A10");
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> action9 = OnDisconnected;
		UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionCloseReason>.GetDelegate(action9);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v15 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
		_ = 1;
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnection> value = OnClientDisconnected;
		masterBridge2._003CClientConnections_003Ek__BackingField.OnDestroyed += value;
		Action b = OnBack;
		BackButtonController.AddListener(b);
		if (!OnlineStageManager.IsHostInTheGame())
		{
			_003CDisconnectIfHostNotInGameRoutine_003Ed__4 obj8 = null;
			obj8._003C_003E1__state = 0;
			obj8._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj8);
			_coroutine = coroutine;
		}
	}

	public override void OnExit()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0207: Expected O, but got I
		//IL_0207: Expected O, but got I
		base.OnExit();
		if (_coroutine != null)
		{
			StopCoroutine(_coroutine);
			_coroutine = null;
		}
		AppStateMachine appStateMachine = base.appStateMachine;
		Action token = SelectStage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action token2 = StartGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		appStateMachine2.SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action = OnShowErrorScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8630");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action2 = ShowAchievements;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7F70");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action3 = ShowCollections;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8030");
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action action4 = ShowPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8270");
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> unityAction = OnDisconnected;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rsi_v8 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v44 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnection> value = OnClientDisconnected;
		masterBridge2._003CClientConnections_003Ek__BackingField.OnDestroyed -= value;
		Action b = OnBack;
		BackButtonController.TryRemoveListener(b);
	}

	private IEnumerator DisconnectIfHostNotInGameRoutine()
	{
		_003CDisconnectIfHostNotInGameRoutine_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void OnClientDisconnected(CoherenceClientConnection clientConn)
	{
		//IL_0033: Expected O, but got Ref
		object obj = default(object);
		object arg = (ClientID)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Detected Client disconnected: {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			OnlineStageManager instance2 = OnlineStageManager._instance;
			if ((nint)clientConn._003CClientId_003Ek__BackingField != (int)instance2._firstSeat || OnlineStageManager._instance.IsHost)
			{
				return;
			}
		}
		DisconnectWithoutLeavingLobby();
	}

	private void DisconnectWithoutLeavingLobby()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CDisconnectWithoutLeavingLobby_003Ed__6 stateMachine = default(_003CDisconnectWithoutLeavingLobby_003Ed__6);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void SelectStage()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42AF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SELECT_STAGE");
		GameEventMessage.SendEvent("SELECT_STAGE");
	}

	private void StartGame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42B0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("START_GAME");
		GameEventMessage.SendEvent("START_GAME");
	}

	private void OnBack()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003COnBack_003Ed__9 stateMachine = default(_003COnBack_003Ed__9);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private unsafe Task Disconnect(bool leaveLobby)
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CDisconnect_003Ed__10 stateMachine = default(_003CDisconnect_003Ed__10);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private unsafe Task LeaveLobby()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CLeaveLobby_003Ed__11 stateMachine = default(_003CLeaveLobby_003Ed__11);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42B4]");
		if ((nint)0 == 0)
		{
			int num = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	private void OnShowErrorScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42B5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("ONLINE_ERROR");
		GameEventMessage.SendEvent("ONLINE_ERROR");
	}

	private void ShowAchievements()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42B6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ACHIEVEMENTS");
		GameEventMessage.SendEvent("SHOW_ACHIEVEMENTS");
	}

	private void ShowCollections()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42B7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_COLLECTIONS");
		GameEventMessage.SendEvent("SHOW_COLLECTIONS");
	}

	private void ShowPowerUps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42B8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_POWER_UPS");
		GameEventMessage.SendEvent("SHOW_POWER_UPS");
	}

	public AppOnlineLobbyState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
