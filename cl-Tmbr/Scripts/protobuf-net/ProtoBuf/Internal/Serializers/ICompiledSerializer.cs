using System;

namespace ProtoBuf.Internal.Serializers
{
	internal interface ICompiledSerializer
	{
		Type ExpectedType { get; }
	}
}
