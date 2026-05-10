using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Yarn
{
	public sealed class Instruction : IMessage<Instruction>, IMessage, IEquatable<Instruction>, IDeepCloneable<Instruction>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum OpCode
			{
				[OriginalName("JUMP_TO")]
				JumpTo = 0,
				[OriginalName("JUMP")]
				Jump = 1,
				[OriginalName("RUN_LINE")]
				RunLine = 2,
				[OriginalName("RUN_COMMAND")]
				RunCommand = 3,
				[OriginalName("ADD_OPTION")]
				AddOption = 4,
				[OriginalName("SHOW_OPTIONS")]
				ShowOptions = 5,
				[OriginalName("PUSH_STRING")]
				PushString = 6,
				[OriginalName("PUSH_FLOAT")]
				PushFloat = 7,
				[OriginalName("PUSH_BOOL")]
				PushBool = 8,
				[OriginalName("PUSH_NULL")]
				PushNull = 9,
				[OriginalName("JUMP_IF_FALSE")]
				JumpIfFalse = 10,
				[OriginalName("POP")]
				Pop = 11,
				[OriginalName("CALL_FUNC")]
				CallFunc = 12,
				[OriginalName("PUSH_VARIABLE")]
				PushVariable = 13,
				[OriginalName("STORE_VARIABLE")]
				StoreVariable = 14,
				[OriginalName("STOP")]
				Stop = 15,
				[OriginalName("RUN_NODE")]
				RunNode = 16
			}
		}

		private static readonly MessageParser<Instruction> _parser;

		private UnknownFieldSet _unknownFields;

		public const int OpcodeFieldNumber = 1;

		private Types.OpCode opcode_;

		public const int OperandsFieldNumber = 2;

		private static readonly FieldCodec<Operand> _repeated_operands_codec;

		private readonly RepeatedField<Operand> operands_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Instruction> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.OpCode Opcode
		{
			get
			{
				return default(Types.OpCode);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Operand> Operands => null;

		internal string ToString(Program p, Library l)
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Instruction()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Instruction(Instruction other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Instruction Clone()
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
		public bool Equals(Instruction other)
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
		public void MergeFrom(Instruction other)
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
