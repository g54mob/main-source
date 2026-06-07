using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Log;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using Zenject;

namespace VampireSurvivors
{
	public class LobbiesManager : IInitializable, IDisposable
	{
		private struct PingResult
		{
			public bool isDone;

			public long time;

			public PingResult(bool isDone, long time)
			{
				this.isDone = false;
				this.time = 0L;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateNewLobby_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbyResult> _003C_003Et__builder;

			public LobbiesManager _003C_003E4__this;

			private string _003CbestRegion_003E5__2;

			private List<CloudAttribute> _003ClobbyAttributes_003E5__3;

			private List<CloudAttribute> _003CplayerAttributes_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__1;

			private Task<LobbySession> _003Ctask_003E5__5;

			private int _003C_003E7__wrap5;

			private TaskAwaiter<LobbySession> _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

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
		private struct _003CGetBestRegion_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public LobbiesManager _003C_003E4__this;

			private string _003CbestRegion_003E5__2;

			private long _003CbestRtt_003E5__3;

			private PingResult _003CresultEu_003E5__4;

			private PingResult _003CresultUs_003E5__5;

			private PingResult _003CresultUsw_003E5__6;

			private TaskAwaiter<PingResult> _003C_003Eu__1;

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
		private struct _003CGetRTTForRegion_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PingResult> _003C_003Et__builder;

			public string region;

			public LobbiesManager _003C_003E4__this;

			private Ping _003Cping_003E5__2;

			private float _003Ctimeout_003E5__3;

			private TaskAwaiter<IPHostEntry> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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
		private struct _003CJoinLobby_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LobbyResult> _003C_003Et__builder;

			public LobbiesManager _003C_003E4__this;

			public string tag;

			private Task<IReadOnlyList<LobbyData>> _003Ctask_003E5__2;

			private Task<LobbySession> _003CjoinTask_003E5__3;

			private TaskAwaiter<IReadOnlyList<LobbyData>> _003C_003Eu__1;

			private TaskAwaiter<LobbySession> _003C_003Eu__2;

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
		private struct _003CLeaveLobby_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public LobbiesManager _003C_003E4__this;

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

		private LobbySession _activeLobby;

		private readonly Coherence.Log.Logger _logger;

		private static Dictionary<string, string> _regionUrls;

		private static HashSet<SystemPlatformTypes> _specialPlatforms;

		private const string InviteCodeAlphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

		private const int InviteCodeLength = 6;

		public LobbySession ActiveLobby => null;

		public bool IsPartOfLobby => false;

		public bool IsHost => false;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CCreateNewLobby_003Ed__15))]
		public Task<LobbyResult> CreateNewLobby()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CJoinLobby_003Ed__16))]
		public Task<LobbyResult> JoinLobby(string tag)
		{
			return null;
		}

		private static LobbyFilter DisableCrossplay(LobbyFilter filter)
		{
			return default(LobbyFilter);
		}

		[AsyncStateMachine(typeof(_003CLeaveLobby_003Ed__18))]
		public Task<bool> LeaveLobby()
		{
			return null;
		}

		public bool ArePlayersReadyToStartGame()
		{
			return false;
		}

		private bool CheckAttributes(LobbyData lobbyData, out string errorMessage)
		{
			errorMessage = null;
			return false;
		}

		private bool CheckHostDlcs(LobbyData lobbyData, out string errorMessage)
		{
			errorMessage = null;
			return false;
		}

		private string GenerateLobbyCode()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetBestRegion_003Ed__23))]
		private Task<string> GetBestRegion()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetRTTForRegion_003Ed__24))]
		private Task<PingResult> GetRTTForRegion(string region)
		{
			return null;
		}

		private bool TryGetFirstIPv4Address(IPAddress[] addressList, out IPAddress firstIPv4Address)
		{
			firstIPv4Address = null;
			return false;
		}

		private string GetCurrentlyLoadedDLCAsString()
		{
			return null;
		}
	}
}
