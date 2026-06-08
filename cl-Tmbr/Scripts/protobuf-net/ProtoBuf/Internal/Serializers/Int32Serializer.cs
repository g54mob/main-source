using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class Int32Serializer : IRuntimeProtoSerializerNode, IDirectWriteNode
	{
		internal static readonly Int32Serializer Instance = new Int32Serializer();

		private static readonly Type expectedType = typeof(int);

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private Int32Serializer()
		{
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadInt32();
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteInt32((int)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteInt32", valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.EmitStateBasedRead("ReadInt32", ExpectedType);
		}

		bool IDirectWriteNode.CanEmitDirectWrite(WireType wireType)
		{
			return wireType == WireType.Variant;
		}

		void IDirectWriteNode.EmitDirectWrite(int fieldNumber, WireType wireType, CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(int), valueFrom);
			ctx.LoadState();
			ctx.LoadValue(fieldNumber);
			ctx.LoadValue(local);
			ctx.EmitCall(typeof(ProtoWriter.State).GetMethod("WriteInt32Varint", BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
			{
				typeof(int),
				typeof(int)
			}, null));
		}
	}
}
