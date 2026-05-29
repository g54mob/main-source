using System;
using UnityEngine;

namespace Placemaker.Graphs
{
	[Serializable]
	public struct FlowData
	{
		public Voxel voxel;

		public byte neighbourCount;

		public float dist;

		public float newDist;

		public float denom;

		public Vector3 dir;

		public Vector3 newDir;

		public bool target;

		public static readonly FlowData empty;
	}
}
