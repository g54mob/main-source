using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Platforms;
using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public abstract class BaseService<TTarget, TLobby> : MonoBehaviour, INetworkService where TTarget : INetworkTarget
	{
		public struct LobbyCreationResult
		{
			public TLobby Lobby;

			public bool Success;

			public bool AbandonFurtherAttempts;

			public static LobbyCreationResult Fail => default(LobbyCreationResult);

			public static LobbyCreationResult Abandon => new LobbyCreationResult
			{
				AbandonFurtherAttempts = true
			};
		}

		protected NetworkConnectionMaintainer ConnectionMaintainer;

		public EventLog Events => EventLog.Networking;

		public PlatformState State { get; protected set; }

		public bool ShouldConnect { get; set; }

		public abstract string Name { get; }

		public virtual bool IsCrossplay => false;

		public virtual bool CanAcceptJoinCode => false;

		public abstract TTarget Me { get; }

		public virtual string NetworkAccessIdentifier => Name;

		public event Action<TTarget, byte[]> OnNetworkMessage = delegate
		{
		};

		public event Action<TTarget, TLobby> OnLobbyMemberChange = delegate
		{
		};

		public abstract Task<Result<INetworkTarget>> GetTargetFromJoinCode(JoinCode invite);

		public virtual bool CanHandleTarget(INetworkTarget target)
		{
			return target is TTarget;
		}

		public abstract INetworkTransport GetNewTransport(JoinCode join_code);

		public abstract Task<Result<INetworkTarget>> CanHandleInvite(NetworkInviteData data);

		public abstract Task<LobbyCreationResult> CreateNewLobby(JoinCode join_code, CancellationToken token);

		public abstract void LeaveLobby(TLobby lobby);

		public virtual void HandleHostDisconnect(TLobby lobby)
		{
			LeaveLobby(lobby);
		}

		public abstract Task<LobbyCreationResult> JoinLobby(TTarget target, CancellationToken token);

		public abstract void GetOtherLobbyMembers(TLobby lobby, ref List<TTarget> result);

		public abstract TTarget GetLobbyHost(TLobby lobby);

		public virtual Task<string> SetLobbyJoinCode(TLobby lobby, string[] candidates)
		{
			return Task.FromResult("");
		}

		public abstract void SetLobbyPermission(TLobby lobby, NetworkPermissions perms);

		public abstract bool IsValidLobby(TLobby lobby);

		public abstract string GetUsernameInLobby(TLobby lobby, TTarget user);

		protected virtual void ConnectToService()
		{
			if (State == PlatformState.Ready)
			{
				return;
			}
			Platform.Current.AddAccessRequest(NetworkAccessIdentifier);
			State = PlatformState.Starting;
			Task.Run(async delegate
			{
				try
				{
					State = ((await PerformConnectToService()) ? PlatformState.Ready : PlatformState.Failed);
				}
				catch (CancelledByUserException)
				{
					Events.Report(NetworkEvent.DisconnectingAfterUserCancellation);
					DisconnectFromService();
				}
				catch (NotPossibleException ex2)
				{
					Events.Report(NetworkEvent.DisconnectingAfterPermanentFailure, ex2);
					DisconnectFromService();
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					throw;
				}
			});
		}

		public virtual void DisconnectFromService()
		{
			Platform.Current.RemoveAccessRequest(NetworkAccessIdentifier);
			PerformDisconnectFromService();
			State = PlatformState.NotStarted;
			ShouldConnect = false;
		}

		protected virtual void Awake()
		{
			State = PlatformState.NotStarted;
			NetworkServices.Available.RemoveAll((INetworkService p) => p.GetType() == GetType());
			SetSingleton();
		}

		protected virtual void Update()
		{
			if (ConnectionMaintainer == null)
			{
				ConnectionMaintainer = new NetworkConnectionMaintainer(this);
			}
			PerformUpdate();
			bool num = State == PlatformState.NotStarted && ShouldConnect;
			bool flag = State == PlatformState.Failed && ConnectionMaintainer.ShouldReconnect();
			if (num || flag)
			{
				ConnectToService();
				return;
			}
			bool num2 = (State == PlatformState.Starting || State == PlatformState.Ready) && !ShouldConnect;
			bool flag2 = State == PlatformState.Ready && ConnectionMaintainer.ShouldTimeout();
			if (num2 || flag2)
			{
				DisconnectFromService();
			}
			else if (State == PlatformState.Ready && ShouldConnect)
			{
				PerformConnectedUpdate();
			}
		}

		private void OnDestroy()
		{
			DisconnectFromService();
		}

		public abstract TransportSendResult SendData(TLobby lobby, TTarget user, byte[] data);

		protected void HandleNetworkMessage(TTarget t, byte[] b)
		{
			this.OnNetworkMessage(t, b);
		}

		protected void HandleLobbyMemberChange(TTarget t, TLobby l)
		{
			this.OnLobbyMemberChange(t, l);
		}

		protected abstract void SetSingleton();

		protected virtual void PerformConnectedUpdate()
		{
		}

		protected virtual void PerformUpdate()
		{
		}

		protected abstract Task<bool> PerformConnectToService();

		protected abstract void PerformDisconnectFromService();

		public abstract bool IsInLobby(TLobby lobby);

		public virtual void KickFromLobby(TLobby current_lobby, TTarget t_target)
		{
		}
	}
}
