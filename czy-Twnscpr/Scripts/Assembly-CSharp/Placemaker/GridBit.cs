using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public class GridBit : MonoBehaviour
	{
		public enum State : byte
		{
			Verts = 0,
			Relax = 1,
			Clusters = 2,
			Compose = 3,
			Mesh = 4,
			Done = 5
		}

		public int2 hexPos;

		public byte motivations;

		public byte relaxationSteps;

		public byte clusterCount;

		public bool patchDone;

		public State state;

		public List<float2> verts;

		public bool done => false;
	}
}
