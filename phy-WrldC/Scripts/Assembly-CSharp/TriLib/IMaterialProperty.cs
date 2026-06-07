using System;

namespace TriLib
{
	public interface IMaterialProperty
	{
		string Name { get; }

		Type Type { get; }

		uint Index { get; }

		uint Semantic { get; }
	}
}
