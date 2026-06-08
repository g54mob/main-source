using System;
using System.Globalization;
using System.Net;
using System.Text;

namespace Amazon.Runtime.EventStreams
{
	public class EventStreamHeader : IEventStreamHeader
	{
		private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		private const int _sizeOfByte = 1;

		private const int _sizeOfInt16 = 2;

		private const int _sizeOfInt32 = 4;

		private const int _sizeOfInt64 = 8;

		private const int _sizeOfGuid = 16;

		public string Name { get; }

		public EventStreamHeaderType HeaderType { get; set; }

		private object HeaderValue { get; set; }

		public EventStreamHeader(string name)
		{
			Name = name;
		}

		public static EventStreamHeader FromBuffer(byte[] buffer, int offset, ref int newOffset)
		{
			newOffset = offset;
			byte b = buffer[newOffset++];
			EventStreamHeader eventStreamHeader = new EventStreamHeader(Encoding.UTF8.GetString(buffer, newOffset, b));
			newOffset += b;
			eventStreamHeader.HeaderType = (EventStreamHeaderType)buffer[newOffset++];
			short num = 0;
			switch (eventStreamHeader.HeaderType)
			{
			case EventStreamHeaderType.BoolTrue:
				eventStreamHeader.HeaderValue = true;
				break;
			case EventStreamHeaderType.BoolFalse:
				eventStreamHeader.HeaderValue = false;
				break;
			case EventStreamHeaderType.SByte:
				eventStreamHeader.HeaderValue = (sbyte)buffer[newOffset];
				newOffset++;
				break;
			case EventStreamHeaderType.Int16:
				eventStreamHeader.HeaderValue = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, newOffset));
				newOffset += 2;
				break;
			case EventStreamHeaderType.Int32:
				eventStreamHeader.HeaderValue = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, newOffset));
				newOffset += 4;
				break;
			case EventStreamHeaderType.Int64:
				eventStreamHeader.HeaderValue = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, newOffset));
				newOffset += 8;
				break;
			case EventStreamHeaderType.ByteBuf:
				num = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, newOffset));
				newOffset += 2;
				eventStreamHeader.HeaderValue = new byte[num];
				Buffer.BlockCopy(buffer, newOffset, eventStreamHeader.HeaderValue as byte[], 0, num);
				newOffset += num;
				break;
			case EventStreamHeaderType.String:
				num = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, newOffset));
				newOffset += 2;
				eventStreamHeader.HeaderValue = Encoding.UTF8.GetString(buffer, newOffset, num);
				newOffset += num;
				break;
			case EventStreamHeaderType.Timestamp:
			{
				long num2 = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, newOffset));
				newOffset += 8;
				DateTime unixEpoch = _unixEpoch;
				eventStreamHeader.HeaderValue = unixEpoch.AddMilliseconds(num2);
				break;
			}
			case EventStreamHeaderType.UUID:
			{
				byte[] array = new byte[16];
				num = 16;
				Buffer.BlockCopy(buffer, newOffset, array, 0, num);
				newOffset += num;
				eventStreamHeader.HeaderValue = new Guid(array);
				break;
			}
			default:
				throw new EventStreamParseException(string.Format(CultureInfo.InvariantCulture, "Header Type: {0} is an unknown type.", eventStreamHeader.HeaderType));
			}
			return eventStreamHeader;
		}

		public int WriteToBuffer(byte[] buffer, int offset)
		{
			int num = offset;
			buffer[num++] = (byte)Name.Length;
			Buffer.BlockCopy(Encoding.UTF8.GetBytes(Name), 0, buffer, num, Name.Length);
			num += Name.Length;
			buffer[num++] = (byte)HeaderType;
			byte[] array = null;
			int num2 = 0;
			switch (HeaderType)
			{
			case EventStreamHeaderType.SByte:
				buffer[num++] = (byte)(sbyte)HeaderValue;
				break;
			case EventStreamHeaderType.Int16:
				array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)HeaderValue));
				Buffer.BlockCopy(array, 0, buffer, num, 2);
				num += 2;
				break;
			case EventStreamHeaderType.Int32:
				array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int)HeaderValue));
				Buffer.BlockCopy(array, 0, buffer, num, 4);
				num += 4;
				break;
			case EventStreamHeaderType.Int64:
				array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)HeaderValue));
				Buffer.BlockCopy(array, 0, buffer, num, 8);
				num += 8;
				break;
			case EventStreamHeaderType.ByteBuf:
				array = HeaderValue as byte[];
				num2 = array.Length;
				Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)num2)), 0, buffer, num, 2);
				num += 2;
				Buffer.BlockCopy(array, 0, buffer, num, num2);
				num += num2;
				break;
			case EventStreamHeaderType.String:
				array = Encoding.UTF8.GetBytes(HeaderValue as string);
				num2 = array.Length;
				Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)num2)), 0, buffer, num, 2);
				num += 2;
				Buffer.BlockCopy(array, 0, buffer, num, num2);
				num += num2;
				break;
			case EventStreamHeaderType.Timestamp:
				array = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)((DateTime)HeaderValue).Subtract(_unixEpoch).TotalMilliseconds));
				Buffer.BlockCopy(array, 0, buffer, num, 8);
				num += 8;
				break;
			case EventStreamHeaderType.UUID:
				array = ((Guid)HeaderValue).ToByteArray();
				Buffer.BlockCopy(array, 0, buffer, num, array.Length);
				num += array.Length;
				break;
			default:
				throw new EventStreamParseException(string.Format(CultureInfo.InvariantCulture, "Header Type: {0} is an unknown type.", HeaderType));
			case EventStreamHeaderType.BoolTrue:
			case EventStreamHeaderType.BoolFalse:
				break;
			}
			return num;
		}

		public int GetWireSize()
		{
			int num = 1 + Name.Length + 1;
			switch (HeaderType)
			{
			case EventStreamHeaderType.SByte:
				num++;
				break;
			case EventStreamHeaderType.Int16:
				num += 2;
				break;
			case EventStreamHeaderType.Int32:
				num += 4;
				break;
			case EventStreamHeaderType.Int64:
				num += 8;
				break;
			case EventStreamHeaderType.ByteBuf:
			{
				byte[] array = HeaderValue as byte[];
				num += 2 + array.Length;
				break;
			}
			case EventStreamHeaderType.String:
			{
				int num2 = Encoding.UTF8.GetBytes(HeaderValue as string).Length;
				num += 2 + num2;
				break;
			}
			case EventStreamHeaderType.Timestamp:
				num += 8;
				break;
			case EventStreamHeaderType.UUID:
				num += 16;
				break;
			default:
				throw new EventStreamParseException(string.Format(CultureInfo.InvariantCulture, "Header Type: {0} is an unknown type.", HeaderType));
			case EventStreamHeaderType.BoolTrue:
			case EventStreamHeaderType.BoolFalse:
				break;
			}
			return num;
		}

		public bool AsBool()
		{
			return HeaderType == EventStreamHeaderType.BoolTrue;
		}

		public void SetBool(bool value)
		{
			HeaderValue = value;
			HeaderType = ((!value) ? EventStreamHeaderType.BoolFalse : EventStreamHeaderType.BoolTrue);
		}

		public sbyte AsSByte()
		{
			return (sbyte)HeaderValue;
		}

		public void SetSByte(sbyte value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.SByte;
		}

		public short AsInt16()
		{
			return (short)HeaderValue;
		}

		public void SetInt16(short value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Int16;
		}

		public int AsInt32()
		{
			return (int)HeaderValue;
		}

		public void SetInt32(int value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Int32;
		}

		public long AsInt64()
		{
			return (long)HeaderValue;
		}

		public void SetInt64(long value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Int64;
		}

		public byte[] AsByteBuf()
		{
			return HeaderValue as byte[];
		}

		public void SetByteBuf(byte[] value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.ByteBuf;
		}

		public string AsString()
		{
			return HeaderValue as string;
		}

		public void SetString(string value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.String;
		}

		public DateTime AsTimestamp()
		{
			return (DateTime)HeaderValue;
		}

		public void SetTimestamp(DateTime value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Timestamp;
		}

		public Guid AsUUID()
		{
			return (Guid)HeaderValue;
		}

		public void SetUUID(Guid value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.UUID;
		}
	}
}
