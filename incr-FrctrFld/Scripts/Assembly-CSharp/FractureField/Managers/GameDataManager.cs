using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FractureField.Shared.DTOs.GameData;

namespace FractureField.Managers
{
	public class GameDataManager
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass8_0
		{
			public GameDataManager _003C_003E4__this;

			public Action<GameDataDto> onSuccess;

			public TaskCompletionSource<bool> taskCompletionSource;

			public Action<string> onFailure;

			internal void _003CLoadGameData_003Eb__1(GameDataDto response)
			{
			}

			internal void _003CLoadGameData_003Eb__2(Exception error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadGameData_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public GameDataManager _003C_003E4__this;

			public Action<GameDataDto> onSuccess;

			public Action<string> onFailure;

			private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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
		private struct _003CRefreshGameData_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public GameDataManager _003C_003E4__this;

			public Action<GameDataDto> onSuccess;

			public Action<string> onFailure;

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

		public bool IsGameDataLoaded { get; private set; }

		public GameDataDto CurrentGameData { get; private set; }

		[AsyncStateMachine(typeof(_003CLoadGameData_003Ed__8))]
		public Task<bool> LoadGameData(Action<GameDataDto> onSuccess = null, Action<string> onFailure = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRefreshGameData_003Ed__9))]
		public Task<bool> RefreshGameData(Action<GameDataDto> onSuccess = null, Action<string> onFailure = null)
		{
			return null;
		}

		private void HandleGameDataLoadFailure(string errorMessage, Action<string> onFailure = null)
		{
		}
	}
}
