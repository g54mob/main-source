using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal interface IRuntimeProtoSerializerNode
	{
		bool IsScalar { get; }

		Type ExpectedType { get; }

		bool RequiresOldValue { get; }

		bool ReturnsValue { get; }

		void Write(ref ProtoWriter.State state, object value);

		object Read(ref ProtoReader.State state, object value);

		void EmitWrite(CompilerContext ctx, Local valueFrom);

		void EmitRead(CompilerContext ctx, Local entity);
	}
}
