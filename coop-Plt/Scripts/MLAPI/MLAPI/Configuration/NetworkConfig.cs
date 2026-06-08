using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MLAPI.Hashing;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;
using MLAPI.Transports;
using UnityEngine;
using UnityEngine.Serialization;

namespace MLAPI.Configuration
{
	[Serializable]
	public class NetworkConfig
	{
		[Tooltip("Use this to make two builds incompatible with each other")]
		public ushort ProtocolVersion;

		[Tooltip("The NetworkTransport to use")]
		public Transport NetworkTransport;

		[Tooltip("The Scenes that can be switched to by the server")]
		public List<string> RegisteredScenes = new List<string>();

		[Tooltip("Whether or not runtime scene changes should be allowed and expected.\n If this is true, clients with different initial configurations will not work together.")]
		public bool AllowRuntimeSceneChanges;

		[Tooltip("The prefabs that can be spawned across the network")]
		public List<NetworkedPrefab> NetworkedPrefabs = new List<NetworkedPrefab>();

		[SerializeField]
		internal NullableBoolSerializable PlayerPrefabHash;

		[Tooltip("Whether or not a player object should be created by default. This value can be overriden on a case by case basis with ConnectionApproval.")]
		public bool CreatePlayerPrefab = true;

		[Tooltip("The amount of times per second the receive queue is emptied from pending incoming messages")]
		public int ReceiveTickrate = 64;

		[Tooltip("The maximum amount of Receive events to poll per Receive tick. This is to prevent flooding and freezing on the server")]
		public int MaxReceiveEventsPerTickRate = 500;

		[Tooltip("The amount of times per second the internal event loop will run. This includes for example NetworkedVar checking and LagCompensation tracking")]
		public int EventTickrate = 64;

		[FormerlySerializedAs("MaxBehaviourUpdatesPerTick")]
		[Tooltip("The maximum amount of NetworkedObject SyncedVars to process per Event tick. This is to prevent freezing")]
		public int MaxObjectUpdatesPerTick = -1;

		[Tooltip("The amount of seconds to wait for the handshake to complete before the client times out")]
		public int ClientConnectionBufferTimeout = 10;

		[Tooltip("Whether or not to force clients to be approved before they connect")]
		public bool ConnectionApproval;

		[Tooltip("The connection data sent along with connection requests")]
		public byte[] ConnectionData = new byte[0];

		[Tooltip("The amount of seconds to keep lag compensation position history")]
		public int SecondsHistory = 5;

		[Tooltip("Enable this to resync the NetworkedTime after the initial sync")]
		public bool EnableTimeResync;

		[Tooltip("The amount of seconds between resyncs of NetworkedTime, if enabled")]
		public int TimeResyncInterval = 30;

		[Tooltip("Whether or not to enable the NetworkedVar system")]
		public bool EnableNetworkedVar = true;

		[Tooltip("Ensures that NetworkedVars can be read even if a client accidental writes where its not allowed to. This will cost some CPU time and bandwidth")]
		public bool EnsureNetworkedVarLengthSafety;

		[Tooltip("Enables scene management. This will allow network scene switches and automatic scene diff corrections upon connect.\nSoftSynced scene objects wont work with this disabled. That means that disabling SceneManagement also enables PrefabSync.")]
		public bool EnableSceneManagement = true;

		[Tooltip("Whether or not the MLAPI should check for differences in the prefab lists at connection")]
		public bool ForceSamePrefabs = true;

		[Tooltip("If true, all NetworkedObject's need to be prefabs and all scene objects will be replaced on server side which causes all serialization to be lost. Useful for multi project setups\nIf false, Only non scene objects have to be prefabs. Scene objects will be matched using their PrefabInstanceId which can be precomputed globally for a scene at build time. Useful for single projects")]
		public bool UsePrefabSync;

		[Tooltip("If true, NetworkIds will be reused after the NetworkIdRecycleDelay")]
		public bool RecycleNetworkIds = true;

		[Tooltip("The amount of seconds a NetworkId has to unused in order for it to be reused")]
		public float NetworkIdRecycleDelay = 120f;

		[Tooltip("The maximum amount of bytes to use for RPC messages. Leave this to 2 unless you are facing hash collisions")]
		public HashSize RpcHashSize;

		[Tooltip("The amount of seconds to wait for all clients to load a requested scene")]
		public int LoadSceneTimeOut = 120;

		[Tooltip("Whether or not message buffering should be enabled. This will resolve most out of order messages during spawn")]
		public bool EnableMessageBuffering = true;

		[Tooltip("The amount of time a message should be buffered for without being consumed. If it is not consumed within this time, it will be dropped")]
		public float MessageBufferTimeout = 20f;

		public bool EnableNetworkLogs = true;

		[Tooltip("Whether or not to enable the ECDHE key exchange to allow for encryption and authentication of messages")]
		public bool EnableEncryption;

		[Tooltip("Whether or not to sign the diffie hellman key exchange to prevent MITM attacks on")]
		public bool SignKeyExchange;

		[Tooltip("The certificate in base64 encoded PFX format")]
		[TextArea]
		public string ServerBase64PfxCertificate;

		private X509Certificate2 serverX509Certificate;

		private byte[] serverX509CertificateBytes;

		private ulong? ConfigHash;

		public X509Certificate2 ServerX509Certificate
		{
			get
			{
				return serverX509Certificate;
			}
			internal set
			{
				serverX509CertificateBytes = null;
				serverX509Certificate = value;
			}
		}

		public byte[] ServerX509CertificateBytes
		{
			get
			{
				if (serverX509CertificateBytes == null)
				{
					serverX509CertificateBytes = ServerX509Certificate.Export(X509ContentType.Cert);
				}
				return serverX509CertificateBytes;
			}
		}

