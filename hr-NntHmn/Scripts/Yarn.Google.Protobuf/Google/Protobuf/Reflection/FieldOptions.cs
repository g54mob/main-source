using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FieldOptions : IExtendableMessage<FieldOptions>, IMessage<FieldOptions>, IMessage, IEquatable<FieldOptions>, IDeepCloneable<FieldOptions>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum CType
			{
				[OriginalName("STRING")]
				String = 0,
				[OriginalName("CORD")]
				Cord = 1,
				[OriginalName("STRING_PIECE")]
				StringPiece = 2
			}

			public enum JSType
			{
				[OriginalName("JS_NORMAL")]
				JsNormal = 0,
				[OriginalName("JS_STRING")]
				JsString = 1,
				[OriginalName("JS_NUMBER")]
				JsNumber = 2
			}

			public enum OptionRetention
			{
				[OriginalName("RETENTION_UNKNOWN")]
				RetentionUnknown = 0,
				[OriginalName("RETENTION_RUNTIME")]
				RetentionRuntime = 1,
				[OriginalName("RETENTION_SOURCE")]
				RetentionSource = 2
			}

			public enum OptionTargetType
			{
				[OriginalName("TARGET_TYPE_UNKNOWN")]
				TargetTypeUnknown = 0,
				[OriginalName("TARGET_TYPE_FILE")]
				TargetTypeFile = 1,
				[OriginalName("TARGET_TYPE_EXTENSION_RANGE")]
				TargetTypeExtensionRange = 2,
				[OriginalName("TARGET_TYPE_MESSAGE")]
				TargetTypeMessage = 3,
				[OriginalName("TARGET_TYPE_FIELD")]
				TargetTypeField = 4,
				[OriginalName("TARGET_TYPE_ONEOF")]
				TargetTypeOneof = 5,
				[OriginalName("TARGET_TYPE_ENUM")]
				TargetTypeEnum = 6,
				[OriginalName("TARGET_TYPE_ENUM_ENTRY")]
				TargetTypeEnumEntry = 7,
				[OriginalName("TARGET_TYPE_SERVICE")]
				TargetTypeService = 8,
				[OriginalName("TARGET_TYPE_METHOD")]
				TargetTypeMethod = 9
			}

			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class EditionDefault : IMessage<EditionDefault>, IMessage, IEquatable<EditionDefault>, IDeepCloneable<EditionDefault>, IBufferMessage
			{
				private static readonly MessageParser<EditionDefault> _parser;

				private UnknownFieldSet _unknownFields;

				private int _hasBits0;

				public const int EditionFieldNumber = 3;

				private static readonly Edition EditionDefaultValue;

				private Edition edition_;

				public const int ValueFieldNumber = 2;

				private static readonly string ValueDefaultValue;

				private string value_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<EditionDefault> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Edition Edition
				{
					get
					{
						return default(Edition);
					}
					set
					{
					}
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public bool HasEdition => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public string Value
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
				public bool HasValue => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public EditionDefault()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public EditionDefault(EditionDefault other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public EditionDefault Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearEdition()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearValue()
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
				public bool Equals(EditionDefault other)
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
				public void MergeFrom(EditionDefault other)
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

		private static readonly MessageParser<FieldOptions> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<FieldOptions> _extensions;

		private int _hasBits0;

		public const int CtypeFieldNumber = 1;

		private static readonly Types.CType CtypeDefaultValue;

		private Types.CType ctype_;

		public const int PackedFieldNumber = 2;

		private static readonly bool PackedDefaultValue;

		private bool packed_;

		public const int JstypeFieldNumber = 6;

		private static readonly Types.JSType JstypeDefaultValue;

		private Types.JSType jstype_;

		public const int LazyFieldNumber = 5;

		private static readonly bool LazyDefaultValue;

		private bool lazy_;

		public const int UnverifiedLazyFieldNumber = 15;

		private static readonly bool UnverifiedLazyDefaultValue;

		private bool unverifiedLazy_;

		public const int DeprecatedFieldNumber = 3;

		private static readonly bool DeprecatedDefaultValue;

		private bool deprecated_;

		public const int WeakFieldNumber = 10;

		private static readonly bool WeakDefaultValue;

		private bool weak_;

		public const int DebugRedactFieldNumber = 16;

		private static readonly bool DebugRedactDefaultValue;

		private bool debugRedact_;

		public const int RetentionFieldNumber = 17;

		private static readonly Types.OptionRetention RetentionDefaultValue;

		private Types.OptionRetention retention_;

		public const int TargetsFieldNumber = 19;

		private static readonly FieldCodec<Types.OptionTargetType> _repeated_targets_codec;

		private readonly RepeatedField<Types.OptionTargetType> targets_;

		public const int EditionDefaultsFieldNumber = 20;

		private static readonly FieldCodec<Types.EditionDefault> _repeated_editionDefaults_codec;

		private readonly RepeatedField<Types.EditionDefault> editionDefaults_;

		public const int FeaturesFieldNumber = 21;

		private FeatureSet features_;

		public const int UninterpretedOptionFieldNumber = 999;

		private static readonly FieldCodec<UninterpretedOption> _repeated_uninterpretedOption_codec;

		private readonly RepeatedField<UninterpretedOption> uninterpretedOption_;

		private ExtensionSet<FieldOptions> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FieldOptions> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.CType Ctype
		{
			get
			{
				return default(Types.CType);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasCtype => false;

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
		public bool HasPacked => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.JSType Jstype
		{
			get
			{
				return default(Types.JSType);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasJstype => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Lazy
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
		public bool HasLazy => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool UnverifiedLazy
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
		public bool HasUnverifiedLazy => false;

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
		public bool Weak
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
		public bool HasWeak => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool DebugRedact
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
		public bool HasDebugRedact => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.OptionRetention Retention
		{
			get
			{
				return default(Types.OptionRetention);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasRetention => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.OptionTargetType> Targets => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.EditionDefault> EditionDefaults => null;

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
		public FieldOptions()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldOptions(FieldOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldOptions Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearCtype()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPacked()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearJstype()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearLazy()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearUnverifiedLazy()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDeprecated()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearWeak()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDebugRedact()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearRetention()
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
		public bool Equals(FieldOptions other)
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
		public void MergeFrom(FieldOptions other)
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

		public TValue GetExtension<TValue>(Extension<FieldOptions, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<FieldOptions, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<FieldOptions, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<FieldOptions, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<FieldOptions, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<FieldOptions, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<FieldOptions, TValue> extension)
		{
		}
	}
}
