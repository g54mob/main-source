using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class BlobSerializer : IRuntimeProtoSerializerNode
	{
		private static readonly Type expectedType = typeof(byte[]);

		private readonly bool overwriteList;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => !overwriteList;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public BlobSerializer(bool overwriteList)
		{
			this.overwriteList = overwriteList;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.AppendBytes(overwriteList ? null : ((byte[])value));
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteBytes((byte[])value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite("WriteBytes", valueFrom, null, typeof(byte[]));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			using Local local = (overwriteList ? null : ctx.GetLocalWithValue(typeof(byte[]), entity));
			ctx.LoadState();
			if (overwriteList)
			{
				ctx.LoadNullRef();
			}
			else
			{
				ctx.LoadValue(local);
			}
			ctx.EmitCall(typeof(ProtoReader.State).GetMethod("AppendBytes", new Type[1] { typeof(byte[]) }));
		}
	}
}
