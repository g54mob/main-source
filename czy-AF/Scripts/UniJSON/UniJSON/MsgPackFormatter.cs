using System;

namespace UniJSON
{
	public class MsgPackFormatter : IFormatter, IRpc
	{
		private IStore m_store;

		public const int REQUEST_TYPE = 0;

		public const int RESPONSE_TYPE = 1;

		public const int NOTIFY_TYPE = 2;

		private int m_msgId = 1;

		public MsgPackFormatter(IStore store)
		{
			m_store = store;
		}

		public MsgPackFormatter()
			: this(new BytesStore())
		{
		}

		public void Clear()
		{
			m_store.Clear();
		}

		public void BeginList(int n)
		{
			if (n < 15)
			{
				m_store.Write((byte)(0x90 | n));
			}
			else if (n < 65535)
			{
				m_store.Write(220);
				m_store.WriteBigEndian((ushort)n);
			}
			else
			{
				m_store.Write(221);
				m_store.WriteBigEndian(n);
			}
		}

		public void EndList()
		{
		}

		public void BeginMap(int n)
		{
			if (n < 15)
			{
				m_store.Write((byte)(0x80 | n));
			}
			else if (n < 65535)
			{
				m_store.Write(222);
				m_store.WriteBigEndian((ushort)n);
			}
			else
			{
				m_store.Write(223);
				m_store.WriteBigEndian(n.ToNetworkByteOrder());
			}
		}

		public void EndMap()
		{
		}

		public void Null()
		{
			m_store.Write(192);
		}

		public void Key(Utf8String key)
		{
			Value(key);
		}

		public void Value(string s)
		{
			Value(Utf8String.From(s));
		}

		public void Value(Utf8String s)
		{
			ArraySegment<byte> bytes = s.Bytes;
			int count = bytes.Count;
			if (count < 32)
			{
				m_store.Write((byte)(0xA0 | count));
				m_store.Write(bytes);
			}
			else if (count < 255)
			{
				m_store.Write(217);
				m_store.Write((byte)count);
				m_store.Write(bytes);
			}
			else if (count < 65535)
			{
				m_store.Write(218);
				m_store.WriteBigEndian((ushort)count);
				m_store.Write(bytes);
			}
			else
			{
				m_store.Write(219);
				m_store.WriteBigEndian(count);
				m_store.Write(bytes);
			}
		}

		public void Value(bool value)
		{
			if (value)
			{
				m_store.Write(195);
			}
			else
			{
				m_store.Write(194);
			}
		}

		public void Value(sbyte n)
		{
			if (n >= 0)
			{
				Value((byte)n);
			}
			else if (n >= -32)
			{
				MsgPackType value = (MsgPackType)(n + 32 + 224);
				m_store.Write((byte)value);
			}
			else
			{
				m_store.Write(208);
				m_store.Write((byte)n);
			}
		}

		public void Value(short n)
		{
			if (n >= 0)
			{
				if (n <= 255)
				{
					Value((byte)n);
				}
				else
				{
					Value((ushort)n);
				}
			}
			else if (n >= -128)
			{
				m_store.Write((sbyte)n);
			}
			else
			{
				m_store.Write(209);
				m_store.WriteBigEndian(n);
			}
		}

		public void Value(int n)
		{
			if (n >= 0)
			{
				if (n <= 255)
				{
					Value((byte)n);
				}
				else if (n <= 65535)
				{
					Value((ushort)n);
				}
				else
				{
					Value((uint)n);
				}
			}
			else if (n >= -128)
			{
				Value((sbyte)n);
			}
			else if (n >= -32768)
			{
				Value((short)n);
			}
			else
			{
				m_store.Write(210);
				m_store.WriteBigEndian(n);
			}
		}

		public void Value(long n)
		{
			if (n >= 0)
			{
				if (n <= 255)
				{
					Value((byte)n);
				}
				else if (n <= 65535)
				{
					Value((ushort)n);
				}
				else if (n <= uint.MaxValue)
				{
					Value((uint)n);
				}
				else
				{
					Value((ulong)n);
				}
			}
			else if (n >= -128)
			{
				Value((sbyte)n);
			}
			else if (n >= -32768)
			{
				Value((short)n);
			}
			else if (n >= int.MinValue)
			{
				Value((int)n);
			}
			else
			{
				m_store.Write(211);
				m_store.WriteBigEndian(n);
			}
		}

		public void Value(byte n)
		{
			if (n <= 127)
			{
				m_store.Write(n);
				return;
			}
			m_store.Write(204);
			m_store.Write(n);
		}

		public void Value(ushort n)
		{
			if (n <= 255)
			{
				Value((byte)n);
				return;
			}
			m_store.Write(205);
			m_store.WriteBigEndian(n);
		}

		public void Value(uint n)
		{
			if (n <= 255)
			{
				Value((byte)n);
				return;
			}
			if (n <= 65535)
			{
				Value((ushort)n);
				return;
			}
			m_store.Write(206);
			m_store.WriteBigEndian(n);
		}

