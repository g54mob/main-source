using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Yarn
{
	public sealed class Program : IMessage<Program>, IMessage, IEquatable<Program>, IDeepCloneable<Program>, IBufferMessage
	{
		private static readonly MessageParser<Program> _parser;

		private UnknownFieldSet _unknownFields;

		public const int NameFieldNumber = 1;

		private string name_;

		public const int NodesFieldNumber = 2;

		private static readonly MapField<string, Node>.Codec _map_nodes_codec;

		private readonly MapField<string, Node> nodes_;

		public const int InitialValuesFieldNumber = 3;

		private static readonly MapField<string, Operand>.Codec _map_initialValues_codec;

		private readonly MapField<string, Operand> initialValues_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Program> Parser => null;

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
		public MapField<string, Node> Nodes => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MapField<string, Operand> InitialValues => null;

		internal string DumpCode(Library l)
		{
			return null;
		}

		public List<string> LineIDsForNode(string nodeName)
		{
			return null;
		}

		internal IEnumerable<string> GetTagsForNode(string nodeName)
		{
			return null;
		}

		public static Program Combine(params Program[] programs)
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Program()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Program(Program other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Program Clone()
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
		public bool Equals(Program other)
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
		public void MergeFrom(Program other)
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
