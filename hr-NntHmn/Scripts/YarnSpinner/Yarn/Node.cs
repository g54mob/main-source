using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Yarn
{
	public sealed class Node : IMessage<Node>, IMessage, IEquatable<Node>, IDeepCloneable<Node>, IBufferMessage
	{
		private static readonly MessageParser<Node> _parser;

		private UnknownFieldSet _unknownFields;

		public const int NameFieldNumber = 1;

		private string name_;

		public const int InstructionsFieldNumber = 2;

		private static readonly FieldCodec<Instruction> _repeated_instructions_codec;

		private readonly RepeatedField<Instruction> instructions_;

		public const int LabelsFieldNumber = 3;

		private static readonly MapField<string, int>.Codec _map_labels_codec;

		private readonly MapField<string, int> labels_;

		public const int TagsFieldNumber = 4;

		private static readonly FieldCodec<string> _repeated_tags_codec;

		private readonly RepeatedField<string> tags_;

		public const int SourceTextStringIDFieldNumber = 5;

		private string sourceTextStringID_;

		public const int HeadersFieldNumber = 6;

		private static readonly FieldCodec<Header> _repeated_headers_codec;

		private readonly RepeatedField<Header> headers_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Node> Parser => null;

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
		public RepeatedField<Instruction> Instructions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MapField<string, int> Labels => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<string> Tags => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string SourceTextStringID
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
		public RepeatedField<Header> Headers => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Node()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Node(Node other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Node Clone()
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
		public bool Equals(Node other)
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
		public void MergeFrom(Node other)
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
