using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Placemaker.Quads.GridGeneration
{
	[Serializable]
	public struct MotivationCounter : IEnumerable<int2>, IEnumerable
	{
		public byte count;

		public int AddMotivation(int2 source)
		{
			return 0;
		}

		public int RemoveMotivation(int2 source)
		{
			return 0;
		}

		public IEnumerator<int2> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
