using System;
using System.Collections.Generic;
using MLAPI.Configuration;
using MLAPI.Internal;
using MLAPI.Logging;
using MLAPI.Profiling;
using MLAPI.Security;
using MLAPI.Serialization;

namespace MLAPI.Messaging
{
	internal static class InternalMessageSender
	{
		internal static void Send(ulong clientId, byte messageType, string channelName, BitStream messageStream, SecuritySendFlags flags, NetworkedObject targetObject)
		{
			messageStream.PadStream();
			if (NetworkingManager.Singleton.IsServer && clientId == NetworkingManager.Singleton.ServerClientId)
			{
				return;
			}
			if (targetObject != null && !targetObject.observers.Contains(clientId))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogWarning("Silently suppressed send call because it was directed to an object without visibility");
				}
				return;
			}
			using BitStream bitStream = MessagePacker.WrapMessage(messageType, clientId, messageStream, flags);
			NetworkProfiler.StartEvent(TickType.Send, (uint)bitStream.Length, channelName, MLAPIConstants.MESSAGE_NAMES[messageType]);
			NetworkingManager.Singleton.NetworkConfig.NetworkTransport.Send(clientId, new ArraySegment<byte>(bitStream.GetBuffer(), 0, (int)bitStream.Length), channelName);
			NetworkProfiler.EndEvent();
		}

		internal static void Send(byte messageType, string channelName, BitStream messageStream, SecuritySendFlags flags, NetworkedObject targetObject)
		{
			bool flag = (flags & SecuritySendFlags.Encrypted) == SecuritySendFlags.Encrypted && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
			bool flag2 = (flags & SecuritySendFlags.Authenticated) == SecuritySendFlags.Authenticated && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
			if (flag2 || flag)
			{
				for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
				{
					Send(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, messageType, channelName, messageStream, flags, targetObject);
				}
				return;
			}
			messageStream.PadStream();
			using BitStream bitStream = MessagePacker.WrapMessage(messageType, 0uL, messageStream, flags);
			NetworkProfiler.StartEvent(TickType.Send, (uint)bitStream.Length, channelName, MLAPIConstants.MESSAGE_NAMES[messageType]);
			for (int j = 0; j < NetworkingManager.Singleton.ConnectedClientsList.Count; j++)
			{
				if (NetworkingManager.Singleton.IsServer && NetworkingManager.Singleton.ConnectedClientsList[j].ClientId == NetworkingManager.Singleton.ServerClientId)
				{
					continue;
				}
				if (targetObject != null && !targetObject.observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogWarning("Silently suppressed send(all) call because it was directed to an object without visibility");
					}
				}
				else
				{
					NetworkingManager.Singleton.NetworkConfig.NetworkTransport.Send(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId, new ArraySegment<byte>(bitStream.GetBuffer(), 0, (int)bitStream.Length), channelName);
				}
			}
			NetworkProfiler.EndEvent();
		}

		internal static void Send(byte messageType, string channelName, List<ulong> clientIds, BitStream messageStream, SecuritySendFlags flags, NetworkedObject targetObject)
		{
			if (clientIds == null)
			{
				Send(messageType, channelName, messageStream, flags, targetObject);
				return;
			}
			bool flag = (flags & SecuritySendFlags.Encrypted) == SecuritySendFlags.Encrypted && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
			bool flag2 = (flags & SecuritySendFlags.Authenticated) == SecuritySendFlags.Authenticated && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
			if (flag2 || flag)
			{
				for (int i = 0; i < clientIds.Count; i++)
				{
					Send(clientIds[i], messageType, channelName, messageStream, flags, targetObject);
				}
				return;
			}
			messageStream.PadStream();
			using BitStream bitStream = MessagePacker.WrapMessage(messageType, 0uL, messageStream, flags);
			NetworkProfiler.StartEvent(TickType.Send, (uint)bitStream.Length, channelName, MLAPIConstants.MESSAGE_NAMES[messageType]);
			for (int j = 0; j < clientIds.Count; j++)
			{
				if (NetworkingManager.Singleton.IsServer && clientIds[j] == NetworkingManager.Singleton.ServerClientId)
				{
					continue;
				}
				if (targetObject != null && !targetObject.observers.Contains(clientIds[j]))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogWarning("Silently suppressed send(all) call because it was directed to an object without visibility");
					}
				}
				else
				{
					NetworkingManager.Singleton.NetworkConfig.NetworkTransport.Send(clientIds[j], new ArraySegment<byte>(bitStream.GetBuffer(), 0, (int)bitStream.Length), channelName);
				}
			}
			NetworkProfiler.EndEvent();
		}

		internal static void Send(byte messageType, string channelName, ulong clientIdToIgnore, BitStream messageStream, SecuritySendFlags flags, NetworkedObject targetObject)
		{
			bool flag = (flags & SecuritySendFlags.Encrypted) == SecuritySendFlags.Encrypted && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
			bool flag2 = (flags & SecuritySendFlags.Authenticated) == SecuritySendFlags.Authenticated && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
			if (flag || flag2)
			{
				for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
				{
					if (NetworkingManager.Singleton.ConnectedClientsList[i].ClientId != clientIdToIgnore)
					{
						Send(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, messageType, channelName, messageStream, flags, targetObject);
					}
				}
				return;
			}
			messageStream.PadStream();
			using BitStream bitStream = MessagePacker.WrapMessage(messageType, 0uL, messageStream, flags);
			NetworkProfiler.StartEvent(TickType.Send, (uint)bitStream.Length, channelName, MLAPIConstants.MESSAGE_NAMES[messageType]);
			for (int j = 0; j < NetworkingManager.Singleton.ConnectedClientsList.Count; j++)
			{
				if (NetworkingManager.Singleton.ConnectedClientsList[j].ClientId == clientIdToIgnore || (NetworkingManager.Singleton.IsServer && NetworkingManager.Singleton.ConnectedClientsList[j].ClientId == NetworkingManager.Singleton.ServerClientId))
				{
					continue;
				}
				if (targetObject != null && !targetObject.observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogWarning("Silently suppressed send(ignore) call because it was directed to an object without visibility");
					}
				}
				else
				{
					NetworkingManager.Singleton.NetworkConfig.NetworkTransport.Send(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId, new ArraySegment<byte>(bitStream.GetBuffer(), 0, (int)bitStream.Length), channelName);
				}
			}
			NetworkProfiler.EndEvent();
		}
	}
}
