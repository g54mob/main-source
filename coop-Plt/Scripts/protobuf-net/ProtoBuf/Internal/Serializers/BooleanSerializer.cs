using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class BooleanSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly BooleanSerializer Instance = new BooleanSerializer();

		private static readonly Type expectedType = typeof(bool);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private BooleanSerializer()
		{
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteBoolean((bool)value);
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadBoolean();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteBoolean", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadBoolean", ExpectedType);
		}
	}
}
