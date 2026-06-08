using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class SingleSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly SingleSerializer Instance = new SingleSerializer();

		private static readonly Type expectedType = typeof(float);

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private SingleSerializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadSingle();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteSingle((float)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteSingle", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadSingle", ExpectedType);
		}
	}
}
