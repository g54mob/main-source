using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Int32Value : IMessage<Int32Value>, IMessage, IEquatable<Int32Value>, IDeepCloneable<Int32Value>, IBufferMessage
	{
		private static readonly MessageParser<Int32Value> _parser;

		private UnknownFieldSet _unknownFields;

		public const int ValueFieldNumber = 1;

		private int value_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Int32Value> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Int32Value()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Int32Value(Int32Value other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Int32Value Clone()
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
		public bool Equals(Int32Value other)
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
		public void MergeFrom(Int32Value other)
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
