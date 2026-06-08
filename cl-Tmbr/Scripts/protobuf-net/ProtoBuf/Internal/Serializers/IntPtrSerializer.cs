using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class IntPtrSerializer : IRuntimeProtoSerializerNode
	{
		internal static readonly IntPtrSerializer Instance = new IntPtrSerializer();

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => typeof(IntPtr);

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private IntPtrSerializer()
		{
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteIntPtr((IntPtr)value);
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadIntPtr();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteIntPtr", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadIntPtr", ExpectedType);
		}
	}
}
