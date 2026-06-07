using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BestHTTP.Connections;
using BestHTTP.Extensions;
using BestHTTP.SignalR.Authentication;
using BestHTTP.SignalR.Hubs;
using BestHTTP.SignalR.JsonEncoders;
using BestHTTP.SignalR.Messages;
using BestHTTP.SignalR.Transports;
using PlatformSupport.Collections.ObjectModel;
using PlatformSupport.Collections.Specialized;

namespace BestHTTP.SignalR
{
	public sealed class Connection : IHeartbeat, IConnection
	{
		public static IJsonEncoder DefaultEncoder;

		private ConnectionStates _state;

		private ObservableDictionary<string, string> additionalQueryParams;

		internal long ClientMessageCounter;

		private readonly string[] ClientProtocols;

		private long RequestCounter;

		private MultiMessage LastReceivedMessage;

		private string GroupsToken;

		private List<IServerMessage> BufferedMessages;

		private DateTime LastMessageReceivedAt;

		private DateTime ReconnectStartedAt;

		private DateTime ReconnectDelayStartedAt;

		private bool ReconnectStarted;

		private DateTime LastPingSentAt;

		private HTTPRequest PingRequest;

		private DateTime? TransportConnectionStartedAt;

		private StringBuilder queryBuilder;

		private string BuiltConnectionData;

		private string BuiltQueryParams;

		private SupportedProtocols NextProtocolToTry;

		public Uri Uri { get; private set; }

		public ConnectionStates State
		{
			get
			{
				return default(ConnectionStates);
			}
			private set
			{
			}
		}

		public NegotiationData NegotiationResult { get; private set; }

		public Hub[] Hubs { get; private set; }

		public TransportBase Transport { get; private set; }

		public ProtocolVersions Protocol { get; private set; }

		public ObservableDictionary<string, string> AdditionalQueryParams
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool QueryParamsOnlyForHandshake { get; set; }

		public IJsonEncoder JsonEncoder { get; set; }

		public IAuthenticationProvider AuthenticationProvider { get; set; }

		public TimeSpan PingInterval { get; set; }

		public TimeSpan ReconnectDelay { get; set; }

		public OnPrepareRequestDelegate RequestPreparator { get; set; }

		public Hub Item => null;

		public Hub Item => null;

		private uint Timestamp => 0u;

		private string ConnectionData => null;

		private string QueryParams => null;

		public event OnConnectedDelegate OnConnected
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

		public event OnClosedDelegate OnClosed
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

		public event OnErrorDelegate OnError
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

		public event OnConnectedDelegate OnReconnecting
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

		public event OnConnectedDelegate OnReconnected
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

		public event OnStateChanged OnStateChanged
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

		public event OnNonHubMessageDelegate OnNonHubMessage
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

		public Connection(Uri uri, params string[] hubNames)
		{
		}

		public Connection(Uri uri, params Hub[] hubs)
		{
		}

		public Connection(Uri uri)
		{
		}

		public void Open()
		{
		}

		private void OnAuthenticationSucceded(IAuthenticationProvider provider)
		{
		}

		private void OnAuthenticationFailed(IAuthenticationProvider provider, string reason)
		{
		}

		private void StartImpl()
		{
		}

		private void OnNegotiationDataReceived(NegotiationData data)
		{
		}

		private void OnNegotiationError(NegotiationData data, string error)
		{
		}

		public void Close()
		{
		}

		public void Reconnect()
		{
		}

		public bool Send(object arg)
		{
			return false;
		}

		public bool SendJson(string json)
		{
			return false;
		}

		void IConnection.OnMessage(IServerMessage msg)
		{
		}

		void IConnection.TransportStarted()
		{
		}

		void IConnection.TransportReconnected()
		{
		}

		void IConnection.TransportAborted()
		{
		}

		void IConnection.Error(string reason)
		{
		}

		Uri IConnection.BuildUri(RequestTypes type)
		{
			return null;
		}

		Uri IConnection.BuildUri(RequestTypes type, TransportBase transport)
		{
			return null;
		}

		HTTPRequest IConnection.PrepareRequest(HTTPRequest req, RequestTypes type)
		{
			return null;
		}

		string IConnection.ParseResponse(string responseStr)
		{
			return null;
		}

		void IHeartbeat.OnHeartbeatUpdate(TimeSpan dif)
		{
		}

		private void InitOnStart()
		{
		}

		private Hub FindHub(ulong msgId)
		{
			return null;
		}

		private bool TryFallbackTransport()
		{
			return false;
		}

		private void AdditionalQueryParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		private void Ping()
		{
		}

		private void OnPingRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}
	}
}
