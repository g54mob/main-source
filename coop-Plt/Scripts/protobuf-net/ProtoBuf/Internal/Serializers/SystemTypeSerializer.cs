using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class SystemTypeSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly SystemTypeSerializer Instance = new SystemTypeSerializer();

		private static readonly Type expectedType = typeof(Type);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private SystemTypeSerializer()
		{
		}

		void IRuntimeProtoSerializerNode.Write(ref ProtoWriter.State state, object value)
		{
			state.WriteType((Type)value);
		}

		object IRuntimeProtoSerializerNode.Read(ref ProtoReader.State state, object value)
		{
			return state.ReadType();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteType", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadType", ExpectedType);
		}
	}
}
