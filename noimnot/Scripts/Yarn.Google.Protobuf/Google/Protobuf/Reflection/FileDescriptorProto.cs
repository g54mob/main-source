using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FileDescriptorProto : IMessage<FileDescriptorProto>, IMessage, IEquatable<FileDescriptorProto>, IDeepCloneable<FileDescriptorProto>, IBufferMessage
	{
		private static readonly MessageParser<FileDescriptorProto> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int NameFieldNumber = 1;

		private static readonly string NameDefaultValue;

		private string name_;

		public const int PackageFieldNumber = 2;

		private static readonly string PackageDefaultValue;

		private string package_;

		public const int DependencyFieldNumber = 3;

		private static readonly FieldCodec<string> _repeated_dependency_codec;

		private readonly RepeatedField<string> dependency_;

		public const int PublicDependencyFieldNumber = 10;

		private static readonly FieldCodec<int> _repeated_publicDependency_codec;

		private readonly RepeatedField<int> publicDependency_;

		public const int WeakDependencyFieldNumber = 11;

		private static readonly FieldCodec<int> _repeated_weakDependency_codec;

		private readonly RepeatedField<int> weakDependency_;

		public const int MessageTypeFieldNumber = 4;

		private static readonly FieldCodec<DescriptorProto> _repeated_messageType_codec;

		private readonly RepeatedField<DescriptorProto> messageType_;

		public const int EnumTypeFieldNumber = 5;

		private static readonly FieldCodec<EnumDescriptorProto> _repeated_enumType_codec;

		private readonly RepeatedField<EnumDescriptorProto> enumType_;

		public const int ServiceFieldNumber = 6;

		private static readonly FieldCodec<ServiceDescriptorProto> _repeated_service_codec;

		private readonly RepeatedField<ServiceDescriptorProto> service_;

		public const int ExtensionFieldNumber = 7;

		private static readonly FieldCodec<FieldDescriptorProto> _repeated_extension_codec;

		private readonly RepeatedField<FieldDescriptorProto> extension_;

		public const int OptionsFieldNumber = 8;

		private FileOptions options_;

		public const int SourceCodeInfoFieldNumber = 9;

		private SourceCodeInfo sourceCodeInfo_;

		public const int SyntaxFieldNumber = 12;

		private static readonly string SyntaxDefaultValue;

		private string syntax_;

		public const int EditionFieldNumber = 14;

		private static readonly Edition EditionDefaultValue;

		private Edition edition_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FileDescriptorProto> Parser => null;

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
		public string Package
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
		public bool HasPackage => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<string> Dependency => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<int> PublicDependency => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<int> WeakDependency => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<DescriptorProto> MessageType => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<EnumDescriptorProto> EnumType => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<ServiceDescriptorProto> Service => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<FieldDescriptorProto> Extension => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FileOptions Options
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
		public SourceCodeInfo SourceCodeInfo
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
		public string Syntax
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
		public bool HasSyntax => false;

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
		public FileDescriptorProto()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FileDescriptorProto(FileDescriptorProto other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FileDescriptorProto Clone()
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
		public void ClearPackage()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearSyntax()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearEdition()
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
		public bool Equals(FileDescriptorProto other)
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
		public void MergeFrom(FileDescriptorProto other)
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
