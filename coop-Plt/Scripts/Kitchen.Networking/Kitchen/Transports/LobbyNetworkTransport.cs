using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen.Transports
{
	public abstract class LobbyNetworkTransport<TTarget, TLobby> : BaseNetworkTransport<TTarget, TLobby> where TTarget : INetworkTarget
	{
		protected struct LobbyTask
		{
			public Task<TLobby> Task;

			public TTarget Target;

			public CancellationTokenSource CancellationToken;
		}

		public static readonly byte[] KickMessage = Encoding.ASCII.GetBytes("kick");

		public TTarget IntendedConnectionTarget;

		protected TTarget SuspendedConnectionTarget;

		public JoinCode LobbyJoinCode;

		public const int MaxRetries = 3;

		protected int RemainingRetries;

		protected List<TTarget> LobbyMembers = new List<TTarget>();

		protected HashSet<TTarget> KickedMembers = new HashSet<TTarget>();

		protected HashSet<TTarget> BannedMembers = new HashSet<TTarget>();

		protected LobbyTask CurrentTask;

		private NetworkPermissions CurrentNetworkPermissions;

		public TLobby CurrentLobby { get; protected set; }

		public LobbyTransportStatus LobbyStatus
		{
			get
			{
				if (IntendedConnectionTarget == null || !IntendedConnectionTarget.IsValid)
				{
					return LobbyTransportStatus.Unstarted;
				}
				if (IsValidLobby(CurrentLobby) && IsNetworkTargetResolved(IntendedConnectionTarget) && IsEquivalent(IntendedConnectionTarget, CurrentLobby) && Service.IsInLobby(CurrentLobby))
				{
					return LobbyTransportStatus.Ready;
				}
				if (CurrentLobby != null && IsValidLobby(CurrentLobby))
				{
					return LobbyTransportStatus.Disconnecting;
				}
				return LobbyTransportStatus.Connecting;
			}
		}

		public override bool IsHosting => IsEquivalent(Service.Me, CurrentLobby);

		public override TransportConnectionStatus ConnectionStatus
		{
			get
			{
				if (LobbyStatus == LobbyTransportStatus.Unstarted)
				{
					return TransportConnectionStatus.Disconnected;
				}
				if (IsHosting)
				{
					return TransportConnectionStatus.ActiveHosting;
				}
				return TransportConnectionStatus.ActiveClient;
			}
		}

		public override TransportSendStatus SendStatus
		{
			get
			{
				if (LobbyStatus != LobbyTransportStatus.Ready)
				{
					return TransportSendStatus.NoSendNotConnected;
				}
				if (IsHosting)
				{
					if (LobbyMembers.Count <= 0)
					{
						return TransportSendStatus.NoSendNoClients;
					}
					return TransportSendStatus.Ready;
				}
				if (!IsValidLobby(CurrentLobby))
				{
					return TransportSendStatus.NoSendNotConnected;
				}
				return TransportSendStatus.Ready;
			}
		}

		public LobbyNetworkTransport(JoinCode join_code)
		{
			LobbyJoinCode = join_code;
		}

		protected abstract bool IsEquivalent(TTarget target, TLobby lobby);

		protected abstract string GetTargetName(TTarget target);

		protected abstract bool IsValidLobby(TLobby lobby);

		public abstract TTarget GetTargetForLobby(TLobby lobby);

		public override bool RequestJoinServer(INetworkTarget target)
		{
			if (!(target is TTarget intendedConnectionTarget))
			{
				return false;
			}
			if (target == null)
			{
				return false;
			}
			EventLog.Networking.Report(NetworkEvent.TransportReceiveJoinRequest, target.ToString());
			Service.ShouldConnect = true;
			IntendedConnectionTarget = intendedConnectionTarget;
			RemainingRetries = 3;
			return true;
		}

		public override void RequestStartServer()
		{
			EventLog.Networking.Report(NetworkEvent.TransportReceiveHostRequest);
			IntendedConnectionTarget = Service.Me;
			RemainingRetries = 3;
		}

		public override void RequestDisconnect()
		{
			try
			{
				if (IntendedConnectionTarget != null)
				{
					EventLog.Networking.Report(NetworkEvent.TransportReceiveDisconnectRequest, IntendedConnectionTarget.ToString());
				}
				LeaveLobby();
			}
			catch (Exception ex)
			{
				EventLog.Networking.Report(NetworkEvent.ErrorWhileDisconnecting, ex);
			}
			IntendedConnectionTarget = default(TTarget);
		}

		public override void RequestSuspend()
		{
			if (SuspendedConnectionTarget == null || !SuspendedConnectionTarget.IsValid)
			{
				try
				{
					LeaveLobby();
				}
				catch (Exception ex)
				{
					EventLog.Networking.Report(NetworkEvent.ErrorWhileSuspending, ex);
				}
				SuspendedConnectionTarget = IntendedConnectionTarget;
				IntendedConnectionTarget = default(TTarget);
			}
		}

		public override void RequestUnsuspend()
		{
			if (SuspendedConnectionTarget != null && SuspendedConnectionTarget.IsValid)
			{
				IntendedConnectionTarget = SuspendedConnectionTarget;
				RemainingRetries = 3;
				SuspendedConnectionTarget = default(TTarget);
			}
		}

		public override void RequestKickUser(INetworkTarget target)
		{
			EventLog.Networking.Report(NetworkEvent.TransportReceiveKickRequest, target.ToString());
			if (target is TTarget val)
			{
				SendToClient(val, KickMessage);
				Service.KickFromLobby(CurrentLobby, val);
				KickedMembers.Add(val);
			}
		}

		public override void RequestBanUser(INetworkTarget target)
		{
			EventLog.Networking.Report(NetworkEvent.TransportReceiveBanRequest, target.ToString());
			if (target is TTarget val)
			{
				SendToClient(val, KickMessage);
				BannedMembers.Add(val);
			}
		}

		public override void GetConnectedPlayers(ref List<NetworkTargetDescription> users)
		{
			foreach (TTarget lobbyMember in LobbyMembers)
			{
				users.Add(new NetworkTargetDescription
				{
					Target = lobbyMember,
					Username = GetTargetName(lobbyMember)
				});
			}
		}

		public override void Update()
		{
			base.Update();
			switch (LobbyStatus)
			{
			case LobbyTransportStatus.Unstarted:
				if (IsValidLobby(CurrentLobby))
				{
					LeaveLobby();
				}
				break;
			case LobbyTransportStatus.Connecting:
				UpdateCurrentTask();
				break;
			case LobbyTransportStatus.Disconnecting:
				IntendedConnectionTarget = ClearTargetResolution(IntendedConnectionTarget);
				LeaveLobby();
				break;
			case LobbyTransportStatus.Ready:
				if (CurrentTask.Task != null)
				{
					CurrentTask.CancellationToken.Cancel();
					CurrentTask = default(LobbyTask);
				}
				UpdatePermissions();
				UpdateLobbyMembers();
				break;
			}
		}

		protected virtual void UpdateCurrentTask()
		{
			if (CurrentTask.Task == null)
			{
				if (Service.State != PlatformState.Ready)
				{
					return;
				}
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				if (!IsNetworkTargetResolved(IntendedConnectionTarget))
				{
					EventLog.Networking.Report(NetworkEvent.TransportTaskResolveTarget, IntendedConnectionTarget.ToString());
					CurrentTask = new LobbyTask
					{
						Task = ResolveIntendedTarget(cancellationTokenSource.Token),
						Target = IntendedConnectionTarget,
						CancellationToken = cancellationTokenSource
					};
					return;
				}
				ref TTarget intendedConnectionTarget = ref IntendedConnectionTarget;
				object other = Service.Me;
				if (intendedConnectionTarget.IsEquivalent((INetworkTarget)other))
				{
					EventLog.Networking.Report(NetworkEvent.TransportTaskCreateLobby, IntendedConnectionTarget.ToString());
					CurrentTask = new LobbyTask
					{
						Task = CreateNewLobby(cancellationTokenSource.Token),
						Target = IntendedConnectionTarget,
						CancellationToken = cancellationTokenSource
					};
				}
				else if (RemainingRetries < 0)
				{
					EventLog.Networking.Report(NetworkEvent.TransportGivingUpAfterRetries, IntendedConnectionTarget.ToString());
					RequestDisconnect();
					Liveness.SetUnlive();
				}
				else
				{
					RemainingRetries--;
					EventLog.Networking.Report(NetworkEvent.TransportTaskJoinLobby, IntendedConnectionTarget.ToString());
					CurrentTask = new LobbyTask
					{
						Task = JoinTargetLobby(IntendedConnectionTarget, cancellationTokenSource.Token),
						Target = IntendedConnectionTarget,
						CancellationToken = cancellationTokenSource
					};
				}
			}
			else if (!CurrentTask.Task.IsCompleted)
			{
				if (Service.State == PlatformState.Failed)
				{
					EventLog.Networking.Report(NetworkEvent.TransportTaskFail);
					CurrentTask.CancellationToken.Cancel();
					CurrentTask = default(LobbyTask);
				}
			}
			else
			{
				if (!CurrentTask.Task.IsFaulted && !CurrentTask.Task.IsCanceled && CurrentTask.Task.Result != null)
				{
					HandleNewLobby(CurrentTask.Task.Result);
				}
				CurrentTask.CancellationToken.Cancel();
				CurrentTask = default(LobbyTask);
			}
		}

		protected virtual bool IsNetworkTargetResolved(TTarget target)
		{
			return true;
		}

		protected virtual TTarget ClearTargetResolution(TTarget target)
		{
			return target;
		}

		protected virtual void HandleNewLobby(TLobby lobby)
		{
			if (IsValidLobby(lobby))
			{
				if (!IsEquivalent(IntendedConnectionTarget, lobby))
				{
					EventLog.Networking.Report(NetworkEvent.TransportJoinedIncorrectLobby, lobby.ToString());
					Service.LeaveLobby(lobby);
					return;
				}
				EventLog.Networking.Report(NetworkEvent.TransportJoinedLobby, lobby.ToString());
				RemainingRetries = 3;
				CurrentLobby = lobby;
				UpdatePermissions();
				UpdateLobbyMembers();
			}
		}

		protected virtual void UpdatePermissions(bool force = false)
		{
			NetworkPermissions currentNetworkPermissions = NetworkHelpers.CurrentNetworkPermissions;
			if (force || currentNetworkPermissions != CurrentNetworkPermissions)
			{
				CurrentNetworkPermissions = currentNetworkPermissions;
				if (IsHosting)
				{
					Service.SetLobbyPermission(CurrentLobby, CurrentNetworkPermissions);
				}
			}
		}

		public override string GetTargetName(INetworkTarget target)
		{
			if (target is TTarget target2)
			{
				return GetTargetName(target2);
			}
			return "";
		}

		protected virtual async Task<TLobby> JoinTargetLobby(TTarget target, CancellationToken token)
		{
			EventLog.Networking.Report(NetworkEvent.TransportJoiningLobby, target.ToString());
			RefreshLiveness();
			LeaveLobby();
			while (Service.State != PlatformState.Ready)
			{
				await Task.Delay(100, token);
			}
			object other = Service.Me;
			bool is_me = target.IsEquivalent((INetworkTarget)other);
			BaseService<TTarget, TLobby>.LobbyCreationResult lobbyCreationResult = await (is_me ? Service.CreateNewLobby(LobbyJoinCode, token) : Service.JoinLobby(target, token));
			RefreshLiveness();
			if (!lobbyCreationResult.Success)
			{
				EventLog.Networking.Report(is_me ? NetworkEvent.TransportCreateLobbyFailure : NetworkEvent.TransportJoinLobbyFailure);
				if (lobbyCreationResult.AbandonFurtherAttempts)
				{
					IntendedConnectionTarget = default(TTarget);
				}
				await Task.Delay(TimeSpan.FromSeconds(1.0), token);
				return default(TLobby);
			}
			EventLog.Networking.Report(is_me ? NetworkEvent.TransportCreateLobbySuccess : NetworkEvent.TransportJoinLobbySuccess, lobbyCreationResult.Lobby.ToString());
			CurrentNetworkPermissions = NetworkPermissions.Unset;
			return lobbyCreationResult.Lobby;
		}

		protected virtual Task<TLobby> ResolveIntendedTarget(CancellationToken token)
		{
			return Task.FromResult(default(TLobby));
		}

		protected virtual Task<TLobby> CreateNewLobby(CancellationToken token)
		{
			return JoinTargetLobby(Service.Me, token);
		}

		protected virtual void LeaveLobby()
		{
			CurrentNetworkPermissions = NetworkPermissions.Unset;
			LobbyMembers.Clear();
			KickedMembers.Clear();
			BannedMembers.Clear();
			if (CurrentLobby != null && IsValidLobby(CurrentLobby))
			{
				EventLog.Networking.Report(NetworkEvent.TransportLeaveLobby, CurrentLobby.ToString());
				Service.LeaveLobby(CurrentLobby);
			}
			RefreshLiveness();
			CurrentLobby = default(TLobby);
		}

		protected void UpdateLobbyMembers()
		{
			if (LobbyStatus != LobbyTransportStatus.Ready || !Service.IsValidLobby(CurrentLobby))
			{
				LobbyMembers.Clear();
				return;
			}
			Service.GetOtherLobbyMembers(CurrentLobby, ref LobbyMembers);
			TTarget lobbyHost = Service.GetLobbyHost(CurrentLobby);
			bool flag = lobbyHost?.IsEquivalent(Service.Me) ?? false;
			if (IsHosting != flag)
			{
				EventLog.Networking.Report(NetworkEvent.LobbyDisconnectingHostingButNotHost, $"{Service.Me} is not {lobbyHost}");
				RequestDisconnect();
			}
			else
			{
				KickedMembers.RemoveWhere((TTarget t) => !LobbyMembers.Contains(t));
			}
		}

		public override string GetDebugInfo()
		{
			NetworkInviteData invite_data = default(NetworkInviteData);
			SupplyInviteData(ref invite_data);
			return $"({ConnectionType}) T:{SendStatus}, {LobbyStatus} ({IntendedConnectionTarget} / {CurrentLobby})\n({ConnectionType}){invite_data.InviteString}\n({ConnectionType}) --> {Stats.Summary}";
		}

		protected abstract TransportSendResult SendToClient(TTarget client, byte[] data);

		protected virtual TransportSendResult SendToClients(byte[] data)
		{
			TransportSendResult result = TransportSendResult.Success;
			foreach (TTarget lobbyMember in LobbyMembers)
			{
				if (!KickedMembers.Contains(lobbyMember) && !BannedMembers.Contains(lobbyMember))
				{
					TransportSendResult transportSendResult = SendToClient(lobbyMember, data);
					if (transportSendResult != TransportSendResult.Success)
					{
						result = transportSendResult;
					}
				}
			}
			return result;
		}

		protected virtual TransportSendResult SendToHost(byte[] data)
		{
			TTarget lobbyHost = Service.GetLobbyHost(CurrentLobby);
			if (lobbyHost != null)
			{
				object other = Service.Me;
				if (!lobbyHost.IsEquivalent((INetworkTarget)other))
				{
					return SendToClient(lobbyHost, data);
				}
			}
			EventLog.Networking.Report(NetworkEvent.TransportDisconnectInvalidHost, lobbyHost?.ToString());
			RequestDisconnect();
			return TransportSendResult.FailedNotConnected;
		}

		public override TransportSendResult Send(byte[] data)
		{
			if (LobbyStatus != LobbyTransportStatus.Ready)
			{
				return TransportSendResult.FailedNotConnected;
			}
			if (data != null)
			{
				Stats.ReportPacket(data.Length, is_up: true, LobbyMembers.Count);
			}
			try
			{
				if (CurrentLobby == null)
				{
					return TransportSendResult.FailedNotConnected;
				}
				if (IsHosting)
				{
					return SendToClients(data);
				}
				return SendToHost(data);
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
				return TransportSendResult.FailedError;
			}
		}

		protected void ReceiveData(TTarget source, byte[] data)
		{
			object other = Service.Me;
			if (source.IsEquivalent((INetworkTarget)other))
			{
				EventLog.Networking.Report(NetworkEvent.TransportReceivedOwnData, source.ToString());
			}
			else if (data != null)
			{
				if (data.SequenceEqual(KickMessage))
				{
					RequestDisconnect();
				}
				else if (!KickedMembers.Contains(source) && !BannedMembers.Contains(source))
				{
					RefreshLiveness();
					Stats.ReportPacket(data.Length, is_up: false);
					ReportReceive(source, data);
				}
			}
		}

		public override bool IsTargetConnected(INetworkTarget target)
		{
			foreach (TTarget lobbyMember in LobbyMembers)
			{
				if (lobbyMember.IsEquivalent(target))
				{
					return true;
				}
			}
			if (!IsHosting && target.IsEquivalent(IntendedConnectionTarget))
			{
				return true;
			}
			return false;
		}
	}
}
