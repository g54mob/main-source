using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FieldDescriptorProto : IMessage<FieldDescriptorProto>, IMessage, IEquatable<FieldDescriptorProto>, IDeepCloneable<FieldDescriptorProto>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum Type
			{
				[OriginalName("TYPE_DOUBLE")]
				Double = 1,
				[OriginalName("TYPE_FLOAT")]
				Float = 2,
				[OriginalName("TYPE_INT64")]
				Int64 = 3,
				[OriginalName("TYPE_UINT64")]
				Uint64 = 4,
				[OriginalName("TYPE_INT32")]
				Int32 = 5,
				[OriginalName("TYPE_FIXED64")]
				Fixed64 = 6,
				[OriginalName("TYPE_FIXED32")]
				Fixed32 = 7,
				[OriginalName("TYPE_BOOL")]
				Bool = 8,
				[OriginalName("TYPE_STRING")]
				String = 9,
				[OriginalName("TYPE_GROUP")]
				Group = 10,
				[OriginalName("TYPE_MESSAGE")]
				Message = 11,
				[OriginalName("TYPE_BYTES")]
				Bytes = 12,
				[OriginalName("TYPE_UINT32")]
				Uint32 = 13,
				[OriginalName("TYPE_ENUM")]
				Enum = 14,
				[OriginalName("TYPE_SFIXED32")]
				Sfixed32 = 15,
				[OriginalName("TYPE_SFIXED64")]
				Sfixed64 = 16,
				[OriginalName("TYPE_SINT32")]
				Sint32 = 17,
				[OriginalName("TYPE_SINT64")]
				Sint64 = 18
			}

			public enum Label
			{
				[OriginalName("LABEL_OPTIONAL")]
				Optional = 1,
				[OriginalName("LABEL_REPEATED")]
				Repeated = 3,
				[OriginalName("LABEL_REQUIRED")]
				Required = 2
			}
		}

		private static readonly MessageParser<FieldDescriptorProto> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int NameFieldNumber = 1;

		private static readonly string NameDefaultValue;

		private string name_;

		public const int NumberFieldNumber = 3;

		private static readonly int NumberDefaultValue;

		private int number_;

		public const int LabelFieldNumber = 4;

		private static readonly Types.Label LabelDefaultValue;

		private Types.Label label_;

		public const int TypeFieldNumber = 5;

		private static readonly Types.Type TypeDefaultValue;

		private Types.Type type_;

		public const int TypeNameFieldNumber = 6;

		private static readonly string TypeNameDefaultValue;

		private string typeName_;

		public const int ExtendeeFieldNumber = 2;

		private static readonly string ExtendeeDefaultValue;

		private string extendee_;

		public const int DefaultValueFieldNumber = 7;

		private static readonly string DefaultValueDefaultValue;

		private string defaultValue_;

		public const int OneofIndexFieldNumber = 9;

		private static readonly int OneofIndexDefaultValue;

		private int oneofIndex_;

		public const int JsonNameFieldNumber = 10;

		private static readonly string JsonNameDefaultValue;

		private string jsonName_;

		public const int OptionsFieldNumber = 8;

		private FieldOptions options_;

		public const int Proto3OptionalFieldNumber = 17;

		private static readonly bool Proto3OptionalDefaultValue;

		private bool proto3Optional_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FieldDescriptorProto> Parser => null;

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
		public Types.Label Label
		{
			get
			{
				return default(Types.Label);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasLabel => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.Type Type
		{
			get
			{
				return default(Types.Type);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasType => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string TypeName
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
		public bool HasTypeName => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Extendee
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
		public bool HasExtendee => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string DefaultValue
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
		public bool HasDefaultValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int OneofIndex
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
		public bool HasOneofIndex => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string JsonName
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
		public bool HasJsonName => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldOptions Options
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
		public bool Proto3Optional
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
		public bool HasProto3Optional => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldDescriptorProto()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldDescriptorProto(FieldDescriptorProto other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldDescriptorProto Clone()
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
		public void ClearLabel()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearType()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearTypeName()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearExtendee()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDefaultValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearOneofIndex()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJsonName()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearProto3Optional()
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
		public bool Equals(FieldDescriptorProto other)
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
		public void MergeFrom(FieldDescriptorProto other)
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
