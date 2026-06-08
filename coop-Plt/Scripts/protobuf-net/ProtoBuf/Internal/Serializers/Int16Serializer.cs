using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class Int16Serializer : IRuntimeProtoSerializerNode
	{
		internal static readonly Int16Serializer Instance = new Int16Serializer();

		private static readonly Type expectedType = typeof(short);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private Int16Serializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadInt16();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteInt16((short)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteInt16", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadInt16", ExpectedType);
		}
	}
}
