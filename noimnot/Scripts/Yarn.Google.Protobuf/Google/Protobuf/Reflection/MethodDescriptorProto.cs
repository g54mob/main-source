using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class MethodDescriptorProto : IMessage<MethodDescriptorProto>, IMessage, IEquatable<MethodDescriptorProto>, IDeepCloneable<MethodDescriptorProto>, IBufferMessage
	{
		private static readonly MessageParser<MethodDescriptorProto> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int NameFieldNumber = 1;

		private static readonly string NameDefaultValue;

		private string name_;

		public const int InputTypeFieldNumber = 2;

		private static readonly string InputTypeDefaultValue;

		private string inputType_;

		public const int OutputTypeFieldNumber = 3;

		private static readonly string OutputTypeDefaultValue;

		private string outputType_;

		public const int OptionsFieldNumber = 4;

		private MethodOptions options_;

		public const int ClientStreamingFieldNumber = 5;

		private static readonly bool ClientStreamingDefaultValue;

		private bool clientStreaming_;

		public const int ServerStreamingFieldNumber = 6;

		private static readonly bool ServerStreamingDefaultValue;

		private bool serverStreaming_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<MethodDescriptorProto> Parser => null;

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
		public string InputType
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
		public bool HasInputType => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string OutputType
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
		public bool HasOutputType => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodOptions Options
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
		public bool ClientStreaming
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
		public bool HasClientStreaming => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool ServerStreaming
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
		public bool HasServerStreaming => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodDescriptorProto()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodDescriptorProto(MethodDescriptorProto other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodDescriptorProto Clone()
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
		public void ClearInputType()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearOutputType()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearClientStreaming()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearServerStreaming()
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
		public bool Equals(MethodDescriptorProto other)
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
		public void MergeFrom(MethodDescriptorProto other)
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
