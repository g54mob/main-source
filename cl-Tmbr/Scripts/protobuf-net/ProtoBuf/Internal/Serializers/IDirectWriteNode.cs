using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal interface IDirectWriteNode
	{
		bool CanEmitDirectWrite(WireType wireType);

		void EmitDirectWrite(int fieldNumber, WireType wireType, CompilerContext ctx, Local valueFrom);
	}
}
