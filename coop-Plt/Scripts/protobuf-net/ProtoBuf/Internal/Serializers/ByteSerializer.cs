using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class ByteSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly ByteSerializer Instance = new ByteSerializer();

		private static readonly Type expectedType = typeof(byte);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private ByteSerializer()
		{
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteByte((byte)value);
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadByte();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteByte", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadByte", ExpectedType);
		}
	}
}
