using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mirror.RemoteCalls;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public sealed class NetworkIdentity : MonoBehaviour
	{
		public delegate void ClientAuthorityCallback(NetworkConnection conn, NetworkIdentity identity, bool authorityState);

		public Dictionary<int, NetworkConnection> observers;

		[HideInInspector]
		public ulong sceneId;

		public bool serverOnly;

		internal bool destroyCalled;

		private NetworkConnectionToClient _connectionToClient;

		public static readonly Dictionary<uint, NetworkIdentity> spawned;

		private NetworkBehaviour[] _NetworkBehaviours;

		private NetworkVisibility visibilityCache;

		public Visibility visible;

		[SerializeField]
		[HideInInspector]
		private string m_AssetId;

		private static readonly Dictionary<ulong, NetworkIdentity> sceneIds;

		private static uint nextNetworkId;

		[SerializeField]
		[HideInInspector]
		private bool hasSpawned;

		private bool clientStarted;

		private static NetworkIdentity previousLocalPlayer;

		private bool hadAuthority;

		public bool isClient { get; internal set; }

		public bool isServer { get; internal set; }

		public bool isLocalPlayer { get; internal set; }

		public bool isServerOnly => false;

		public bool isClientOnly => false;

		public bool hasAuthority { get; internal set; }

		public uint netId { get; internal set; }

		public NetworkConnection connectionToServer { get; internal set; }

		public NetworkConnectionToClient connectionToClient
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public NetworkBehaviour[] NetworkBehaviours => null;

		[Obsolete]
		public NetworkVisibility visibility => null;

		public Guid assetId
		{
			get
			{
				return default(Guid);
			}
			internal set
			{
			}
		}

		public bool SpawnedFromInstantiate { get; private set; }

		public static event ClientAuthorityCallback clientAuthorityCallback
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

		public static NetworkIdentity GetSceneIdentity(ulong id)
		{
			return null;
		}

		internal void SetClientOwner(NetworkConnection conn)
		{
		}

		internal static uint GetNextNetworkId()
		{
			return 0u;
		}

		public static void ResetNextNetworkId()
		{
		}

		internal void RemoveObserverInternal(NetworkConnection conn)
		{
		}

		private void Awake()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}

		internal void OnStartServer()
		{
		}

		internal void OnStopServer()
		{
		}

		internal void OnStartClient()
		{
		}

		internal void OnStopClient()
		{
		}

		internal void OnStartLocalPlayer()
		{
		}

		internal void NotifyAuthority()
		{
		}

		internal void OnStartAuthority()
		{
		}

		internal void OnStopAuthority()
		{
		}

		[Obsolete]
		public void RebuildObservers(bool initialize)
		{
		}

		internal void OnSetHostVisibility(bool visible)
		{
		}

		private bool OnSerializeSafely(NetworkBehaviour comp, NetworkWriter writer, bool initialState)
		{
			return false;
		}

		internal void OnSerializeAllSafely(bool initialState, NetworkWriter ownerWriter, out int ownerWritten, NetworkWriter observersWriter, out int observersWritten)
		{
			ownerWritten = default(int);
			observersWritten = default(int);
		}

		private void OnDeserializeSafely(NetworkBehaviour comp, NetworkReader reader, bool initialState)
		{
		}

		internal void OnDeserializeAllSafely(NetworkReader reader, bool initialState)
		{
		}

		internal void HandleRemoteCall(int componentIndex, int functionHash, MirrorInvokeType invokeType, NetworkReader reader, NetworkConnectionToClient senderConnection = null)
		{
		}

		internal CommandInfo GetCommandInfo(int componentIndex, int cmdHash)
		{
			return default(CommandInfo);
		}

		internal void ClearObservers()
		{
		}

		internal void AddObserver(NetworkConnection conn)
		{
		}

		public bool AssignClientAuthority(NetworkConnection conn)
		{
			return false;
		}

		public void RemoveClientAuthority()
		{
		}

		internal void Reset()
		{
		}

		internal void ClearAllComponentsDirtyBits()
		{
		}

		internal void ClearDirtyComponentsDirtyBits()
		{
		}

		private void ResetSyncObjects()
		{
		}
	}
}
