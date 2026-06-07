using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class MessageOptions : IExtendableMessage<MessageOptions>, IMessage<MessageOptions>, IMessage, IEquatable<MessageOptions>, IDeepCloneable<MessageOptions>, IBufferMessage
	{
		private static readonly MessageParser<MessageOptions> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<MessageOptions> _extensions;

		private int _hasBits0;

		public const int MessageSetWireFormatFieldNumber = 1;

		private static readonly bool MessageSetWireFormatDefaultValue;

		private bool messageSetWireFormat_;

		public const int NoStandardDescriptorAccessorFieldNumber = 2;

		private static readonly bool NoStandardDescriptorAccessorDefaultValue;

		private bool noStandardDescriptorAccessor_;

		public const int DeprecatedFieldNumber = 3;

		private static readonly bool DeprecatedDefaultValue;

		private bool deprecated_;

		public const int MapEntryFieldNumber = 7;

		private static readonly bool MapEntryDefaultValue;

		private bool mapEntry_;

		public const int DeprecatedLegacyJsonFieldConflictsFieldNumber = 11;

		private static readonly bool DeprecatedLegacyJsonFieldConflictsDefaultValue;

		private bool deprecatedLegacyJsonFieldConflicts_;

		public const int FeaturesFieldNumber = 12;

		private FeatureSet features_;

		public const int UninterpretedOptionFieldNumber = 999;

		private static readonly FieldCodec<UninterpretedOption> _repeated_uninterpretedOption_codec;

		private readonly RepeatedField<UninterpretedOption> uninterpretedOption_;

		private ExtensionSet<MessageOptions> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<MessageOptions> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool MessageSetWireFormat
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
		public bool HasMessageSetWireFormat => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool NoStandardDescriptorAccessor
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
		public bool HasNoStandardDescriptorAccessor => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Deprecated
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
		public bool HasDeprecated => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool MapEntry
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
		public bool HasMapEntry => false;

		[Obsolete]
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool DeprecatedLegacyJsonFieldConflicts
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete]
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDeprecatedLegacyJsonFieldConflicts => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSet Features
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
		public RepeatedField<UninterpretedOption> UninterpretedOption => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MessageOptions()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MessageOptions(MessageOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MessageOptions Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMessageSetWireFormat()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearNoStandardDescriptorAccessor()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDeprecated()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMapEntry()
		{
		}

		[Obsolete]
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDeprecatedLegacyJsonFieldConflicts()
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
		public bool Equals(MessageOptions other)
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
		public void MergeFrom(MessageOptions other)
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

		public TValue GetExtension<TValue>(Extension<MessageOptions, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<MessageOptions, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<MessageOptions, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<MessageOptions, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<MessageOptions, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<MessageOptions, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<MessageOptions, TValue> extension)
		{
		}
	}
}
