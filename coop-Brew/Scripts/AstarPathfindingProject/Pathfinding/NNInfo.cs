using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding
{
	public readonly struct NNInfo
	{
		public readonly GraphNode node;

		public readonly Vector3 position;

		public readonly float distanceCostSqr;

		public static readonly NNInfo Empty;

		[Obsolete("This field has been renamed to 'position'", true)]
		public Vector3 clampedPosition => default(Vector3);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NNInfo(GraphNode node, Vector3 position, float distanceCostSqr)
		{
			this.node = null;
			this.position = default(Vector3);
			this.distanceCostSqr = 0f;
		}

		public static explicit operator Vector3(NNInfo ob)
		{
			return default(Vector3);
		}

		public static explicit operator GraphNode(NNInfo ob)
		{
			return null;
		}
	}
}
