using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal sealed class DepthQuery : QueryBaseSimple, IDepthProvider, IQueryProvider
	{
		protected override int Kernel => 2;

		public DepthQuery()
			: base(ManagerBehaviour<WaterRenderer>.Instance.DepthLod)
		{
		}

		public DepthQuery(WaterRenderer water)
			: base(water.DepthLod)
		{
		}

		public override int Query(int hash, float minimumSpatialLength, Vector3[] queries, Vector3[] results, Vector3? center = null)
		{
			int result = base.Query(hash, minimumSpatialLength, queries, results, center);
			for (int i = 0; i < results.Length; i++)
			{
				Vector3 vector = results[i];
				if (float.IsNaN(vector.x))
				{
					vector.x = float.PositiveInfinity;
				}
				if (float.IsNaN(vector.y))
				{
					vector.y = float.PositiveInfinity;
				}
				results[i] = vector;
			}
			return result;
		}
	}
}
