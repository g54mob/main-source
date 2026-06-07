using System;
using Unity.Mathematics;

namespace Placemaker
{
	[Serializable]
	public struct BitMeshQuadChange : IComparable<BitMeshQuadChange>
	{
		public byte quadIndex;

		public int2 hexPos;

		public bool state;

		int IComparable<BitMeshQuadChange>.CompareTo(BitMeshQuadChange other)
		{
			return 0;
		}
	}
}
