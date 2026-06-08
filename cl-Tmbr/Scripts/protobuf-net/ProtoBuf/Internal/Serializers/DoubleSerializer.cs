using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class DoubleSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly DoubleSerializer Instance = new DoubleSerializer();

		private static readonly Type expectedType = typeof(double);

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private DoubleSerializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadDouble();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteDouble((double)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteDouble", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadDouble", ExpectedType);
		}
	}
}
