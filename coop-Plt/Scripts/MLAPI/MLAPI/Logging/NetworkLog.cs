using MLAPI.Messaging;
using MLAPI.Security;
using MLAPI.Serialization.Pooled;
using UnityEngine;

namespace MLAPI.Logging
{
	public static class NetworkLog
	{
		internal enum LogType
		{
			Info = 0,
			Warning = 1,
			Error = 2,
			None = 3
		}

		internal static LogLevel CurrentLogLevel
		{
			get
			{
				if (NetworkingManager.Singleton == null)
				{
					return LogLevel.Normal;
				}
				return NetworkingManager.Singleton.LogLevel;
			}
		}

		internal static void LogInfo(string message)
		{
			Debug.Log("[MLAPI] " + message);
		}

		internal static void LogWarning(string message)
		{
			Debug.LogWarning("[MLAPI] " + message);
		}

		internal static void LogError(string message)
		{
			Debug.LogError("[MLAPI] " + message);
		}

		public static void LogInfoServer(string message)
		{
			LogServer(message, LogType.Info);
		}

		public static void LogWarningServer(string message)
		{
			LogServer(message, LogType.Warning);
		}

		public static void LogErrorServer(string message)
		{
			LogServer(message, LogType.Error);
		}

		private static void LogServer(string message, LogType logType)
		{
			ulong sender = ((NetworkingManager.Singleton != null) ? NetworkingManager.Singleton.LocalClientId : 0);
			switch (logType)
			{
			case LogType.Info:
				LogInfoServerLocal(message, sender);
				break;
			case LogType.Warning:
				LogWarningServerLocal(message, sender);
				break;
			case LogType.Error:
				LogErrorServerLocal(message, sender);
				break;
			}
			if (!(NetworkingManager.Singleton != null) || NetworkingManager.Singleton.IsServer || !NetworkingManager.Singleton.NetworkConfig.EnableNetworkLogs)
			{
				return;
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteByte((byte)logType);
			pooledBitWriter.WriteStringPacked(message);
			InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 24, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		internal static void LogInfoServerLocal(string message, ulong sender)
		{
			Debug.Log("[MLAPI_SERVER Sender=" + sender + "] " + message);
		}

		internal static void LogWarningServerLocal(string message, ulong sender)
		{
			Debug.LogWarning("[MLAPI_SERVER Sender=" + sender + "] " + message);
		}

		internal static void LogErrorServerLocal(string message, ulong sender)
		{
			Debug.LogError("[MLAPI_SERVER Sender=" + sender + "] " + message);
		}
	}
}
