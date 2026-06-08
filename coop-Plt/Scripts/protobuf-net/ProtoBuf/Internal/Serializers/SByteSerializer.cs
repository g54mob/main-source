using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class SByteSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly SByteSerializer Instance = new SByteSerializer();

		private static readonly Type expectedType = typeof(sbyte);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private SByteSerializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadSByte();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteSByte((sbyte)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteSByte", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadSByte", ExpectedType);
		}
	}
}
