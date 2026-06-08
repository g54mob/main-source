using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal abstract class ProtoDecoratorBase : IRuntimeProtoSerializerNode
	{
		protected readonly IRuntimeProtoSerializerNode Tail;

		public virtual bool IsScalar => Tail.IsScalar;

		public abstract Type ExpectedType { get; }

		public abstract bool ReturnsValue { get; }

		public abstract bool RequiresOldValue { get; }

		protected ProtoDecoratorBase(IRuntimeProtoSerializerNode tail)
		{
			Tail = tail;
		}

		public abstract void Write(ref ProtoWriter.State state, object value);

		public abstract object Read(ref ProtoReader.State state, object value);

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			EmitWrite(ctx, valueFrom);
		}

		protected abstract void EmitWrite(CompilerContext ctx, Local valueFrom);

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			EmitRead(ctx, entity);
		}

		protected abstract void EmitRead(CompilerContext ctx, Local valueFrom);
	}
}
