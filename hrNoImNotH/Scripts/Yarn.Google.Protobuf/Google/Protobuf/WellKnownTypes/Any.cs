using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Any : IMessage<Any>, IMessage, IEquatable<Any>, IDeepCloneable<Any>, IBufferMessage
	{
		private static readonly MessageParser<Any> _parser;

		private UnknownFieldSet _unknownFields;

		public const int TypeUrlFieldNumber = 1;

		private string typeUrl_;

		public const int ValueFieldNumber = 2;

		private ByteString value_;

		private const string DefaultPrefix = "type.googleapis.com";

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Any> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string TypeUrl
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ByteString Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Any()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Any(Any other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Any Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Equals(Any other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override string ToString()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void WriteTo(CodedOutputStream output)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalWriteTo(ref WriteContext output)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void MergeFrom(Any other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void MergeFrom(CodedInputStream input)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalMergeFrom(ref ParseContext input)
		{
		}

		private static string GetTypeUrl(MessageDescriptor descriptor, string prefix)
		{
			return null;
		}

		public static string GetTypeName(string typeUrl)
		{
			return null;
		}

		public bool Is(MessageDescriptor descriptor)
		{
			return false;
		}

		public T Unpack<T>() where T : IMessage, new()
		{
			return default(T);
		}

		public bool TryUnpack<T>(out T result) where T : IMessage, new()
		{
			result = default(T);
			return false;
		}

		public IMessage Unpack(TypeRegistry registry)
		{
			return null;
		}

		public static Any Pack(IMessage message)
		{
			return null;
		}

		public static Any Pack(IMessage message, string typeUrlPrefix)
		{
			return null;
		}
	}
}
