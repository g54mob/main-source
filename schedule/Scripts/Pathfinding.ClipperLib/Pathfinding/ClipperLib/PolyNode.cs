using System.Collections.Generic;

namespace Pathfinding.ClipperLib
{
	public class PolyNode
	{
		internal PolyNode m_Parent;

		internal List<IntPoint> m_polygon;

		internal int m_Index;

		internal List<PolyNode> m_Childs;

		public int ChildCount => 0;

		public List<IntPoint> Contour => null;

		public List<PolyNode> Childs => null;

		public PolyNode Parent => null;

		public bool IsHole => false;

		public bool IsOpen { get; set; }

		private bool IsHoleNode()
		{
			return false;
		}

		internal void AddChild(PolyNode Child)
		{
		}

		public PolyNode GetNext()
		{
			return null;
		}

		internal PolyNode GetNextSiblingUp()
		{
			return null;
		}
	}
}
