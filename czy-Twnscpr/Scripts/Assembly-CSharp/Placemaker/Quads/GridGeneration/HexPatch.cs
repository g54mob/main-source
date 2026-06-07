using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Placemaker.Quads.GridGeneration
{
	[Serializable]
	public class HexPatch
	{
		public enum State : byte
		{
			Verts = 0,
			Triangulate = 1,
			Quadrangulate = 2,
			Subdivide = 3,
			Sort = 4,
			Done = 5
		}

		public int2 hexPos;

		public ushort quadTriCutoff;

		public List<byte> quads;

		public List<int2> verts;

		public MotivationCounter motivations;

		public State state;

		public byte subdivisions;

		public bool done => false;
	}
}
