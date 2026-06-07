using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class EnumOptions : IExtendableMessage<EnumOptions>, IMessage<EnumOptions>, IMessage, IEquatable<EnumOptions>, IDeepCloneable<EnumOptions>, IBufferMessage
	{
		private static readonly MessageParser<EnumOptions> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<EnumOptions> _extensions;

		private int _hasBits0;

		public const int AllowAliasFieldNumber = 2;

		private static readonly bool AllowAliasDefaultValue;

		private bool allowAlias_;

		public const int DeprecatedFieldNumber = 3;

		private static readonly bool DeprecatedDefaultValue;

		private bool deprecated_;

		public const int DeprecatedLegacyJsonFieldConflictsFieldNumber = 6;

		private static readonly bool DeprecatedLegacyJsonFieldConflictsDefaultValue;

		private bool deprecatedLegacyJsonFieldConflicts_;

		public const int FeaturesFieldNumber = 7;

		private FeatureSet features_;

		public const int UninterpretedOptionFieldNumber = 999;

		private static readonly FieldCodec<UninterpretedOption> _repeated_uninterpretedOption_codec;

		private readonly RepeatedField<UninterpretedOption> uninterpretedOption_;

		private ExtensionSet<EnumOptions> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<EnumOptions> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool AllowAlias
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
		public bool HasAllowAlias => false;

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
		public EnumOptions()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public EnumOptions(EnumOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public EnumOptions Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearAllowAlias()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDeprecated()
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
		public bool Equals(EnumOptions other)
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
		public void MergeFrom(EnumOptions other)
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

		public TValue GetExtension<TValue>(Extension<EnumOptions, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<EnumOptions, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<EnumOptions, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<EnumOptions, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<EnumOptions, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<EnumOptions, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<EnumOptions, TValue> extension)
		{
		}
	}
}
