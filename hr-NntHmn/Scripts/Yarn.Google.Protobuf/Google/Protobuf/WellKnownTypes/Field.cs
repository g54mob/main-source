using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Field : IMessage<Field>, IMessage, IEquatable<Field>, IDeepCloneable<Field>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum Kind
			{
				[OriginalName("TYPE_UNKNOWN")]
				TypeUnknown = 0,
				[OriginalName("TYPE_DOUBLE")]
				TypeDouble = 1,
				[OriginalName("TYPE_FLOAT")]
				TypeFloat = 2,
				[OriginalName("TYPE_INT64")]
				TypeInt64 = 3,
				[OriginalName("TYPE_UINT64")]
				TypeUint64 = 4,
				[OriginalName("TYPE_INT32")]
				TypeInt32 = 5,
				[OriginalName("TYPE_FIXED64")]
				TypeFixed64 = 6,
				[OriginalName("TYPE_FIXED32")]
				TypeFixed32 = 7,
				[OriginalName("TYPE_BOOL")]
				TypeBool = 8,
				[OriginalName("TYPE_STRING")]
				TypeString = 9,
				[OriginalName("TYPE_GROUP")]
				TypeGroup = 10,
				[OriginalName("TYPE_MESSAGE")]
				TypeMessage = 11,
				[OriginalName("TYPE_BYTES")]
				TypeBytes = 12,
				[OriginalName("TYPE_UINT32")]
				TypeUint32 = 13,
				[OriginalName("TYPE_ENUM")]
				TypeEnum = 14,
				[OriginalName("TYPE_SFIXED32")]
				TypeSfixed32 = 15,
				[OriginalName("TYPE_SFIXED64")]
				TypeSfixed64 = 16,
				[OriginalName("TYPE_SINT32")]
				TypeSint32 = 17,
				[OriginalName("TYPE_SINT64")]
				TypeSint64 = 18
			}

			public enum Cardinality
			{
				[OriginalName("CARDINALITY_UNKNOWN")]
				Unknown = 0,
				[OriginalName("CARDINALITY_OPTIONAL")]
				Optional = 1,
				[OriginalName("CARDINALITY_REQUIRED")]
				Required = 2,
				[OriginalName("CARDINALITY_REPEATED")]
				Repeated = 3
			}
		}

		private static readonly MessageParser<Field> _parser;

		private UnknownFieldSet _unknownFields;

		public const int KindFieldNumber = 1;

		private Types.Kind kind_;

		public const int CardinalityFieldNumber = 2;

		private Types.Cardinality cardinality_;

		public const int NumberFieldNumber = 3;

		private int number_;

		public const int NameFieldNumber = 4;

		private string name_;

		public const int TypeUrlFieldNumber = 6;

		private string typeUrl_;

		public const int OneofIndexFieldNumber = 7;

		private int oneofIndex_;

		public const int PackedFieldNumber = 8;

		private bool packed_;

		public const int OptionsFieldNumber = 9;

		private static readonly FieldCodec<Option> _repeated_options_codec;

		private readonly RepeatedField<Option> options_;

		public const int JsonNameFieldNumber = 10;

		private string jsonName_;

		public const int DefaultValueFieldNumber = 11;

		private string defaultValue_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Field> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.Kind Kind
		{
			get
			{
				return default(Types.Kind);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.Cardinality Cardinality
		{
			get
			{
				return default(Types.Cardinality);
			}
			set
			{
			}
		}

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
		public bool Packed
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
		public RepeatedField<Option> Options => null;

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
		public Field()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Field(Field other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Field Clone()
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
		public bool Equals(Field other)
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
		public void MergeFrom(Field other)
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
