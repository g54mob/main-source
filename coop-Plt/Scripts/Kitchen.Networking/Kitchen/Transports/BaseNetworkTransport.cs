using System;
using System.Collections.Generic;
using Kitchen.NetworkSupport;
using Platforms;

namespace Kitchen.Transports
{
	public abstract class BaseNetworkTransport<TTarget, TLobby> : INetworkTransport, ILiveness where TTarget : INetworkTarget
	{
		public NetworkTransportStats Stats = new NetworkTransportStats();

		public NetworkLiveness Liveness = new NetworkLiveness();

		protected bool IsDueLivenessRefresh;

		protected abstract BaseService<TTarget, TLobby> Service { get; }

		public abstract ConnectionType ConnectionType { get; }

		public abstract bool IsHosting { get; }

		public abstract TransportConnectionStatus ConnectionStatus { get; }

		public abstract TransportSendStatus SendStatus { get; }

		public bool IsLive => Liveness.IsLive;

		public bool IsGoodQuality => Liveness.IsGoodQuality;

		public virtual bool ShouldBeActive => true;

		public event Action<INetworkTarget, byte[]> OnReceive = delegate
		{
		};

		public bool IsValidTarget(INetworkTarget target)
		{
			return target is TTarget;
		}

		public virtual void Initialise()
		{
		}

		public virtual void Dispose()
		{
			EventLog.Networking.Report(NetworkEvent.TransportDisconnectDisposing);
			RequestDisconnect();
		}

		protected void ReportReceive(INetworkTarget target, byte[] data)
		{
			this.OnReceive(target, data);
		}

		public void RefreshLiveness()
		{
			IsDueLivenessRefresh = true;
		}

		protected void ApplyLivenessRefresh()
		{
			if (IsDueLivenessRefresh)
			{
				IsDueLivenessRefresh = false;
				Liveness.RefreshLiveness();
			}
		}

		public virtual void Update()
		{
			Stats.Update();
			ApplyLivenessRefresh();
		}

		public abstract TransportSendResult Send(byte[] data);

		public abstract bool RequestJoinServer(INetworkTarget target);

		public abstract void RequestStartServer();

		public abstract void RequestDisconnect();

		public abstract string GetTargetName(INetworkTarget target);

		public abstract void SupplyInviteData(ref NetworkInviteData invite_data);

		public abstract bool IsTargetConnected(INetworkTarget target);

		public abstract string GetDebugInfo();

		public abstract void GetConnectedPlayers(ref List<NetworkTargetDescription> users);

		public abstract void RequestKickUser(INetworkTarget target);

		public abstract void RequestBanUser(INetworkTarget target);

		public abstract void RequestSuspend();

		public abstract void RequestUnsuspend();
	}
}
