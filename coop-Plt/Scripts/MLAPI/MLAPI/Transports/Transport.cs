using System;
using System.Collections.Generic;
using MLAPI.Transports.Tasks;
using UnityEngine;

namespace MLAPI.Transports
{
	public abstract class Transport : MonoBehaviour
	{
		public delegate void RequestChannelsDelegate(List<TransportChannel> channels);

		public delegate void TransportEventDelegate(NetEventType type, ulong clientId, string channelName, ArraySegment<byte> payload, float receiveTime);

		private TransportChannel[] _channelsCache;

		private TransportChannel[] MLAPI_INTERNAL_CHANNELS = new TransportChannel[7]
		{
			new TransportChannel
			{
				Name = "MLAPI_INTERNAL",
				Type = ChannelType.ReliableFragmentedSequenced
			},
			new TransportChannel
			{
				Name = "MLAPI_DEFAULT_MESSAGE",
				Type = ChannelType.Reliable
			},
			new TransportChannel
			{
				Name = "MLAPI_POSITION_UPDATE",
				Type = ChannelType.UnreliableSequenced
			},
			new TransportChannel
			{
				Name = "MLAPI_ANIMATION_UPDATE",
				Type = ChannelType.ReliableSequenced
			},
			new TransportChannel
			{
				Name = "MLAPI_NAV_AGENT_STATE",
				Type = ChannelType.ReliableSequenced
			},
			new TransportChannel
			{
				Name = "MLAPI_NAV_AGENT_CORRECTION",
				Type = ChannelType.UnreliableSequenced
			},
			new TransportChannel
			{
				Name = "MLAPI_TIME_SYNC",
				Type = ChannelType.Unreliable
			}
		};

		public abstract ulong ServerClientId { get; }

		public virtual bool IsSupported => true;

		public TransportChannel[] MLAPI_CHANNELS
		{
			get
			{
				if (_channelsCache == null)
				{
					List<TransportChannel> list = new List<TransportChannel>();
					if (this.OnChannelRegistration != null)
					{
						this.OnChannelRegistration(list);
					}
					_channelsCache = new TransportChannel[MLAPI_INTERNAL_CHANNELS.Length + list.Count];
					for (int i = 0; i < MLAPI_INTERNAL_CHANNELS.Length; i++)
					{
						_channelsCache[i] = MLAPI_INTERNAL_CHANNELS[i];
					}
					for (int j = 0; j < list.Count; j++)
					{
						_channelsCache[j + MLAPI_INTERNAL_CHANNELS.Length] = list[j];
					}
				}
				return _channelsCache;
			}
		}

		public event RequestChannelsDelegate OnChannelRegistration;

		public event TransportEventDelegate OnTransportEvent;

		internal void ResetChannelCache()
		{
			_channelsCache = null;
		}

		public abstract void Send(ulong clientId, ArraySegment<byte> data, string channelName);

		public abstract NetEventType PollEvent(out ulong clientId, out string channelName, out ArraySegment<byte> payload, out float receiveTime);

		public abstract SocketTasks StartClient();

		public abstract SocketTasks StartServer();

		public abstract void DisconnectRemoteClient(ulong clientId);

		public abstract void DisconnectLocalClient();

		public abstract ulong GetCurrentRtt(ulong clientId);

		public abstract void Shutdown();

		public abstract void Init();
	}
}
