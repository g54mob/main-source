using System;
using BestHTTP.SocketIO.Transports;
using PlatformSupport.Collections.ObjectModel;
using PlatformSupport.Collections.Specialized;

namespace BestHTTP.SocketIO
{
	public sealed class SocketOptions
	{
		private float randomizationFactor;

		private ObservableDictionary<string, string> additionalQueryParams;

		public Func<SocketManager, Socket, string> Auth;

		private string BuiltQueryParams;

		public TransportTypes ConnectWith { get; set; }

		public bool Reconnection { get; set; }

		public int ReconnectionAttempts { get; set; }

		public TimeSpan ReconnectionDelay { get; set; }

		public TimeSpan ReconnectionDelayMax { get; set; }

		public float RandomizationFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TimeSpan Timeout { get; set; }

		public bool AutoConnect { get; set; }

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

		public HTTPRequestCallbackDelegate HTTPRequestCustomizationCallback { get; set; }

		public SupportedSocketIOVersions ServerVersion { get; set; }

		internal string BuildQueryParams()
		{
			return null;
		}

		private void AdditionalQueryParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}
	}
}
