using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	public class CollisionQueryJundroo : CollisionQueryWithPasses
	{
		public CollisionQueryJundroo(WaterRenderer water)
			: base(water)
		{
		}

		public int QueryOnce(int i_ownerHash, float i_minSpatialLength, Span<Vector3> i_queryPoints, bool includeNormals, CollisionLayer layer = CollisionLayer.Everything)
		{
			CollisionQuery provider = GetProvider(layer);
			int num = 0;
			if (!provider.UpdateQueryPoints(i_ownerHash, i_minSpatialLength, i_queryPoints, includeNormals ? i_queryPoints : ((Span<Vector3>)null), once: true))
			{
				num |= 2;
			}
			return num;
		}

		public int GetQueryResults(int i_ownerHash, float[] o_resultHeights, Vector3[] o_resultNorms, Vector3[] o_resultVels, CollisionLayer layer = CollisionLayer.Everything)
		{
			CollisionQuery provider = GetProvider(layer);
			int num = 0;
			if (!provider.JRetrieveResults(i_ownerHash, null, o_resultHeights, o_resultNorms))
			{
				num |= 1;
			}
			if (o_resultVels != null)
			{
				num |= provider.JCalculateVelocities(i_ownerHash, o_resultVels);
			}
			return num;
		}
	}
}
