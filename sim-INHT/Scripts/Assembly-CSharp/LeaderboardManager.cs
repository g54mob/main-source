using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Heathen.SteamworksIntegration;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLeaderboard_CompleteRun_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LeaderboardManager _003C_003E4__this;

		public Action onCompleted;

		private TaskAwaiter<PostLeaderboardScoreResponse> _003C_003Eu__1;

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
	private struct _003CLeaderboard_StartRun_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LeaderboardManager _003C_003E4__this;

		public Gamemodes gamemode;

		private TaskAwaiter<GetSessionKeyResponse> _003C_003Eu__1;

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
	private struct _003CPushOperationState_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public OperationState state;

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
	private struct _003CRegisterUser_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LeaderboardManager _003C_003E4__this;

		private string _003CdeviceId_003E5__2;

		private string _003CsteamId_003E5__3;

		private string _003Cusername_003E5__4;

		private string _003CavatarBase64_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private TaskAwaiter<RegisterResponse> _003C_003Eu__3;

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

	public static LeaderboardManager Instance;

	[Header("Setup")]
	public string APIEndpoint;

	public string SecretKey;

	public Camera MapCamera;

	public RenderTexture MapCameraOutput;

	[ReadOnly]
	public LeaderboardRunData CurrentRun;

	private string _sessionKey;

	private bool _submitting;

	private string DeviceId => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[AsyncStateMachine(typeof(_003CRegisterUser_003Ed__12))]
	public Task RegisterUser()
	{
		return null;
	}

	private Task<string> GetSteamAvatarBase64(UserData user)
	{
		return null;
	}

	private string GetFallbackAvatarBase64()
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CPushOperationState_003Ed__15))]
	public static void PushOperationState(OperationState state)
	{
	}

	[AsyncStateMachine(typeof(_003CLeaderboard_StartRun_003Ed__16))]
	public void Leaderboard_StartRun(Gamemodes gamemode)
	{
	}

	[AsyncStateMachine(typeof(_003CLeaderboard_CompleteRun_003Ed__17))]
	public void Leaderboard_CompleteRun(Action onCompleted)
	{
	}

	public static string CaptureToBase64Image(Camera cam, RenderTexture target)
	{
		return null;
	}

	public void RecordAction(string action, string details, int scoreDelta, bool includeImage = false)
	{
	}

	private void ModifyScore(int value)
	{
	}
}