		private void Sort()
		{
			RegisteredScenes.Sort(StringComparer.Ordinal);
		}

		public string ToBase64()
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt16Packed(ProtocolVersion);
			pooledBitWriter.WriteUInt16Packed((ushort)RegisteredScenes.Count);
			for (int i = 0; i < RegisteredScenes.Count; i++)
			{
				pooledBitWriter.WriteString(RegisteredScenes[i]);
			}
			pooledBitWriter.WriteInt32Packed(ReceiveTickrate);
			pooledBitWriter.WriteInt32Packed(MaxReceiveEventsPerTickRate);
			pooledBitWriter.WriteInt32Packed(EventTickrate);
			pooledBitWriter.WriteInt32Packed(ClientConnectionBufferTimeout);
			pooledBitWriter.WriteBool(ConnectionApproval);
			pooledBitWriter.WriteInt32Packed(SecondsHistory);
			pooledBitWriter.WriteBool(EnableEncryption);
			pooledBitWriter.WriteBool(SignKeyExchange);
			pooledBitWriter.WriteInt32Packed(LoadSceneTimeOut);
			pooledBitWriter.WriteBool(EnableTimeResync);
			pooledBitWriter.WriteBool(EnsureNetworkedVarLengthSafety);
			pooledBitWriter.WriteBits((byte)RpcHashSize, 2);
			pooledBitWriter.WriteBool(ForceSamePrefabs);
			pooledBitWriter.WriteBool(UsePrefabSync);
			pooledBitWriter.WriteBool(EnableSceneManagement);
			pooledBitWriter.WriteBool(RecycleNetworkIds);
			pooledBitWriter.WriteSinglePacked(NetworkIdRecycleDelay);
			pooledBitWriter.WriteBool(EnableNetworkedVar);
			pooledBitWriter.WriteBool(AllowRuntimeSceneChanges);
			pooledBitWriter.WriteBool(EnableNetworkLogs);
			pooledBitStream.PadStream();
			return Convert.ToBase64String(pooledBitStream.ToArray());
		}

		public void FromBase64(string base64)
		{
			byte[] target = Convert.FromBase64String(base64);
			using BitStream stream = new BitStream(target);
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ProtocolVersion = pooledBitReader.ReadUInt16Packed();
			ushort num = pooledBitReader.ReadUInt16Packed();
			RegisteredScenes.Clear();
			for (int i = 0; i < num; i++)
			{
				RegisteredScenes.Add(pooledBitReader.ReadString().ToString());
			}
			ReceiveTickrate = pooledBitReader.ReadInt32Packed();
			MaxReceiveEventsPerTickRate = pooledBitReader.ReadInt32Packed();
			EventTickrate = pooledBitReader.ReadInt32Packed();
			ClientConnectionBufferTimeout = pooledBitReader.ReadInt32Packed();
			ConnectionApproval = pooledBitReader.ReadBool();
			SecondsHistory = pooledBitReader.ReadInt32Packed();
			EnableEncryption = pooledBitReader.ReadBool();
			SignKeyExchange = pooledBitReader.ReadBool();
			LoadSceneTimeOut = pooledBitReader.ReadInt32Packed();
			EnableTimeResync = pooledBitReader.ReadBool();
			EnsureNetworkedVarLengthSafety = pooledBitReader.ReadBool();
			RpcHashSize = (HashSize)pooledBitReader.ReadBits(2);
			ForceSamePrefabs = pooledBitReader.ReadBool();
			UsePrefabSync = pooledBitReader.ReadBool();
			EnableSceneManagement = pooledBitReader.ReadBool();
			RecycleNetworkIds = pooledBitReader.ReadBool();
			NetworkIdRecycleDelay = pooledBitReader.ReadSinglePacked();
			EnableNetworkedVar = pooledBitReader.ReadBool();
			AllowRuntimeSceneChanges = pooledBitReader.ReadBool();
			EnableNetworkLogs = pooledBitReader.ReadBool();
		}

		public ulong GetConfig(bool cache = true)
		{
			if (ConfigHash.HasValue && cache)
			{
				return ConfigHash.Value;
			}
			Sort();
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt16Packed(ProtocolVersion);
			pooledBitWriter.WriteString("12.0.0");
			if (EnableSceneManagement && !AllowRuntimeSceneChanges)
			{
				for (int i = 0; i < RegisteredScenes.Count; i++)
				{
					pooledBitWriter.WriteString(RegisteredScenes[i]);
				}
			}
			if (ForceSamePrefabs)
			{
				List<NetworkedPrefab> list = NetworkedPrefabs.OrderBy((NetworkedPrefab x) => x.Hash).ToList();
				for (int num = 0; num < list.Count; num++)
				{
					pooledBitWriter.WriteUInt64Packed(list[num].Hash);
				}
			}
			pooledBitWriter.WriteBool(EnableNetworkedVar);
			pooledBitWriter.WriteBool(ForceSamePrefabs);
			pooledBitWriter.WriteBool(UsePrefabSync);
			pooledBitWriter.WriteBool(EnableSceneManagement);
			pooledBitWriter.WriteBool(EnsureNetworkedVarLengthSafety);
			pooledBitWriter.WriteBool(EnableEncryption);
			pooledBitWriter.WriteBool(SignKeyExchange);
			pooledBitWriter.WriteBits((byte)RpcHashSize, 2);
			pooledBitStream.PadStream();
			if (cache)
			{
				ConfigHash = pooledBitStream.ToArray().GetStableHash64();
				return ConfigHash.Value;
			}
			return pooledBitStream.ToArray().GetStableHash64();
		}

		public bool CompareConfig(ulong hash)
		{
			return hash == GetConfig();
		}
	}
}
