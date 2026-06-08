using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class StringSerializer : IRuntimeProtoSerializerNode, IDirectWriteNode
	{
		internal static readonly StringSerializer Instance = new StringSerializer();

		private static readonly Type expectedType = typeof(string);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		private StringSerializer()
		{
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteString((string)value);
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadString();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(string), valueFrom);
			ctx.LoadState();
			ctx.LoadValue(local);
			ctx.LoadNullRef();
			ctx.EmitCall(typeof(ProtoWriter.State).GetMethod("WriteString", BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
			{
				typeof(string),
				typeof(StringMap)
			}, null));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.LoadState();
			ctx.LoadNullRef();
			ctx.EmitCall(typeof(ProtoReader.State).GetMethod("ReadString", BindingFlags.Instance | BindingFlags.Public, null, new Type[1] { typeof(StringMap) }, null));
		}

		bool IDirectWriteNode.CanEmitDirectWrite(WireType wireType)
		{
			return wireType == WireType.String;
		}

		void IDirectWriteNode.EmitDirectWrite(int fieldNumber, WireType wireType, CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(string), valueFrom);
			ctx.LoadState();
			ctx.LoadValue(fieldNumber);
			ctx.LoadValue(local);
			ctx.LoadNullRef();
			ctx.EmitCall(typeof(ProtoWriter.State).GetMethod("WriteString", BindingFlags.Instance | BindingFlags.Public, null, new Type[3]
			{
				typeof(int),
				typeof(string),
				typeof(StringMap)
			}, null));
		}
	}
}
