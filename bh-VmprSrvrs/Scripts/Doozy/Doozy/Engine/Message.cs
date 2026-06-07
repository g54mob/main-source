using System;
using System.Collections.Generic;

namespace Doozy.Engine
{
	public class Message
	{
		public delegate void OnMessageHandleDelegate(Type callerType, Type handlerType, Type messageType, string messageName, string handlerMethodName);

		private const string TYPELESS_MESSAGE_PREFIX = "typeless ";

		private static readonly Dictionary<string, List<Delegate>> Handlers;

		public static OnMessageHandleDelegate OnMessageHandle;

		protected Message()
		{
		}

		public static void AddListener(string messageName, Action callback)
		{
		}

		public static void AddListener<T>(Action<T> callback) where T : Message
		{
		}

		public static void AddListener<T>(string messageName, Action<T> callback) where T : Message
		{
		}

		public static void RemoveListener(string messageName, Action callback)
		{
		}

		public static void RemoveListener<T>(Action<T> callback) where T : Message
		{
		}

		public static void RemoveListener<T>(string messageName, Action<T> callback) where T : Message
		{
		}

		public static void Send(string messageName)
		{
		}

		public static void Send<T>(T message) where T : Message
		{
		}

		public static void Send<T>(string messageName, T message) where T : Message
		{
		}

		private static void RegisterListener(string messageName, Delegate callback)
		{
		}

		private static void UnregisterListener(string messageName, Delegate callback)
		{
		}

		private static void SendMessage<T>(string messageName, T e) where T : Message
		{
		}
	}
}
