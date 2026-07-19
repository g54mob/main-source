using System.Collections.Generic;

namespace UniHumanoid
{
	public interface ISkeletonDetector
	{
		Skeleton Detect(IList<IBone> bones);
	}
}