		public void Value(ulong n)
		{
			if (n <= 255)
			{
				Value((byte)n);
				return;
			}
			if (n <= 65535)
			{
				Value((ushort)n);
				return;
			}
			if (n <= uint.MaxValue)
			{
				Value((uint)n);
				return;
			}
			m_store.Write(207);
			m_store.WriteBigEndian(n);
		}

		public void Value(float value)
		{
			m_store.Write(202);
			m_store.WriteBigEndian(value);
		}

		public void Value(double value)
		{
			m_store.Write(203);
			m_store.WriteBigEndian(value);
		}

		public void Value(ArraySegment<byte> bytes)
		{
			if (bytes.Count < 255)
			{
				m_store.Write(196);
				m_store.Write((byte)bytes.Count);
				m_store.Write(bytes);
			}
			else if (bytes.Count < 65535)
			{
				m_store.Write(197);
				m_store.WriteBigEndian((ushort)bytes.Count);
				m_store.Write(bytes);
			}
			else
			{
				m_store.Write(198);
				m_store.WriteBigEndian(bytes.Count);
				m_store.Write(bytes);
			}
		}

		public void TimeStamp32(DateTimeOffset time)
		{
			if (time < DateTimeOffsetExtensions.EpochTime)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_store.Write(214);
			m_store.Write(-1);
			m_store.WriteBigEndian((uint)time.ToUnixTimeSeconds());
		}

		public void Value(DateTimeOffset time)
		{
			TimeStamp32(time);
		}

		public void Value(ListTreeNode<MsgPackValue> node)
		{
			m_store.Write(node.Value.Bytes);
		}

		public IStore GetStore()
		{
			return m_store;
		}

		public void Request(Utf8String method)
		{
			BeginList(4);
			Value(0);
			Value(m_msgId++);
			Value(method);
			BeginList(0);
			EndList();
			EndList();
		}

		public void Request<A0>(Utf8String method, A0 a0)
		{
			BeginList(4);
			Value(0);
			Value(m_msgId++);
			Value(method);
			BeginList(1);
			this.Serialize(a0);
			EndList();
			EndList();
		}

		public void Request<A0, A1>(Utf8String method, A0 a0, A1 a1)
		{
			BeginList(4);
			Value(0);
			Value(m_msgId++);
			Value(method);
			BeginList(2);
			this.Serialize(a0);
			this.Serialize(a1);
			EndList();
			EndList();
		}

		public void Request<A0, A1, A2>(Utf8String method, A0 a0, A1 a1, A2 a2)
		{
			throw new NotImplementedException();
		}

		public void Request<A0, A1, A2, A3>(Utf8String method, A0 a0, A1 a1, A2 a2, A3 a3)
		{
			throw new NotImplementedException();
		}

		public void Request<A0, A1, A2, A3, A4>(Utf8String method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4)
		{
			throw new NotImplementedException();
		}

		public void Request<A0, A1, A2, A3, A4, A5>(Utf8String method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
		{
			throw new NotImplementedException();
		}

		public void ResponseSuccess(int id)
		{
			BeginList(4);
			Value(1);
			Value(id);
			Null();
			Null();
			EndList();
		}

		public void ResponseSuccess<T>(int id, T result)
		{
			BeginList(4);
			Value(1);
			Value(id);
			Null();
			this.Serialize(result);
			EndList();
		}

		public void ResponseError(int id, Exception error)
		{
			BeginList(4);
			Value(1);
			Value(id);
			this.Serialize(error);
			Null();
			EndList();
		}

		public void Notify(Utf8String method)
		{
			BeginList(3);
			Value(2);
			Value(method);
			BeginList(0);
			EndList();
			EndList();
		}

		public void Notify<A0>(Utf8String method, A0 a0)
		{
			BeginList(3);
			Value(2);
			Value(method);
			BeginList(1);
			this.Serialize(a0);
			EndList();
			EndList();
		}

		public void Notify<A0, A1>(Utf8String method, A0 a0, A1 a1)
		{
			BeginList(3);
			Value(2);
			Value(method);
			BeginList(2);
			this.Serialize(a0);
			this.Serialize(a1);
			EndList();
			EndList();
		}

		public void Notify<A0, A1, A2>(Utf8String method, A0 a0, A1 a1, A2 a2)
		{
			throw new NotImplementedException();
		}

		public void Notify<A0, A1, A2, A3>(Utf8String method, A0 a0, A1 a1, A2 a2, A3 a3)
		{
			throw new NotImplementedException();
		}

		public void Notify<A0, A1, A2, A3, A4>(Utf8String method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4)
		{
			throw new NotImplementedException();
		}

		public void Notify<A0, A1, A2, A3, A4, A5>(Utf8String method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
		{
			throw new NotImplementedException();
		}
	}
}
