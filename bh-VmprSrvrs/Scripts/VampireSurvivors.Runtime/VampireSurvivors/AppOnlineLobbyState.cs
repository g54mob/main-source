using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Connection;
using Coherence.Toolkit;
using UnityEngine;

namespace VampireSurvivors
{
	public class AppOnlineLobbyState : AppStateMachineState
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisconnect_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public bool leaveLobby;

			public AppOnlineLobbyState _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CDisconnectIfHostNotInGameRoutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AppOnlineLobbyState _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDisconnectIfHostNotInGameRoutine_003Ed__4(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisconnectWithoutLeavingLobby_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AppOnlineLobbyState _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLeaveLobby_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AppOnlineLobbyState _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnBack_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AppOnlineLobbyState _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
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
		}

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		[IteratorStateMachine(typeof(_003CDisconnectIfHostNotInGameRoutine_003Ed__4))]
		private IEnumerator DisconnectIfHostNotInGameRoutine()
		{
			return null;
		}

		private void OnClientDisconnected(CoherenceClientConnection clientConn)
		{
		}

		[AsyncStateMachine(typeof(_003CDisconnectWithoutLeavingLobby_003Ed__6))]
		private void DisconnectWithoutLeavingLobby()
		{
		}

		private void SelectStage()
		{
		}

		private void StartGame()
		{
		}

		[AsyncStateMachine(typeof(_003COnBack_003Ed__9))]
		private void OnBack()
		{
		}

		[AsyncStateMachine(typeof(_003CDisconnect_003Ed__10))]
		private Task Disconnect(bool leaveLobby)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLeaveLobby_003Ed__11))]
		private Task LeaveLobby()
		{
			return null;
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}

		private void OnShowErrorScreen()
		{
		}

		private void ShowAchievements()
		{
		}

		private void ShowCollections()
		{
		}

		private void ShowPowerUps()
		{
		}
	}
}
