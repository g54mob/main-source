using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Api : IMessage<Api>, IMessage, IEquatable<Api>, IDeepCloneable<Api>, IBufferMessage
	{
		private static readonly MessageParser<Api> _parser;

		private UnknownFieldSet _unknownFields;

		public const int NameFieldNumber = 1;

		private string name_;

		public const int MethodsFieldNumber = 2;

		private static readonly FieldCodec<Method> _repeated_methods_codec;

		private readonly RepeatedField<Method> methods_;

		public const int OptionsFieldNumber = 3;

		private static readonly FieldCodec<Option> _repeated_options_codec;

		private readonly RepeatedField<Option> options_;

		public const int VersionFieldNumber = 4;

		private string version_;

		public const int SourceContextFieldNumber = 5;

		private SourceContext sourceContext_;

		public const int MixinsFieldNumber = 6;

		private static readonly FieldCodec<Mixin> _repeated_mixins_codec;

		private readonly RepeatedField<Mixin> mixins_;

		public const int SyntaxFieldNumber = 7;

		private Syntax syntax_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Api> Parser => null;

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
		public RepeatedField<Method> Methods => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Option> Options => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Version
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
		public RepeatedField<Mixin> Mixins => null;

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
		public Api()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Api(Api other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Api Clone()
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
		public bool Equals(Api other)
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
		public void MergeFrom(Api other)
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
