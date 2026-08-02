using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Mirror.SimpleWeb
{
	internal class ServerHandshake
	{
		private const int GetSize = 3;

		private const int ResponseLength = 129;

		private const int KeyLength = 24;

		private const int MergedKeyLength = 60;

		private const string KeyHeaderString = "\r\nSec-WebSocket-Key: ";

		private readonly int maxHttpHeaderSize = 3000;

		private readonly SHA1 sha1 = SHA1.Create();

		private readonly BufferPool bufferPool;

		public ServerHandshake(BufferPool bufferPool, int handshakeMaxSize)
		{
			this.bufferPool = bufferPool;
			maxHttpHeaderSize = handshakeMaxSize;
		}

		~ServerHandshake()
		{
			sha1.Dispose();
		}

		public bool TryHandshake(Connection conn)
		{
			Stream stream = conn.stream;
			using (ArrayBuffer arrayBuffer = bufferPool.Take(3))
			{
				if (!ReadHelper.TryRead(stream, arrayBuffer.array, 0, 3))
				{
					return false;
				}
				arrayBuffer.count = 3;
				if (!IsGet(arrayBuffer.array))
				{
					Log.Warn("[SimpleWebTransport] First bytes from client was not 'GET' for handshake, instead was " + Log.BufferToString(arrayBuffer.array, 0, 3), showColor: false);
					return false;
				}
			}
			string text = ReadToEndForHandshake(stream);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			try
			{
				AcceptHandshake(stream, text);
				conn.request = new Request(text);
				conn.remoteAddress = conn.CalculateAddress();
				return true;
			}
			catch (ArgumentException e)
			{
				Log.InfoException(e);
				return false;
			}
		}

		private string ReadToEndForHandshake(Stream stream)
		{
			using ArrayBuffer arrayBuffer = bufferPool.Take(maxHttpHeaderSize);
			int? num = ReadHelper.SafeReadTillMatch(stream, arrayBuffer.array, 0, maxHttpHeaderSize, Constants.endOfHandshake);
			if (!num.HasValue)
			{
				return null;
			}
			int value = num.Value;
			string text = Encoding.ASCII.GetString(arrayBuffer.array, 0, value);
			text = "GET" + text;
			Log.Info("Client Handshake Message:\r\n" + text, showColor: false);
			return text;
		}

		private static bool IsGet(byte[] getHeader)
		{
			if (getHeader[0] == 71 && getHeader[1] == 69)
			{
				return getHeader[2] == 84;
			}
			return false;
		}

		private void AcceptHandshake(Stream stream, string msg)
		{
			using ArrayBuffer arrayBuffer = bufferPool.Take(24 + Constants.HandshakeGUIDLength);
			using ArrayBuffer arrayBuffer2 = bufferPool.Take(129);
			GetKey(msg, arrayBuffer.array);
			AppendGuid(arrayBuffer.array);
			CreateResponse(CreateHash(arrayBuffer.array), arrayBuffer2.array);
			stream.Write(arrayBuffer2.array, 0, 129);
		}

		private static void GetKey(string msg, byte[] keyBuffer)
		{
			int num = msg.IndexOf("\r\nSec-WebSocket-Key: ", StringComparison.InvariantCultureIgnoreCase) + "\r\nSec-WebSocket-Key: ".Length;
			Log.Verbose("[SimpleWebTransport] Handshake Key: " + msg.Substring(num, 24), showColor: false);
			Encoding.ASCII.GetBytes(msg, num, 24, keyBuffer, 0);
		}

		private static void AppendGuid(byte[] keyBuffer)
		{
			Buffer.BlockCopy(Constants.HandshakeGUIDBytes, 0, keyBuffer, 24, Constants.HandshakeGUIDLength);
		}

		private byte[] CreateHash(byte[] keyBuffer)
		{
			Log.Verbose("[SimpleWebTransport] Handshake Hashing " + Encoding.ASCII.GetString(keyBuffer, 0, 60), showColor: false);
			return sha1.ComputeHash(keyBuffer, 0, 60);
		}

		private static void CreateResponse(byte[] keyHash, byte[] responseBuffer)
		{
			string arg = Convert.ToBase64String(keyHash);
			string text = $"HTTP/1.1 101 Switching Protocols\r\nConnection: Upgrade\r\nUpgrade: websocket\r\nSec-WebSocket-Accept: {arg}\r\n\r\n";
			Log.Verbose($"[SimpleWebTransport] Handshake Response length {text.Length}, IsExpected {text.Length == 129}", showColor: false);
			Encoding.ASCII.GetBytes(text, 0, 129, responseBuffer, 0);
		}
	}
}
