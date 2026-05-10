using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class DescriptorProto : IMessage<DescriptorProto>, IMessage, IEquatable<DescriptorProto>, IDeepCloneable<DescriptorProto>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class ExtensionRange : IMessage<ExtensionRange>, IMessage, IEquatable<ExtensionRange>, IDeepCloneable<ExtensionRange>, IBufferMessage
			{
				private static readonly MessageParser<ExtensionRange> _parser;

				private UnknownFieldSet _unknownFields;

				private int _hasBits0;

				public const int StartFieldNumber = 1;

				private static readonly int StartDefaultValue;

				private int start_;

				public const int EndFieldNumber = 2;

				private static readonly int EndDefaultValue;

				private int end_;

				public const int OptionsFieldNumber = 3;

				private ExtensionRangeOptions options_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<ExtensionRange> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public int Start
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
				public bool HasStart => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public int End
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
				public bool HasEnd => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public ExtensionRangeOptions Options
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
				public ExtensionRange()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public ExtensionRange(ExtensionRange other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public ExtensionRange Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearStart()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearEnd()
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
				public bool Equals(ExtensionRange other)
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
				public void MergeFrom(ExtensionRange other)
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

			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class ReservedRange : IMessage<ReservedRange>, IMessage, IEquatable<ReservedRange>, IDeepCloneable<ReservedRange>, IBufferMessage
			{
				private static readonly MessageParser<ReservedRange> _parser;

				private UnknownFieldSet _unknownFields;

				private int _hasBits0;

				public const int StartFieldNumber = 1;

				private static readonly int StartDefaultValue;

				private int start_;

				public const int EndFieldNumber = 2;

				private static readonly int EndDefaultValue;

				private int end_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<ReservedRange> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public int Start
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
				public bool HasStart => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public int End
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
				public bool HasEnd => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public ReservedRange()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public ReservedRange(ReservedRange other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public ReservedRange Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearStart()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearEnd()
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
				public bool Equals(ReservedRange other)
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
				public void MergeFrom(ReservedRange other)
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

		private static readonly MessageParser<DescriptorProto> _parser;

		private UnknownFieldSet _unknownFields;

		public const int NameFieldNumber = 1;

		private static readonly string NameDefaultValue;

		private string name_;

		public const int FieldFieldNumber = 2;

		private static readonly FieldCodec<FieldDescriptorProto> _repeated_field_codec;

		private readonly RepeatedField<FieldDescriptorProto> field_;

		public const int ExtensionFieldNumber = 6;

		private static readonly FieldCodec<FieldDescriptorProto> _repeated_extension_codec;

		private readonly RepeatedField<FieldDescriptorProto> extension_;

		public const int NestedTypeFieldNumber = 3;

		private static readonly FieldCodec<DescriptorProto> _repeated_nestedType_codec;

		private readonly RepeatedField<DescriptorProto> nestedType_;

		public const int EnumTypeFieldNumber = 4;

		private static readonly FieldCodec<EnumDescriptorProto> _repeated_enumType_codec;

		private readonly RepeatedField<EnumDescriptorProto> enumType_;

		public const int ExtensionRangeFieldNumber = 5;

		private static readonly FieldCodec<Types.ExtensionRange> _repeated_extensionRange_codec;

		private readonly RepeatedField<Types.ExtensionRange> extensionRange_;

		public const int OneofDeclFieldNumber = 8;

		private static readonly FieldCodec<OneofDescriptorProto> _repeated_oneofDecl_codec;

		private readonly RepeatedField<OneofDescriptorProto> oneofDecl_;

		public const int OptionsFieldNumber = 7;

		private MessageOptions options_;

		public const int ReservedRangeFieldNumber = 9;

		private static readonly FieldCodec<Types.ReservedRange> _repeated_reservedRange_codec;

		private readonly RepeatedField<Types.ReservedRange> reservedRange_;

		public const int ReservedNameFieldNumber = 10;

		private static readonly FieldCodec<string> _repeated_reservedName_codec;

		private readonly RepeatedField<string> reservedName_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<DescriptorProto> Parser => null;

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
		public RepeatedField<FieldDescriptorProto> Field => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<FieldDescriptorProto> Extension => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<DescriptorProto> NestedType => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<EnumDescriptorProto> EnumType => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.ExtensionRange> ExtensionRange => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<OneofDescriptorProto> OneofDecl => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MessageOptions Options
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
		public RepeatedField<Types.ReservedRange> ReservedRange => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<string> ReservedName => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public DescriptorProto()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public DescriptorProto(DescriptorProto other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public DescriptorProto Clone()
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
		public override bool Equals(object other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Equals(DescriptorProto other)
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
		public void MergeFrom(DescriptorProto other)
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
