using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Placemaker.Quads.GridGeneration
{
	[Serializable]
	public class CustomGridPatch
	{
		public List<int2> verts;

		public List<byte> quads;

		public ushort quadTriCutoff;

		public byte subdivisions;
	}
}
