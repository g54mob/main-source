using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VampireSurvivors
{
	public class AppOnlineState : AppStateMachineState
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnBack_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AppOnlineState _003C_003E4__this;

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

		private bool _isLeavingLobby;

		public override void Init(StateMachine stateMachine)
		{
		}

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		[AsyncStateMachine(typeof(_003COnBack_003Ed__4))]
		private void OnBack()
		{
		}

		private void GoBackOnline()
		{
		}

		private void OnShowLobbyScreen()
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

		private void ShowOptions()
		{
		}

		private void ShowCredits()
		{
		}

		private void ShowPowerUps()
		{
		}

		private void ShowBestiary()
		{
		}

		private void ShowAdventuresSelection()
		{
		}
	}
}
