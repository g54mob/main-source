using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace ModApi.Design
{
	public interface ISymmetrySlice
	{
		float Angle { get; }

		List<PartData> Parts { get; }

		PartData SliceRootPart { get; set; }

		ISymmetryGroup SymmetryGroup { get; }

		PartData GetPart(Guid symmetryId);

		void UpdatePartTransform(IPartScript sourcePart, IPartScript symmetricPart);
	}
}
