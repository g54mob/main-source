using System;

namespace ProtoBuf.Serializers
{
	[Obsolete("This API is deprecated and is never used; it will be removed soon", true)]
	public interface IObjectSerializer<T> : ISerializer<T>
	{
		Type BaseType { get; }
	}
}
