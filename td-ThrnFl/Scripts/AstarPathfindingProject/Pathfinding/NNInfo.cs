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

		public static readonly NNInfo Empty = new NNInfo(null, Vector3.positiveInfinity, float.PositiveInfinity);

		[Obsolete("This field has been renamed to 'position'")]
		public Vector3 clampedPosition => position;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NNInfo(GraphNode node, Vector3 position, float distanceCostSqr)
		{
			this.node = node;
			if (node == null)
			{
				this.position = Vector3.positiveInfinity;
				this.distanceCostSqr = float.PositiveInfinity;
			}
			else
			{
				this.position = position;
				this.distanceCostSqr = distanceCostSqr;
			}
		}

		public static explicit operator Vector3(NNInfo ob)
		{
			return ob.position;
		}

		public static explicit operator GraphNode(NNInfo ob)
		{
			return ob.node;
		}
	}
}
