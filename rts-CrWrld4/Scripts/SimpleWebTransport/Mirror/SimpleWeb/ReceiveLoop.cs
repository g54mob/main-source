using System.Collections.Concurrent;

namespace Mirror.SimpleWeb
{
	internal static class ReceiveLoop
	{
		public struct Config
		{
			public readonly Connection conn;

			public readonly int maxMessageSize;

			public readonly bool expectMask;

			public readonly ConcurrentQueue<Message> queue;

			public readonly BufferPool bufferPool;

			public Config(Connection conn, int maxMessageSize, bool expectMask, ConcurrentQueue<Message> queue, BufferPool bufferPool)
			{
				this.conn = null;
				this.maxMessageSize = 0;
				this.expectMask = false;
				this.queue = null;
				this.bufferPool = null;
			}

			public void Deconstruct(out Connection conn, out int maxMessageSize, out bool expectMask, out ConcurrentQueue<Message> queue, out BufferPool bufferPool)
			{
				conn = null;
				maxMessageSize = default(int);
				expectMask = default(bool);
				queue = null;
				bufferPool = null;
			}
		}

		public static void Loop(Config config)
		{
		}

		private static void ReadOneMessage(Config config, byte[] buffer)
		{
		}

		private static void HandleArrayMessage(Config config, byte[] buffer, int msgOffset, int payloadLength)
		{
		}

		private static void HandleCloseMessage(Config config, byte[] buffer, int msgOffset, int payloadLength)
		{
		}

		private static string GetCloseMessage(byte[] buffer, int msgOffset, int payloadLength)
		{
			return null;
		}

		private static int GetCloseCode(byte[] buffer, int msgOffset)
		{
			return 0;
		}
	}
}
