using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class LeaderboardClient
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CDiscordLinkRequest_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string code;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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
	private struct _003CGenerateDiscordLinkKey_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CGetMine_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GetMyLeaderboardResponse> _003C_003Et__builder;

		public Gamemodes gamemode;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CGetSessionKey_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GetSessionKeyResponse> _003C_003Et__builder;

		public Gamemodes gamemode;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CGetTop_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GetTopLeaderboardResponse> _003C_003Et__builder;

		public int count;

		public Gamemodes gamemode;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CPushOperationState_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public PostOperationStateRequest request;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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
	private struct _003CRegister_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<RegisterResponse> _003C_003Et__builder;

		public RegisterRequest request;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CSubmitScore_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PostLeaderboardScoreResponse> _003C_003Et__builder;

		public PostLeaderboardScoreRequest request;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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

	private static readonly HttpClient _http;

	private static string _baseUrl;

	private static string _secret;

	private static string _deviceID;

	public static RegisterResponse LatestRegisterResponse;

	private static readonly JsonSerializerSettings _jsonOptions;

	public static void Init(string baseUrl, string secretKey, string deviceID)
	{
	}

	private static HttpRequestMessage CreateRequest(HttpMethod method, string url, object body = null)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CDiscordLinkRequest_003Ed__8))]
	public static Task<bool> DiscordLinkRequest(string code)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGenerateDiscordLinkKey_003Ed__9))]
	public static Task<string> GenerateDiscordLinkKey()
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CRegister_003Ed__10))]
	public static Task<RegisterResponse> Register(RegisterRequest request)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CPushOperationState_003Ed__11))]
	public static Task<bool> PushOperationState(PostOperationStateRequest request)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGetTop_003Ed__12))]
	public static Task<GetTopLeaderboardResponse> GetTop(Gamemodes gamemode, int count)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGetMine_003Ed__13))]
	public static Task<GetMyLeaderboardResponse> GetMine(Gamemodes gamemode)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGetSessionKey_003Ed__14))]
	public static Task<GetSessionKeyResponse> GetSessionKey(Gamemodes gamemode)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CSubmitScore_003Ed__15))]
	public static Task<PostLeaderboardScoreResponse> SubmitScore(PostLeaderboardScoreRequest request)
	{
		return null;
	}
}
