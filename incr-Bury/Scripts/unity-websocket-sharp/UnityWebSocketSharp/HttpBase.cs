using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	internal abstract class HttpBase
	{
		private NameValueCollection _headers;

		private static readonly int _maxMessageHeaderLength;

		private string _messageBody;

		private byte[] _messageBodyData;

		private Version _version;

		protected static readonly string CrLf;

		protected static readonly string CrLfHt;

		protected static readonly string CrLfSp;

		internal byte[] MessageBodyData => _messageBodyData;

		protected string HeaderSection
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(64);
				string[] allKeys = _headers.AllKeys;
				foreach (string text in allKeys)
				{
					stringBuilder.AppendFormat("{0}: {1}{2}", text, _headers[text], CrLf);
				}
				stringBuilder.Append(CrLf);
				return stringBuilder.ToString();
			}
		}

		public bool HasMessageBody => _messageBodyData != null;

		public NameValueCollection Headers => _headers;

		public string MessageBody
		{
			get
			{
				if (_messageBody == null)
				{
					_messageBody = getMessageBody();
				}
				return _messageBody;
			}
		}

		public abstract string MessageHeader { get; }

		public Version ProtocolVersion => _version;

		static HttpBase()
		{
			_maxMessageHeaderLength = 8192;
			CrLf = "\r\n";
			CrLfHt = "\r\n\t";
			CrLfSp = "\r\n ";
		}

		protected HttpBase(Version version, NameValueCollection headers)
		{
			_version = version;
			_headers = headers;
		}

		private string getMessageBody()
		{
			if (_messageBodyData == null || _messageBodyData.LongLength == 0L)
			{
				return string.Empty;
			}
			string text = _headers["Content-Type"];
			return ((text != null && text.Length > 0) ? HttpUtility.GetEncoding(text) : Encoding.UTF8).GetString(_messageBodyData);
		}

		private static byte[] readMessageBodyFrom(Stream stream, string length)
		{
			if (!long.TryParse(length, out var result))
			{
				throw new ArgumentException("It cannot be parsed.", "length");
			}
			if (result < 0)
			{
				string message = "It is less than zero.";
				throw new ArgumentOutOfRangeException("length", message);
			}
			if (result <= 1024)
			{
				if (result <= 0)
				{
					return null;
				}
				return stream.ReadBytes((int)result);
			}
			return stream.ReadBytes(result, 1024);
		}

		private static string[] readMessageHeaderFrom(Stream stream)
		{
			List<byte> buff = new List<byte>();
			int cnt = 0;
			Action<int> beforeComparing = delegate(int i)
			{
				if (i == -1)
				{
					throw new EndOfStreamException("The header could not be read from the data stream.");
				}
				buff.Add((byte)i);
				cnt++;
			};
			bool flag = false;
			do
			{
				flag = stream.ReadByte().IsEqualTo('\r', beforeComparing) && stream.ReadByte().IsEqualTo('\n', beforeComparing) && stream.ReadByte().IsEqualTo('\r', beforeComparing) && stream.ReadByte().IsEqualTo('\n', beforeComparing);
				if (cnt > _maxMessageHeaderLength)
				{
					throw new InvalidOperationException("The length of the header is greater than the max length.");
				}
			}
			while (!flag);
			byte[] bytes = buff.ToArray();
			return Encoding.UTF8.GetString(bytes).Replace(CrLfSp, " ").Replace(CrLfHt, " ")
				.Split(new string[1] { CrLf }, StringSplitOptions.RemoveEmptyEntries);
		}

		internal void WriteTo(Stream stream)
		{
			byte[] array = ToByteArray();
			stream.Write(array, 0, array.Length);
		}

		protected static T Read<T>(Stream stream, Func<string[], T> parser, int millisecondsTimeout) where T : HttpBase
		{
			T val = null;
			bool timeout = false;
			Timer timer = new Timer(delegate
			{
				timeout = true;
				stream.Close();
			}, null, millisecondsTimeout, -1);
			Exception ex = null;
			try
			{
				string[] arg = readMessageHeaderFrom(stream);
				val = parser(arg);
				string text = val.Headers["Content-Length"];
				if (text != null && text.Length > 0)
				{
					val._messageBodyData = readMessageBodyFrom(stream, text);
				}
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			finally
			{
				timer.Change(-1, -1);
				timer.Dispose();
			}
			if (timeout)
			{
				throw new WebSocketException("A timeout has occurred.");
			}
			if (ex != null)
			{
				throw new WebSocketException("An exception has occurred.", ex);
			}
			return val;
		}

		public byte[] ToByteArray()
		{
			byte[] bytes = Encoding.UTF8.GetBytes(MessageHeader);
			if (_messageBodyData == null)
			{
				return bytes;
			}
			return bytes.Concat(_messageBodyData).ToArray();
		}

		public override string ToString()
		{
			if (_messageBodyData == null)
			{
				return MessageHeader;
			}
			return MessageHeader + MessageBody;
		}
	}
}
