using System;
using System.Collections.Generic;
using Coherence.Common;
using Coherence.Plugins.NativeUtils;
using Coherence.Transport;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coherence
{
	[PreloadedSingleton]
	public class RuntimeSettings : PreloadedSingleton<RuntimeSettings>, IRuntimeSettings
	{
		[Serializable]
		public class AdvancedSettings
		{
			internal static bool Enabled;

			public ThreadResumerSettings ThreadResumer;
		}

		[SerializeField]
		private string schemaID;

		[SerializeField]
		private VersionInfo versionInfo;

		[SerializeField]
		private string runtimeKey;

		[SerializeField]
		private string simulatorSlug;

		[SerializeField]
		private string localHost;

		[SerializeField]
		[FormerlySerializedAs("localPort")]
		private int localWorldUDPPort;

		[SerializeField]
		private int localWorldWebPort;

		[SerializeField]
		private int remoteWebPort;

		[SerializeField]
		private int localRoomsUDPPort;

		[SerializeField]
		private int localRoomsWebPort;

		[SerializeField]
		[FormerlySerializedAs("roomsPort")]
		private int apiPort;

		[SerializeField]
		private int worldsAPIPort;

		[SerializeField]
		[Tooltip("Can be overriden via --coherence-multi-room-sim-host")]
		private string localHttpServerHost;

		[SerializeField]
		[Tooltip("Can be overriden via --coherence-multi-room-sim-port")]
		private int localHttpServerPort;

		[FormerlySerializedAs("allowLocal")]
		[SerializeField]
		private bool localDevelopmentMode;

		[SerializeField]
		private bool useDebugStreams;

		[SerializeField]
		private string organizationID;

		[SerializeField]
		private string projectID;

		[SerializeField]
		private string projectName;

		[SerializeField]
		private string organizationName;

		[SerializeField]
		private TransportType transportType;

		[SerializeField]
		private TransportConfiguration transportConfiguration;

		[SerializeField]
		private AdvancedSettings advancedSettings;

		[SerializeField]
		private string replicationServerToken;

		[SerializeField]
		[Tooltip("Can be overriden via --coherence-play-api-endpoint")]
		private string playApiEndpoint;

		[Tooltip("Generated from the API Endpoint")]
		private string webSocketEndpoint;

		[SerializeField]
		internal SchemaAsset[] schemas;

		[SerializeField]
		public SchemaAsset[] extraSchemas;

		[Obsolete("Use TransportType instead.")]
		[Deprecated("04/2024", 1, 3, 0, Reason = "Use TransportType instead.")]
		[SerializeField]
		[HideInInspector]
		internal DefaultTransportMode defaultTransportMode;

		[SerializeField]
		[HideInInspector]
		internal bool defaultTransportModeMigrated;

		[NonSerialized]
		private bool disableKeepAlive;

		public bool IsWebGL => false;

		public string ApiEndpoint => null;

		public string WebSocketEndpoint => null;

		public string LocalHost => null;

		public int LocalWorldUDPPort => 0;

		public int LocalWorldWebPort => 0;

		public int RemoteWebPort => 0;

		public int LocalRoomsUDPPort => 0;

		public int LocalRoomsWebPort => 0;

		public int APIPort => 0;

		public int WorldsAPIPort => 0;

		public string LocalHttpServerHost => null;

		public int LocalHttpServerPort => 0;

		public bool LocalDevelopmentMode => false;

		public bool UseDebugStreams => false;

		public AdvancedSettings Advanced => null;

		public string RuntimeKey
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string SimulatorSlug
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SchemaID
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public IVersionInfo VersionInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string OrganizationID
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string OrganizationName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string ProjectID
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string ProjectName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public TransportType TransportType
		{
			get
			{
				return default(TransportType);
			}
			internal set
			{
			}
		}

		public TransportConfiguration TransportConfiguration
		{
			get
			{
				return default(TransportConfiguration);
			}
			internal set
			{
			}
		}

		public string ReplicationServerToken
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public IReadOnlyCollection<SchemaAsset> DefaultSchemas => null;

		public string CombinedSchemaText { get; private set; }

		public bool DisableKeepAlive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Reset()
		{
		}

		protected override void OnEnable()
		{
		}

		private void Init()
		{
		}

		private static bool TryGetArg(string name, out string value)
		{
			value = null;
			return false;
		}

		private void LoadCliOverrides()
		{
		}

		public void SetApiEndpoint(string endpoint)
		{
		}

		public void SetRuntimeKey(string key)
		{
		}

		public void SetProjectID(string id)
		{
		}

		public void SetSchemaID(string id)
		{
		}

		public void SetApiPort(int port)
		{
		}
	}
}
