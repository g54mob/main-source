using System;
using System.Collections.Generic;
using BestHTTP.SocketIO.JsonEncoders;

namespace BestHTTP.SocketIO
{
	public sealed class Packet
	{
		private enum PayloadTypes : byte
		{
			Textual = 0,
			Binary = 1
		}

		public const string Placeholder = "_placeholder";

		private List<byte[]> attachments;

		public TransportEventTypes TransportEvent { get; private set; }

		public SocketIOEventTypes SocketIOEvent { get; private set; }

		public int AttachmentCount { get; private set; }

		public int Id { get; private set; }

		public string Namespace { get; private set; }

		public string Payload { get; private set; }

		public string EventName { get; private set; }

		public List<byte[]> Attachments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasAllAttachment => false;

		public bool IsDecoded { get; private set; }

		public object[] DecodedArgs { get; private set; }

		internal Packet()
		{
		}

		internal Packet(string from)
		{
		}

		public Packet(TransportEventTypes transportEvent, SocketIOEventTypes packetType, string nsp, string payload, int attachment = 0, int id = 0)
		{
		}

		public object[] Decode(IJsonEncoder encoder)
		{
			return null;
		}

		public string DecodeEventName()
		{
			return null;
		}

		public string RemoveEventName(bool removeArrayMarks)
		{
			return null;
		}

		public bool ReconstructAttachmentAsIndex()
		{
			return false;
		}

		public bool ReconstructAttachmentAsBase64()
		{
			return false;
		}

		internal void Parse(string from)
		{
		}

		private int ToInt(char ch)
		{
			return 0;
		}

		internal string Encode()
		{
			return null;
		}

		internal byte[] EncodeBinary()
		{
			return null;
		}

		internal void AddAttachmentFromServer(byte[] data, bool copyFull)
		{
		}

		private byte[] EncodeData(byte[] data, PayloadTypes type, byte[] afterHeaderData)
		{
			return null;
		}

		private bool PlaceholderReplacer(Action<string, Dictionary<string, object>> onFound)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		internal Packet Clone()
		{
			return null;
		}
	}
}
