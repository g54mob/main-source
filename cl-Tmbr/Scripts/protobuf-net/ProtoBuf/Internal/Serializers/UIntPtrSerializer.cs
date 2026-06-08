using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class UIntPtrSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly UIntPtrSerializer Instance = new UIntPtrSerializer();

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => typeof(UIntPtr);

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private UIntPtrSerializer()
		{
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteUIntPtr((UIntPtr)value);
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadUIntPtr();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteUIntPtr", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadUIntPtr", ExpectedType);
		}
	}
}
