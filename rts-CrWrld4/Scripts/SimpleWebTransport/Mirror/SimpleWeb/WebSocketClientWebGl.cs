using System;
using System.Collections.Generic;

namespace Mirror.SimpleWeb
{
	public class WebSocketClientWebGl : SimpleWebClient
	{
		private static readonly Dictionary<int, WebSocketClientWebGl> instances;

		private int index;

		internal WebSocketClientWebGl(int maxMessageSize, int maxMessagesPerTick)
			: base(0, 0)
		{
		}

		public bool CheckJsConnected()
		{
			return false;
		}

		public override void Connect(Uri serverAddress)
		{
		}

		public override void Disconnect()
		{
		}

		public override void Send(ArraySegment<byte> segment)
		{
		}

		private void onOpen()
		{
		}

		private void onClose()
		{
		}

		private void onMessage(IntPtr bufferPtr, int count)
		{
		}

		private void onErr()
		{
		}

		private static void OpenCallback(int index)
		{
		}

		private static void CloseCallBack(int index)
		{
		}

		private static void MessageCallback(int index, IntPtr bufferPtr, int count)
		{
		}

		private static void ErrorCallback(int index)
		{
		}
	}
}
