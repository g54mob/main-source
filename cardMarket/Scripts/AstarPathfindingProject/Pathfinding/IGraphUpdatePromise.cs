using System.Collections.Generic;
using Unity.Jobs;

namespace Pathfinding
{
	public interface IGraphUpdatePromise
	{
		float Progress => 0f;

		IEnumerator<JobHandle> Prepare()
		{
			return null;
		}

		void Apply(IGraphUpdateContext context);
	}
}
