using UnityEngine;

namespace Pathfinding
{
	public interface IGraphUpdateContext
	{
		void DirtyBounds(Bounds bounds);
	}
}
