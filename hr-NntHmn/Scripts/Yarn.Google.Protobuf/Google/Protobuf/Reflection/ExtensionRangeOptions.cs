using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class ExtensionRangeOptions : IExtendableMessage<ExtensionRangeOptions>, IMessage<ExtensionRangeOptions>, IMessage, IEquatable<ExtensionRangeOptions>, IDeepCloneable<ExtensionRangeOptions>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum VerificationState
			{
				[OriginalName("DECLARATION")]
				Declaration = 0,
				[OriginalName("UNVERIFIED")]
				Unverified = 1
			}

			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class Declaration : IMessage<Declaration>, IMessage, IEquatable<Declaration>, IDeepCloneable<Declaration>, IBufferMessage
			{
				private static readonly MessageParser<Declaration> _parser;

				private UnknownFieldSet _unknownFields;

				private int _hasBits0;

				public const int NumberFieldNumber = 1;

				private static readonly int NumberDefaultValue;

				private int number_;

				public const int FullNameFieldNumber = 2;

				private static readonly string FullNameDefaultValue;

				private string fullName_;

				public const int TypeFieldNumber = 3;

				private static readonly string TypeDefaultValue;

				private string type_;

				public const int ReservedFieldNumber = 5;

				private static readonly bool ReservedDefaultValue;

				private bool reserved_;

				public const int RepeatedFieldNumber = 6;

				private static readonly bool RepeatedDefaultValue;

				private bool repeated_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<Declaration> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

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
				public string FullName
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
				public bool HasFullName => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public string Type
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
				public bool HasType => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public bool Reserved
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
				public bool HasReserved => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public bool Repeated
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
				public bool HasRepeated => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Declaration()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Declaration(Declaration other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Declaration Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearNumber()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearFullName()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearType()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearReserved()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearRepeated()
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
				public bool Equals(Declaration other)
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
				public void MergeFrom(Declaration other)
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

		private static readonly MessageParser<ExtensionRangeOptions> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<ExtensionRangeOptions> _extensions;

		private int _hasBits0;

		public const int UninterpretedOptionFieldNumber = 999;

		private static readonly FieldCodec<UninterpretedOption> _repeated_uninterpretedOption_codec;

		private readonly RepeatedField<UninterpretedOption> uninterpretedOption_;

		public const int DeclarationFieldNumber = 2;

		private static readonly FieldCodec<Types.Declaration> _repeated_declaration_codec;

		private readonly RepeatedField<Types.Declaration> declaration_;

		public const int FeaturesFieldNumber = 50;

		private FeatureSet features_;

		public const int VerificationFieldNumber = 3;

		private static readonly Types.VerificationState VerificationDefaultValue;

		private Types.VerificationState verification_;

		private ExtensionSet<ExtensionRangeOptions> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<ExtensionRangeOptions> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<UninterpretedOption> UninterpretedOption => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.Declaration> Declaration => null;

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
		public Types.VerificationState Verification
		{
			get
			{
				return default(Types.VerificationState);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasVerification => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ExtensionRangeOptions()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ExtensionRangeOptions(ExtensionRangeOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ExtensionRangeOptions Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearVerification()
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
		public bool Equals(ExtensionRangeOptions other)
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
		public void MergeFrom(ExtensionRangeOptions other)
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

		public TValue GetExtension<TValue>(Extension<ExtensionRangeOptions, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<ExtensionRangeOptions, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<ExtensionRangeOptions, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<ExtensionRangeOptions, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<ExtensionRangeOptions, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<ExtensionRangeOptions, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<ExtensionRangeOptions, TValue> extension)
		{
		}
	}
}
