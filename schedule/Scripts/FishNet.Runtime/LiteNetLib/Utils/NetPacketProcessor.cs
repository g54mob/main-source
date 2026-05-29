using System;
using System.Collections.Generic;

namespace LiteNetLib.Utils
{
	public class NetPacketProcessor
	{
		private static class HashCache<T>
		{
			public static readonly ulong Id;

			static HashCache()
			{
			}
		}

		protected delegate void SubscribeDelegate(NetDataReader reader, object userData);

		private readonly NetSerializer _netSerializer;

		private readonly Dictionary<ulong, SubscribeDelegate> _callbacks;

		private readonly NetDataWriter _netDataWriter;

		public NetPacketProcessor()
		{
		}

		public NetPacketProcessor(int maxStringLength)
		{
		}

		protected virtual ulong GetHash<T>()
		{
			return 0uL;
		}

		protected virtual SubscribeDelegate GetCallbackFromData(NetDataReader reader)
		{
			return null;
		}

		protected virtual void WriteHash<T>(NetDataWriter writer)
		{
		}

		public void RegisterNestedType<T>() where T : struct, INetSerializable
		{
		}

		public void RegisterNestedType<T>(Action<NetDataWriter, T> writeDelegate, Func<NetDataReader, T> readDelegate)
		{
		}

		public void RegisterNestedType<T>(Func<T> constructor) where T : class, INetSerializable
		{
		}

		public void ReadAllPackets(NetDataReader reader)
		{
		}

		public void ReadAllPackets(NetDataReader reader, object userData)
		{
		}

		public void ReadPacket(NetDataReader reader)
		{
		}

		public void Send<T>(NetPeer peer, T packet, DeliveryMethod options) where T : class, new()
		{
		}

		public void SendNetSerializable<T>(NetPeer peer, ref T packet, DeliveryMethod options) where T : INetSerializable
		{
		}

		public void Send<T>(NetManager manager, T packet, DeliveryMethod options) where T : class, new()
		{
		}

		public void SendNetSerializable<T>(NetManager manager, ref T packet, DeliveryMethod options) where T : INetSerializable
		{
		}

		public void Write<T>(NetDataWriter writer, T packet) where T : class, new()
		{
		}

		public void WriteNetSerializable<T>(NetDataWriter writer, ref T packet) where T : INetSerializable
		{
		}

		public void ReadPacket(NetDataReader reader, object userData)
		{
		}

		public void Subscribe<T>(Action<T> onReceive, Func<T> packetConstructor) where T : class, new()
		{
		}

		public void Subscribe<T, TUserData>(Action<T, TUserData> onReceive, Func<T> packetConstructor) where T : class, new()
		{
		}

		public void SubscribeReusable<T>(Action<T> onReceive) where T : class, new()
		{
		}

		public void SubscribeReusable<T, TUserData>(Action<T, TUserData> onReceive) where T : class, new()
		{
		}

		public void SubscribeNetSerializable<T, TUserData>(Action<T, TUserData> onReceive, Func<T> packetConstructor) where T : INetSerializable
		{
		}

		public void SubscribeNetSerializable<T>(Action<T> onReceive, Func<T> packetConstructor) where T : INetSerializable
		{
		}

		public void SubscribeNetSerializable<T, TUserData>(Action<T, TUserData> onReceive) where T : INetSerializable, new()
		{
		}

		public void SubscribeNetSerializable<T>(Action<T> onReceive) where T : INetSerializable, new()
		{
		}

		public bool RemoveSubscription<T>()
		{
			return false;
		}
	}
}
