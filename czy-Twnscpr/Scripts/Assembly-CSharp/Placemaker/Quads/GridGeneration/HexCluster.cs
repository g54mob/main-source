using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Placemaker.Quads.GridGeneration
{
	[Serializable]
	public class HexCluster
	{
		public int2 hexPos;

		public MotivationCounter motivations;

		public byte relaxationSteps;

		public byte patchCount;

		public bool done;

		public int3 patchVertOffsets;

		public List<short> vertIndexes;

		public List<float2> relaxedVerts;
	}
}
