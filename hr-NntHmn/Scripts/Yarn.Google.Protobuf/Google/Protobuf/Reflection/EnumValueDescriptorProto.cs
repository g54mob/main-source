using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class EnumValueDescriptorProto : IMessage<EnumValueDescriptorProto>, IMessage, IEquatable<EnumValueDescriptorProto>, IDeepCloneable<EnumValueDescriptorProto>, IBufferMessage
	{
		private static readonly MessageParser<EnumValueDescriptorProto> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int NameFieldNumber = 1;

		private static readonly string NameDefaultValue;

		private string name_;

		public const int NumberFieldNumber = 2;

		private static readonly int NumberDefaultValue;

		private int number_;

		public const int OptionsFieldNumber = 3;

		private EnumValueOptions options_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<EnumValueDescriptorProto> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Name
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
		public bool HasName => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int Number
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
		public bool HasNumber => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public EnumValueOptions Options
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
		public EnumValueDescriptorProto()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public EnumValueDescriptorProto(EnumValueDescriptorProto other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public EnumValueDescriptorProto Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearName()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearNumber()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Equals(EnumValueDescriptorProto other)
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
		public void MergeFrom(EnumValueDescriptorProto other)
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
