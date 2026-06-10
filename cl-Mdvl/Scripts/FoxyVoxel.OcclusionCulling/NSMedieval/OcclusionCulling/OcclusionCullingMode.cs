using System;

namespace NSMedieval.OcclusionCulling
{
	[Serializable]
	public enum OcclusionCullingMode
	{
		Disabled = 0,
		CanBeOccludedOnly = 1,
		Enabled = 2
	}
}
