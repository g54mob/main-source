using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace ModApi.Design
{
	public interface ISymmetryGroup
	{
		AttachPoint AttachPoint { get; }

		int Count { get; }

		IPartScript RootPart { get; }

		List<ISymmetrySlice> Slices { get; }

		SymmetryMode SymmetryMode { get; }
	}
}
