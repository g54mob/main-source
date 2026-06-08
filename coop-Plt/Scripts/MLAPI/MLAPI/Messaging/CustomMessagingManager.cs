using System.Collections.Generic;
using System.IO;
using MLAPI.Configuration;
using MLAPI.Hashing;
using MLAPI.Logging;
using MLAPI.Security;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;

namespace MLAPI.Messaging
{
	public static class CustomMessagingManager
	{
		public delegate void UnnamedMessageDelegate(ulong clientId, Stream stream);

		public delegate void HandleNamedMessageDelegate(ulong sender, Stream payload);

		private static readonly Dictionary<ulong, HandleNamedMessageDelegate> namedMessageHandlers16 = new Dictionary<ulong, HandleNamedMessageDelegate>();

		private static readonly Dictionary<ulong, HandleNamedMessageDelegate> namedMessageHandlers32 = new Dictionary<ulong, HandleNamedMessageDelegate>();

		private static readonly Dictionary<ulong, HandleNamedMessageDelegate> namedMessageHandlers64 = new Dictionary<ulong, HandleNamedMessageDelegate>();

		public static event UnnamedMessageDelegate OnUnnamedMessage;

		internal static void InvokeUnnamedMessage(ulong clientId, Stream stream)
		{
			if (CustomMessagingManager.OnUnnamedMessage != null)
			{
				CustomMessagingManager.OnUnnamedMessage(clientId, stream);
			}
			NetworkingManager.Singleton.InvokeOnIncomingCustomMessage(clientId, stream);
		}

		public static void SendUnnamedMessage(List<ulong> clientIds, BitStream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogWarning("Can not send unnamed messages to multiple users as a client");
				}
			}
			else
			{
				InternalMessageSender.Send(20, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, clientIds, stream, security, null);
			}
		}

		public static void SendUnnamedMessage(ulong clientId, BitStream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			InternalMessageSender.Send(clientId, 20, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, stream, security, null);
		}

		internal static void InvokeNamedMessage(ulong hash, ulong sender, Stream stream)
		{
			if (NetworkingManager.Singleton == null)
			{
				if (namedMessageHandlers16.ContainsKey(hash))
				{
					namedMessageHandlers16[hash](sender, stream);
				}
				if (namedMessageHandlers32.ContainsKey(hash))
				{
					namedMessageHandlers32[hash](sender, stream);
				}
				if (namedMessageHandlers64.ContainsKey(hash))
				{
					namedMessageHandlers64[hash](sender, stream);
				}
			}
			else if (NetworkingManager.Singleton.NetworkConfig.RpcHashSize == HashSize.VarIntTwoBytes)
			{
				if (namedMessageHandlers16.ContainsKey(hash))
				{
					namedMessageHandlers16[hash](sender, stream);
				}
			}
			else if (NetworkingManager.Singleton.NetworkConfig.RpcHashSize == HashSize.VarIntFourBytes)
			{
				if (namedMessageHandlers32.ContainsKey(hash))
				{
					namedMessageHandlers32[hash](sender, stream);
				}
			}
			else if (NetworkingManager.Singleton.NetworkConfig.RpcHashSize == HashSize.VarIntEightBytes && namedMessageHandlers64.ContainsKey(hash))
			{
				namedMessageHandlers64[hash](sender, stream);
			}
		}

		public static void RegisterNamedMessageHandler(string name, HandleNamedMessageDelegate callback)
		{
			namedMessageHandlers16[name.GetStableHash16()] = callback;
			namedMessageHandlers32[name.GetStableHash32()] = callback;
			namedMessageHandlers64[name.GetStableHash64()] = callback;
		}

		public static void UnregisterNamedMessageHandler(string name)
		{
			namedMessageHandlers16.Remove(name.GetStableHash16());
			namedMessageHandlers32.Remove(name.GetStableHash32());
			namedMessageHandlers64.Remove(name.GetStableHash64());
		}

		public static void SendNamedMessage(string name, ulong clientId, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			ulong value = NetworkedBehaviour.HashMethodName(name);
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				pooledBitWriter.WriteUInt64Packed(value);
			}
			pooledBitStream.CopyFrom(stream);
			InternalMessageSender.Send(clientId, 22, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, pooledBitStream, security, null);
		}

		public static void SendNamedMessage(string name, List<ulong> clientIds, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			ulong value = NetworkedBehaviour.HashMethodName(name);
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				pooledBitWriter.WriteUInt64Packed(value);
			}
			pooledBitStream.CopyFrom(stream);
			if (!NetworkingManager.Singleton.IsServer)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogWarning("Can not send named messages to multiple users as a client");
				}
			}
			else
			{
				InternalMessageSender.Send(22, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, clientIds, pooledBitStream, security, null);
			}
		}
	}
}
