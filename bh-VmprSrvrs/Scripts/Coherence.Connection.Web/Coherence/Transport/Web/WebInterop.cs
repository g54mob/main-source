using System;
using System.Collections.Generic;
using AOT;
using Coherence.Log;
using Newtonsoft.Json;

namespace Coherence.Transport.Web
{
	public static class WebInterop
	{
		private static readonly Logger logger;

		private static readonly Dictionary<int, WebCallbacks> callbacks;

		private static readonly JsonSerializerSettings jsErrorSerializationSettings;

		public static void WebConnect(int id, string host, int roomId, string token, string uniqueRoomId, string worldId, string region, string schemaId)
		{
		}

		public static void WebDisconnect(int id)
		{
		}

		public static void WebSend(int id, byte[] data, int size)
		{
		}

		private static int WebInitialize(OnConnectCallback onConnect, OnPacketCallback onPacket, OnErrorCallback onError)
		{
			return 0;
		}

		public static int InitializeConnection(Action onOpen, Action<byte[]> onPacket, Action<JsError> onError)
		{
			return 0;
		}

		[MonoPInvokeCallback(typeof(OnConnectCallback))]
		private static void OnConnect(int id)
		{
		}

		[MonoPInvokeCallback(typeof(OnPacketCallback))]
		private static void OnPacket(int id, int length, IntPtr ptr)
		{
		}

		[MonoPInvokeCallback(typeof(OnErrorCallback))]
		private static void OnError(int id, string errorJson)
		{
		}
	}
}
