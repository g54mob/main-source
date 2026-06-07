using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Log;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public sealed class AuthClient : IAuthClientInternal, IAuthClient, IDisposableInternal, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitializeSimulatorAuthentication_003Ed__90 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

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
		private struct _003CLogin_003Ed__81 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public LoginInfo info;

			public AuthClient _003C_003E4__this;

			public CancellationToken cancellationToken;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private TaskAwaiter<(bool success, string error)> _003C_003Eu__2;

			private TaskAwaiter<LoginResult> _003C_003Eu__3;

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
		private struct _003CLoginAsGuest_003Ed__66 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public CancellationToken cancellationToken;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private TaskAwaiter<LoginResult> _003C_003Eu__2;

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
		private struct _003CLoginWithEpicGames_003Ed__72 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string token;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithJwt_003Ed__69 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string token;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithNintendo_003Ed__75 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string token;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithOneTimeCode_003Ed__70 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string code;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithPassword_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string username;

			public string password;

			public bool autoSignup;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithPlayStation_003Ed__73 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string token;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithSessionToken_003Ed__68 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public SessionToken sessionToken;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithSteam_003Ed__71 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string ticket;

			public string identity;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CLoginWithXbox_003Ed__74 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			public string token;

			public CancellationToken cancellationToken;

			private TaskAwaiter<LoginResult> _003C_003Eu__1;

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
		private struct _003CWaitUntilConnected_003Ed__84 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<(bool success, string error)> _003C_003Et__builder;

			public AuthClient _003C_003E4__this;

			private TaskAwaiter<(bool success, string error)> _003C_003Eu__1;

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

		internal const string LoginRequestName = "AuthClient.Login";

		internal const string UserOperationName = "AuthClient.PlayerAccountOperation";

		internal const string LoginRequestMethod = "POST";

		private const string ConnectionClosedPath = "/connection/closed";

		private Action<PlayerAccount> onLoggingIn;

		private Action<PlayerAccount> onLoggingOut;

		private readonly IRequestFactory requestFactory;

		private readonly TimeSpan simulatorTokenRefreshPeriodInDays;

		private PlayerAccount playerAccount;

		private CancellationTokenSource initialAuthCancellationToken;

		private Task refreshTokenTask;

		private Action onWebSocketConnect;

		private bool isDisposed;

		private readonly IPlayerAccountProvider playerAccountProvider;

		private bool shouldDisposePlayerAccountProvider;

		private readonly Logger logger;

		public bool LoggedIn { get; private set; }

		PlayerAccount IAuthClientInternal.PlayerAccount
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		SessionToken IAuthClientInternal.SessionToken => default(SessionToken);

		PlayerAccountId IAuthClientInternal.PlayerAccountId => default(PlayerAccountId);

		string IDisposableInternal.InitializationContext
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		string IDisposableInternal.InitializationStackTrace
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		bool IDisposableInternal.IsDisposed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private SessionToken SessionToken => default(SessionToken);

		private CloudUniqueId UniqueId => default(CloudUniqueId);

		private string ProjectId => null;

		event Action<PlayerAccount> IAuthClientInternal.OnLoggingIn
		{
			add
			{
			}
			remove
			{
			}
		}

		event Action<PlayerAccount> IAuthClientInternal.OnLoggingOut
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<LoginResponse> OnLogin
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnLogout
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<LoginError> OnError
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal event Action BeingDisposed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static AuthClient ForPlayer(IRequestFactory requestFactory, string projectId)
		{
			return null;
		}

		internal static AuthClient ForPlayer(IRequestFactory requestFactory, IPlayerAccountProvider playerAccountProvider)
		{
			return null;
		}

		internal static AuthClient ForSimulator(IRequestFactory requestFactory, SimulatorPlayerAccountProvider playerAccountProvider)
		{
			return null;
		}

		private AuthClient(IPlayerAccountProvider playerAccountProvider, IRequestFactory requestFactory)
		{
		}

		[AsyncStateMachine(typeof(_003CLoginAsGuest_003Ed__66))]
		public Task<LoginResult> LoginAsGuest(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithPassword_003Ed__67))]
		public Task<LoginResult> LoginWithPassword(string username, string password, bool autoSignup, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithSessionToken_003Ed__68))]
		public Task<LoginResult> LoginWithSessionToken(SessionToken sessionToken, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithJwt_003Ed__69))]
		public Task<LoginResult> LoginWithJwt(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithOneTimeCode_003Ed__70))]
		public Task<LoginResult> LoginWithOneTimeCode(string code, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithSteam_003Ed__71))]
		public Task<LoginResult> LoginWithSteam(string ticket, string identity = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithEpicGames_003Ed__72))]
		public Task<LoginResult> LoginWithEpicGames(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithPlayStation_003Ed__73))]
		public Task<LoginResult> LoginWithPlayStation(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithXbox_003Ed__74))]
		public Task<LoginResult> LoginWithXbox(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoginWithNintendo_003Ed__75))]
		public Task<LoginResult> LoginWithNintendo(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public void Logout()
		{
		}

		~AuthClient()
		{
		}

		public void Dispose()
		{
		}

		private void OnConnectionClosedHandler(string responseBody)
		{
		}

		Task<LoginResult> IAuthClientInternal.Login(LoginInfo info, CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLogin_003Ed__81))]
		internal Task<LoginResult> Login(LoginInfo info, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		PlayerAccountOperation<TResult> IAuthClientInternal.PlayerAccountOperationAsync<TRequest, TResponse, TResult>(PlayerAccountOperationInfo<TRequest> info, [MaybeNull] Func<TResponse, TResult> resultFactory, CancellationToken cancellationToken, Action onCompletingSuccessfully)
		{
			return null;
		}

		private static PlayerAccountOperationException CreateUserOperationException(PlayerAccountErrorType errorType, Error error, string response = "", Exception exception = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitUntilConnected_003Ed__84))]
		private Task<(bool, string)> WaitUntilConnected()
		{
			return null;
		}

		private LoginResult HandleLoginError(LoginType loginType, Result resultType, LoginErrorType loginErrorType, ErrorType errorType, Error error, string response = "", Exception exception = null, Warning? logWarning = null)
		{
			return null;
		}

		private LoginResult HandleLoginError(LoginError error, Result resultType, Warning? logWarning = null)
		{
			return null;
		}

		private static string GetRequestBody(LoginInfo loginInfo)
		{
			return null;
		}

		private static object GetLoginRequest(LoginInfo info)
		{
			return null;
		}

		private LoginResult HandleLoginResponse(LoginType loginType, string response)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CInitializeSimulatorAuthentication_003Ed__90))]
		private void InitializeSimulatorAuthentication()
		{
		}
	}
}
