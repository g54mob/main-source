using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class Int64Serializer : IRuntimeProtoSerializerNode
	{
		internal static readonly Int64Serializer Instance = new Int64Serializer();

		private static readonly Type expectedType = typeof(long);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private Int64Serializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadInt64();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteInt64((long)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteInt64", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadInt64", ExpectedType);
		}
	}
}
