using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ClipperLib
{
	public class PolyNode
	{
		internal PolyNode m_Parent;

		internal List<IntPoint> m_polygon;

		internal int m_Index;

		internal JoinType m_jointype;

		internal EndType m_endtype;

		internal List<PolyNode> m_Childs;

		[CompilerGenerated]
		private bool _003CIsOpen_003Ek__BackingField;

		public int ChildCount => 0;

		public List<PolyNode> Childs => null;

		internal void AddChild(PolyNode Child)
		{
		}
	}
}
