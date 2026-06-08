using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal class UInt16Serializer : IRuntimeProtoSerializerNode
	{
		internal static readonly UInt16Serializer Instance = new UInt16Serializer();

		private static readonly Type expectedType = typeof(ushort);

		public virtual Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		protected UInt16Serializer()
		{
		}

		public virtual object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadUInt16();
		}

		public virtual void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteUInt16((ushort)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteUInt16", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadUInt16", typeof(ushort));
		}
	}
}
