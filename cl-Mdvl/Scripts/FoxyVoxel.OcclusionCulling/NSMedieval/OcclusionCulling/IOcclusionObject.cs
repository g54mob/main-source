using UnityEngine;

namespace NSMedieval.OcclusionCulling
{
	public interface IOcclusionObject
	{
		OcclusionCullingMode OcclusionCullingMode { get; }

		bool IsOcclusionCulled { get; set; }

		Bounds OcclusionLocalSpaceBoundingBox { get; }

		Vector3 WorldPosition { get; }
	}
}
