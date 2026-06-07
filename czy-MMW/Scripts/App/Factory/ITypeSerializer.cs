using System;

namespace Factory
{
	public interface ITypeSerializer : ISerializer
	{
		Type Type { get; }

		int TypeId { get; }

		int Version { get; }
	}
}
