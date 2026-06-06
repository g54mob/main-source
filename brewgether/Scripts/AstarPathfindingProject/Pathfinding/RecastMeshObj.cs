using System;

namespace Pathfinding
{
	[Obsolete("Has been renamed to RecastNavmeshModifier")]
	public interface RecastMeshObj
	{
		bool enabled { get; set; }

		bool dynamic { get; set; }

		bool solid { get; set; }

		RecastNavmeshModifier.GeometrySource geometrySource { get; set; }

		RecastNavmeshModifier.ScanInclusion includeInScan { get; set; }

		int surfaceID { get; set; }

		RecastNavmeshModifier.Mode mode { get; set; }
	}
}
