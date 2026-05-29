using System;
using System.Collections.Generic;

namespace Placemaker
{
	[Serializable]
	public class BigMeshPart
	{
		public BigMesh bigMesh;

		public List<ushort> vertIndexes;

		public List<int> triIndexes;
	}
}
