using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.Compiler
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class CodeGeneratorResponse : IMessage<CodeGeneratorResponse>, IMessage, IEquatable<CodeGeneratorResponse>, IDeepCloneable<CodeGeneratorResponse>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum Feature
			{
				[OriginalName("FEATURE_NONE")]
				None = 0,
				[OriginalName("FEATURE_PROTO3_OPTIONAL")]
				Proto3Optional = 1,
				[OriginalName("FEATURE_SUPPORTS_EDITIONS")]
				SupportsEditions = 2
			}

			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class File : IMessage<File>, IMessage, IEquatable<File>, IDeepCloneable<File>, IBufferMessage
			{
				private static readonly MessageParser<File> _parser;

				private UnknownFieldSet _unknownFields;

				public const int NameFieldNumber = 1;

				private static readonly string NameDefaultValue;

				private string name_;

				public const int InsertionPointFieldNumber = 2;

				private static readonly string InsertionPointDefaultValue;

				private string insertionPoint_;

				public const int ContentFieldNumber = 15;

				private static readonly string ContentDefaultValue;

				private string content_;

				public const int GeneratedCodeInfoFieldNumber = 16;

				private GeneratedCodeInfo generatedCodeInfo_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<File> Parser => null;

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
				public string InsertionPoint
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
				public bool HasInsertionPoint => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public string Content
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
				public bool HasContent => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public GeneratedCodeInfo GeneratedCodeInfo
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
				public File()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public File(File other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public File Clone()
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
				public void ClearInsertionPoint()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearContent()
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
				public bool Equals(File other)
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
				public void MergeFrom(File other)
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

		private static readonly MessageParser<CodeGeneratorResponse> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int ErrorFieldNumber = 1;

		private static readonly string ErrorDefaultValue;

		private string error_;

		public const int SupportedFeaturesFieldNumber = 2;

		private static readonly ulong SupportedFeaturesDefaultValue;

		private ulong supportedFeatures_;

		public const int FileFieldNumber = 15;

		private static readonly FieldCodec<Types.File> _repeated_file_codec;

		private readonly RepeatedField<Types.File> file_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<CodeGeneratorResponse> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Error
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
		public bool HasError => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ulong SupportedFeatures
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
		public bool HasSupportedFeatures => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.File> File => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public CodeGeneratorResponse()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public CodeGeneratorResponse(CodeGeneratorResponse other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public CodeGeneratorResponse Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearError()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearSupportedFeatures()
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
		public bool Equals(CodeGeneratorResponse other)
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
		public void MergeFrom(CodeGeneratorResponse other)
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
