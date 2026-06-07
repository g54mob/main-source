using System;
using System.Security.Cryptography;

namespace Mirror.SimpleWeb
{
	internal static class SendLoop
	{
		public struct Config
		{
			public readonly Connection conn;

			public readonly int bufferSize;

			public readonly bool setMask;

			public Config(Connection conn, int bufferSize, bool setMask)
			{
				this.conn = null;
				this.bufferSize = 0;
				this.setMask = false;
			}

			public void Deconstruct(out Connection conn, out int bufferSize, out bool setMask)
			{
				conn = null;
				bufferSize = default(int);
				setMask = default(bool);
			}
		}

		private sealed class MaskHelper : IDisposable
		{
			private readonly byte[] maskBuffer;

			private readonly RNGCryptoServiceProvider random;

			public void Dispose()
			{
			}

			public int WriteMask(byte[] buffer, int offset)
			{
				return 0;
			}
		}

		public static void Loop(Config config)
		{
		}

		private static int SendMessage(byte[] buffer, int startOffset, ArrayBuffer msg, bool setMask, MaskHelper maskHelper)
		{
			return 0;
		}

		private static int WriteHeader(byte[] buffer, int startOffset, int msgLength, bool setMask)
		{
			return 0;
		}
	}
}
