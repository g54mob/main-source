using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class BoolValue : IMessage<BoolValue>, IMessage, IEquatable<BoolValue>, IDeepCloneable<BoolValue>, IBufferMessage
	{
		private static readonly MessageParser<BoolValue> _parser;

		private UnknownFieldSet _unknownFields;

		public const int ValueFieldNumber = 1;

		private bool value_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<BoolValue> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public BoolValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public BoolValue(BoolValue other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public BoolValue Clone()
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
		public bool Equals(BoolValue other)
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
		public void MergeFrom(BoolValue other)
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
	}
}
