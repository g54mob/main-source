using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Ionic.Zlib;

namespace Amazon.Runtime.EventStreams
{
	public class EventStreamMessage : IEventStreamMessage
	{
		internal const int SizeOfInt32 = 4;

		internal const int PreludeLen = 12;

		internal const int TrailerLen = 4;

		internal const int FramingSize = 16;

		public const string ContentType = "vnd.amazon.eventstream";

		public Dictionary<string, IEventStreamHeader> Headers { get; set; }

		public byte[] Payload { get; set; }

		private EventStreamMessage()
		{
		}

		public EventStreamMessage(List<IEventStreamHeader> headers, byte[] payload)
		{
			Headers = new Dictionary<string, IEventStreamHeader>(headers.Count, StringComparer.Ordinal);
			foreach (IEventStreamHeader header in headers)
			{
				Headers.Add(header.Name, header);
			}
			Payload = payload;
		}

		public static EventStreamMessage FromBuffer(byte[] buffer, int offset, int length)
		{
			int num = offset;
			int network = BitConverter.ToInt32(buffer, num);
			network = IPAddress.NetworkToHostOrder(network);
			num += 4;
			int network2 = BitConverter.ToInt32(buffer, num);
			network2 = IPAddress.NetworkToHostOrder(network2);
			num += 4;
			int network3 = BitConverter.ToInt32(buffer, num);
			network3 = IPAddress.NetworkToHostOrder(network3);
			EventStreamMessage eventStreamMessage = new EventStreamMessage();
			eventStreamMessage.Headers = new Dictionary<string, IEventStreamHeader>(StringComparer.Ordinal);
			using NullStream stream = new NullStream();
			using CrcCalculatorStream crcCalculatorStream = new CrcCalculatorStream(stream);
			crcCalculatorStream.Write(buffer, offset, num - offset);
			if (network3 != crcCalculatorStream.Crc32)
			{
				throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Prelude Checksum failure. Expected {0} but was {1}", network3, crcCalculatorStream.Crc32));
			}
			if (network != length)
			{
				throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Total Length didn't match the passed in length. Expected {0} but was {1}", length, network));
			}
			crcCalculatorStream.Write(buffer, num, 4);
			num += 4;
			int num2 = network - network2 - 16;
			if (network2 > 0)
			{
				int num3 = num;
				while (num - 12 < network2)
				{
					EventStreamHeader eventStreamHeader = EventStreamHeader.FromBuffer(buffer, num, ref num);
					eventStreamMessage.Headers.Add(eventStreamHeader.Name, eventStreamHeader);
				}
				crcCalculatorStream.Write(buffer, num3, num - num3);
			}
			eventStreamMessage.Payload = new byte[num2];
			Buffer.BlockCopy(buffer, num, eventStreamMessage.Payload, 0, eventStreamMessage.Payload.Length);
			crcCalculatorStream.Write(buffer, num, eventStreamMessage.Payload.Length);
			num += eventStreamMessage.Payload.Length;
			int network4 = BitConverter.ToInt32(buffer, num);
			network4 = IPAddress.NetworkToHostOrder(network4);
			if (network4 != crcCalculatorStream.Crc32)
			{
				throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Checksum failure. Expected {0} but was {1}", network4, crcCalculatorStream.Crc32));
			}
			return eventStreamMessage;
		}

		public byte[] ToByteArray()
		{
			int num = 0;
			if (Headers != null)
			{
				foreach (KeyValuePair<string, IEventStreamHeader> header in Headers)
				{
					num += header.Value.GetWireSize();
				}
			}
			byte[] payload = Payload;
			int num2 = ((payload != null) ? payload.Length : 0);
			int num3 = num + num2 + 16;
			byte[] array = new byte[num3];
			int num4 = 0;
			Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(num3)), 0, array, num4, 4);
			num4 += 4;
			Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(num)), 0, array, num4, 4);
			num4 += 4;
			using NullStream stream = new NullStream();
			using CrcCalculatorStream crcCalculatorStream = new CrcCalculatorStream(stream);
			crcCalculatorStream.Write(array, 0, num4);
			Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(crcCalculatorStream.Crc32)), 0, array, num4, 4);
			crcCalculatorStream.Write(array, num4, 4);
			num4 += 4;
			if (Headers != null)
			{
				foreach (KeyValuePair<string, IEventStreamHeader> header2 in Headers)
				{
					num4 = header2.Value.WriteToBuffer(array, num4);
				}
				crcCalculatorStream.Write(array, 12, num4 - 12);
			}
			if (Payload != null)
			{
				Buffer.BlockCopy(Payload, 0, array, num4, Payload.Length);
				crcCalculatorStream.Write(array, num4, Payload.Length);
				num4 += Payload.Length;
			}
			Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(crcCalculatorStream.Crc32)), 0, array, num4, 4);
			return array;
		}
	}
}
