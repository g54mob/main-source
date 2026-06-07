using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.Compiler
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class CodeGeneratorRequest : IMessage<CodeGeneratorRequest>, IMessage, IEquatable<CodeGeneratorRequest>, IDeepCloneable<CodeGeneratorRequest>, IBufferMessage
	{
		private static readonly MessageParser<CodeGeneratorRequest> _parser;

		private UnknownFieldSet _unknownFields;

		public const int FileToGenerateFieldNumber = 1;

		private static readonly FieldCodec<string> _repeated_fileToGenerate_codec;

		private readonly RepeatedField<string> fileToGenerate_;

		public const int ParameterFieldNumber = 2;

		private static readonly string ParameterDefaultValue;

		private string parameter_;

		public const int ProtoFileFieldNumber = 15;

		private static readonly FieldCodec<FileDescriptorProto> _repeated_protoFile_codec;

		private readonly RepeatedField<FileDescriptorProto> protoFile_;

		public const int SourceFileDescriptorsFieldNumber = 17;

		private static readonly FieldCodec<FileDescriptorProto> _repeated_sourceFileDescriptors_codec;

		private readonly RepeatedField<FileDescriptorProto> sourceFileDescriptors_;

		public const int CompilerVersionFieldNumber = 3;

		private Version compilerVersion_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<CodeGeneratorRequest> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<string> FileToGenerate => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Parameter
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
		public bool HasParameter => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<FileDescriptorProto> ProtoFile => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<FileDescriptorProto> SourceFileDescriptors => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Version CompilerVersion
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
		public CodeGeneratorRequest()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public CodeGeneratorRequest(CodeGeneratorRequest other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public CodeGeneratorRequest Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearParameter()
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
		public bool Equals(CodeGeneratorRequest other)
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
		public void MergeFrom(CodeGeneratorRequest other)
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
