using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Enum : IMessage<Enum>, IMessage, IEquatable<Enum>, IDeepCloneable<Enum>, IBufferMessage
	{
		private static readonly MessageParser<Enum> _parser;

		private UnknownFieldSet _unknownFields;

		public const int NameFieldNumber = 1;

		private string name_;

		public const int EnumvalueFieldNumber = 2;

		private static readonly FieldCodec<EnumValue> _repeated_enumvalue_codec;

		private readonly RepeatedField<EnumValue> enumvalue_;

		public const int OptionsFieldNumber = 3;

		private static readonly FieldCodec<Option> _repeated_options_codec;

		private readonly RepeatedField<Option> options_;

		public const int SourceContextFieldNumber = 4;

		private SourceContext sourceContext_;

		public const int SyntaxFieldNumber = 5;

		private Syntax syntax_;

		public const int EditionFieldNumber = 6;

		private string edition_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Enum> Parser => null;

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
		public RepeatedField<EnumValue> Enumvalue => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Option> Options => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SourceContext SourceContext
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
		public Syntax Syntax
		{
			get
			{
				return default(Syntax);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Edition
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
		public Enum()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Enum(Enum other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Enum Clone()
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
		public bool Equals(Enum other)
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
		public void MergeFrom(Enum other)
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
