using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class UninterpretedOption : IMessage<UninterpretedOption>, IMessage, IEquatable<UninterpretedOption>, IDeepCloneable<UninterpretedOption>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class NamePart : IMessage<NamePart>, IMessage, IEquatable<NamePart>, IDeepCloneable<NamePart>, IBufferMessage
			{
				private static readonly MessageParser<NamePart> _parser;

				private UnknownFieldSet _unknownFields;

				private int _hasBits0;

				public const int NamePart_FieldNumber = 1;

				private static readonly string NamePart_DefaultValue;

				private string namePart_;

				public const int IsExtensionFieldNumber = 2;

				private static readonly bool IsExtensionDefaultValue;

				private bool isExtension_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<NamePart> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public string NamePart_
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
				public bool HasNamePart_ => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public bool IsExtension
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
				public bool HasIsExtension => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public NamePart()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public NamePart(NamePart other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public NamePart Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearNamePart_()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearIsExtension()
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
				public bool Equals(NamePart other)
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
				public void MergeFrom(NamePart other)
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

		private static readonly MessageParser<UninterpretedOption> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int NameFieldNumber = 2;

		private static readonly FieldCodec<Types.NamePart> _repeated_name_codec;

		private readonly RepeatedField<Types.NamePart> name_;

		public const int IdentifierValueFieldNumber = 3;

		private static readonly string IdentifierValueDefaultValue;

		private string identifierValue_;

		public const int PositiveIntValueFieldNumber = 4;

		private static readonly ulong PositiveIntValueDefaultValue;

		private ulong positiveIntValue_;

		public const int NegativeIntValueFieldNumber = 5;

		private static readonly long NegativeIntValueDefaultValue;

		private long negativeIntValue_;

		public const int DoubleValueFieldNumber = 6;

		private static readonly double DoubleValueDefaultValue;

		private double doubleValue_;

		public const int StringValueFieldNumber = 7;

		private static readonly ByteString StringValueDefaultValue;

		private ByteString stringValue_;

		public const int AggregateValueFieldNumber = 8;

		private static readonly string AggregateValueDefaultValue;

		private string aggregateValue_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<UninterpretedOption> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.NamePart> Name => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string IdentifierValue
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
		public bool HasIdentifierValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ulong PositiveIntValue
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPositiveIntValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public long NegativeIntValue
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasNegativeIntValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public double DoubleValue
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDoubleValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ByteString StringValue
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
		public bool HasStringValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string AggregateValue
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
		public bool HasAggregateValue => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public UninterpretedOption()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public UninterpretedOption(UninterpretedOption other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public UninterpretedOption Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearIdentifierValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPositiveIntValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearNegativeIntValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDoubleValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearStringValue()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearAggregateValue()
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
		public bool Equals(UninterpretedOption other)
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
		public void MergeFrom(UninterpretedOption other)
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
