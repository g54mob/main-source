using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FractureField.Shared.DTOs;
using FractureField.Shared.DTOs.Auth;

namespace FractureField.Managers
{
	public class AuthManager
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

			public TaskCompletionSource<bool> taskCompletionSource;

			public Action<string> onFailure;

			internal void _003CCreateNewApiKey_003Eb__0(AuthResponse response)
			{
			}

			internal void _003CCreateNewApiKey_003Eb__1(Exception error)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass21_0
		{
			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

			public TaskCompletionSource<bool> taskCompletionSource;

			public Action<string> onFailure;

			internal void _003CLoginWithApiKey_003Eb__0(AuthResponse response)
			{
			}

			internal void _003CLoginWithApiKey_003Eb__1(Exception error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAttemptAutoLogin_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAttemptAutoLoginInternal_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

			public Action<string> onFailure;

			public int retryCount;

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
		private struct _003CCreateNewApiKey_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

			public Action<string> onFailure;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

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
		private struct _003CLoginWithApiKey_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

			public Action<string> onFailure;

			public string apiKey;

			private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

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
		private struct _003CRefreshAuthentication_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AuthManager _003C_003E4__this;

			public Action<PlayerDto> onSuccess;

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

		public bool IsAuthenticated { get; private set; }

		public PlayerDto CurrentPlayer { get; private set; }

		public string CurrentApiKey { get; private set; }

		public string CurrentAuthToken { get; private set; }

		private string GetStoredApiKey()
		{
			return null;
		}

		private void StoreApiKey(string apiKey)
		{
		}

		[AsyncStateMachine(typeof(_003CAttemptAutoLogin_003Ed__18))]
		public Task<bool> AttemptAutoLogin(Action<PlayerDto> onSuccess = null, Action<string> onFailure = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAttemptAutoLoginInternal_003Ed__19))]
		private Task<bool> AttemptAutoLoginInternal(Action<PlayerDto> onSuccess = null, Action<string> onFailure = null, int retryCount = 0)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCreateNewApiKey_003Ed__20))]
		public Task<bool> CreateNewApiKey(Action<PlayerDto> onSuccess = null, Action<string> onFailure = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithApiKey_003Ed__21))]
		public Task<bool> LoginWithApiKey(string apiKey, Action<PlayerDto> onSuccess = null, Action<string> onFailure = null)
		{
			return null;
		}

		private void HandleAuthenticationSuccess(string apiKey, string token, PlayerDto player, Action<PlayerDto> onSuccess = null)
		{
		}

		public void ResetAuthState()
		{
		}

		private void HandleAuthenticationFailure(string errorMessage, Action<string> onFailure = null)
		{
		}

		public void Logout(Action onLogout = null)
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshAuthentication_003Ed__26))]
		public Task<bool> RefreshAuthentication(Action<PlayerDto> onSuccess = null, Action<string> onFailure = null)
		{
			return null;
		}
	}
}
