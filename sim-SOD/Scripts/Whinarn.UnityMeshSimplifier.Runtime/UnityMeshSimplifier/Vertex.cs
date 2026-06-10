using System;
using System.Runtime.CompilerServices;

namespace UnityMeshSimplifier
{
	public class Vertex : IEquatable<Vertex>
	{
		public int index;

		public Vector3d p;

		public int tstart;

		public int tcount;

		public int estart;

		public int ecount;

		public SymmetricMatrix q;

		public SymmetricMatrix qPenaltyEdge;

		public bool borderEdge;

		public bool uvSeamEdge;

		public bool uvFoldoverEdge;

		public ToleranceSphere enclosingSphere;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vertex(int index, Vector3d p)
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Vertex other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
