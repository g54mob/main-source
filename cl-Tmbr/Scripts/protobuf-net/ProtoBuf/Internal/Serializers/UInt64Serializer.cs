using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class UInt64Serializer : IRuntimeProtoSerializerNode
	{
		internal static readonly UInt64Serializer Instance = new UInt64Serializer();

		private static readonly Type expectedType = typeof(ulong);

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private UInt64Serializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadUInt64();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteUInt64((ulong)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteUInt64", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadUInt64", ExpectedType);
		}
	}
}
