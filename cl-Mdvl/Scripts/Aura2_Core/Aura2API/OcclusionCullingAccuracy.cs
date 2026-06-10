using System;

namespace Aura2API
{
	public enum OcclusionCullingAccuracy
	{
		Lowest = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		[Obsolete("This setting will temporarilly fallback on \"High\" for compatibility reasons.")]
		Highest = 3
	}
}
