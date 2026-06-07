using System.Collections.Generic;

namespace Brewery.Face
{
	public class FaceFrame
	{
		private readonly Dictionary<int, float> _values;

		private readonly List<int> _dirtyIndices;

		public IReadOnlyList<int> DirtyIndices => null;

		public void Clear()
		{
		}

		public void Add(int blendIndex, float weight, float sourceFade)
		{
		}

		public void SetExclusive(int blendIndex, float weight)
		{
		}

		public float Get(int blendIndex)
		{
			return 0f;
		}
	}
}
