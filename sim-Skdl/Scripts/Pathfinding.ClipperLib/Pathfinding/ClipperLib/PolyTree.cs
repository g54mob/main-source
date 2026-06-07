using System.Collections.Generic;

namespace Pathfinding.ClipperLib
{
	public class PolyTree : PolyNode
	{
		internal List<PolyNode> m_AllPolys;

		public int Total => 0;

		~PolyTree()
		{
		}

		public void Clear()
		{
		}

		public PolyNode GetFirst()
		{
			return null;
		}
	}
}
