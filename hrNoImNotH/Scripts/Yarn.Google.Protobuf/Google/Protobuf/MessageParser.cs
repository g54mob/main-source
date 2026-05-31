using System;
using System.Buffers;
using System.IO;

namespace Google.Protobuf
{
	public class MessageParser
	{
		private readonly Func<IMessage> factory;

		private protected bool DiscardUnknownFields { get; }

		internal ExtensionRegistry Extensions { get; }

		internal MessageParser(Func<IMessage> factory, bool discardUnknownFields, ExtensionRegistry extensions)
		{
		}

		internal IMessage CreateTemplate()
		{
			return null;
		}

		public IMessage ParseFrom(byte[] data)
		{
			return null;
		}

		public IMessage ParseFrom(byte[] data, int offset, int length)
		{
			return null;
		}

		public IMessage ParseFrom(ByteString data)
		{
			return null;
		}

		public IMessage ParseFrom(Stream input)
		{
			return null;
		}

		public IMessage ParseFrom(ReadOnlySequence<byte> data)
		{
			return null;
		}

		public IMessage ParseFrom(ReadOnlySpan<byte> data)
		{
			return null;
		}

		public IMessage ParseDelimitedFrom(Stream input)
		{
			return null;
		}

		public IMessage ParseFrom(CodedInputStream input)
		{
			return null;
		}

		public IMessage ParseJson(string json)
		{
			return null;
		}

		internal void MergeFrom(IMessage message, CodedInputStream codedInput)
		{
		}

		public MessageParser WithDiscardUnknownFields(bool discardUnknownFields)
		{
			return null;
		}

		public MessageParser WithExtensionRegistry(ExtensionRegistry registry)
		{
			return null;
		}
	}
	public sealed class MessageParser<T> : MessageParser where T : IMessage<T>
	{
		private readonly Func<T> factory;

		public MessageParser(Func<T> factory)
			: base(null, discardUnknownFields: false, null)
		{
		}

		internal MessageParser(Func<T> factory, bool discardUnknownFields, ExtensionRegistry extensions)
			: base(null, discardUnknownFields: false, null)
		{
		}

		internal new T CreateTemplate()
		{
			return default(T);
		}

		public new T ParseFrom(byte[] data)
		{
			return default(T);
		}

		public new T ParseFrom(byte[] data, int offset, int length)
		{
			return default(T);
		}

		public new T ParseFrom(ByteString data)
		{
			return default(T);
		}

		public new T ParseFrom(Stream input)
		{
			return default(T);
		}

		public new T ParseFrom(ReadOnlySequence<byte> data)
		{
			return default(T);
		}

		public new T ParseFrom(ReadOnlySpan<byte> data)
		{
			return default(T);
		}

		public new T ParseDelimitedFrom(Stream input)
		{
			return default(T);
		}

		public new T ParseFrom(CodedInputStream input)
		{
			return default(T);
		}

		public new T ParseJson(string json)
		{
			return default(T);
		}

		public new MessageParser<T> WithDiscardUnknownFields(bool discardUnknownFields)
		{
			return null;
		}

		public new MessageParser<T> WithExtensionRegistry(ExtensionRegistry registry)
		{
			return null;
		}
	}
}
