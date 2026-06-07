using System;
using Unity.Properties;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[GeneratePropertyBag]
	public struct GraphMask
	{
		[SerializeField]
		private int value;

		private const uint LargeGraphIndicesBit = 2147483648u;

		private const uint InvertedBit = 1073741824u;

		private const uint SmallestLargeGraphIndex = 30u;

		private const uint RemainingGraphIndicesBit = 1073741824u;

		private const uint Everything = 4294967295u;

		public static GraphMask everything => default(GraphMask);

		public bool containsAllGraphs => false;

		public bool isPureBitmask => false;

		public GraphMask(uint value)
		{
			this.value = 0;
		}

		public static GraphMask operator |(GraphMask lhs, GraphMask rhs)
		{
			return default(GraphMask);
		}

		private unsafe static void InsertMask(uint* indices, ref int cnt, uint mask)
		{
		}

		private unsafe static void InsertSorted(uint* indices, ref int cnt, uint value)
		{
		}

		public static GraphMask operator ~(GraphMask lhs)
		{
			return default(GraphMask);
		}

		public static bool operator ==(GraphMask lhs, GraphMask rhs)
		{
			return false;
		}

		public static bool operator !=(GraphMask lhs, GraphMask rhs)
		{
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			return false;
		}

		public override readonly int GetHashCode()
		{
			return 0;
		}

		public readonly bool Contains(NavGraph graph)
		{
			return false;
		}

		public readonly bool Contains(uint graphIndex)
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

		public static GraphMask FromGraphIndex(uint graphIndex)
		{
			return default(GraphMask);
		}

		public static GraphMask FromGraphName(string graphName)
		{
			return default(GraphMask);
		}
	}
}
