using System;

namespace Pathfinding
{
	[Serializable]
	public struct GraphMask
	{
		public int value;

		public static GraphMask everything => default(GraphMask);

		public GraphMask(int value)
		{
			this.value = 0;
		}

		public static implicit operator int(GraphMask mask)
		{
			return 0;
		}

		public static implicit operator GraphMask(int mask)
		{
			return default(GraphMask);
		}

		public static GraphMask operator &(GraphMask lhs, GraphMask rhs)
		{
			return default(GraphMask);
		}

		public static GraphMask operator |(GraphMask lhs, GraphMask rhs)
		{
			return default(GraphMask);
		}

		public static GraphMask operator ~(GraphMask lhs)
		{
			return default(GraphMask);
		}

		public bool Contains(int graphIndex)
		{
			return false;
		}

		public static GraphMask FromGraph(NavGraph graph)
		{
			return default(GraphMask);
		}

		public override string ToString()
		{
			return null;
		}

		public static GraphMask FromGraphName(string graphName)
		{
			return default(GraphMask);
		}
	}
}
