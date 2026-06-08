using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class UInt32Serializer : IRuntimeProtoSerializerNode
	{
		internal static readonly UInt32Serializer Instance = new UInt32Serializer();

		private static readonly Type expectedType = typeof(uint);

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private UInt32Serializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadUInt32();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteUInt32((uint)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteUInt32", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadUInt32", typeof(uint));
		}
	}
}
