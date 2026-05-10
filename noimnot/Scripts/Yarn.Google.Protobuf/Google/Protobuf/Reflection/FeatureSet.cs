using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FeatureSet : IExtendableMessage<FeatureSet>, IMessage<FeatureSet>, IMessage, IEquatable<FeatureSet>, IDeepCloneable<FeatureSet>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum FieldPresence
			{
				[OriginalName("FIELD_PRESENCE_UNKNOWN")]
				Unknown = 0,
				[OriginalName("EXPLICIT")]
				Explicit = 1,
				[OriginalName("IMPLICIT")]
				Implicit = 2,
				[OriginalName("LEGACY_REQUIRED")]
				LegacyRequired = 3
			}

			public enum EnumType
			{
				[OriginalName("ENUM_TYPE_UNKNOWN")]
				Unknown = 0,
				[OriginalName("OPEN")]
				Open = 1,
				[OriginalName("CLOSED")]
				Closed = 2
			}

			public enum RepeatedFieldEncoding
			{
				[OriginalName("REPEATED_FIELD_ENCODING_UNKNOWN")]
				Unknown = 0,
				[OriginalName("PACKED")]
				Packed = 1,
				[OriginalName("EXPANDED")]
				Expanded = 2
			}

			public enum Utf8Validation
			{
				[OriginalName("UTF8_VALIDATION_UNKNOWN")]
				Unknown = 0,
				[OriginalName("NONE")]
				None = 1,
				[OriginalName("VERIFY")]
				Verify = 2
			}

			public enum MessageEncoding
			{
				[OriginalName("MESSAGE_ENCODING_UNKNOWN")]
				Unknown = 0,
				[OriginalName("LENGTH_PREFIXED")]
				LengthPrefixed = 1,
				[OriginalName("DELIMITED")]
				Delimited = 2
			}

			public enum JsonFormat
			{
				[OriginalName("JSON_FORMAT_UNKNOWN")]
				Unknown = 0,
				[OriginalName("ALLOW")]
				Allow = 1,
				[OriginalName("LEGACY_BEST_EFFORT")]
				LegacyBestEffort = 2
			}
		}

		private static readonly MessageParser<FeatureSet> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<FeatureSet> _extensions;

		private int _hasBits0;

		public const int FieldPresenceFieldNumber = 1;

		private static readonly Types.FieldPresence FieldPresenceDefaultValue;

		private Types.FieldPresence fieldPresence_;

		public const int EnumTypeFieldNumber = 2;

		private static readonly Types.EnumType EnumTypeDefaultValue;

		private Types.EnumType enumType_;

		public const int RepeatedFieldEncodingFieldNumber = 3;

		private static readonly Types.RepeatedFieldEncoding RepeatedFieldEncodingDefaultValue;

		private Types.RepeatedFieldEncoding repeatedFieldEncoding_;

		public const int Utf8ValidationFieldNumber = 4;

		private static readonly Types.Utf8Validation Utf8ValidationDefaultValue;

		private Types.Utf8Validation utf8Validation_;

		public const int MessageEncodingFieldNumber = 5;

		private static readonly Types.MessageEncoding MessageEncodingDefaultValue;

		private Types.MessageEncoding messageEncoding_;

		public const int JsonFormatFieldNumber = 6;

		private static readonly Types.JsonFormat JsonFormatDefaultValue;

		private Types.JsonFormat jsonFormat_;

		private ExtensionSet<FeatureSet> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FeatureSet> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.FieldPresence FieldPresence
		{
			get
			{
				return default(Types.FieldPresence);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasFieldPresence => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.EnumType EnumType
		{
			get
			{
				return default(Types.EnumType);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasEnumType => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.RepeatedFieldEncoding RepeatedFieldEncoding
		{
			get
			{
				return default(Types.RepeatedFieldEncoding);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasRepeatedFieldEncoding => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.Utf8Validation Utf8Validation
		{
			get
			{
				return default(Types.Utf8Validation);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasUtf8Validation => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.MessageEncoding MessageEncoding
		{
			get
			{
				return default(Types.MessageEncoding);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasMessageEncoding => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.JsonFormat JsonFormat
		{
			get
			{
				return default(Types.JsonFormat);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJsonFormat => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSet()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSet(FeatureSet other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSet Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearFieldPresence()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearEnumType()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearRepeatedFieldEncoding()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearUtf8Validation()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMessageEncoding()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJsonFormat()
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
		public bool Equals(FeatureSet other)
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
		public void MergeFrom(FeatureSet other)
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

		public TValue GetExtension<TValue>(Extension<FeatureSet, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<FeatureSet, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<FeatureSet, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<FeatureSet, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<FeatureSet, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<FeatureSet, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<FeatureSet, TValue> extension)
		{
		}
	}
}
