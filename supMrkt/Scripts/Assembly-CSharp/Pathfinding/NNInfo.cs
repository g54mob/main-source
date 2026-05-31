using System;
using UnityEngine;

namespace Pathfinding
{
	public struct NNInfo
	{
		public readonly GraphNode node;

		public readonly Vector3 position;

		[Obsolete("This field has been renamed to 'position'")]
		public Vector3 clampedPosition => default(Vector3);

		public NNInfo(NNInfoInternal internalInfo)
		{
			node = null;
			position = default(Vector3);
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
